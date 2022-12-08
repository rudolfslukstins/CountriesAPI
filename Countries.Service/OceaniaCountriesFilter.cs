using System.Collections;
using Countries.Data;


namespace Countries.Service
{
    public class OceaniaCountriesFilter : IOceaniaCountriesFilter
    {
        public IEnumerable<Core.Models.Country> FilterCountriesByPopulation(
            IEnumerable<Core.Models.Country> countries)
        {
            return countries.OrderByDescending(country => country.Population).Take(10);
        }

        public IEnumerable<Core.Models.Country> FilterCountriesByPopulationDensity(
            IEnumerable<Core.Models.Country> countries)
        {
            return countries.OrderByDescending(country => country.Population / country.Area).Take(10);
        }

        public IEnumerable<Core.Models.Country> FilterCountriesByRegion(IEnumerable<Core.Models.Country> countries)
        {
            var region = "oceania";
            return countries.Where(country => country.Region.Trim().ToLower().Contains(region));
        }
    }
}