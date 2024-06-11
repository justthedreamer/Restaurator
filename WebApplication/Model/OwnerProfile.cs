using System.Text.Json.Serialization;

namespace Razor_App.Model;

public class OwnerProfile
{
    [JsonPropertyName("ownerDto")]
    public OwnerDto OwnerDto { get; set; }
    
    [JsonPropertyName("restaurants")]
    public List<Restaurant> Restaurants { get; set; }
}