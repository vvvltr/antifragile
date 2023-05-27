using antifragile.Models;

namespace antifragile.Data.Interfaces;

public interface ICart
{
    List<Product> productsInCart { get; }
    
    public void AddProductToCart(Product product);

    public void DeleteCart();
}