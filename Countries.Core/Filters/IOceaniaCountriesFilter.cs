namespace Countries.Service;

public interface IOceaniaCountriesFilter
{
    IEnumerable<Core.Models.Country> FilterCountriesByPopulation(
        IEnumerable<Core.Models.Country> countries);

    IEnumerable<Core.Models.Country> FilterCountriesByPopulationDensity(
        IEnumerable<Core.Models.Country> countries);

    public IEnumerable<Core.Models.Country> FilterCountriesByRegion(
        IEnumerable<Core.Models.Country> countries);
}