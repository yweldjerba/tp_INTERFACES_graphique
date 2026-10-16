using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_ClientPanier
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private BaseDeDonnees bdd;
        private void Form2_Load(object sender, EventArgs e)
        {
            bdd = new BaseDeDonnees("localhost", "pcshop", "root", "");
            bdd.Ouvrir();
            List<Client> clients = bdd.ChargerClients();
            cbClient.DataSource = clients;
            lvPanier.View = View.Details;
            lvPanier.FullRowSelect = true;
            lvPanier.GridLines = true;
            lvPanier.Columns.Clear();
            lvPanier.Columns.Add("Produit", 150);
            lvPanier.Columns.Add("Prix Unitaire (€)", 100);
            lvPanier.Columns.Add("Quantité", 80);
            lvPanier.Columns.Add("Total Ligne (€)", 100);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (cbClient.SelectedItem is Client client)
            {
                lvPanier.Items.Clear();
                var paniers = bdd.ChargerPanierClient(client.Id);
                foreach (var panier in paniers)
                {
                    var item = new ListViewItem(panier.Produit.Nom);
                    item.SubItems.Add(panier.Produit.Prix.ToString("C2"));
                    item.SubItems.Add(panier.Quantite.ToString());
                    item.SubItems.Add((panier.Quantite * panier.Produit.Prix).ToString("C2"));
                    lvPanier.Items.Add(item);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbClient.SelectedItem is Client client)
            {
                FormAjout fa = new FormAjout(bdd, client);
                fa.ShowDialog();
            }
        }
    }
}