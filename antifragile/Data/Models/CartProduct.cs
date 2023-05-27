using antifragile.Models;

namespace antifragile.Data.Models;

public class CartProduct
{
    public int itemId { get; set; }
    public Product Product { get; set; }
    public int Price { get; set; }
    
    public int itemCartId { get; set; }
}