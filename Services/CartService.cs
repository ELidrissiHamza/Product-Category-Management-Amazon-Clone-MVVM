using Microsoft.AspNetCore.Http;
using System.Text.Json;

public class CartService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CartService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Cart GetCart()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        string cartJson = session.GetString("Cart");
        if (cartJson != null)
        {
            return JsonSerializer.Deserialize<Cart>(cartJson);
        }

        return new Cart();
    }

    public void SaveCart(Cart cart)
    {
        var session = _httpContextAccessor.HttpContext.Session;
        session.SetString("Cart", JsonSerializer.Serialize(cart));
    }
}
