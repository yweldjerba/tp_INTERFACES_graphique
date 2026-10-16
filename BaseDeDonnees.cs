using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using TP_ClientPanier;

namespace TP_ClientPanier
{
    public class BaseDeDonnees
    {
        private MySqlConnection connexion;

        public BaseDeDonnees(string serveur, string bdd, string utilisateur,
                             string motDePasse, string port = "3306")
        {
            string chaine = $"server={serveur};Database={bdd};port={port};uid={utilisateur};pwd={motDePasse}";
            connexion = new MySqlConnection(chaine);
        }

        public void Ouvrir() => connexion.Open();
        public void Fermer() => connexion.Close();
        public MySqlConnection Connexion => connexion;

        // ============================================================
        //  CLIENTS
        // ============================================================
        public List<Client> ChargerClients()
        {
            List<Client> clients = new List<Client>();
            string requete = "SELECT * FROM Client";
            MySqlCommand commande = new MySqlCommand(requete, connexion);
            MySqlDataReader reader = commande.ExecuteReader();

            while (reader.Read())
            {
                int Id = reader.GetInt32("id");
                string Nom = reader.GetString("nom");
                string Prenom = reader.GetString("prenom");
                string Adresse = reader.GetString("adresse");
                clients.Add(new Client(Id, Nom, Prenom, Adresse));
            }
            reader.Close();
            return clients;
        }

        // ============================================================
        //  PANIER D'UN CLIENT
        // ============================================================
        public List<Panier> ChargerPanierClient(int idClient)
        {
            List<Panier> paniers = new List<Panier>();
            string requete = @"SELECT p.id, p.nom, p.prix, p.description, pa.quantite
                               FROM Panier pa
                               JOIN Produit p ON pa.idProduit = p.id
                               WHERE pa.idClient = @idClient";
            MySqlCommand commande = new MySqlCommand(requete, connexion);
            commande.Parameters.AddWithValue("@idClient", idClient);

            // pas de "using var" : non supporté en C# 7.3 (.NET Framework)
            MySqlDataReader reader = commande.ExecuteReader();
            while (reader.Read())
            {
                int Id = reader.GetInt32("id");
                string Nom = reader.GetString("nom");
                decimal Prix = reader.GetDecimal("prix");
                string Description = reader.IsDBNull(reader.GetOrdinal("description"))
                                     ? "" : reader.GetString("description");
                Produit p = new Produit(Id, Nom, Prix, Description);

                int Quantite = reader.GetInt32("quantite");
                paniers.Add(new Panier(p, Quantite));
            }
            reader.Close();
            return paniers;
        }

        // ============================================================
        //  LISTE DES PRODUITS (avec le stock)
        // ============================================================
        public List<Produit> ChargerProduits()
        {
            List<Produit> produits = new List<Produit>();
            string requete = @"SELECT id, nom, prix, description, stockMax, stockRestant
                               FROM Produit
                               ORDER BY nom";
            MySqlCommand commande = new MySqlCommand(requete, connexion);
            MySqlDataReader reader = commande.ExecuteReader();

            while (reader.Read())
            {
                int Id = reader.GetInt32("id");
                string Nom = reader.GetString("nom");
                decimal Prix = reader.GetDecimal("prix");
                string Description = reader.IsDBNull(reader.GetOrdinal("description"))
                                     ? "" : reader.GetString("description");
                int StockMax = reader.GetInt32("stockMax");
                int StockRestant = reader.GetInt32("stockRestant");

                produits.Add(new Produit(Id, Nom, Prix, Description, StockMax, StockRestant));
            }
            reader.Close();
            return produits;
        }

        // ============================================================
        //  VÉRIFIE SI LE PRODUIT EST DÉJÀ DANS LE PANIER DU CLIENT
        // ============================================================
        public bool ProduitDansPanier(int idClient, int idProduit)
        {
            string requete = @"SELECT COUNT(*) FROM Panier
                               WHERE idClient = @idClient AND idProduit = @idProduit";
            MySqlCommand commande = new MySqlCommand(requete, connexion);
            commande.Parameters.AddWithValue("@idClient", idClient);
            commande.Parameters.AddWithValue("@idProduit", idProduit);

            int nb = Convert.ToInt32(commande.ExecuteScalar());
            return nb > 0;
        }

        // ============================================================
        //  AJOUT AU PANIER + DÉCRÉMENTATION DU STOCK
        //  Transaction : soit les 2 requêtes passent, soit aucune.
        //  Retourne false si le stock est insuffisant.
        // ============================================================
        public bool AjouterAuPanier(int idClient, int idProduit, int quantite)
        {
            MySqlTransaction transaction = connexion.BeginTransaction();
            try
            {
                // 1. On retire du stock SEULEMENT s'il en reste assez
                string reqStock = @"UPDATE Produit
                                    SET stockRestant = stockRestant - @quantite
                                    WHERE id = @idProduit AND stockRestant >= @quantite";
                MySqlCommand cmdStock = new MySqlCommand(reqStock, connexion, transaction);
                cmdStock.Parameters.AddWithValue("@quantite", quantite);
                cmdStock.Parameters.AddWithValue("@idProduit", idProduit);

                int lignesModifiees = cmdStock.ExecuteNonQuery();
                if (lignesModifiees == 0)
                {
                    transaction.Rollback();   // stock insuffisant
                    return false;
                }

                // 2. On ajoute la ligne dans le panier
                string reqPanier = @"INSERT INTO Panier (idClient, idProduit, quantite)
                                     VALUES (@idClient, @idProduit, @quantite)";
                MySqlCommand cmdPanier = new MySqlCommand(reqPanier, connexion, transaction);
                cmdPanier.Parameters.AddWithValue("@idClient", idClient);
                cmdPanier.Parameters.AddWithValue("@idProduit", idProduit);
                cmdPanier.Parameters.AddWithValue("@quantite", quantite);
                cmdPanier.ExecuteNonQuery();

                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;   // l'erreur remonte au formulaire
            }
        }
    }
}