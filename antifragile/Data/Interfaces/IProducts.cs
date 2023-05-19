using antifragile.Models;

namespace antifragile.Data.Interfaces;

public interface IProducts
{
    IEnumerable<Product>? AllProducts { get; }
    IEnumerable<Product> ProductsOfCategory(string Category);
    IEnumerable<Product> FavouriteProducts { get;}
    Product findProduct(int prodName);
}