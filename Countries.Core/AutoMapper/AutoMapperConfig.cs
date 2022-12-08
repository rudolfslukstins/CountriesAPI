using AutoMapper;

namespace Countries.Core.AutoMapper;

public class AutoMapperConfig : Profile
{
    public static IMapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Models.Country, CountryWithoutNameData>()
                .ForMember(country => country.Population,
                    options =>
                        options.MapFrom(country => country.Population))
                .ForMember(country => country.Area,
                    options =>
                        options.MapFrom(country => country.Area))
                .ForMember(country => country.Region,
                    options =>
                        options.MapFrom(country => country.Region))
                .ForMember(country => country.TopLevelDomain,
                    options =>
                        options.MapFrom(country => country.TopLevelDomain.First()));

        });

        config.AssertConfigurationIsValid();

        return config.CreateMapper();
    }
}