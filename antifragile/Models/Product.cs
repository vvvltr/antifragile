using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace antifragile.Models;



public class Product
{
    [Display(Name = "Product ID")]
    public int id { get; set; }
    [Display(Name = "Product name")]
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("price")]
    public int Price { get; set; }
    [JsonPropertyName("pic-path")]
    public string PicPath { get; set; } = "antifragile/wwwroot/imgs/default_pic.png";
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("material")]
    public string Material { get; set; }
    [JsonPropertyName("size")]
    public string Size { get; set; }
    [JsonPropertyName("availavility")]
    public bool Availability { get; set; }
    [JsonPropertyName("comeback")]
    public string Comeback { get; set; }
    
    [JsonPropertyName("category")]
    public string Category { get; set; }
    
    public bool isFavourite { get; set; }
}