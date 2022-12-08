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
        private readonly IOceaniaCountriesFilter _service;
        private readonly IMapper _mapper;

        public CountriesController(ILogger<CountriesController> logger,
            IApiDataConsumer countriesData,
            IOceaniaCountriesFilter service,
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
            _logger.LogInformation("Executing GetTopTenCountriesByPopulationInOceania");

            var countriesInOceania = await _countriesData.GetAllCountriesInOceania();
            var topTenCountriesByPopulation = _service.FilterCountriesByPopulation(countriesInOceania);

            _logger.LogInformation($"Found {topTenCountriesByPopulation.Count()} entries");

            return Ok(topTenCountriesByPopulation);
        }

        [HttpGet]
        [Route("Oceania-Population-Density/Top10")]
        public async Task<IActionResult> GetTopTenByPopulationDensityInOceania()
        {
            _logger.LogInformation("Executing GetTopTenCountriesByPopulationDensityInOceania");

            var countriesInOceania = await _countriesData.GetAllCountriesInOceania();
            var topTenCountriesByPopulationDensity = _service.FilterCountriesByPopulationDensity(countriesInOceania);

            _logger.LogInformation($"Found {topTenCountriesByPopulationDensity.Count()} entries");

            return Ok(topTenCountriesByPopulationDensity);
        }

        [HttpGet]
        [Route("Oceania-Country/{name}")]
        public async Task<IActionResult> GetOceaniaCountryByName(string name)
        {
            _logger.LogInformation($"Searching for country: {name}");

            var searchCountryByName = await _countriesData.GetOceaniaCountryByName(name);
            var countryInOceania = _service.FilterCountriesByRegion(searchCountryByName);

            if (countryInOceania?.Any() == false)
            {
                _logger.LogWarning($"Country with name {name} not found!");

                return NotFound($"Country by the name {name} not found!");
            }

            var countryWithOutName = _mapper.Map<CountryData>(countryInOceania.First());

            return Ok(countryWithOutName);
        }

    }
}