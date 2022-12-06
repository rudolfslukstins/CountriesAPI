using Refit;

namespace Countries.Data;

public interface IApiDataConsumer
{

    [Get("/v3.1/region/oceania")]
    Task<IEnumerable<Core.Models.Countries>> GetAllCountriesInOceania();

    [Get("/v3.1/name/{name}")]
    Task<IEnumerable<Core.Models.Countries>> GetOceaniaCountryByName(string name);

}