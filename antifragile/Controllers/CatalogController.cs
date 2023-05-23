using antifragile.Data.Interfaces;
using antifragile.Models;
using antifragile.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace antifragile.Controllers;

public class CatalogController : Controller
{
    public IProducts _products;

    public CatalogController(IProducts products)
    {
        _products = products;
    }
    
    [HttpGet("Catalog/{category?}")]
    [HttpGet("Catalog/{category?}/{filter?}")]
    [HttpGet("Catalog/{filter?}/{category}")]
    public IActionResult Index(string author, string category)
    {
        IEnumerable<Product> prods = new List<Product>();
        
        prods = SortByCategory(category);
        prods = SortByAuthor(author, prods);
        
        
        var prodViewMod = new ProductsViewModel()
        {
            allProducts = prods,
        };

        return View(prodViewMod);
    }

    public IEnumerable<Product> SortByCategory(string category)
    {
        if (string.IsNullOrEmpty(category))
        {
            return _products.AllProducts;
        }
        else
        {
            return _products.ProductsOfCategory(category);
        }
    }

    public IEnumerable<Product> SortByAuthor(string author, IEnumerable<Product> prods)
    {
        if (string.IsNullOrEmpty(author)==false)
        {
            var temp = new List<Product>();
            foreach (var VARIABLE in prods)
            {
                if (VARIABLE.Name.Contains(author))
                {
                    temp.Add(VARIABLE);
                }
            }
            prods = temp;
        }

        return prods;
    }
}