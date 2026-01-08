using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.Common;
using System.Collections.ObjectModel;
using System.IO;
using System.Collections;

namespace jpo
{
    public partial class frmEnregistrementLigues : Form
    {

        Boolean enregModifierLigue;
        String connectionString;

        public frmEnregistrementLigues()
        {
            InitializeComponent();
            connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={Path.GetFullPath(@"..\..\..\..\jpo.accdb")}";
        }

        #region remplissage BDD -> application

        private void ChargerLigues()
        {
            lbxLigues.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT nomLigue FROM LIGUES";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lbxLigues.Items.Add(reader["nomLigue"].ToString());
                            }
                        }
                    }

                    if (lbxLigues.Items.Count > 0)
                    {
                        lbxLigues.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors du chargement des ligues : {ex.Message}");
                }
            }
        }


        #endregion



        private void frmEnregistrementLigues_Load(object sender, EventArgs e)
        {
            ChargerLigues();

            tbxNomLigue.Enabled = false;
            tbxAdresseLigue.Enabled = false;

            btnEnregistrerLigue.Visible = false;
            btnAnnulerLigue.Visible = false;

            tbxDisciplines.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        #region textbox

        private void tbxAdresseLigue_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxNomLigue_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string searchQuery = tbxRechercheLigues.Text.ToLower();

            lbxLigues.Items.Clear();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT nomLigue FROM LIGUES WHERE nomLigue LIKE ?";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", "%" + searchQuery + "%");

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                lbxLigues.Items.Add(reader["nomLigue"].ToString());
                            }
                        }
                    }

                    if (lbxLigues.Items.Count > 0)
                    {
                        lbxLigues.SelectedIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la recherche des ligues : {ex.Message}");
                }
            }
        }


        #endregion


        #region listbox

        // 1. Charger la discipline dans tbxDisciplineTemp lors de la sélection d'une ligue
        private void lbxLigues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxLigues.SelectedIndex != -1)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        string selectedLigue = lbxLigues.SelectedItem.ToString();
                        string query = "SELECT * FROM LIGUES WHERE nomLigue = ?";

                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("?", selectedLigue);
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    tbxNomLigue.Text = reader["nomLigue"].ToString();
                                    tbxAdresseLigue.Text = reader["adresse"].ToString();

                                    string discipline = reader["discipline"].ToString();
                                    tbxDisciplines.Text = discipline; // Mise à jour de la discipline
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la récupération des détails de la ligue : {ex.Message}");
                    }
                }
            }
        }


        

        #endregion


        #region boutons

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (tbxNomLigue.Text != "")
            {
                enregModifierLigue = true;
                tbxNomLigue.Enabled = true;
                tbxAdresseLigue.Enabled = true;
                tbxDisciplines.Enabled = true; // Réactiver tbxDisciplines pour modification

                // Changer la visibilité des boutons
                btnAjouterLigue.Visible = false;
                btnSupprimerLigue.Visible = false;
                btnModifierLigue.Enabled = false;

                btnEnregistrerLigue.Visible = true;
                btnAnnulerLigue.Visible = true;

                // Désactiver la ListBox et le champ de recherche pendant l'édition
                lbxLigues.Enabled = false;
                tbxRechercheLigues.Enabled = false;
            }
        }





        private void btnAjouterLigue_Click(object sender, EventArgs e)
        {
            // Réinitialise les champs pour l'ajout d'une nouvelle ligue
            tbxNomLigue.Text = "";
            tbxAdresseLigue.Text = "";
            tbxDisciplines.Text = "";  // Réinitialiser tbxDisciplines

            // Ajoute un élément vide en bas de la ListBox
            lbxLigues.Items.Add("");  // Ajoute une ligne vide

            // Sélectionne cette ligne vide pour commencer à saisir une nouvelle ligue
            lbxLigues.SelectedIndex = lbxLigues.Items.Count - 1;

            // Active les champs de saisie
            tbxNomLigue.Enabled = true;
            tbxAdresseLigue.Enabled = true;
            tbxDisciplines.Enabled = true;  // Activer tbxDisciplines pour l'ajout

            // Change la visibilité des boutons
            btnAjouterLigue.Visible = false;
            btnSupprimerLigue.Visible = false;
            btnModifierLigue.Enabled = false;

            btnEnregistrerLigue.Visible = true;
            btnAnnulerLigue.Visible = true;

            // Désactive la ListBox et le champ de recherche pendant l'édition
            lbxLigues.Enabled = false;
            tbxRechercheLigues.Enabled = false;

            // Réinitialiser le flag de modification pour l'ajout
            enregModifierLigue = false;  // Important de réinitialiser ce flag à chaque ajout
        }








        private void btnSupprimerLigue_Click(object sender, EventArgs e)
        {
            if (lbxLigues.SelectedIndex != -1)
            {
                string ligueASupprimer = lbxLigues.SelectedItem.ToString();

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        string query = "DELETE FROM LIGUES WHERE nomLigue = ?";
                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("?", ligueASupprimer);
                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Ligue supprimée avec succès !");
                                ChargerLigues(); // Recharger les ligues après suppression
                            }
                            else
                            {
                                MessageBox.Show("Erreur lors de la suppression de la ligue.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur : {ex.Message}");
                    }
                }

                // Griser et effacer tbxDisciplines après la suppression
                tbxDisciplines.Enabled = false; // Griser tbxDisciplines
                tbxDisciplines.Text = ""; // Effacer le contenu de tbxDisciplines
            }
            else
            {
                MessageBox.Show("Aucune ligue sélectionnée.");
            }
        }





        private void btnAnnulerLigue_Click(object sender, EventArgs e)
        {
            // Réactiver la ListBox et le champ de recherche
            lbxLigues.Enabled = true;
            tbxRechercheLigues.Enabled = true;

            // Désactiver les champs de saisie
            tbxNomLigue.Enabled = false;
            tbxAdresseLigue.Enabled = false;
            tbxDisciplines.Enabled = false;  // Désactiver tbxDisciplines

            // Réinitialiser les champs (effacer les données)
            tbxNomLigue.Text = "";
            tbxAdresseLigue.Text = "";
            tbxDisciplines.Text = "";  // Effacer la sélection de tbxDisciplines

            // Cacher les boutons d'enregistrement et d'annulation
            btnEnregistrerLigue.Visible = false;
            btnAnnulerLigue.Visible = false;

            // Réactiver les boutons de modification et d'ajout
            btnAjouterLigue.Visible = true;
            btnSupprimerLigue.Visible = true;
            btnModifierLigue.Enabled = true;

            // Réinitialiser le flag de modification pour l'ajout
            enregModifierLigue = false;

            // Recharge la liste pour supprimer l'entrée vide ajoutée
            ChargerLigues();
        }













        private int ObtenirProchainCodeLigue()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT MAX(CInt(codeLigue)) FROM LIGUES";
                OleDbCommand command = new OleDbCommand(query, connection);
                object result = command.ExecuteScalar();

                return result == DBNull.Value ? 1 : Convert.ToInt32(result) + 1;
            }
        }


        private void btnEnregistrerLigue_Click(object sender, EventArgs e)
        {
            try
            {
                string nomLigue = tbxNomLigue.Text.Trim();
                string adresseLigue = tbxAdresseLigue.Text.Trim();
                string disciplineLigue = tbxDisciplines.Text.Trim();

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Vérifier si la discipline existe déjà pour une autre ligue (uniquement lors de l'ajout d'une ligue)
                    if (!enregModifierLigue)
                    {
                        string query = "SELECT COUNT(*) FROM LIGUES WHERE discipline = ?";
                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("?", disciplineLigue);
                            int count = (int)command.ExecuteScalar();

                            if (count > 0)
                            {
                                MessageBox.Show("Cette discipline est déjà utilisée par une autre ligue. Veuillez en choisir une autre.");
                                return; // Ne pas procéder à l'ajout de la ligue
                            }
                        }
                    }

                    if (enregModifierLigue)
                    {
                        string ligueAModifier = lbxLigues.SelectedItem.ToString();
                        string query = @"UPDATE LIGUES SET nomLigue = ?, adresse = ?, discipline = ? WHERE nomLigue = ?";

                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("?", nomLigue);
                            command.Parameters.AddWithValue("?", adresseLigue);
                            command.Parameters.AddWithValue("?", disciplineLigue);
                            command.Parameters.AddWithValue("?", ligueAModifier);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Ligue modifiée avec succès !");
                            }
                            else
                            {
                                MessageBox.Show("Erreur lors de la modification de la ligue.");
                            }
                        }
                    }
                    else
                    {
                        int nouveauCodeLigue = ObtenirProchainCodeLigue();
                        string query = @"INSERT INTO LIGUES (codeLigue, nomLigue, adresse, discipline) VALUES (?, ?, ?, ?)";

                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("?", nouveauCodeLigue);
                            command.Parameters.AddWithValue("?", nomLigue);
                            command.Parameters.AddWithValue("?", adresseLigue);
                            command.Parameters.AddWithValue("?", disciplineLigue);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Ligue ajoutée avec succès !");
                            }
                            else
                            {
                                MessageBox.Show("Erreur lors de l'ajout de la ligue.");
                            }
                        }
                    }
                }

                // Recharger les ligues
                ChargerLigues();

                // Désélectionner l'élément sélectionné dans la ListBox
                lbxLigues.ClearSelected();

                // Retirer le focus de tbxDisciplines et donner le focus à un autre contrôle
                tbxDisciplines.SelectionLength = 0; // Effacer la sélection du texte
                tbxNomLigue.Focus(); // Par exemple, donner le focus à tbxNomLigue

                // Griser la tbxDisciplines
                tbxDisciplines.Enabled = false;

                // Réinitialiser l'interface après l'enregistrement
                ReinitialiserInterface();

                // Réinitialiser le flag de modification
                enregModifierLigue = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }


        






        private void ReinitialiserInterface()
        {
            // Réactiver la ListBox et le champ de recherche
            lbxLigues.Enabled = true;
            tbxRechercheLigues.Enabled = true;

            // Désactiver les champs de saisie
            tbxNomLigue.Enabled = false;
            tbxAdresseLigue.Enabled = false;

            // Réinitialiser les champs (effacer les données)
            tbxNomLigue.Text = "";
            tbxAdresseLigue.Text = "";

            // Cacher les boutons d'enregistrement et d'annulation
            btnEnregistrerLigue.Visible = false;
            btnAnnulerLigue.Visible = false;

            // Réactiver les boutons de modification et d'ajout
            btnAjouterLigue.Visible = true;
            btnSupprimerLigue.Visible = true;
            btnModifierLigue.Enabled = true;

            // Recharger la liste pour afficher les modifications
            ChargerLigues();
        }




        private void tbxNomLigue_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Accepter uniquement les lettres, l'espace, les tirets et la touche Backspace
            if (!Char.IsLetter(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != '-' && e.KeyChar != (char)8)
            {
                e.Handled = true; // Empêche l'entrée du caractère
            }
            tbxNomLigue.MaxLength = 40; // Limite de caractères à 40

        }




        private void tbxAdresseLigue_KeyPress(object sender, KeyPressEventArgs e)
        {
            tbxNomLigue.MaxLength = 40; // Limite de caractères à 40

        }

        private void tbxDisciplines_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}




















#endregion


