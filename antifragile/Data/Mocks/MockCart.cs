using antifragile.Data.Interfaces;
using antifragile.Models;
using Newtonsoft.Json;

namespace antifragile.Data.Mocks;

public class MockCart:ICart
{
    private string path = @"C:\Users\Владислава\RiderProjects\antifragile\antifragile\Data\Cart.json";
    public List<Product> productsInCart 
    {
        get
        {
            string json = File.ReadAllText(path);
            var prods = JsonConvert.DeserializeObject<List<Product>>(json);
            return prods;
        }
    }
    
    public void AddProductToCart(Product product)
    {
        List<Product> products = new List<Product>(productsInCart);
        products.Add(product);

        string ser = JsonConvert.SerializeObject(products);
        File.WriteAllText(path, ser);
    }


    public void DeleteCart()
    {
        File.WriteAllText(path, "[]");
    }
}