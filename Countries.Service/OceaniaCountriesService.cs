using System.Collections;
using Countries.Data;


namespace Countries.Service
{
    public class OceaniaCountriesService : IOceaniaCountriesService
    {
        public IEnumerable<Core.Models.Countries> FilterCountriesByPopulation(
            IEnumerable<Core.Models.Countries> countries)
        {
            return countries.OrderByDescending(country => country.Population).Take(10);
        }

        public IEnumerable<Core.Models.Countries> FilterCountriesByPopulationDensity(
            IEnumerable<Core.Models.Countries> countries)
        {
            return countries.OrderByDescending(country => country.Population / country.Area).Take(10);
        }
    }
}