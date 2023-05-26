using System.Text.Json.Serialization;

namespace antifragile.Data.Models;

public class Address
{
    [JsonPropertyName("userID")]
    public int UserID { get; set; }
    [JsonPropertyName("index")]
    public string Index { get; set; }
    [JsonPropertyName("city")]
    public string City { get; set; }
    [JsonPropertyName("street")]
    public string Street { get; set; }
}