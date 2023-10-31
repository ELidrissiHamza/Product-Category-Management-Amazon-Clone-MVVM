using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MonCatalogue.Model;

namespace MonCatalogue.Pages.Produits
{
    public class DetailsModel : PageModel
    {
        private readonly MonCatalogue.Model.CatalogDBContext _context;
        private readonly CartService _cartService;

        public DetailsModel(MonCatalogue.Model.CatalogDBContext context, CartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        public Produit Produit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Produit = await _context.Produits.FirstOrDefaultAsync(m => m.ProduitId == id);

            if (Produit == null)
            {
                return NotFound();
            }

            return Page();
        }

      /*  public IActionResult OnPostAddToCart(int productId)
        {
            var product = _context.Produits.FirstOrDefault(p => p.ProduitId == productId);
            if (product == null)
            {
                return NotFound();
            }

            var cart = _cartService.GetCart();

            cart.Products.Add(product);
            _cartService.SaveCart(cart);

            return RedirectToPage("/Produits/Index");
        }*/
    }
}
