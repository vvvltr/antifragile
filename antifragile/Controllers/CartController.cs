using Microsoft.AspNetCore.Mvc;

namespace antifragile.Controllers;

public class CartController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}