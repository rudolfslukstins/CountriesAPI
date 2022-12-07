using Countries.Core.Models;

namespace Countries.Core.AutoMapper;

public class CountryData
{
    public double Area { get; set; }
    public int Population { get; set; }
    public string TopLevelDomain { get; set; }
    public string Region { get; set; }
}