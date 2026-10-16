namespace TP_ClientPanier
{
    public class Produit
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public decimal Prix { get; set; }
        public string Description { get; set; }
        public int StockMax { get; set; }
        public int StockRestant { get; set; }

        // Constructeur utilisé par ChargerPanierClient (sans le stock)
        public Produit(int Id, string Nom, decimal Prix, string Description)
        {
            this.Id = Id;
            this.Nom = Nom;
            this.Prix = Prix;
            this.Description = Description;
        }

        // Constructeur complet utilisé par ChargerProduits (avec le stock)
        public Produit(int Id, string Nom, decimal Prix, string Description,
                       int StockMax, int StockRestant)
            : this(Id, Nom, Prix, Description)
        {
            this.StockMax = StockMax;
            this.StockRestant = StockRestant;
        }

        // Texte affiché dans la ComboBox cbProduits
        public override string ToString() => $"{Nom} - {Prix:C2}";
    }
}