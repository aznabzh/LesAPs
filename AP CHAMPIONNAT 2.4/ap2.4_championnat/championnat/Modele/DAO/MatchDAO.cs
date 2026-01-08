using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Windows.Forms;
using championnat.Modele.Metier;

namespace championnat.Modele.DAO
{
    /*
     * ** ATTENTION ***
     * Les commentaires de cette classe ne sont pas des commentaires normaux !!!
     * Ils sont là pour vous aider à comprendre, car vous êtes encore en train d'apprendre
     * 
     * Dans la vraie vie, on ne met pas de commentaires comme ça
     */
    internal class MatchDAO
    {
        public static List<Match> ReadAllMatches()
        {
            List<Match> lesMatches = new List<Match>();

            /*
             * Ici on récupère les informations des matchs
             * Si on avait des objets liés (ex: Equipe), on pourrait aussi utiliser un dictionnaire
             * comme dans JoueurDAO avec Poste, mais ici on fait simple
             */
            string query = "SELECT CodeM, DateM, LieuM, ScoreEquipe1, ScoreEquipe2, CodeEquipe1, CodeEquipe2 " +
                           "FROM matches";
            OdbcCommand commande = new OdbcCommand(query);

            DbConnex.connexionBase();

            using (OdbcDataReader reader = DbConnex.GetDataReader(commande))
            {
                try
                {
                    while (reader.Read())
                    {
                        /*
                         * On lit chaque match depuis le reader et on crée un objet Match
                         */
                        string codeM = reader.GetString(0);
                        DateTime dateM = reader.GetDateTime(1);
                        string lieuM = reader.GetString(2);
                        int scoreE1 = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        int scoreE2 = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                        string codeE1 = reader.GetString(5);
                        string codeE2 = reader.GetString(6);

                        Match match = new Match(codeM, dateM, lieuM, scoreE1, scoreE2, codeE1, codeE2);
                        lesMatches.Add(match);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la lecture des matchs : " + ex.Message);
                }
                finally
                {
                    DbConnex.connexionClose();
                }
            }

            return lesMatches;
        }

        public static Match ReadMatchByCode(string codeM)
        {
            Match match = null;

            /*
             * Lecture d'un match précis par son code
             */
            string query = "SELECT CodeM, DateM, LieuM, ScoreEquipe1, ScoreEquipe2, CodeEquipe1, CodeEquipe2 " +
                           "FROM matches " +
                           "WHERE CodeM = ?;";
            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("CodeM", codeM);

            DbConnex.connexionBase();

            using (OdbcDataReader reader = DbConnex.GetDataReader(commande))
            {
                try
                {
                    while (reader.Read())
                    {
                        string code = reader.GetString(0);
                        DateTime date = reader.GetDateTime(1);
                        string lieu = reader.GetString(2);
                        int scoreE1 = reader.IsDBNull(3) ? 0 : reader.GetInt32(3);
                        int scoreE2 = reader.IsDBNull(4) ? 0 : reader.GetInt32(4);
                        string codeE1 = reader.GetString(5);
                        string codeE2 = reader.GetString(6);

                        match = new Match(code, date, lieu, scoreE1, scoreE2, codeE1, codeE2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors de la lecture du match : " + ex.Message);
                }
                finally
                {
                    DbConnex.connexionClose();
                }
            }

            return match;
        }

        public static bool CreateMatch(Match match)
        {
           
            //if (CodeIsAvailable(match.CodeM))
            //{
                string query = "INSERT INTO matches(CodeM, DateM, LieuM, ScoreEquipe1, ScoreEquipe2, CodeEquipe1, CodeEquipe2) " +
                               "VALUES (?, ?, ?, ?, ?, ?, ?);";

                OdbcCommand commande = new OdbcCommand(query);
                commande.Parameters.AddWithValue("CodeM", match.CodeM);
                commande.Parameters.AddWithValue("DateM", match.Date);
                commande.Parameters.AddWithValue("LieuM", match.Lieu);
                commande.Parameters.AddWithValue("ScoreEquipe1", match.ScoreE1);
                commande.Parameters.AddWithValue("ScoreEquipe2", match.ScoreE2);
                commande.Parameters.AddWithValue("CodeEquipe1", match.CodeE1);
                commande.Parameters.AddWithValue("CodeEquipe2", match.CodeE2);

                DbConnex.connexionBase();
                bool reponse = DbConnex.NonQuery(commande);
                DbConnex.connexionClose();
                return reponse;
            //}
            //else
            //{
            //    MessageBox.Show("Le code du match est déjà utilisé !");
            //    return false;
            //}
        }

        //private static bool CodeIsAvailable(string codeM)
        //{
        //    
        //    string query = "SELECT COUNT(*) FROM matches WHERE CodeM = ?;";
        //    OdbcCommand commande = new OdbcCommand(query);
        //    commande.Parameters.AddWithValue("CodeM", codeM);
        //
        //    DbConnex.connexionBase();
        //    int count = DbConnex.Unscalar(commande);
        //    DbConnex.connexionClose();
        //
        //    return count == 0;
        //}

        public static int GetMaxNumero()
        {
            List<string> tousLesCodes = ReadAllMatches().Select(m => m.CodeM).ToList();

            int max = 0;
            foreach (string code in tousLesCodes)
            {
                if (code.StartsWith("M"))
                {
                    string numPart = code.Substring(1); // retire le "M"
                    if (int.TryParse(numPart, out int number))
                    {
                        if (number > max)
                            max = number;
                    }
                }
            }
            return max;
        }


        public static bool UpdateMatch(Match match)
        {
            /*
             * Mise à jour d'un match existant
             * ATTENTION : l'ordre des paramètres doit respecter la requête SQL
             */
            string query = "UPDATE matches " +
                           "SET DateM = ?, LieuM = ?, ScoreEquipe1 = ?, ScoreEquipe2 = ?, CodeEquipe1 = ?, CodeEquipe2 = ? " +
                           "WHERE CodeM = ?;";

            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("DateM", match.Date);
            commande.Parameters.AddWithValue("LieuM", match.Lieu);
            commande.Parameters.AddWithValue("ScoreEquipe1", match.ScoreE1);
            commande.Parameters.AddWithValue("ScoreEquipe2", match.ScoreE2);
            commande.Parameters.AddWithValue("CodeEquipe1", match.CodeE1);
            commande.Parameters.AddWithValue("CodeEquipe2", match.CodeE2);
            commande.Parameters.AddWithValue("CodeM", match.CodeM);

            DbConnex.connexionBase();
            bool reponse = DbConnex.NonQuery(commande);
            DbConnex.connexionClose();
            return reponse;
        }

        public static bool DeleteMatchByCode(string codeM)
        {
            /*
             * Suppression d'un match par son code
             */
            string query = "DELETE FROM matches WHERE CodeM = ?;";

            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("CodeM", codeM);

            DbConnex.connexionBase();
            bool reponse = DbConnex.NonQuery(commande);
            DbConnex.connexionClose();
            return reponse;
        }
    }
}
