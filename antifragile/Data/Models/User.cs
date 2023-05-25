using System.Text.Json.Serialization;

namespace antifragile.Data.Models;

public class User
{
    public int id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("password")]
    public string Password { get; set; }
    [JsonPropertyName("phone_num")]
    public string PhoneNumber { get; set; }
    [JsonPropertyName("email")]
    public string Email { get; set; }
    [JsonPropertyName("addresses")]
    public List<Address> Adresses;
    
}