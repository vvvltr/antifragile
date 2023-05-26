using antifragile.Data.Models;

namespace antifragile.Models;


public class Category
{
    public int id { get; set; }
    public string CategoryName { get; set; }
    
    public List<Product> Products { get; set; }
}