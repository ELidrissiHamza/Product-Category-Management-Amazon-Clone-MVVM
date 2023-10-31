using MonCatalogue.Model;
using System;
using System.Collections.Generic;

public class Cart
{
    public List<Produit> Products { get; set; } // Liste des produits dans le panier

    public Cart()
    {
        Products = new List<Produit>();
    }
}
