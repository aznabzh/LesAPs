using System;
using System.Collections.Generic;
using System.Data.Odbc;
using championnat.Modele.Metier;
using System.Windows.Forms;

namespace championnat.Modele.DAO
{
    internal class PosteDAO
    {
        public static List<Poste> ReadAllPostes()
        {
            List<Poste> lesPostes = new List<Poste>();

            string query = "SELECT CodeP, LibelleP FROM poste;";
            OdbcCommand commande = new OdbcCommand(query);

            DbConnex.connexionBase();
            using (OdbcDataReader reader = DbConnex.GetDataReader(commande))
            {
                try
                {
                    while (reader.Read())
                    {
                        Poste poste = new Poste(reader.GetString(0), reader.GetString(1));
                        lesPostes.Add(poste);
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
            return lesPostes;
        }

        public static Poste ReadPosteByCode(string code)
        {
            Poste poste = null;

            string query = "SELECT CodeP, LibelleP FROM poste WHERE CodeP = ?;";
            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("CodeP", code);

            DbConnex.connexionBase();
            using (OdbcDataReader reader = DbConnex.GetDataReader(commande))
            {
                try
                {
                    while (reader.Read())
                    {
                        poste = new Poste(reader.GetString(0), reader.GetString(1));
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
            return poste;
        }

        public static bool CreatePoste(Poste poste)
        {
            string query = "INSERT INTO poste(CodeP, LibelleP) VALUES (?, ?);";

            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("CodeP", poste.Code);
            commande.Parameters.AddWithValue("LibelleP", poste.Libelle);

            DbConnex.connexionBase();
            bool reponse = DbConnex.NonQuery(commande);
            DbConnex.connexionClose();
            return reponse;
        }

        public static bool UpdatePoste(Poste poste)
        {
            string query = "UPDATE poste SET LibelleP = ? WHERE CodeP = ?;";

            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("LibelleP", poste.Libelle);
            commande.Parameters.AddWithValue("CodeP", poste.Code);            

            DbConnex.connexionBase();
            bool reponse = DbConnex.NonQuery(commande);
            DbConnex.connexionClose();
            return reponse;
        }

        public static bool DeletePosteByCode(string codePoste)
        {
            string query = "DELETE FROM poste WHERE CodeP = ?;";

            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("CodePoste", codePoste);

            DbConnex.connexionBase();
            bool reponse = DbConnex.NonQuery(commande);
            DbConnex.connexionClose();
            return reponse;
        }
    }
}
