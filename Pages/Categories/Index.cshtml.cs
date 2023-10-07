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
    public class IndexModel : PageModel
    {
        private readonly MonCatalogue.Model.CatalogDBContext _context;

        public IndexModel(MonCatalogue.Model.CatalogDBContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Categorie = await _context.Categories.ToListAsync();
            }
        }
    }
}
