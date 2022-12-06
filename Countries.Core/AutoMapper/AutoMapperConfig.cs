﻿using AutoMapper;

namespace Countries.Core.AutoMapper;

public class AutoMapperConfig
{
    public static IMapper CreateMapper()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Models.Countries, CountryData>()
                .ForMember(country => country.Population,
                    options => 
                        options.MapFrom(country => country.Population))
                .ForMember(country => country.Area,
                    options =>
                        options.MapFrom(country => country.Area))
                .ForMember(country => country.TopLevelDomain,
                    options =>
                        options.MapFrom(country => country.TopLevelDomain.First()));

        });

        config.AssertConfigurationIsValid();

        return config.CreateMapper();
    }
}