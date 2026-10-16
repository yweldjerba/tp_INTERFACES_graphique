using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using TP_ClientPanier;

namespace TP_ClientPanier
{
    public partial class Form1 : Form
    {
        private BaseDeDonnees bdd;

        public Form1()
        {
            InitializeComponent();
        }

        // Double-clic sur Form1
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                bdd = new BaseDeDonnees("localhost", "pcshop", "root", "");
                bdd.Ouvrir();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Connexion à la BDD impossible :\n" + ex.Message,
                                "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cbClients.DropDownStyle = ComboBoxStyle.DropDownList;
            List<Client> clients = bdd.ChargerClients();
            cbClients.DataSource = clients;

            // paramétrage de la ListView
            lblTotal.View = View.Details;
            lblTotal.FullRowSelect = true;
            lblTotal.GridLines = true;
            lblTotal.Columns.Clear();
            lblTotal.Columns.Add("Produit", 150);
            lblTotal.Columns.Add("Prix Unitaire (€)", 100);
            lblTotal.Columns.Add("Quantité", 80);
            lblTotal.Columns.Add("Total Ligne (€)", 100);

            lblTotal.Text = "Total : 0,00 €";
        }

        // Double-clic sur le bouton "Charger"
        private void btnChargerPanier_Click(object sender, EventArgs e)
        {
            if (cbClients.SelectedItem is Client client)
            {
                AfficherPanier(client);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client.");
            }
        }

        // Double-clic sur le bouton "Ajouter un produit"
        private void btnAjouterProduit_Click(object sender, EventArgs e)
        {
            if (!(cbClients.SelectedItem is Client client))
            {
                MessageBox.Show("Veuillez sélectionner un client.");
                return;
            }

            // Ouvre le 2e formulaire en lui passant la BDD et le client
            using (FormAjout formAjout = new FormAjout(bdd, client))
            {
                // Si l'ajout a réussi, on rafraîchit la ListView
                if (formAjout.ShowDialog() == DialogResult.OK)
                {
                    AfficherPanier(client);
                }
            }
        }

        // Remplit la ListView et calcule le total du panier
        private void AfficherPanier(Client client)
        {
            lblTotal.Items.Clear();
            List<Panier> paniers = bdd.ChargerPanierClient(client.Id);
            decimal totalPanier = 0;

            foreach (Panier panier in paniers)
            {
                decimal totalLigne = panier.Quantite * panier.Produit.Prix;
                totalPanier += totalLigne;

                ListViewItem item = new ListViewItem(panier.Produit.Nom);
                item.SubItems.Add(panier.Produit.Prix.ToString("C2"));
                item.SubItems.Add(panier.Quantite.ToString());
                item.SubItems.Add(totalLigne.ToString("C2"));
                lblTotal.Items.Add(item);
            }

            lblTotal.Text = "Total : " + totalPanier.ToString("C2");
        }

        // Propriétés > ⚡ > double-clic sur FormClosing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (bdd != null) bdd.Fermer();
        }
    }
}