using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MonCatalogue.Model
{
    [Table("Categorie")]
    public class Categorie
    {
        [Key]
        public int CategorieId { get; set; }
        [StringLength(50)]
        public string CategorieNom { get; set; }
        public virtual ICollection<Produit>? Produits { get; set; }//lazy=virtual

    }
}
