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
    public class DeleteModel : PageModel
    {
        private readonly MonCatalogue.Model.CatalogDBContext _context;

        public DeleteModel(MonCatalogue.Model.CatalogDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Produit Produit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }

            var produit = await _context.Produits.FirstOrDefaultAsync(m => m.ProduitId == id);

            if (produit == null)
            {
                return NotFound();
            }
            else 
            {
                Produit = produit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Produits == null)
            {
                return NotFound();
            }
            var produit = await _context.Produits.FindAsync(id);

            if (produit != null)
            {
                Produit = produit;
                _context.Produits.Remove(Produit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
