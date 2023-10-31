using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MonCatalogue.Model;
namespace MonCatalogue.Pages.Carts
{
    public class CartModel : PageModel
    {
        private readonly CartService _cartService;

        public CartModel(CartService cartService)
        {
            _cartService = cartService;
        }

        public Cart Cart { get; set; }

        public void OnGet()
        {
            Cart = _cartService.GetCart();
        }

        public IActionResult OnPostRemoveFromCart(int productId)
        {
            var cart = _cartService.GetCart();
            cart.Products.Remove(item: cart.Products.Where(p => p.ProduitId == productId).First());
            _cartService.SaveCart(cart);
            return RedirectToAction(nameof(Index));
        }
    }
}
