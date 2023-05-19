using Microsoft.AspNetCore.Mvc;

namespace antifragile.Controllers;

public class FAQController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}