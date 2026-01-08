using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jpo
{
    public partial class frmInscriptionLigues : Form
    {
        String connectionString;

        public frmInscriptionLigues()
        {
            InitializeComponent();
            connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={System.IO.Path.GetFullPath(@"..\..\..\..\jpo.accdb")}";
        }



        private void frmInscriptionLigues_Load(object sender, EventArgs e)
        {
            ChargerLiguesInscrites();
            ChargerLiguesNonInscrites();
            ChargerEquipements();

            btnModifier.Enabled = false;
            btnModifier.Visible = false;
            btnSupprimer.Enabled = false;
            btnSupprimer.Visible = false;
            btnEnregistrer.Enabled = false;
            btnEnregistrer.Visible = false;
            btnAnnuler.Enabled = false;
            btnAnnuler.Visible = false;
            btnAjouter.Enabled = false;
            btnAjouter.Visible = false;

            tbxLongueurStand.Enabled = false;
            tbxLargeurStand.Enabled = false;
            clbxEquipementSouhaite.Enabled = false;

            tbxLongueurStand.Text = "";
            tbxLargeurStand.Text = "";
        }

        #region chargement bdd
        private void ChargerLiguesInscrites()
        {
            lbxLiguesInscrites.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = @"SELECT LIGUES.CodeLigue, LIGUES.NomLigue 
                         FROM LIGUES 
                         WHERE CodeLigue IN (SELECT CodeLigue FROM INSCRIPTION)";

                OleDbCommand command = new OleDbCommand(query, connection);

                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string nomLigue = reader["NomLigue"].ToString();
                        lbxLiguesInscrites.Items.Add(nomLigue);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des ligues inscrites : " + ex.Message);
                }
            }
        }


        private void ChargerLiguesNonInscrites()
        {
            lbxLiguesNonInscrites.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = @"SELECT LIGUES.CodeLigue, LIGUES.NomLigue 
                         FROM LIGUES 
                         WHERE CodeLigue NOT IN (SELECT CodeLigue FROM INSCRIPTION)";

                OleDbCommand command = new OleDbCommand(query, connection);

                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        string nomLigue = reader["NomLigue"].ToString();
                        lbxLiguesNonInscrites.Items.Add(nomLigue);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des ligues non inscrites : " + ex.Message);
                }
            }
        }

        #endregion

        private void ChargerEquipements()
        {
            clbxEquipementSouhaite.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT Libellé FROM EQUIPEMENT";

                OleDbCommand command = new OleDbCommand(query, connection);

                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        clbxEquipementSouhaite.Items.Add(reader["Libellé"].ToString());
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des équipements : " + ex.Message);
                }
            }
        }













        #region Boutons
        private void btnAjouter_Click(object sender, EventArgs e)
        {

            lbxLiguesInscrites.Enabled = false;
            lbxLiguesNonInscrites.Enabled = false;

            btnEnregistrer.Enabled = true;
            btnEnregistrer.Visible = true;
            btnAnnuler.Enabled = true;
            btnAnnuler.Visible = true;
            btnAjouter.Enabled = false;
            btnAjouter.Visible = false;
            clbxEquipementSouhaite.Enabled = true;
            tbxLongueurStand.Enabled = true;
            tbxLargeurStand.Enabled = true;

            tbxLongueurStand.Enabled = true;
            tbxLargeurStand.Enabled = true;
            clbxEquipementSouhaite.Enabled = true;
        }


        private void btnModifier_Click(object sender, EventArgs e)
        {

            lbxLiguesInscrites.Enabled = false;
            lbxLiguesNonInscrites.Enabled = false;

            btnEnregistrer.Enabled = true;
            btnEnregistrer.Visible = true;
            btnAnnuler.Enabled = true;
            btnAnnuler.Visible = true;

            btnModifier.Enabled = false;
            btnModifier.Visible = false;
            btnSupprimer.Enabled = false;
            btnSupprimer.Visible = false;

            tbxLongueurStand.Enabled = true;
            tbxLargeurStand.Enabled = true;
            clbxEquipementSouhaite.Enabled = true;


        }




        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            string ligueInscrite = lbxLiguesInscrites.SelectedItem?.ToString();

            if (ligueInscrite != null)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = @"DELETE FROM INSCRIPTION 
                             WHERE CodeLigue = (SELECT CodeLigue FROM LIGUES WHERE NomLigue = @NomLigue)";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@NomLigue", ligueInscrite);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur lors de la suppression de l'inscription : " + ex.Message);
                        return;
                    }
                }

                lbxLiguesInscrites.Items.Remove(ligueInscrite);
                lbxLiguesNonInscrites.Items.Add(ligueInscrite);

                reinitialiserInterface();

                MessageBox.Show("Ligue supprimée et déplacée vers les ligues non inscrites.");
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligue inscrite à supprimer.");
            }
        }



        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            lbxLiguesInscrites.Enabled = lbxLiguesNonInscrites.Enabled = false;

            string nomLigue = null;
            bool isModification = false;

            if (lbxLiguesInscrites.SelectedItem != null)
            {
                nomLigue = lbxLiguesInscrites.SelectedItem.ToString();
                isModification = true;
            }
            else if (lbxLiguesNonInscrites.SelectedItem != null)
            {
                nomLigue = lbxLiguesNonInscrites.SelectedItem.ToString();
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligue.");
                return;
            }

            if (!int.TryParse(tbxLargeurStand.Text, out int largeur) || !int.TryParse(tbxLongueurStand.Text, out int longueur))
            {
                MessageBox.Show("Dimensions invalides.");
                return;
            }

            var equipements = new List<string>();
            foreach (object item in clbxEquipementSouhaite.CheckedItems)
                equipements.Add(item.ToString());

            if (equipements.Count == 0)
            {
                MessageBox.Show("Sélectionnez au moins un équipement.");
                return;
            }

            string equipementsStr = string.Join(", ", equipements);

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "";

                if (isModification)
                {
                    query = @"
                UPDATE INSCRIPTION
                SET Longueur = @Longueur, Largeur = @Largeur, equipements = @equipements
                WHERE CodeLigue = (SELECT CodeLigue FROM LIGUES WHERE NomLigue = @NomLigue)";
                }
                else
                {
                    query = @"
                INSERT INTO INSCRIPTION (Longueur, Largeur, CodeLigue, equipements) 
                SELECT @Longueur, @Largeur, CodeLigue, @equipements
                FROM LIGUES WHERE NomLigue = @NomLigue";

                }

                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@Largeur", largeur);
                command.Parameters.AddWithValue("@Longueur", longueur);
                command.Parameters.AddWithValue("@equipements", equipementsStr);
                command.Parameters.AddWithValue("@NomLigue", nomLigue);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    if (!isModification)
                    {
                        lbxLiguesInscrites.Items.Add(nomLigue);
                        lbxLiguesNonInscrites.Items.Remove(nomLigue);
                    }

                    reinitialiserInterface();


                    MessageBox.Show(isModification ? "Ligue modifiée avec succès !" : "Ligue enregistrée avec succès !");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }

        private void reinitialiserInterface()
        {
            tbxLargeurStand.Clear();
            tbxLongueurStand.Clear();

            lbxLiguesInscrites.Enabled = true;
            lbxLiguesNonInscrites.Enabled = true;
            lbxLiguesInscrites.ClearSelected();
            lbxLiguesNonInscrites.ClearSelected();
            clbxEquipementSouhaite.ClearSelected();

            btnAjouter.Enabled = false;
            btnAjouter.Visible = false;
            btnModifier.Enabled = false;
            btnModifier.Visible = false;
            btnSupprimer.Enabled = false;
            btnSupprimer.Visible = false;
            btnEnregistrer.Enabled = false;
            btnEnregistrer.Visible = false;
            btnAnnuler.Enabled = false;
            btnAnnuler.Visible = false;

            clbxEquipementSouhaite.Enabled = false;
            tbxLongueurStand.Enabled = false;
            tbxLargeurStand.Enabled = false;

            for (int i = 0; i < clbxEquipementSouhaite.Items.Count; i++)
            {
                clbxEquipementSouhaite.SetItemChecked(i, false);
            }
        }


















        private void btnAnnuler_Click(object sender, EventArgs e)
        {

            btnModifier.Enabled = false;
            btnModifier.Visible = false;
            btnSupprimer.Enabled = false;
            btnSupprimer.Visible = false;
            btnEnregistrer.Enabled = false;
            btnEnregistrer.Visible = false;
            btnAnnuler.Enabled = false;
            btnAnnuler.Visible = false;



            clbxEquipementSouhaite.Enabled = false;
            tbxLongueurStand.Enabled = false;
            tbxLargeurStand.Enabled = false;

            tbxLongueurStand.Text = "";
            tbxLargeurStand.Text = "";

            // Décocher tous les équipements
            for (int i = 0; i < clbxEquipementSouhaite.Items.Count; i++)
            {
                clbxEquipementSouhaite.SetItemChecked(i, false);
            }

            // Désélectionner tout
            lbxLiguesInscrites.ClearSelected();
            lbxLiguesNonInscrites.ClearSelected();
            clbxEquipementSouhaite.ClearSelected();

            // Réactiver les ListBox
            lbxLiguesInscrites.Enabled = true;
            lbxLiguesNonInscrites.Enabled = true;

            btnAjouter.Enabled = false;
            btnAjouter.Visible = false;

        }





        #endregion

        #region Textbox
        private void tbxRechercheLiguesNonInscrites_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = tbxRechercheLiguesNonInscrites.Text.ToLower();


            lbxLiguesNonInscrites.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();


                    string query = "SELECT nomLigue FROM LIGUES WHERE CodeLigue NOT IN (SELECT CodeLigue FROM INSCRIPTION) AND nomLigue LIKE ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Paramètre pour la recherche (ajoute des caractères génériques)
                        command.Parameters.AddWithValue("?", "%" + searchQuery + "%");

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lbxLiguesNonInscrites.Items.Add(reader["nomLigue"].ToString());
                            }
                        }
                    }


                    if (lbxLiguesNonInscrites.Items.Count > 0)
                    {
                        lbxLiguesNonInscrites.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la recherche des ligues non inscrites : {ex.Message}");
                }
            }
        }


        private void tbxRechercheLiguesInscrites_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = tbxRechercheLiguesInscrites.Text.ToLower();


            lbxLiguesInscrites.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();


                    string query = "SELECT nomLigue FROM LIGUES WHERE CodeLigue IN (SELECT CodeLigue FROM INSCRIPTION) AND nomLigue LIKE ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("?", "%" + searchQuery + "%");

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lbxLiguesInscrites.Items.Add(reader["nomLigue"].ToString());
                            }
                        }
                    }

                    if (lbxLiguesInscrites.Items.Count > 0)
                    {
                        lbxLiguesInscrites.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la recherche des ligues inscrites : {ex.Message}");
                }
            }
        }





        private void tbxLongueurStand_TextChanged(object sender, EventArgs e)
        {

        }
        private void tbxLargeurStand_TextChanged(object sender, EventArgs e)
        {

        }
        #endregion

        #region Listbox
        private void lbxLiguesInscrites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxLiguesInscrites.SelectedItem != null)
            {
                lbxLiguesNonInscrites.ClearSelected();

                btnAjouter.Enabled = false;
                btnAjouter.Visible = false;

                btnModifier.Enabled = true;
                btnModifier.Visible = true;
                btnSupprimer.Enabled = true;
                btnSupprimer.Visible = true;

                string nomLigue = lbxLiguesInscrites.SelectedItem.ToString();

                ChargerDetailsLigueInscrite(nomLigue);
            }
            else
            {
                btnModifier.Enabled = false;
                btnModifier.Visible = false;
                btnSupprimer.Enabled = false;
                btnSupprimer.Visible = false;

                btnAjouter.Enabled = false;
                btnAjouter.Visible = false;
            }
        }

        private void ChargerDetailsLigueInscrite(string nomLigue)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = @"
                    SELECT Longueur, Largeur, Equipements 
                    FROM INSCRIPTION 
                    WHERE CodeLigue = (SELECT CodeLigue FROM LIGUES WHERE NomLigue = @NomLigue)";


                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@NomLigue", nomLigue);

                try
                {
                    connection.Open();
                    OleDbDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        tbxLargeurStand.Text = reader["Largeur"].ToString();
                        tbxLongueurStand.Text = reader["Longueur"].ToString();

                        string equipementsStr = reader["Equipements"].ToString();
                        string[] equipementsArray = equipementsStr.Split(new string[] { ", " }, StringSplitOptions.None);

                        for (int i = 0; i < clbxEquipementSouhaite.Items.Count; i++)
                        {
                            clbxEquipementSouhaite.SetItemChecked(i, false);
                        }

                        foreach (string equipement in equipementsArray)
                        {
                            int index = clbxEquipementSouhaite.Items.IndexOf(equipement);
                            if (index != -1)
                            {
                                clbxEquipementSouhaite.SetItemChecked(index, true);
                            }
                        }
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des détails de la ligue : " + ex.Message);
                }
            }
        }



        private void lbxLiguesNonInscrites_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxLiguesNonInscrites.SelectedItem != null)
            {
                lbxLiguesInscrites.ClearSelected();

                // Réinitialiser les champs lorsque l'utilisateur sélectionne une ligue non inscrite
                tbxLargeurStand.Clear();
                tbxLongueurStand.Clear();
                for (int i = 0; i < clbxEquipementSouhaite.Items.Count; i++)
                {
                    clbxEquipementSouhaite.SetItemChecked(i, false);
                }

                // Mettre à jour les boutons
                btnModifier.Enabled = false;
                btnModifier.Visible = false;
                btnSupprimer.Enabled = false;
                btnSupprimer.Visible = false;

                btnAjouter.Enabled = true;
                btnAjouter.Visible = true;
            }
            else
            {
                if (lbxLiguesInscrites.SelectedItem != null)
                {
                    btnModifier.Enabled = true;
                    btnModifier.Visible = true;
                    btnSupprimer.Enabled = true;
                    btnSupprimer.Visible = true;
                }

                btnAjouter.Enabled = false;
                btnAjouter.Visible = false;
            }
        }




        #endregion

        #region Initialisation
        #endregion

        #region Combobox
        #endregion

        #region CheckList
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        #endregion

        private void tbxLargeurStand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            tbxLargeurStand.MaxLength = 12;
        }

        private void tbxLongueurStand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
            tbxLongueurStand.MaxLength = 12;
        }
    }
}