using System.Text.Json.Serialization;

namespace Razor_App.Model;

public class Restaurant
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("address")]
    public Address Address { get; set; }
    
    [JsonPropertyName("contactNumbers")]
    public List<string> ContactNumbers { get; set; }
    
    [JsonPropertyName("contactEmails")]
    public List<string> ContactEmails { get; set; }
}