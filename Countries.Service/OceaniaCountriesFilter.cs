using System.Collections;
using Countries.Data;


namespace Countries.Service
{
    public class OceaniaCountriesFilter : IOceaniaCountriesFilter
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

        public IEnumerable<Core.Models.Countries> FilterCountriesByRegion(IEnumerable<Core.Models.Countries> countries)
        {
            var region = "oceania";
            return countries.Where(country => country.Region.Trim().ToLower().Contains(region));
        }
    }
}