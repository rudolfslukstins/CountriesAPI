using Refit;

namespace Countries.Data;

public interface IApiDataConsumer
{

    [Get("/v3.1/region/oceania")]
    Task<IEnumerable<Core.Models.Country>> GetAllCountriesInOceania();

    [Get("/v3.1/name/{name}")]
    Task<IEnumerable<Core.Models.Country>> GetOceaniaCountryByName(string name);

}