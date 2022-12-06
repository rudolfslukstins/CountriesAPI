using AutoMapper;
using Castle.Core.Logging;
using Countries.Data;
using Countries.Service;
using CountriesAPI.Controllers;
using Moq;

namespace CountriesApi.Tests.Controller.Tests;

[TestClass]
public class CountriesControllerTests
{
    private Mock<IApiDataConsumer> _consumerMock;
    private Mock<ILogger> _loggerMock;
    private Mock<IMapper> _mapperMock;
    private Mock<IOceaniaCountriesService> _countryServiceMock;
    private CountriesController _controller;


    [TestInitialize]
    public void Setup()
    {
        _consumerMock = new Mock<IApiDataConsumer>();
        _loggerMock = new Mock<ILogger>();
        _mapperMock = new Mock<IMapper>();
        _countryServiceMock = new Mock<IOceaniaCountriesService>();
        _controller = new CountriesController(_consumerMock.Object, _loggerMock.Object, _mapperMock.Object, _countryServiceMock.Object);
    }
}