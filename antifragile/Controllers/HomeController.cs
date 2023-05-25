﻿using System.Diagnostics;
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
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(LoginViewModel uvm)
    {
        Console.WriteLine(HttpContext.User.Identity);
        return View(uvm);
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