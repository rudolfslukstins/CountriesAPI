using System.Text.Json.Serialization;

namespace Countries.Core.Models;

public class Country
{
    public Name Name { get; set; }
    public double Area { get; set; }
    public int Population { get; set; }
    [JsonPropertyName("tld")]
    public List<string> TopLevelDomain { get; set; }
    public string Region { get; set; }
}