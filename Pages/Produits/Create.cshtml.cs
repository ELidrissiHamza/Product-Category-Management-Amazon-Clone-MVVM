using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MonCatalogue.Model;

namespace MonCatalogue.Pages.Produits
{
    public class CreateModel : PageModel
    {
        private readonly MonCatalogue.Model.CatalogDBContext _context;

        public CreateModel(MonCatalogue.Model.CatalogDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategorieId"] = new SelectList(_context.Categories, "CategorieId", "CategorieId");
            return Page();
        }

        [BindProperty]
        public Produit Produit { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
         /* if (!ModelState.IsValid || _context.Produits == null || Produit == null)
            {
                return Page();
            }*/
            if (Produit.ImageFile != null)
            {
                var fileName = Path.GetFileName(Produit.ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await Produit.ImageFile.CopyToAsync(stream);
                }
                Produit.Image = fileName;
            }
            _context.Produits.Add(Produit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
