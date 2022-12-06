using Countries.Data;
using FluentAssertions;
using Refit;

namespace CountriesApi.Tests.DataConsumer.Tests;

[TestClass]
public class DataConsumerTests
{
    private IApiDataConsumer _data;

    [TestInitialize]
    public void Setup()
    {
        _data = RestService.For<IApiDataConsumer>("https://restcountries.com");
    }

    [TestMethod]
    public async Task GetAllOceaniaCountries_ResponseShouldBeNotNull()
    {
        var oceaniaCountries = await _data.GetAllCountriesInOceania();

        oceaniaCountries.Should().NotBeNull();
    }

    [TestMethod]
    public async Task GetAllOceaniaCountries_ShouldReturnAllOceaniaCountries()
    {
        var oceaniaCountries = await _data.GetAllCountriesInOceania();

        oceaniaCountries.Count().Should().Be(27);
    }

    [TestMethod]
    public async Task GetOceaniaCountryByName_ShouldNotBeNull()
    {
        string name = "peru";
        var oceaniaCountry = await _data.GetOceaniaCountryByName(name);

        oceaniaCountry.Should().NotBeNull();
    }

    [TestMethod]
    public async Task GetOceaniaCountryByName_ShouldReturnOneCountry()
    {
        string name = "peru";
        var oceaniaCountry = await _data.GetOceaniaCountryByName(name);

        oceaniaCountry.Count().Should().Be(1);
    }
}