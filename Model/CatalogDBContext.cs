using Microsoft.EntityFrameworkCore;

namespace MonCatalogue.Model
{
    public class CatalogDBContext:DbContext
    {
        public DbSet<Produit> Produits { get; set; }
        public DbSet<Categorie> Categories { get; set; }
        //sql server
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UP37QDS;Database=CAT_DB_8;Trusted_Connection=True;TrustServerCertificate=True");
            
        }*/
        //sqlite
        public CatalogDBContext(DbContextOptions<CatalogDBContext> options)
: base(options)
        { }

    }
}
