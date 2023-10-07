using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonCatalogue.Model
{
    [Table("Produit")]
    public class Produit
    {
        [Key]
        public int ProduitId { get; set; }
        [StringLength(50)]
        public string? ProduitNom { get; set; }
        public double Prix { get; set; }
        public int Quantite { get; set; }
        public string? Image { get; set; }   
        public int CategorieId { get; set; }
        public virtual Categorie? Categorie { get; set; }//lazy=virtual
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
    }
}
