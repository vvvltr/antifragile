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
    // GET
    [HttpGet("Catalog/")]
    [HttpGet("Catalog/{category?}")]
    public IActionResult Index(string category)
    {
        IEnumerable<Product> prods = new List<Product>();
        string currCat = "";
        if (string.IsNullOrEmpty(category))
        {
            prods = _products.AllProducts;
        }
        else
        {
            prods = _products.ProductsOfCategory(category);
        }

        currCat = category;
        var prodViewMod = new ProductsViewModel()
        {
            allProducts = prods,
            currentCategory = currCat
        };

        return View(prodViewMod);
    }

}