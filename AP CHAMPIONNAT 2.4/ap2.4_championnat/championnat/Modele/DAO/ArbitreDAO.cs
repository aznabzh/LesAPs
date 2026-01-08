using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Windows.Forms;
using championnat.Modele.Metier;

namespace championnat.Modele.DAO
{
    internal class ArbitreDAO
    {
        public static List<Arbitre> ReadAllArbitres()
        {
            List<Arbitre> lesArbitres = new List<Arbitre>();

            string query = "SELECT CodeA, NomA, PrenomA FROM arbitre;";
            OdbcCommand commande = new OdbcCommand(query);

            DbConnex.connexionBase();

            using (OdbcDataReader reader = DbConnex.GetDataReader(commande))
            {
                try
                {
                    while (reader.Read())
                    {
                        string code = reader.GetString(0);
                        string nom = reader.GetString(1);
                        string prenom = reader.GetString(2);

                        Arbitre arbitre = new Arbitre(code, nom, prenom);
                        lesArbitres.Add(arbitre);
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

            return lesArbitres;
        }

        public static Arbitre ReadArbitreByCode(string code)
        {
            Arbitre arbitre = null;

            string query = "SELECT CodeA, NomA, PrenomA FROM arbitre WHERE CodeA = ?;";
            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("CodeA", code);

            DbConnex.connexionBase();

            using (OdbcDataReader reader = DbConnex.GetDataReader(commande))
            {
                try
                {
                    if (reader.Read())
                    {
                        string codeA = reader.GetString(0);
                        string nom = reader.GetString(1);
                        string prenom = reader.GetString(2);

                        arbitre = new Arbitre(codeA, nom, prenom);
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

            return arbitre;
        }

        public static bool CreateArbitre(Arbitre arbitre)
        {
            //if (CodeIsAvailable(arbitre.Code))
            //{
                string query = "INSERT INTO arbitre(CodeA, NomA, PrenomA) VALUES (?, ?, ?);";

                OdbcCommand commande = new OdbcCommand(query);
                commande.Parameters.AddWithValue("CodeA", arbitre.Code);
                commande.Parameters.AddWithValue("NomA", arbitre.Nom);
                commande.Parameters.AddWithValue("PrenomA", arbitre.Prenom);

                DbConnex.connexionBase();
                bool reponse = DbConnex.NonQuery(commande);
                DbConnex.connexionClose();

                return reponse;
            //}
            //else
            //{
            //    MessageBox.Show("Le code arbitre est déjà utilisé !");
            //    return false;
            //}
        }

        //private static bool CodeIsAvailable(string code)
        //{
        //    string query = "SELECT COUNT(*) FROM arbitre WHERE CodeA = ?;";
        //    OdbcCommand commande = new OdbcCommand(query);
        //    commande.Parameters.AddWithValue("CodeA", code); 
        //
        //    DbConnex.connexionBase();
        //    int count = DbConnex.Unscalar(commande);
        //    DbConnex.connexionClose();
        //
        //    return count == 0;
        //}



        public static int GetMaxNumero()
        {
            List<string> tousLesCodes = ReadAllArbitres().Select(a => a.Code).ToList();

            int max = 0;
            foreach (string code in tousLesCodes)
            {
                if (code.StartsWith("A"))
                {
                    string numPart = code.Substring(1); 
                    if (int.TryParse(numPart, out int number))
                    {
                        if (number > max)
                            max = number;
                    }
                }
            }
            return max;
        }

        public static bool UpdateArbitre(Arbitre arbitre)
        {
            string query = "UPDATE arbitre SET NomA = ?, PrenomA = ? WHERE CodeA = ?;";

            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("NomA", arbitre.Nom);
            commande.Parameters.AddWithValue("PrenomA", arbitre.Prenom);
            commande.Parameters.AddWithValue("CodeA", arbitre.Code);

            DbConnex.connexionBase();
            bool reponse = DbConnex.NonQuery(commande);
            DbConnex.connexionClose();

            return reponse;
        }

        public static bool DeleteArbitreByCode(string code)
        {
            string query = "DELETE FROM arbitre WHERE CodeA = ?;";

            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("CodeA", code);

            DbConnex.connexionBase();
            bool reponse = DbConnex.NonQuery(commande);
            DbConnex.connexionClose();

            return reponse;
        }
    }
}
