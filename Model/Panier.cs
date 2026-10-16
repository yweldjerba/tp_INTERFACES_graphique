namespace TP_ClientPanier
{
    public class Panier
    {
        public Produit Produit { get; set; }
        public int Quantite { get; set; }

        public Panier(Produit Produit, int Quantite)
        {
            this.Produit = Produit;
            this.Quantite = Quantite;
        }

        public override string ToString() => $"{Produit.Nom} x{Quantite}";
    }
}