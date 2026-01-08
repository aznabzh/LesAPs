using System;
using System.Collections.Generic;
using System.Data.Odbc;
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
    internal class JoueurDAO
    {

        public static List<Joueur> ReadAllJoueurs()
        {
            List<Joueur> lesJoueurs = new List<Joueur>();

            string query = "SELECT NumJ, NomJ, PrenomJ, DateNaissJ, NumLicenceJ, " +
                           "CodeP, LibelleP " +
                           "FROM joueur, poste " +
                           "WHERE joueur.CodePoste=poste.CodeP";
            OdbcCommand commande = new OdbcCommand(query);

            DbConnex.connexionBase();

            using (OdbcDataReader reader = DbConnex.GetDataReader(commande))
            {
                try
                {
                    /*
                     * lesPostes est un dictionnaire
                     * Un Dictionnaire est un type de collection au format clé/valeur
                     * Contrairement aux Listes où les éléments sont stockés et récupérés
                     * avec un indice (index), un Dictionnaire est organisé par clés : 
                     * on stocke une valeur v en lui associant une clé k
                     * Par exemple ici : lesPostes.Add(numPoste, nouveauPoste) 
                     *     -> on stocke le poste nouveauPoste derrière la clé numPoste
                     * 
                     * Pour définir un Dictionnaire, on définit le type de la clé 
                     * et le type de la valeur à stocker
                     * Par exemple ici on a un Dictionnaire avec des clés 
                     * de type string (comme le code d'un Poste)
                     * et des valeurs de type Poste
                     */
                    Dictionary<string, Poste> lesPostes = new Dictionary<string, Poste>();
                    while (reader.Read())
                    {
                        /*
                         * Si deux joueurs ont le même poste, on récupère quand-même
                         * toutes les informations du poste avec notre requête
                         * 
                         * Si on écrit notre mapping objet naïvement, on va créer 
                         * plusieurs objets différents pour le même poste
                         * 
                         * A la place, on choisit de stocker les postes dans un dictionnaire
                         * puis de vérifier si un objet pour  le poste du joueur existe déjà
                         * 
                         * S'il n'existe pas, on crée un nouvel objet et on l'ajoute au dictionnaire
                         * On ira ensuite chercher le poste du joueur dans le dictionnaire
                         */
                        int numero = reader.GetInt16(0);
                        string  nom = reader.GetString(1);
                        string prenom = reader.GetString(2);
                        DateTime dateNaissance = reader.GetDateTime(3);
                        string numeroLicence = reader.GetString(4);
                        string codePoste = reader.GetString(5);
                        if (!lesPostes.ContainsKey(codePoste))
                        {
                            Poste nouveauPoste = new Poste(codePoste, reader.GetString(6));
                            lesPostes.Add(codePoste, nouveauPoste);
                        }
                        Joueur joueur = new Joueur(numero, nom,
                            prenom, dateNaissance, numeroLicence,
                            lesPostes[codePoste]);
                        lesJoueurs.Add(joueur);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                /*
                 * TRES IMPORTANT : le finally s'exécute dans tous les cas : qu'il y ait eu une Exception ou pas
                 * Comme il faut absolument fermer la connexion à la base de données, on le met dans le finally
                 * de manière à ce que ça arrive quoi qu'il se passe dans notre code
                 */
                finally
                {
                    DbConnex.connexionClose();
                }
            }

            return lesJoueurs;
        }

        public static Joueur ReadJoueurByNumero(int numero)
        {
            Joueur joueur = null;

            string query = "SELECT NumJ, NomJ, PrenomJ, DateNaissJ, NumLicenceJ, " +
                           "CodeP, LibelleP" +
                           "FROM joueur, poste" +
                           "WHERE joueur.CodePoste=poste.CodeP" +
                           "AND NumJ = ?;";
            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("NumJ", numero);

            DbConnex.connexionBase();
            using (OdbcDataReader reader = DbConnex.GetDataReader(commande))
            {

                try
                {
                    while (reader.Read())
                    {
                        Poste nouveauPoste = new Poste(reader.GetString(5),
                                                       reader.GetString(6));

                        joueur = new Joueur(reader.GetInt16(0),
                            reader.GetString(1), reader.GetString(2),
                            reader.GetDateTime(3), reader.GetString(4),
                            nouveauPoste);
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

            return joueur;
        }

        public static bool CreateJoueur(Joueur joueur)
        {
            //if (NumeroIsAvailable(joueur.Numero))
            //{
                string query = "INSERT INTO joueur(NumJ, NomJ, PrenomJ, DateNaissJ, NumLicenceJ, CodeEquipe, CodePoste)" +
                               "VALUES (?, ?, ?, ?, ?, ?, ?);";

                OdbcCommand commande = new OdbcCommand(query);
                commande.Parameters.AddWithValue("NumJ", joueur.Numero);
                commande.Parameters.AddWithValue("NomJ", joueur.Nom);
                commande.Parameters.AddWithValue("PrenomJ", joueur.Prenom);
                commande.Parameters.AddWithValue("DateNaissJ", joueur.DateDeNaissance);
                commande.Parameters.AddWithValue("NumLicenceJ", joueur.NumeroLicence);
                //A CHANGER quand on fera le lien avec la classe Equipe
                commande.Parameters.AddWithValue("CodeEquipe", "E1");
                commande.Parameters.AddWithValue("CodePoste", joueur.Poste.Code);

                DbConnex.connexionBase();
                bool reponse = DbConnex.NonQuery(commande);
                DbConnex.connexionClose();
                return reponse;
            //} else
            //{
            //    MessageBox.Show("Le numéro de joueur est déjà utilisé !");
            //    return false;
            //}
        }

        //private static bool NumeroIsAvailable(int numero)
        //{
        //    string query = "SELECT COUNT(*) FROM joueur WHERE NumJ = ?;";
        //    OdbcCommand commande = new OdbcCommand(query);
        //    commande.Parameters.AddWithValue("NumJ", numero);
        //
        //    DbConnex.connexionBase();
        //    int count = DbConnex.Unscalar(commande);
        //    DbConnex.connexionClose();
        //    return count == 0;
        //}

        public static int GetMaxNumero()
        {
            string query = "SELECT MAX(NumJ) FROM joueur;";
            OdbcCommand commande = new OdbcCommand(query);
            DbConnex.connexionBase();
            int max = DbConnex.Unscalar(commande);
            DbConnex.connexionClose();
            return max;
        }

        public static bool UpdateJoueur(Joueur joueur)
        {
            string query = "UPDATE joueur " +
                           "SET NomJ = ?, PrenomJ = ?, DateNaissJ = ?, NumLicenceJ = ?, CodeEquipe = ?, CodePoste = ? " +
                           "WHERE NumJ = ?;";

            OdbcCommand commande = new OdbcCommand(query);
            /*
             * ATTENTION : l'ordre des paramètres est important ! 
             * Même s'ils semblent nommés, ils doivent apparaître dans l'ordre
             * dans lequel ils sont dans la requête, sinon ils seront mélangés !
             */
            commande.Parameters.AddWithValue("NomJ", joueur.Nom);
            commande.Parameters.AddWithValue("PrenomJ", joueur.Prenom);
            commande.Parameters.AddWithValue("DateNaissJ", joueur.DateDeNaissance);
            commande.Parameters.AddWithValue("NumLicenceJ", joueur.NumeroLicence);
            //A CHANGER quand vous ferez le lien avec la classe Equipe
            commande.Parameters.AddWithValue("CodeEquipe", "E1");
            commande.Parameters.AddWithValue("CodePoste", joueur.Poste.Code);
            commande.Parameters.AddWithValue("NumJ", joueur.Numero);

            DbConnex.connexionBase();
            bool reponse = DbConnex.NonQuery(commande);
            DbConnex.connexionClose();
            return reponse;
        }

        public static bool DeleteJoueurByNumero(int numero)
        {
            string query = "DELETE FROM joueur WHERE NumJ = ?;";

            OdbcCommand commande = new OdbcCommand(query);
            commande.Parameters.AddWithValue("NumJ", numero);

            DbConnex.connexionBase();
            bool reponse = DbConnex.NonQuery(commande);
            DbConnex.connexionClose();
            return reponse;
        }
    }
}
