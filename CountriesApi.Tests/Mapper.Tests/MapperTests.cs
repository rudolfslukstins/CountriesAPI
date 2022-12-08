using AutoMapper;
using Countries.Core.AutoMapper;
using Countries.Core.Models;
using FluentAssertions;

namespace CountriesApi.Tests.Mapper.Tests;

[TestClass]
public class MapperTests
{
    private readonly IMapper _mapper = AutoMapperConfig.CreateMapper();
    
    [TestMethod]
    public void AutoMapper_Configuration_IsValid()
    {
        _mapper.ConfigurationProvider.AssertConfigurationIsValid();
    }

    [TestMethod]
    public void AutoMapper_InsertCountry_ShouldReturnRightValues()
    {
        var test = new global::Countries.Core.Models.Country()
        {
            Name = new Name
            {
                Common = "Latvija",
                Official = "Latvija",
                NativeName = new Dictionary<string, NativeName>()
                {
                    {
                        "test", new NativeName
                        {
                            Common = "Latvija",
                            Official = "Latvija"
                        }
                    }
                }
            },
            Area = 2.7d,
            Population = 200000,
            Region = "Europe",
            TopLevelDomain = new List<string>() { ".lv" }
        };

        var result = _mapper.Map<CountryWithoutNameData>(test);
        
        result.Area.Should().Be(2.7d);
        result.Population.Should().Be(200000);
        result.Region.Should().Be("Europe");
        result.TopLevelDomain.Should().Be(".lv");
    }
}