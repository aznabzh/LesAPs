using System;
using System.Data.Odbc;
using System.Text;
using System.Windows.Forms;

namespace championnat.Modele
{
    internal class DbConnex
    {
        private static OdbcConnection connex = new OdbcConnection();

        /*
         * Crée une chaîne de connexion à partir des variables d'environnement
         */
        private static string getConnexString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DRIVER=").Append(Constants.PROVIDER).Append(";");
            sb.Append("SERVER=").Append(Constants.SERVER_NAME).Append(";");
            sb.Append("PORT=").Append(Constants.PORT).Append(";");
            sb.Append("DATABASE=").Append(Constants.DATABASE_NAME).Append(";");
            sb.Append("UID=").Append(Constants.USERNAME).Append(";");
            sb.Append("PASSWORD=").Append(Constants.PASSWORD).Append(";");
            return sb.ToString();
        }

        /*
         * Ouvre une connexion à la base de données
         * 
         * Doit obligatoirement être appelée avant d'appeler les autres
         * méthodes de cette classe
         */
        public static void connexionBase()
        {
            try
            {
                connex.ConnectionString = getConnexString();
                connex.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static System.Data.ConnectionState etatConnection()
        {
            return connex.State;
        }

        /*
         * Ferme la connexion à la base de données
         * 
         * Doit obligatoirement être appelée à la fin de l'utilisation
         * de la base de données
         */
        public static void connexionClose()
        {
            connex.Close();

        }

        /*
         * Permet d'obtenir un DataReader à partir d'une commande SQL
         */
        public static OdbcDataReader GetDataReader(OdbcCommand command)
        {
            try
            {
                command.Connection = connex;
                OdbcDataReader reader = command.ExecuteReader();
                return reader;
            }

            catch (OdbcException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /*
         * Permet d'obtenir une valeur à partir d'une commande SQL
         * contenant une fonction d'agrégation (COUNT, SUM, etc.)
         */
        public static int Unscalar(OdbcCommand command)
        {
            using (connex)
            {
                try
                {
                    command.Connection = connex;
                    int unNB = (Int32)command.ExecuteScalar();
                    return unNB;
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return -1;
                }
            }
        }

        /*
         * Permet d'exécuter une requête SQL qui ne renvoie pas de données
         * (INSERT, UPDATE, DELETE, etc.)
         */
        public static bool NonQuery(OdbcCommand command)
        {
            using (connex)
            {
                try
                {
                    command.Connection = connex;
                    int nbLignesAffectees = command.ExecuteNonQuery();
                    return nbLignesAffectees>=1;
                }
                catch (OdbcException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
        }
    }

}
