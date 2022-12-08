using AutoMapper;
using Countries.Core.AutoMapper;
using Countries.Data;
using Countries.Service;
using CountriesAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Countries = Countries.Core.Models.Countries;

namespace CountriesApi.Tests.Controller.Tests;

[TestClass]
public class CountriesControllerTests
{
    private Mock<IApiDataConsumer> _dataConsumerMock;
    private Mock<ILogger<CountriesController>> _loggerMock;
    private Mock<IMapper> _mapperMock;
    private Mock<IOceaniaCountriesFilter> _countryServiceMock;
    private CountriesController _controller;


    [TestInitialize]
    public void Setup()
    {
        _dataConsumerMock = new Mock<IApiDataConsumer>();
        _loggerMock = new Mock<ILogger<CountriesController>>();
        _mapperMock = new Mock<IMapper>();
        _countryServiceMock = new Mock<IOceaniaCountriesFilter>();
        _controller = new CountriesController(_loggerMock.Object, _dataConsumerMock.Object, _countryServiceMock.Object, _mapperMock.Object);
    }

    [TestMethod]
    public async Task GetTopTenCountriesByPopulationInOceania_ShouldGetTopTenCountriesByPopulationAndReturnOkObjectResult()
    {
        var actionResult = await _controller.GetTopTenCountriesByPopulationInOceania() as ObjectResult;

        Assert.IsNotNull(actionResult);
        Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
    }

    [TestMethod]
    public async Task GetTopTenCountriesByPopulationDensityInOceania_ShouldGetTopTenCountriesByPopulationDensityAndReturnOkObjectResult()
    {
        var actionResult = await _controller.GetTopTenByPopulationDensityInOceania() as ObjectResult;

        Assert.IsNotNull(actionResult);
        Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
    }

    [TestMethod]
    public async Task GetOceaniaCountryByName_InsertCountryThatIsNotInOceaniaRegion_ShouldReturnNotFoundObjectResult()
    {

        var name = "latvia";

        var actionResult = await _controller.GetOceaniaCountryByName(name) as ObjectResult;

        Assert.IsInstanceOfType(actionResult, typeof(NotFoundObjectResult));
    }

    [TestMethod]
    public async Task GetOceaniaCountryByName_InsertCountryThatIsInOceaniaRegion_ShouldReturnOkObjectResult()
    {

        var name = "australia";
        var list = new List<global::Countries.Core.Models.Countries> { new() };
        _dataConsumerMock.Setup(country => country.GetOceaniaCountryByName(name))
            .ReturnsAsync(list);

        _countryServiceMock.Setup(country => country.FilterCountriesByRegion(list)).Returns(list);
        
        var actionResult = await _controller.GetOceaniaCountryByName(name) as ObjectResult;

        Assert.IsInstanceOfType(actionResult, typeof(OkObjectResult));
    }
}