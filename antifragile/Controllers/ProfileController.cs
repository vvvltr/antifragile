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
    public IUser _users;
    public IAddress _addresses;

    public ProfileController(IUser users, IAddress addresses)
    {
        _users = users;        
        _addresses = addresses;
    }
    public IActionResult Index()
    {
        var identity = HttpContext.User.Identity;
        if (identity.IsAuthenticated==false)
        {
            return RedirectToAction("Login", "Profile");
        }

        var identityName = HttpContext.User.Identity.Name;
        User currentUser = _users.AllUsers.First(u => u.Email == identityName);
        /*foreach (var VARIABLE in _users.AllUsers)
        {
            if (VARIABLE.Email == identityName)
            {
                currentUser = VARIABLE;
            }
        }*/
        
        Console.WriteLine(currentUser.id);
        var userAds = _addresses.GetUserAddresses(currentUser);
        ProfileViewModel viewModel = new ProfileViewModel()
        {
            Addresses = userAds,
            Name = currentUser.Name,
            Email = currentUser.Email,
            PhoneNumber = currentUser.PhoneNumber,
        };
        return View(viewModel);
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
        User? user = _users.AllUsers.FirstOrDefault(u => u.Email == loginViewModel.Email && u.Password == loginViewModel.Password);
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
            id = _users.AllUsers.Count() + 1
        };

        Console.WriteLine(newUser.Name);
        foreach (var variable in _users.AllUsers)
        {
            if (newUser.Equals(variable))
            {
                Console.WriteLine("repeated");
                return View();
            }
        }
        
        _users.AddUser(newUser);
        
        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult AddAddress(ProfileViewModel pvm)
    {
        var identityName = HttpContext.User.Identity.Name;
        User currentUser = _users.AllUsers.First(u => u.Email == identityName);
        Address ad = new Address()
        {
            City = pvm.AddressViewModel.City,
            Street = pvm.AddressViewModel.Street, 
            Index = pvm.AddressViewModel.Index, 
            UserID = currentUser.id
        };
        _addresses.AddAddress(ad);

        return RedirectToAction("Index");
    }
}