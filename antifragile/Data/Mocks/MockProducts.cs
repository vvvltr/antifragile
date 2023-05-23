using System.Text.Json;
using antifragile.Data.Interfaces;
using antifragile.Models;

namespace antifragile.Data.Mocks;

public class MockProducts : IProducts
{
    public MockCategory _categories = new MockCategory();
    
    public IEnumerable<Product>? AllProducts
    {
        get
        {
            using (FileStream fs =
                   new FileStream(@"C:\Users\Владислава\RiderProjects\antifragile\antifragile\Data\Products.json",
                       FileMode.OpenOrCreate))
            {
                List<Product>? products = JsonSerializer.Deserialize<List<Product>>(fs);
                return products;
            }
        }
    }

    public List<Product> ProductsOfCategory(string cat)
    {
        var products = new List<Product>();
        foreach (var VARIABLE in AllProducts)
        {
            if (VARIABLE.Category == cat)
            {
                products.Add(VARIABLE);
            }
        }

        return products;
    }

    public IEnumerable<Product> FavouriteProducts
    {
        get
        {
            var favs = new List<Product>();
            foreach (var VARIABLE in AllProducts)
            {
                if (VARIABLE.isFavourite == true)
                {
                    favs.Add(VARIABLE);
                }
            }

            return favs;
        }
    }

    public Product findProduct(int prodName)
    {
        throw new NotImplementedException();
    }
}