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
    public class IndexModel : PageModel
    {
        private readonly MonCatalogue.Model.CatalogDBContext _context;

        public IndexModel(MonCatalogue.Model.CatalogDBContext context)
        {
            _context = context;
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
    }
}
