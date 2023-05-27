using antifragile.Data.Interfaces;
using antifragile.Models;
using antifragile.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace antifragile.Controllers;

public class CartController : Controller
{
    public ICart _Cart;
    public IProducts _Products;

    public CartController(ICart cart, IProducts products)
    {
        _Products = products;
        _Cart = cart;
    }
    // GET
    public IActionResult Index()
    {
        if (HttpContext.User.Identity.IsAuthenticated == false)
        {
            return RedirectToAction("Login", "Profile");
        }
        
        List<Product> products = _Cart.productsInCart;
        var cvm = new CartViewModel()
        {
            cartProducts = products
        };
        return View(cvm);
    }

    [Route("Cart/add/{prodId?}")]
    public IActionResult AddProductToCart(int prodId)
    {
        var product = _Products.AllProducts.First(p => p.id == prodId);
        _Cart.AddProductToCart(product);

        var cvm = new CartViewModel()
        {
            cartProducts = _Cart.productsInCart
        };
        
        return RedirectToAction("Index");
    }
}