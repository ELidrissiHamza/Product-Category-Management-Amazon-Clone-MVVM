using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MonCatalogue.Model;

namespace MonCatalogue.Pages.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly MonCatalogue.Model.CatalogDBContext _context;

        public DeleteModel(MonCatalogue.Model.CatalogDBContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Categorie Categorie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }

            var categorie = await _context.Categories.FirstOrDefaultAsync(m => m.CategorieId == id);

            if (categorie == null)
            {
                return NotFound();
            }
            else 
            {
                Categorie = categorie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Categories == null)
            {
                return NotFound();
            }
            var categorie = await _context.Categories.FindAsync(id);

            if (categorie != null)
            {
                Categorie = categorie;
                _context.Categories.Remove(Categorie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
