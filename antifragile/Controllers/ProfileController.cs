using antifragile.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;
using System.Text.Json.Nodes;
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
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        User? user = new List<User>(_users.AllUsers).FirstOrDefault(u => u.Email == loginViewModel.Email && u.Password == loginViewModel.Password);
        
        if (user!=null)
        {
            Console.WriteLine("user is not null");
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, loginViewModel.Email),
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            AuthenticationProperties authenticationProperties = new AuthenticationProperties()
            {
                AllowRefresh = true,
                IsPersistent = loginViewModel.KeepLoggedIn
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authenticationProperties);

            return RedirectToAction("Index", "Profile");
        }

        return View();
    }

    public IActionResult RedirectToRegister()
    {
        return RedirectToAction("Register");
    }
    
    public IActionResult RedirectToProfile()
    {
        return RedirectToAction("Index");
    }
    
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToAction("Login", "Profile");
    }

    [HttpGet]
    public async Task<IActionResult> Register()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel rvm)
    {
        User newUser = new User()
        {
            Email = rvm.Email,
            PhoneNumber = rvm.PhoneNumber,
            Password = rvm.Password,
            Name = rvm.Name,
            id = _users.AllUsers.Count()
        };

        foreach (var variable in _users.AllUsers)
        {
            if (newUser.Equals(variable))
            {
                Console.WriteLine("repited");
                return View();
            }
        }
        
        List<User> newUsers = new List<User>(_users.AllUsers);
        newUsers.Add(newUser);
        _users.AllUsers = newUsers;
        return RedirectToAction("Index");
    }
}