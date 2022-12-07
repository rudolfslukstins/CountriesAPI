using Countries.Core.Models;
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

    private readonly List<global::Countries.Core.Models.Countries> _testList =
        new()
        {
            new()
            {
                Name = new Name()
                {
                    Common = "Latvija",
                    NativeName = new Dictionary<string, NativeName>(),
                    Official = "Latvija",
                },
                Area = 10000,
                Population = 100000,
                Region = "Europe",
                TopLevelDomain = new List<string>() { ".lv" }
            },

            new()
            {
                Name = new Name()
                {
                    Common = "Australia",
                    NativeName = new Dictionary<string, NativeName>(),
                    Official = "Australia",
                },
                Area = 10,
                Population = 20000000,
                Region = "Oceania",
                TopLevelDomain = new List<string>() { ".au" }
            },

            new()
            {
                Name = new Name()
                {
                    Common = "Fiji",
                    NativeName = new Dictionary<string, NativeName>(),
                    Official = "Fiji",
                },
                Area = 10,
                Population = 2000,
                Region = "Oceania",
                TopLevelDomain = new List<string>() { ".au" }
            },

            new()
            {
                Name = new Name()
                {
                    Common = "New Zealand",
                    NativeName = new Dictionary<string, NativeName>(),
                    Official = "New Zealand",
                },
                Area = 1000000,
                Population = 20000,
                Region = "Oceania",
                TopLevelDomain = new List<string>() { ".nz" }
            }
        };

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

    [TestMethod]
    public async Task GetCountryFromOceaniaRegion_ShouldNotBeNull()
    {
        var name = "australia";

        var searchCountryByName = await _data.GetOceaniaCountryByName(name);
        var checkIfCountryIsFromOceaniaRegion = _countryService.FilterCountriesByRegion(searchCountryByName);

        checkIfCountryIsFromOceaniaRegion.Should().NotBeNull();
    }

    [TestMethod]
    public async Task GetCountryFromOceaniaRegion_ShouldReturn1Country()
    {
        var name = "australia";

        var searchCountryByName = await _data.GetOceaniaCountryByName(name);
        var checkIfCountryIsFromOceaniaRegion = _countryService.FilterCountriesByRegion(searchCountryByName);

        checkIfCountryIsFromOceaniaRegion.Count().Should().Be(1);
    }

    [TestMethod]
    public async Task GetCountryFromOceaniaRegion_TryToSearchCountryWitchIsNotInOceaniaRegion_ShouldReturnNull()
    {
        var name = "latvia";

        var searchCountryByName = await _data.GetOceaniaCountryByName(name);
        var checkIfCountryIsFromOceaniaRegion = _countryService.FilterCountriesByRegion(searchCountryByName);

        checkIfCountryIsFromOceaniaRegion.Should().BeNullOrEmpty();
    }

    [TestMethod]
    public void FilterCountriesByPopulation_SortCountriesByPopulation_ShouldBeCorrect()
    {
        var filteredListByPopulation = _countryService.FilterCountriesByPopulation(_testList);

        var firstCountry = filteredListByPopulation.First();
        var lastCountry = filteredListByPopulation.Last();

        firstCountry.Name.Common.Should().Be("Australia");
        lastCountry.Name.Common.Should().Be("Fiji");
    }

    [TestMethod]
    public void FilterCountriesByPopulationDensity_SortCountriesByPopulationDensity_ShouldBeCorrect()
    {
        var filteredListByPopulation = _countryService.FilterCountriesByPopulationDensity(_testList);

        var firstCountry = filteredListByPopulation.First();
        var lastCountry = filteredListByPopulation.Last();

        firstCountry.Name.Common.Should().Be("Australia");
        lastCountry.Name.Common.Should().Be("New Zealand");
    }

    [TestMethod]
    public void FilterCountriesByRegion_SerchCountryByRegion_ShouldBeCorrect()
    {
        var filteredListByRegion= _countryService.FilterCountriesByRegion(_testList);

        var firstCountry = filteredListByRegion.First();
        
        firstCountry.Name.Common.Should().Be("Australia");
    }
}