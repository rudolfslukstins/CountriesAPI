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
    public async Task GetAllOceaniaCountries_ShouldReturn27Countries()
    {
        var oceaniaCountries = await _data.GetAllCountriesInOceania();

        oceaniaCountries.Count().Should().Be(27);
    }

    [TestMethod]
    public async Task GetOceaniaCountryByName_ShouldNotBeNull()
    {
        string name = "australia";
        var oceaniaCountry = await _data.GetOceaniaCountryByName(name);

        oceaniaCountry.Should().NotBeNull();
    }

    [TestMethod]
    public async Task GetOceaniaCountryByName_ShouldReturnOneCountry()
    {
        string name = "australia";
        var oceaniaCountry = await _data.GetOceaniaCountryByName(name);

        oceaniaCountry.Count().Should().Be(1);
    }
}