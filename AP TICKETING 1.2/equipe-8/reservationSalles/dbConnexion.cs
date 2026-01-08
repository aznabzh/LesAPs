using System.Data;
using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace reservationSalles2018
{
    class dbConnexion
    {
        private static OleDbConnection connex = new System.Data.OleDb.OleDbConnection();
        private static string connexString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data source=..\..\..\..\reservationSalles.accdb";
        private static DataSet reservationsDataSet;
        private static OleDbDataAdapter sallesDataAdapter;
        private static OleDbDataAdapter liguesDataAdapter;
        private static OleDbDataAdapter reservantsDataAdapter;
        private static OleDbDataAdapter reservationsDataAdapter;
        private static OleDbDataAdapter typesSallesDataAdapter;
        private static OleDbDataAdapter equipementsDataAdapter;


        private static DataTable tableSalles, tableLigues, tableReservants,  tableReservations, tableTypesSalles , tableEquipements ;

        private static DataRelation reservantsReservations, sallesReservations, sallesTypes , reservantsLigues;
    
        public static OleDbConnection connexionBase()
        {
            try
            {
                connex.ConnectionString = connexString;
                connex.Open();
                return connex;
             }
             catch
                {
                    return null;

                }
            }


        public static OleDbDataReader GetDataReader(string uneRequete)
        {
            try
            {
                OleDbCommand oleCommande = new OleDbCommand(uneRequete, connex);
                OleDbDataReader reader = oleCommande.ExecuteReader();
                return reader;
            }
            catch
            {
                return null;

            }
        }


        public static void setDataSet()
        {
            sallesDataAdapter = new OleDbDataAdapter();
            liguesDataAdapter = new OleDbDataAdapter();
            reservantsDataAdapter = new OleDbDataAdapter();
            reservationsDataAdapter = new OleDbDataAdapter();
            typesSallesDataAdapter = new OleDbDataAdapter();
            equipementsDataAdapter = new OleDbDataAdapter();


            String sallesRequete = "select * from salles";
            String liguesRequete = "select * from ligues";
            String reservantsRequete = "select * from reservants";
            String reservationsRequete = "select * from reservations order by dateReservation desc";
            String typesSallesRequete = "select * from types";
            String equipementsRequete = "select * from equipements";


            OleDbCommand sallesCommande;
            OleDbCommand liguesCommande;
            OleDbCommand reservantsCommande;
            OleDbCommand reservationsCommande;
            OleDbCommand typesSallesCommande;
            OleDbCommand equipementsCommande;


            OleDbConnection maConnex = connexionBase();

            sallesCommande = new OleDbCommand(sallesRequete);
            sallesCommande.Connection = maConnex;

            liguesCommande = new OleDbCommand(liguesRequete);
            liguesCommande.Connection = maConnex;

            reservantsCommande = new OleDbCommand(reservantsRequete);
            reservantsCommande.Connection = maConnex;

            reservationsCommande = new OleDbCommand(reservationsRequete);
            reservationsCommande.Connection = maConnex;

            typesSallesCommande = new OleDbCommand(typesSallesRequete);
            typesSallesCommande.Connection = maConnex;

            equipementsCommande = new OleDbCommand(equipementsRequete);
            equipementsCommande.Connection = maConnex;

            sallesDataAdapter.SelectCommand = sallesCommande;
            liguesDataAdapter.SelectCommand = liguesCommande;
            reservantsDataAdapter.SelectCommand = reservantsCommande;
            reservationsDataAdapter.SelectCommand = reservationsCommande;
            typesSallesDataAdapter.SelectCommand = typesSallesCommande;
            equipementsDataAdapter.SelectCommand = equipementsCommande;



            // DataSet 
            reservationsDataSet = new DataSet();
            typesSallesDataAdapter.Fill(reservationsDataSet, "types");
            liguesDataAdapter.Fill(reservationsDataSet, "ligues");
            sallesDataAdapter.Fill(reservationsDataSet, "salles");
            reservantsDataAdapter.Fill(reservationsDataSet, "reservants");
            reservationsDataAdapter.Fill(reservationsDataSet, "reservations");
            equipementsDataAdapter.Fill(reservationsDataSet, "equipements");

            tableSalles = reservationsDataSet.Tables["salles"];
            tableSalles.Columns[0].AutoIncrement = true;

            tableLigues = reservationsDataSet.Tables["ligues"];
            tableLigues.Columns[0].AutoIncrement = true;

            tableReservants = reservationsDataSet.Tables["reservants"];
            tableReservants.Columns[0].AutoIncrement = true;
            tableReservants.Columns.Add("nomPrenom", typeof(string), "nomReservant + ' ' + prenomReservant");

            tableReservations = reservationsDataSet.Tables["reservations"];
            tableReservations.Columns[0].AutoIncrement = true;

            tableTypesSalles = reservationsDataSet.Tables["types"];
            tableTypesSalles.Columns[0].AutoIncrement = true;

            tableEquipements = reservationsDataSet.Tables["equipements"];
            tableEquipements.Columns[0].AutoIncrement = true;

            reservantsReservations = new DataRelation("EquiJoinReservationReservant", tableReservants.Columns["idReservant"], tableReservations.Columns["idReservant"]);
            reservationsDataSet.Relations.Add(reservantsReservations);
            
            sallesReservations = new DataRelation("EquiJoinReservationSalle", tableSalles.Columns["idSalle"], tableReservations.Columns["idSalle"]);
            reservationsDataSet.Relations.Add(sallesReservations);

            sallesTypes = new DataRelation("EquiJoinSalleType", tableTypesSalles.Columns["idType"], tableSalles.Columns["idType"]);
            reservationsDataSet.Relations.Add(sallesTypes);

            reservantsLigues = new DataRelation("EquiJoinReservantLigue", tableLigues.Columns["idLigue"], tableReservants.Columns["idLigue"]);
            reservationsDataSet.Relations.Add(reservantsLigues);


            maConnex.Close();


        }


        public static DataSet getDataSet()
        {
            return reservationsDataSet;
        }



        public static void miseJourDataSet()
        {
            reservationsDataSet.Clear();
            typesSallesDataAdapter.Fill(reservationsDataSet, "types");
            liguesDataAdapter.Fill(reservationsDataSet, "ligues");
            sallesDataAdapter.Fill(reservationsDataSet, "salles");
            reservantsDataAdapter.Fill(reservationsDataSet, "reservants");
            reservationsDataAdapter.Fill(reservationsDataSet, "reservations");
            equipementsDataAdapter.Fill(reservationsDataSet, "equipements");

        }

      

        public static void miseJourDataSetRéservations()
        {
            reservationsDataAdapter.Fill(reservationsDataSet, "Reservations");
        }


        public static void ajouterSalle(string unNom, long unType, short uneSurface, short uneCapacite, Single unPrix)
        {
            try
            {
                string uneRequete = "insert into salles (nomSalle , idType, surfaceSalle , capaciteSalle , prixLocationSalle) values (@unNom , @unType ,@uneSurface  , @uneCapacite , @unPrix )";
                connexionBase();
                OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);
                uneCommande.CommandType = CommandType.Text;
                uneCommande.Parameters.Add("@unNom", OleDbType.VarWChar).Value = unNom;
                uneCommande.Parameters.Add("@unType", OleDbType.BigInt).Value = unType;
                uneCommande.Parameters.Add("@uneSurface", OleDbType.SmallInt).Value = uneSurface;
                uneCommande.Parameters.Add("@uneCapacite", OleDbType.SmallInt).Value = uneCapacite;
                uneCommande.Parameters.Add("@unPrix", OleDbType.Single).Value = unPrix;

                uneCommande.ExecuteNonQuery();
                connex.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
              
            }

           



        }
        public static void modifierSalle(int unIdSalle, string unNom, long unType, short uneSurface, short uneCapacite, Single unPrix)
        {
            try
            {
                string uneRequete = "update  salles set nomSalle = @unNom , idType = @unType , surfaceSalle = @uneSurface , capaciteSalle = @uneCapacite , prixLocationSalle = @unPrix  where idSalle = @unIdSalle";
                               
                
                connexionBase();
                OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);

                uneCommande.CommandType = CommandType.Text;
                uneCommande.Parameters.Add("@unNom", OleDbType.VarWChar).Value = unNom;
                uneCommande.Parameters.Add("@unType", OleDbType.BigInt).Value = unType;
                uneCommande.Parameters.Add("@uneSurface", OleDbType.SmallInt).Value = uneSurface;
                uneCommande.Parameters.Add("@uneCapacite", OleDbType.SmallInt).Value = uneCapacite;
                uneCommande.Parameters.Add("@unPrix", OleDbType.Single).Value = unPrix;
                uneCommande.Parameters.Add("@unIdSalle", OleDbType.Single).Value = unIdSalle;

                uneCommande.ExecuteNonQuery();
                connex.Close();
            }
            catch (DataException de)
            {
                MessageBox.Show(de.Message);
            }


        }
        public static void supprimerSalle(int unIdSalle)
        {
            try
            {
                string uneRequete = "delete from salles where idSalle = " + unIdSalle;
                connexionBase();
                OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);
                uneCommande.ExecuteNonQuery();
                connex.Close();
            }
            catch (DataException de)
            {
                MessageBox.Show(de.Message);

            }
        }


        public static void ajouterLigue(string unNom, String unTelephone, String unMail)
        {
            try
            {
                string uneRequete = "insert into ligues (nomLigue , telephoneLigue , mailLigue) values (@unNom  , @unTelephone  , @unMail )";
                connexionBase();
                OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);
                uneCommande.CommandType = CommandType.Text;
                uneCommande.Parameters.Add("@unNom", OleDbType.VarWChar).Value = unNom;
                uneCommande.Parameters.Add("@unTelephone", OleDbType.VarWChar).Value = unTelephone;
                uneCommande.Parameters.Add("@unMail", OleDbType.VarWChar).Value = unMail;
                uneCommande.ExecuteNonQuery();
                connex.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }
        public static void modifierLigue(int unIdLigue, string unNom, string unTelephone, string unMail)
        {
            try
            {
                string uneRequete = "update  ligues set nomLigue = @unNom , telephoneLigue = @unTelephone, mailLigue = @unMail where idLigue = @unIdLigue";
                connexionBase();
                OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);
                uneCommande.CommandType = CommandType.Text;
                uneCommande.Parameters.Add("@unNom", OleDbType.VarWChar).Value = unNom;
                uneCommande.Parameters.Add("@unTelephone", OleDbType.VarWChar).Value = unTelephone;
                uneCommande.Parameters.Add("@unMail", OleDbType.VarWChar).Value = unMail;
                uneCommande.Parameters.Add("@unIdLigue", OleDbType.Integer).Value = unIdLigue;
                uneCommande.ExecuteNonQuery();
                connex.Close();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.Message);
            }


        }
        public static void supprimerLigue(int unIdLigue)
        {
            try
            {
                string uneRequete = "delete from ligues where idLigue = @unIdLigue";
                connexionBase();
                OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);
                uneCommande.CommandType = CommandType.Text;
                uneCommande.Parameters.Add("@unIdLigue", OleDbType.Integer).Value = unIdLigue;
                uneCommande.ExecuteNonQuery();
                connex.Close();
            }
            catch (DataException de)
            {
                MessageBox.Show(de.Message);

            }
        }

        public static void ajouterReservant(String unInsee, String unNom, String unPrenom, String unTelephone, String unMail, int uneLigue , String uneFonction)
        {
            try
            {
               
             
                string uneRequete = "insert into reservants (inseeReservant , nomReservant, prenomReservant  , telephoneReservant, mailReservant, idLigue , fonctionReservant) values (@unInsee, @unNom ,@unPrenom,  @unTelephone , @unMail , @uneLigue , @uneFonction)";

                connexionBase();
                OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);
                uneCommande.CommandType = CommandType.Text;

                uneCommande.Parameters.Add("@unInsee", OleDbType.VarWChar).Value = unInsee;
                uneCommande.Parameters.Add("@unNom", OleDbType.VarWChar).Value = unNom;
                uneCommande.Parameters.Add("@unPrenom", OleDbType.VarWChar).Value = unPrenom;
                uneCommande.Parameters.Add("@unTelephone", OleDbType.VarWChar).Value = unTelephone;
                uneCommande.Parameters.Add("@unMail", OleDbType.VarWChar).Value = unMail;
                uneCommande.Parameters.Add("@uneLigue", OleDbType.Integer).Value = uneLigue;
                uneCommande.Parameters.Add("@uneFonction", OleDbType.VarWChar).Value = uneFonction;

                uneCommande.ExecuteNonQuery();
                connex.Close();

            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.Message);
            }


        }
        public static void modifierReservant(int unIdReservant, String unInsee, String unNom, String unPrenom, String unTelephone, String unMail, int uneLigue, String uneFonction)
        {
            try
            {
                string uneRequete = "update  reservants set inseeReservant = @unInsee,  nomReservant = @unNom , prenomReservant = @unPrenom , telephoneReservant = @unTelephone, mailReservant = @unMail , idLigue = @uneLigue , fonctionReservant = @uneFonction where idReservant = @unIdReservant";

                connexionBase();
                OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);
                uneCommande.CommandType = CommandType.Text;
                uneCommande.Parameters.Add("@unInsee", OleDbType.VarWChar).Value = unInsee;
                uneCommande.Parameters.Add("@unNom", OleDbType.VarWChar).Value = unNom;
                uneCommande.Parameters.Add("@unPrenom", OleDbType.VarWChar).Value = unPrenom;
                uneCommande.Parameters.Add("@unTelephone", OleDbType.VarWChar).Value = unTelephone;
                uneCommande.Parameters.Add("@unMail", OleDbType.VarWChar).Value = unMail;
                uneCommande.Parameters.Add("@uneLigue", OleDbType.Integer).Value = uneLigue;
                uneCommande.Parameters.Add("@uneFonction", OleDbType.VarWChar).Value = uneFonction;
                uneCommande.Parameters.Add("@unIdReservant", OleDbType.Integer).Value = unIdReservant;
                uneCommande.ExecuteNonQuery();
                connex.Close();
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.Message);
            }


        }
        public static void supprimerReservant(int unIdReservant)
        {
            try
            {
                string uneRequete = "delete from reservants where idReservant = @unIdReservant";
                connexionBase();
                OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);
                uneCommande.CommandType = CommandType.Text;
                uneCommande.Parameters.Add("@unIdReservant", OleDbType.Integer).Value = unIdReservant;
                uneCommande.ExecuteNonQuery();
                connex.Close();
            }
            catch (DataException de)
            {
                MessageBox.Show(de.Message);

            }
        }


        public static void ajouterEquipement(string unLibelle, int uneQuantite, Single unPrix)
        {
            try
            {
                string uneRequete = "insert into equipements (libelleEquipement , quantiteEquipement , prixEquipement) values (@unLibelle , @uneQuantite ,  @unPrix)";
                connexionBase();
                OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);
                uneCommande.CommandType = CommandType.Text;

                uneCommande.Parameters.Add("@unLibelle", OleDbType.VarWChar).Value = unLibelle;
                uneCommande.Parameters.Add("@uneQuantite", OleDbType.Integer).Value = uneQuantite;
                uneCommande.Parameters.Add("@unPrix", OleDbType.Single).Value = unPrix;

                uneCommande.ExecuteNonQuery();
                connex.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }
        public static void modifierEquipement(int unIdEquipement, string unLibelle, int uneQuantite, Single unPrix)
        {
            try
            {
                  string uneRequete = "update  equipements set libelleEquipement = @unLibelle , quantiteEquipement = @uneQuantite, prixEquipement = @unPrix where idEquipement = @unIdEquipement";
                   connexionBase();
                   OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);
                   uneCommande.CommandType = CommandType.Text;
                   uneCommande.Parameters.Add("@unLibelle", OleDbType.VarWChar).Value = unLibelle;
                   uneCommande.Parameters.Add("@uneQuantite", OleDbType.Integer).Value = uneQuantite;
                   uneCommande.Parameters.Add("@unPrix", OleDbType.Single).Value = unPrix;
                   uneCommande.Parameters.Add("@unIdEquipement", OleDbType.Integer).Value = unIdEquipement;

           

                   uneCommande.ExecuteNonQuery();
                   connex.Close();
                
            }
            catch (OleDbException e)
            {
                MessageBox.Show(e.Message);
            }


        }
        public static void supprimerEquipement(int unIdEquipement)
        {
            try
            {
                String uneRequete = "delete from equipements where idEquipement = @idEquipement";
                connexionBase();
                OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);
                uneCommande.CommandType = CommandType.Text;
                uneCommande.Parameters.Add("@unIdEquipement", OleDbType.Integer).Value = unIdEquipement;


                uneCommande.ExecuteNonQuery();
                connex.Close();

            }
            catch (DataException de)
            {
                MessageBox.Show(de.Message);

            }
        }




        public static void ajouterReservation(DateTime uneDateReservation, string unePlageReservation, int unIdReservant, int unIdSalle)
        {
            try
            {
                string uneRequete = "insert into reservations (dateReservation , plageReservation ,  idReservant, idSalle) values (" + uneDateReservation.ToOADate() + " , '" + unePlageReservation + "' ,  " + unIdReservant + " ,  " + unIdSalle + ")";

                
                connexionBase();
                OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);
                uneCommande.ExecuteNonQuery();
                connex.Close();
            }
            catch (DataException de)
            {
                      MessageBox.Show(de.Message);
            }


        }
        public static void supprimerReservation( int unIdReservation)
        {
            try
            {
                string uneRequete = "delete from reservations where idReservation = " + unIdReservation ;

                MessageBox.Show(uneRequete);

                connexionBase();
                OleDbCommand uneCommande = new OleDbCommand(uneRequete, connex);
                int reponse = uneCommande.ExecuteNonQuery();
                MessageBox.Show(reponse.ToString());
                connex.Close();
            }
            catch (DataException de)
            {
                MessageBox.Show(de.Message);
            }


        }
   
        public static String[,] creerTabReservations()
        {
            int nbLignesReservations, nbColonnesReservations = 8, i;
            String[,] tabReservations;
           
            nbLignesReservations = reservantsReservations.ChildTable.Rows.Count;
            tabReservations = new String[nbLignesReservations, nbColonnesReservations];

                       i = 0;
            foreach (DataRow reservationsLigne in reservantsReservations.ChildTable.Rows)
            {
                tabReservations[i, 0] = reservationsLigne.GetParentRow(reservantsReservations)["nomReservant"].ToString();
                tabReservations[i, 1] = Convert.ToDateTime(reservationsLigne["dateReservation"]).ToString("MMMM");
                tabReservations[i, 2] = Convert.ToDateTime(reservationsLigne["dateReservation"]).ToString("yyy");
                tabReservations[i, 3] = reservationsLigne["plageReservation"].ToString();
                tabReservations[i, 4] = reservationsLigne["idSalle"].ToString();
                tabReservations[i, 5] = reservationsLigne.GetParentRow(sallesReservations)["nomSalle"].ToString();
                tabReservations[i, 6] = reservationsLigne.GetParentRow(sallesReservations)["prixLocationSalle"].ToString();
                tabReservations[i, 7] = reservationsLigne.GetParentRow(sallesReservations).GetParentRow(sallesTypes)["libelleType"].ToString();
                i++;
            }

            return tabReservations;

        }
        public static String[,] creerTabSalles()
        {
            int  nbLignesSalles, nbColonnesSalles = 6, i;
            String[,] tabSalles;

          
            nbLignesSalles = tableSalles.Rows.Count;
            tabSalles = new String[nbLignesSalles, nbColonnesSalles];


            i = 0;
            foreach (DataRow sallesLigne in tableSalles.Rows)
            {
                tabSalles[i, 0] = sallesLigne["idSalle"].ToString();
                tabSalles[i, 1] = sallesLigne["nomSalle"].ToString(); 
                tabSalles[i, 2] = sallesLigne.GetParentRow(sallesTypes)["libelleType"].ToString();
                tabSalles[i, 3] = sallesLigne["surfaceSalle"].ToString();
                tabSalles[i, 4] = sallesLigne["capaciteSalle"].ToString();
                tabSalles[i, 5] = sallesLigne["prixLocationSalle"].ToString();
                
               
                i++;
            }

            return tabSalles;

        }
        public static String[,] creerTabTypes()
        {
            int nbLignesTypes, nbColonnesTypes = 2, i;
            String[,] tabTypes;


            nbLignesTypes = tableTypesSalles.Rows.Count;
            tabTypes = new String[nbLignesTypes, nbColonnesTypes];


            i = 0;
            foreach (DataRow typesLigne in tableTypesSalles.Rows)
            {
                tabTypes[i, 0] = typesLigne["idType"].ToString();
                tabTypes[i, 1] = typesLigne["libelleType"].ToString();
                i++;
            }

            return tabTypes;

        }

    }
}
