
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MonCatalogue.Model;

namespace MonCatalogue.Pages.Produits
{
    public class IndexModel : PageModel
    {
        private readonly MonCatalogue.Model.CatalogDBContext _context;
        private readonly CartService _cartService;

        public IndexModel(MonCatalogue.Model.CatalogDBContext context, CartService cartService)
        {
            _context = context;
            _cartService = cartService;
        }

        public IList<Produit> Produit { get; set; } = new List<Produit>(); // Initialisez la liste

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; } // Ajoutez la propriété de recherche

        public async Task OnGetAsync()
        {
            var produitsQuery = _context.Produits
                .Include(p => p.Categorie)
                .AsQueryable(); // Créez une requête IQueryable

            if (!string.IsNullOrEmpty(SearchString))
            {
                produitsQuery = produitsQuery
                    .Where(p => p.ProduitNom.Contains(SearchString)); // Filtrez les produits par nom
            }

            Produit = await produitsQuery.ToListAsync();
        }
        //add product to cart
        public IActionResult OnPostAddToCart(int productId)
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
        }

    }

    
}
