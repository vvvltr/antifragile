using antifragile.Models;

namespace antifragile.Data.Models;

public class Cart
{
    public string CartId { get; set; }
    public List<Product> ListCartProducts { get; set; }

    public static Cart GetCart(IServiceProvider service)
    {
        ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        
        session.SetString("CartId", cartId);
        return new Cart() {CartId = cartId};
    }
}