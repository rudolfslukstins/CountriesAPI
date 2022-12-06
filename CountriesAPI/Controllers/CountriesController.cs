using AutoMapper;
using Countries.Core.AutoMapper;
using Countries.Data;
using Countries.Service;
using Microsoft.AspNetCore.Mvc;

namespace CountriesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesController : ControllerBase
    {

        private readonly ILogger<CountriesController> _logger;
        private readonly IApiDataConsumer _countriesData;
        private readonly IOceaniaCountriesService _service;
        private readonly IMapper _mapper;

        public CountriesController(ILogger<CountriesController> logger,
            IApiDataConsumer countriesData,
            IOceaniaCountriesService service,
            IMapper mapper)
        {
            _logger = logger;
            _countriesData = countriesData;
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("Oceania-Population/Top10")]
        public async Task<IActionResult> GetTopTenCountriesByPopulationInOceania()
        {
            var countriesInOceania = await _countriesData.GetAllCountriesInOceania();
            var topTenCountriesByPopulation = _service.FilterCountriesByPopulation(countriesInOceania);
            
            _logger.LogInformation("Executing GetTopTenCountriesByPopulationInOceania");

            return Ok(topTenCountriesByPopulation);
        }

        [HttpGet]
        [Route("Oceania-Population-Density/Top10")]
        public async Task<IActionResult> GetTopTenByPopulationDensityInOceania()
        {
            var countriesInOceania = await _countriesData.GetAllCountriesInOceania();
            var topTenCountriesByPopulationDensity = _service.FilterCountriesByPopulationDensity(countriesInOceania);

            _logger.LogInformation("Executing GetTopTenCountriesByPopulationDensityInOceania");

            return Ok(topTenCountriesByPopulationDensity);
        }

        [HttpGet]
        [Route("Oceania-Country/{name}")]
        public async Task<IActionResult> GetOceaniaCountryByName(string name)
        {
            var countryInOceania = await _countriesData.GetOceaniaCountryByName(name);
            
            if (countryInOceania == null)
            {
                _logger.LogError($"Country with name {name} not found!");
               
                return NotFound($"Country by the name {name} not found!");
            }
            var countryWithOutName = _mapper.Map<Countries.Core.Models.Countries>(countryInOceania.First());
            
            _logger.LogInformation("Executing GetOceaniaCountryByName");
            
            return Ok(countryWithOutName);
        }

    }
}