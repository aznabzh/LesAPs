using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Windows.Forms;
using championnat.Modele.Metier;

namespace championnat.Modele.DAO
{
    internal class FonctionDAO
    {
        public static List<Fonction> ReadAllFonctions()
        {
            List<Fonction> lesFonctions = new List<Fonction>();

            string query = "SELECT CodeFct, LibelleFct FROM fonction;";
            OdbcCommand commande = new OdbcCommand(query);

            DbConnex.connexionBase();

            using (OdbcDataReader reader = DbConnex.GetDataReader(commande))
            {
                try
                {
                    while (reader.Read())
                    {
                        string code = reader.GetString(0);
                        string libelle = reader.GetString(1);

                        Fonction fonction = new Fonction(code, libelle);
                        lesFonctions.Add(fonction);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DbConnex.connexionClose();
                }
            }

            return lesFonctions;
        }

        public static Fonction ReadFonctionByCode(string code)
        {
            Fonction fonction = null;

            string query = "SELECT CodeFct, LibelleFct FROM fonction WHERE CodeFct = ?;";
            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("CodeFct", code);

            DbConnex.connexionBase();

            using (OdbcDataReader reader = DbConnex.GetDataReader(commande))
            {
                try
                {
                    if (reader.Read())
                    {
                        string codeFct = reader.GetString(0);
                        string libelle = reader.GetString(1);

                        fonction = new Fonction(codeFct, libelle);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    DbConnex.connexionClose();
                }
            }

            return fonction;
        }

        public static bool CreateFonction(Fonction fonction)
        {
            // Ici tu peux décommenter la vérification de code si tu veux éviter les doublons
            //if (CodeIsAvailable(fonction.Code))
            //{
            string query = "INSERT INTO fonction(CodeFct, LibelleFct) VALUES (?, ?);";

            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("CodeFct", fonction.Code);
            commande.Parameters.AddWithValue("LibelleFct", fonction.Libelle);

            DbConnex.connexionBase();
            bool reponse = DbConnex.NonQuery(commande);
            DbConnex.connexionClose();

            return reponse;
            //}
            //else
            //{
            //    MessageBox.Show("Le code fonction est déjà utilisé !");
            //    return false;
            //}
        }

        //private static bool CodeIsAvailable(string code)
        //{
        //    string query = "SELECT COUNT(*) FROM fonction WHERE CodeFct = ?;";
        //    OdbcCommand commande = new OdbcCommand(query);
        //    commande.Parameters.AddWithValue("CodeFct", code);
        //
        //    DbConnex.connexionBase();
        //    int count = DbConnex.Unscalar(commande);
        //    DbConnex.connexionClose();
        //
        //    return count == 0;
        //}

        public static bool UpdateFonction(Fonction fonction)
        {
            string query = "UPDATE fonction SET LibelleFct = ? WHERE CodeFct = ?;";

            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("LibelleFct", fonction.Libelle);
            commande.Parameters.AddWithValue("CodeFct", fonction.Code);

            DbConnex.connexionBase();
            bool reponse = DbConnex.NonQuery(commande);
            DbConnex.connexionClose();

            return reponse;
        }

        public static bool DeleteFonctionByCode(string code)
        {
            string query = "DELETE FROM fonction WHERE CodeFct = ?;";

            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("CodeFct", code);

            DbConnex.connexionBase();
            bool reponse = DbConnex.NonQuery(commande);
            DbConnex.connexionClose();

            return reponse;
        }
    }
}
