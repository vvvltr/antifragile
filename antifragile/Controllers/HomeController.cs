using System.Diagnostics;
using antifragile.Data.Interfaces;
using antifragile.Data.Mocks;
using antifragile.Data.Models;
using Microsoft.AspNetCore.Mvc;
using antifragile.Models;
using antifragile.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace antifragile.Controllers;

public class HomeController : Controller
{
    public IProducts _products;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger, IProducts products)
    {
        _logger = logger;
        _products = products;
    }

    public IActionResult Index()
    {
        HomeViewModel hvm = new HomeViewModel();
        hvm.LatestProducts = new List<Product>();
        for (int i = 0; i < 5; i++)
        {
            hvm.LatestProducts.Add(_products.AllProducts.ElementAt(i));
        }
        return View(hvm);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }

    public IActionResult Delivery()
    {
        return View();
    }

    public IActionResult Payment()
    {
        return View();
    }
}