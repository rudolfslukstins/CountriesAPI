using System.Text.Json.Serialization;

namespace Countries.Core.Models;

public class Name
{
    public string Common { get; set; }
    public string Official { get; set; }
    public IDictionary<string, NativeName> NativeName { get; set; }
}