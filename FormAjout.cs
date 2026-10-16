using System;
using System.Windows.Forms;
using TP_ClientPanier;   // ✅ supprime cette ligne si Client/Produit ne sont PAS dans un namespace Model

namespace TP_ClientPanier
{
    public partial class FormAjout : Form
    {
        private BaseDeDonnees bdd;
        private Client client;

        // Constructeur : reçoit la BDD et le client depuis Form1
        public FormAjout(BaseDeDonnees bdd, Client client)
        {
            InitializeComponent();
            this.bdd = bdd;
            this.client = client;
        }

        // Double-clic sur FormAjout
        private void FormAjout_Load(object sender, EventArgs e)
        {
            this.Text = "Ajout au panier de " + client.Nom + " " + client.Prenom;
            cbProduits.DropDownStyle = ComboBoxStyle.DropDownList;
            ChargerProduits();
        }

        private void ChargerProduits()
        {
            cbProduits.DataSource = bdd.ChargerProduits();
            AfficherStock();
        }

        // Double-clic sur la ComboBox cbProduits
        private void cbProduits_SelectedIndexChanged(object sender, EventArgs e)
        {
            AfficherStock();
        }

        // Affiche le stock du produit sélectionné
        private void AfficherStock()
        {
            if (cbProduits.SelectedItem is Produit produit)
            {
                tbQuantite.Text = "Stock : " + produit.StockRestant + " / " + produit.StockMax;
                btnValider.Enabled = produit.StockRestant > 0;   // rupture = bouton grisé
            }
        }

        // Double-clic sur le bouton "Ajouter"
        private void btnValider_Click(object sender, EventArgs e)
        {
            // 1. Un produit est-il sélectionné ?
            if (!(cbProduits.SelectedItem is Produit produit))
            {
                MessageBox.Show("Veuillez sélectionner un produit.");
                return;
            }

            // 2. La quantité est-elle un entier positif ?
            int quantite;
            if (!int.TryParse(tbQuantite.Text, out quantite) || quantite <= 0)   // ✅ tbQuantite
            {
                MessageBox.Show("La quantité doit être un nombre entier supérieur à 0.");
                tbQuantite.Focus();                                              // ✅ tbQuantite
                return;
            }

            // 3. Le produit est-il déjà dans le panier ?
            if (bdd.ProduitDansPanier(client.Id, produit.Id))
            {
                MessageBox.Show("Ce produit est déjà dans le panier du client.",
                                "Doublon", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Le stock est-il suffisant ?
            if (quantite > produit.StockRestant)
            {
                MessageBox.Show("Stock insuffisant : il reste " + produit.StockRestant + " unité(s).",
                                "Stock", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Ajout en BDD (panier + stock)
            try
            {
                bool ajoute = bdd.AjouterAuPanier(client.Id, produit.Id, quantite);
                if (!ajoute)
                {
                    MessageBox.Show("Le stock a changé entre-temps, ajout impossible.");
                    ChargerProduits();   // recharge les stocks à jour
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout :\n" + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 6. Retour à Form1 qui rafraîchira sa ListView
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}