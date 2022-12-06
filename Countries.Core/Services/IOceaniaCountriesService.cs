namespace Countries.Service;

public interface IOceaniaCountriesService
{
    IEnumerable<Core.Models.Countries> FilterCountriesByPopulation(
        IEnumerable<Core.Models.Countries> countries);

    IEnumerable<Core.Models.Countries> FilterCountriesByPopulationDensity(
        IEnumerable<Core.Models.Countries> countries);
}