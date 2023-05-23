using antifragile.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using antifragile.Data.Interfaces;
using antifragile.Data.Mocks;
using antifragile.Data.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace antifragile.Controllers;
public class ProfileController : Controller
{
    // GET
    public IUser _users;

    public ProfileController(IUser users)
    {
        _users = users;
    }
    public IActionResult Index()
    {
        var identity = HttpContext.User.Identity;
        if (identity.IsAuthenticated==false)
        {
            return RedirectToAction("Login", "Profile");
        }
        return View();
    }

    [HttpGet]
    public IActionResult Login()
    {
        var identity = HttpContext.User.Identity;
        if (identity.IsAuthenticated)
        {
            Console.WriteLine("authenticated");
            return RedirectToAction("Index", "Profile");
        }
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(UserViewModel userViewModel)
    {
        User? user = new List<User>(_users.AllUsers).FirstOrDefault(u => u.Email == userViewModel.Email && u.Password == userViewModel.Password);
        
        if (user!=null)
        //if ((userViewModel.Email == "vltr@ya.ru") && userViewModel.Password == "123")
        {
            Console.WriteLine("user is not null");
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userViewModel.Email),
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties authenticationProperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = userViewModel.KeepLoggedIn
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authenticationProperties);

            return RedirectToAction("Index", "Profile");
        } 

        return View();
    }
    
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Profile");
    }
}