using System.Text.Json.Serialization;

namespace Razor_App.Model;

public class Address
{
    [JsonPropertyName("city")]
    public string City { get; set; }
    
    [JsonPropertyName("street")]
    public string Street { get; set; }
    
    [JsonPropertyName("houseNumber")]
    public string HouseNumber { get; set; }
}
