using Countries.Data;
using Countries.Service;
using FluentAssertions;
using Refit;

namespace CountriesApi.Tests.CountriesService.Tests;

[TestClass]
public class CountryServiceTests
{
    private IApiDataConsumer _data;
    private IOceaniaCountriesService _countryService;

    [TestInitialize]
    public void Setup()
    {
        _data = RestService.For<IApiDataConsumer>("https://restcountries.com");
        _countryService = new OceaniaCountriesService();
    }

    [TestMethod]
    public async Task GetTopTenCountriesInOceaniaByPopulation_ShouldNotBeNull()
    {
        var oceaniaCountries = await _data.GetAllCountriesInOceania();
        var topTenCountriesByPopulation = _countryService.FilterCountriesByPopulation(oceaniaCountries);

        topTenCountriesByPopulation.Should().NotBeNull();
    }

    [TestMethod]
    public async Task GetTopTenCountriesInOceaniaByPopulation_ShouldReturn10Countries()
    {
        var oceaniaCountries = await _data.GetAllCountriesInOceania();
        var topTenCountriesByPopulation = _countryService.FilterCountriesByPopulation(oceaniaCountries);

        topTenCountriesByPopulation.Count().Should().Be(10);
    }

    [TestMethod]
    public async Task GetTopTenCountriesInOceaniaByPopulationDensity_ShouldNotBeNull()
    {
        var oceaniaCountries = await _data.GetAllCountriesInOceania();
        var topTenCountriesByPopulation = _countryService.FilterCountriesByPopulationDensity(oceaniaCountries);

        topTenCountriesByPopulation.Should().NotBeNull();
    }

    [TestMethod]
    public async Task GetTopTenCountriesInOceaniaByPopulationDensity_ShouldReturn10Countries()
    {
        var oceaniaCountries = await _data.GetAllCountriesInOceania();
        var topTenCountriesByPopulation = _countryService.FilterCountriesByPopulationDensity(oceaniaCountries);

        topTenCountriesByPopulation.Count().Should().Be(10);
    }
}