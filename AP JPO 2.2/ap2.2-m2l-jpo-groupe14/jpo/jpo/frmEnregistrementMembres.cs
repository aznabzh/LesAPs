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
using System.Text.RegularExpressions;

namespace jpo
{
    public partial class frmEnregistrementMembres : Form
    {
        #region Initialisation
        string databasePath = @"..\..\..\..\jpo.accdb";
        string connectionString;

        public frmEnregistrementMembres()
        {
            InitializeComponent();
            connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Persist Security Info=False;";
        }

        private void frmEnregistrementMembres_Load(object sender, EventArgs e)
        {
            tbxNom.Enabled = false;
            tbxNom.MaxLength = 30;
            tbxPrenom.Enabled = false;
            tbxPrenom.MaxLength = 30;
            tbxTelephone.Enabled = false;
            tbxMail.Enabled = false;
            btnSupprimer.Visible = false;
            btnModifier.Visible = false;
            btnEnregistrer.Visible = false;
            btnAnnuler.Visible = false;

            AutoValidate = AutoValidate.Disable;

            // Remplissage de la ComboBox des ligues
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT DISTINCT nomLigue FROM LIGUES"; // Récupère les disciplines
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        cbxLigue.Items.Clear(); // Vider la ComboBox avant d'ajouter les nouvelles valeurs
                        while (reader.Read())
                        {
                            cbxLigue.Items.Add(reader["nomLigue"].ToString()); // Ajouter chaque ligue dans la ComboBox
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region ComboBox
        private void cbxLigue_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Requête SQL pour récupérer le nom et prénom des membres associés à la ligue sélectionnée
                    string query = @"SELECT nom, prénom
                                     FROM MEMBRE, LIGUES
                                     WHERE LIGUES.nomLigue = @nomLigue
                                     AND MEMBRE.codeLigue = LIGUES.codeLigue";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        string nomLigue = cbxLigue.Text;
                        command.Parameters.AddWithValue("@nomLigue", nomLigue); // Paramètre pour la ligue sélectionnée

                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            lbxListeMembre.Items.Clear(); // Vider la ListBox avant d'ajouter les nouveaux éléments
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    // Récupérer le nom et prénom de chaque membre
                                    string nomPrenom = $"{reader["nom"]} {reader["prénom"]}";
                                    lbxListeMembre.Items.Add(nomPrenom); // Ajouter à la ListBox
                                }
                            }
                            else
                            {
                                lbxListeMembre.Items.Add("Aucun membre trouvé pour cette ligue.");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region ListeBox
        private void lbxListeMembre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxListeMembre.SelectedIndex != -1)  // Vérifie que quelque chose est sélectionné
            {
                string nomPrenomSelectionne = lbxListeMembre.SelectedItem.ToString();
                string[] nomPrenom = nomPrenomSelectionne.Split(' '); // Sépare le nom et prénom sélectionnés

                string nom = nomPrenom[0]; // Premier élément : nom
                string prenom = nomPrenom[1]; // Deuxième élément : prénom

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    try
                    {
                        connection.Open();
                        // Requête SQL pour récupérer les détails du membre par son nom et prénom
                        string query = @"SELECT nom, prénom, téléphone, mail
                                         FROM MEMBRE
                                         WHERE nom = @nom AND prénom = @prenom";

                        using (OleDbCommand command = new OleDbCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@nom", nom);
                            command.Parameters.AddWithValue("@prenom", prenom);

                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())  // Si un membre correspondant est trouvé
                                {
                                    // Remplir les TextBox avec les informations du membre
                                    tbxNom.Text = reader["nom"].ToString();
                                    tbxPrenom.Text = reader["prénom"].ToString();
                                    tbxTelephone.Text = reader["téléphone"].ToString();  // Afficher le téléphone
                                    tbxMail.Text = reader["mail"].ToString();    // Afficher le mail
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            if (tbxNom.Text != "")
            {
                btnSupprimer.Visible = true;
                btnModifier.Visible = true;
            }
        }
        #endregion

        #region Boutons

        #region Ajouter
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            tbxNom.Text = "";
            tbxPrenom.Text = "";
            tbxTelephone.Text = "";
            tbxMail.Text = "";
            lbxListeMembre.Enabled = false;
            tbxNom.Enabled = true;
            tbxPrenom.Enabled = true;
            tbxTelephone.Enabled = true;
            tbxMail.Enabled = true;
            btnAjouter.Visible = false;
            btnEnregistrer.Visible = true;
            btnAnnuler.Visible = true;
            btnModifier.Visible = false;
            btnSupprimer.Visible = false;
        }
        #endregion

        #region Annuler
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            tbxNom.Text = "";
            tbxPrenom.Text = "";
            tbxTelephone.Text = "";
            tbxMail.Text = "";
            tbxNom.Enabled = false;
            tbxPrenom.Enabled = false;
            tbxTelephone.Enabled = false;
            tbxMail.Enabled = false;
            lbxListeMembre.Enabled = true;
            btnAjouter.Visible = true;
            btnEnregistrer.Visible = false;
            btnAnnuler.Visible = false;
        }
        #endregion

        #region Modifier
        private void btnModifier_Click(object sender, EventArgs e)
        {
            lbxListeMembre.Enabled = false;
            tbxNom.Enabled = true;
            tbxPrenom.Enabled = true;
            tbxTelephone.Enabled = true;
            tbxMail.Enabled = true;
            cbxLigue.Enabled = false;
            btnAjouter.Visible = false;
            btnEnregistrer.Visible = true;
            btnAnnuler.Visible = true;
            btnModifier.Visible = false;
            btnSupprimer.Visible = false;
        }
        #endregion

        #region Enregistrer

        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            // Vérifie si tous les champs obligatoires sont remplis (le mail peut être vide)
            if (string.IsNullOrEmpty(tbxNom.Text) || string.IsNullOrEmpty(tbxPrenom.Text) ||
                string.IsNullOrEmpty(tbxTelephone.Text) || cbxLigue.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires avant d'enregistrer le membre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Récupérer les valeurs des TextBox
            string nom = tbxNom.Text;
            string prenom = tbxPrenom.Text;
            string telephone = tbxTelephone.Text;
            string email = string.IsNullOrWhiteSpace(tbxMail.Text) ? null : tbxMail.Text;
            string nomLigue = cbxLigue.SelectedItem.ToString();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    btnAjouter.Visible = true;
                    btnEnregistrer.Visible = false;
                    btnAnnuler.Visible = false;

                    connection.Open();

                    // Récupérer le codeLigue correspondant au nom de la ligue sélectionnée
                    string getCodeLigueQuery = "SELECT codeLigue FROM LIGUES WHERE nomLigue = @nomLigue";
                    using (OleDbCommand getCodeLigueCommand = new OleDbCommand(getCodeLigueQuery, connection))
                    {
                        getCodeLigueCommand.Parameters.AddWithValue("@nomLigue", nomLigue);
                        object codeLigueResult = getCodeLigueCommand.ExecuteScalar();

                        if (codeLigueResult == null)
                        {
                            MessageBox.Show("Erreur : La ligue sélectionnée n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string codeLigue = codeLigueResult.ToString();

                        // Vérifier si le membre existe déjà avec le même nom et prénom
                        string getCodeMembreQuery = "SELECT codeMembre FROM MEMBRE WHERE nom = @nom AND prénom = @prenom";
                        using (OleDbCommand getCodeMembreCommand = new OleDbCommand(getCodeMembreQuery, connection))
                        {
                            getCodeMembreCommand.Parameters.AddWithValue("@nom", nom);
                            getCodeMembreCommand.Parameters.AddWithValue("@prenom", prenom);

                            object existingCodeMembre = getCodeMembreCommand.ExecuteScalar();

                            if (existingCodeMembre != null) // Mettre à jour le membre existant
                            {
                                string updateQuery = @"UPDATE MEMBRE 
                                               SET téléphone = @telephone, mail = @mail, codeLigue = @codeLigue 
                                               WHERE codeMembre = @codeMembre";
                                using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, connection))
                                {
                                    updateCommand.Parameters.AddWithValue("@telephone", telephone);
                                    updateCommand.Parameters.AddWithValue("@mail", (object)email ?? DBNull.Value);
                                    updateCommand.Parameters.AddWithValue("@codeLigue", codeLigue);
                                    updateCommand.Parameters.AddWithValue("@codeMembre", existingCodeMembre.ToString());

                                    int rowsUpdated = updateCommand.ExecuteNonQuery();

                                    if (rowsUpdated > 0)
                                    {
                                        MessageBox.Show("Les informations du membre ont été mises à jour avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Erreur lors de la mise à jour du membre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else // Créer un nouveau membre
                            {
                                // Trouver le prochain codeMembre
                                string maxCodeQuery = "SELECT MAX(CInt(codeMembre)) FROM MEMBRE";
                                using (OleDbCommand maxCommand = new OleDbCommand(maxCodeQuery, connection))
                                {
                                    object result = maxCommand.ExecuteScalar();
                                    int newCodeMembre = (result != DBNull.Value && int.TryParse(result.ToString(), out int maxCode)) ? maxCode + 1 : 1;
                                    string newCodeMembreString = newCodeMembre.ToString();

                                    // Insérer le nouveau membre
                                    string insertQuery = @"INSERT INTO MEMBRE (codeMembre, nom, prénom, téléphone, mail, codeLigue)
                                                   VALUES (@codeMembre, @nom, @prenom, @telephone, @mail, @codeLigue)";

                                    using (OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection))
                                    {
                                        insertCommand.Parameters.AddWithValue("@codeMembre", newCodeMembreString);
                                        insertCommand.Parameters.AddWithValue("@nom", nom);
                                        insertCommand.Parameters.AddWithValue("@prenom", prenom);
                                        insertCommand.Parameters.AddWithValue("@telephone", telephone);
                                        insertCommand.Parameters.AddWithValue("@mail", (object)email ?? DBNull.Value);
                                        insertCommand.Parameters.AddWithValue("@codeLigue", codeLigue);

                                        int rowsInserted = insertCommand.ExecuteNonQuery();

                                        if (rowsInserted > 0)
                                        {
                                            MessageBox.Show("Le membre a été ajouté avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                        else
                                        {
                                            MessageBox.Show("Erreur lors de l'ajout du membre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                            tbxNom.Text = "";
                            tbxPrenom.Text = "";
                            tbxTelephone.Text = "";
                            tbxMail.Text = "";
                            lbxListeMembre.Enabled = true;
                            tbxNom.Enabled = false;
                            tbxPrenom.Enabled = false;
                            tbxTelephone.Enabled = false;
                            tbxMail.Enabled = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Supprimer
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            // Vérifie si un membre est sélectionné dans la listeBox
            if (lbxListeMembre.SelectedIndex == -1)
            {
                MessageBox.Show("Veuillez sélectionner un membre à supprimer.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Demande confirmation avant suppression
            DialogResult confirm = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce membre ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes)
            {
                return;
            }

            // Récupérer le nom et prénom du membre sélectionné
            string selectedMembre = lbxListeMembre.SelectedItem.ToString(); // Format : "Nom Prénom"
            string[] split = selectedMembre.Split(' ');
            if (split.Length < 2)
            {
                MessageBox.Show("Erreur de récupération du membre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nom = split[0];
            string prenom = split[1];

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Requête pour récupérer le codeMembre correspondant
                    string getCodeQuery = "SELECT codeMembre FROM MEMBRE WHERE nom = @nom AND prénom = @prenom";
                    using (OleDbCommand getCodeCommand = new OleDbCommand(getCodeQuery, connection))
                    {
                        getCodeCommand.Parameters.AddWithValue("@nom", nom);
                        getCodeCommand.Parameters.AddWithValue("@prenom", prenom);
                        object result = getCodeCommand.ExecuteScalar();

                        if (result == null)
                        {
                            MessageBox.Show("Membre introuvable dans la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string codeMembre = result.ToString();

                        // Requête pour supprimer le membre
                        string deleteQuery = "DELETE FROM MEMBRE WHERE codeMembre = @codeMembre";
                        using (OleDbCommand deleteCommand = new OleDbCommand(deleteQuery, connection))
                        {
                            deleteCommand.Parameters.AddWithValue("@codeMembre", codeMembre);
                            int rowsAffected = deleteCommand.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Membre supprimé avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Supprimer le membre de la listeBox
                                lbxListeMembre.Items.RemoveAt(lbxListeMembre.SelectedIndex);

                                // Effacer les textBox
                                tbxNom.Clear();
                                tbxPrenom.Clear();
                                tbxTelephone.Clear();
                                tbxMail.Clear();
                            }
                            else
                            {
                                MessageBox.Show("Erreur lors de la suppression du membre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #endregion

        #region KeyPress
        private void tbxNom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '-' && e.KeyChar != '\'' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void tbxPrenom_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '-' && e.KeyChar != '\'' && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void tbxTelephone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        private void tbxMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back && e.KeyChar != '@' && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Regex

        private void tbxNom_Leave(object sender, EventArgs e)
        {
            string nom = tbxNom.Text;
            Regex rxNom = new Regex(@"^(\p{L}+(([-]{1,2}|[' ])\p{L}+)*)$");
            if (!rxNom.IsMatch(nom) && nom != "")
            {
                tbxNom.Text = null;
                tbxNom.Focus();
                MessageBox.Show("Le nom saisi n'est pas valide");
            }
        }

        private void tbxPrenom_Leave(object sender, EventArgs e)
        {
            string prenom = tbxPrenom.Text;
            Regex rxPrenom = new Regex(@"^(\p{L}+(([-]{1,2}|[' ])\p{L}+)*)$");
            if (!rxPrenom.IsMatch(prenom) && prenom != "")
            {
                tbxPrenom.Text = null;
                tbxPrenom.Focus();
                MessageBox.Show("Le prénom saisi n'est pas valide");
            }
        }

        private void tbxTelephone_Leave(object sender, EventArgs e)
        {
            string telephone = tbxTelephone.Text;
            Regex rxTelephone = new Regex(@"^0\d(\.\d{2}){4}$");
            if (!rxTelephone.IsMatch(telephone) && telephone != "")
            {
                tbxTelephone.Text = null;
                tbxTelephone.Focus();
                MessageBox.Show("Le numéro de téléphone saisi n'est pas valide");
            }
        }

        private void tbxMail_Leave(object sender, EventArgs e)
        {
            string mail = tbxMail.Text;
            Regex rxMail = new Regex(@"^((\p{L}|\d|[.-])+@\p{L}{3,8}\.\p{L}{2,3})$");
            if (!rxMail.IsMatch(mail) && mail != "")
            {
                tbxMail.Text = null;
                tbxMail.Focus();
                MessageBox.Show("L'adresse mail saisi n'est pas valide");
            }
        }
        #endregion
    }
}