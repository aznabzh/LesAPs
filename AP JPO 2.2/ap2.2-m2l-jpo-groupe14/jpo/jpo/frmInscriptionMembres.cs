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

    public partial class frmInscriptionMembres : Form
    {
        #region Initialisation
        string databasePath = @"..\..\..\..\jpo.accdb";
        string connectionString;

        public frmInscriptionMembres()
        {
            InitializeComponent();
            connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={databasePath};Persist Security Info=False;";
        }

        private void frmInscriptionMembres_Load(object sender, EventArgs e)
        {
            btnSupprimerInsc.Visible = false;
            btnModifierInsc.Visible = false;
            btnEnregistrerInsc.Visible = false;
            btnAnnulerInsc.Visible = false;

            AutoValidate = AutoValidate.Disable;

            #region Remplissage
            // Remplissage de la ComboBox des ligues
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT DISTINCT nomLigue
                                     FROM LIGUES"; // Récupère les disciplines
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        cbxLigueInsc.Items.Clear(); // Vider la ComboBox avant d'ajouter les nouvelles valeurs
                        while (reader.Read())
                        {
                            cbxLigueInsc.Items.Add(reader["nomLigue"].ToString()); // Ajouter chaque discipline dans la ComboBox
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Remplissage de la ComboBox des activités
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT LibelleActiv
                                     FROM ACTIVITE";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        cbxActivite.Items.Clear(); // Vider la ComboBox avant d'ajouter les nouvelles valeurs
                        while (reader.Read())
                        {
                            cbxActivite.Items.Add(reader["LibelleActiv"].ToString());
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur lors du chargement des activités : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            #endregion
        }
        #endregion

        #region Boutons

        #region Modifier
        private void btnModifierInsc_Click(object sender, EventArgs e)
        {
            btnEnregistrerInsc.Visible = true;
            btnAnnulerInsc.Visible = true;
            btnModifierInsc.Visible = false;
            btnSupprimerInsc.Visible = false;
        }
        #endregion

        #region Enregistrer
        private void btnEnregistrerInsc_Click(object sender, EventArgs e)
        {
            if (lbxListeMembreNonInsc.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un membre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!chbxMatin.Checked && !chbxApresMidi.Checked)
            {
                MessageBox.Show("Veuillez sélectionner un créneau (Matin ou Après-midi).", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Récupérer le nom et prénom du membre sélectionné
            string[] nomPrenom = lbxListeMembreNonInsc.SelectedItem.ToString().Split(' ');
            if (nomPrenom.Length < 2)
            {
                MessageBox.Show("Erreur lors de la récupération du membre.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string nom = nomPrenom[0];
            string prenom = nomPrenom[1];

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Récupérer le codeMembre
                    string getCodeMembreQuery = "SELECT codeMembre FROM MEMBRE WHERE nom = @nom AND prénom = @prenom";
                    using (OleDbCommand getCodeMembreCmd = new OleDbCommand(getCodeMembreQuery, connection))
                    {
                        getCodeMembreCmd.Parameters.AddWithValue("@nom", nom);
                        getCodeMembreCmd.Parameters.AddWithValue("@prenom", prenom);
                        object codeMembreResult = getCodeMembreCmd.ExecuteScalar();

                        if (codeMembreResult == null)
                        {
                            MessageBox.Show("Le membre sélectionné n'existe pas dans la base de données.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string codeMembre = codeMembreResult.ToString();

                        // Récupérer le codeCréneau depuis la base de données
                        List<string> codesCreneaux = new List<string>();

                        if (chbxMatin.Checked)
                        {
                            string getCreneauMatinQuery = "SELECT codeCréneau FROM CRENEAU WHERE libelléCréneau = 'Matin'";
                            using (OleDbCommand getCreneauMatinCmd = new OleDbCommand(getCreneauMatinQuery, connection))
                            {
                                object creneauMatinResult = getCreneauMatinCmd.ExecuteScalar();
                                if (creneauMatinResult != null)
                                {
                                    codesCreneaux.Add(creneauMatinResult.ToString());
                                }
                            }
                        }

                        if (chbxApresMidi.Checked)
                        {
                            string getCreneauApresMidiQuery = "SELECT codeCréneau FROM CRENEAU WHERE libelléCréneau = 'Après midi'";
                            using (OleDbCommand getCreneauApresMidiCmd = new OleDbCommand(getCreneauApresMidiQuery, connection))
                            {
                                object creneauApresMidiResult = getCreneauApresMidiCmd.ExecuteScalar();
                                if (creneauApresMidiResult != null)
                                {
                                    codesCreneaux.Add(creneauApresMidiResult.ToString());
                                }
                            }
                        }

                        if (codesCreneaux.Count == 0)
                        {
                            MessageBox.Show("Erreur : Aucun créneau valide trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Récupérer le codeActivité (si sélectionné)
                        string codeActivite = null;
                        if (cbxActivite.SelectedIndex != -1)
                        {
                            string activite = cbxActivite.SelectedItem.ToString();
                            string getCodeActiviteQuery = "SELECT codeActiv FROM ACTIVITE WHERE LibelleActiv = @activite";
                            using (OleDbCommand getCodeActiviteCmd = new OleDbCommand(getCodeActiviteQuery, connection))
                            {
                                getCodeActiviteCmd.Parameters.AddWithValue("@activite", activite);
                                object codeActiviteResult = getCodeActiviteCmd.ExecuteScalar();

                                if (codeActiviteResult != null)
                                {
                                    codeActivite = codeActiviteResult.ToString();
                                }
                            }
                        }

                        // Insérer chaque créneau sélectionné dans PARTICIPER
                        foreach (string codeCreneau in codesCreneaux)
                        {
                            string insertQuery = @"INSERT INTO PARTICIPER (codeMembre, codeCréneau, codeActivité) 
                                       VALUES (@codeMembre, @codeCreneau, @codeActivite)";
                            using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, connection))
                            {
                                insertCmd.Parameters.AddWithValue("@codeMembre", codeMembre);
                                insertCmd.Parameters.AddWithValue("@codeCreneau", codeCreneau);

                                // Si codeActivite est null, insérer une valeur NULL dans la base
                                if (codeActivite == null)
                                    insertCmd.Parameters.AddWithValue("@codeActivite", DBNull.Value);
                                else
                                    insertCmd.Parameters.AddWithValue("@codeActivite", codeActivite);

                                int rowsAffected = insertCmd.ExecuteNonQuery();

                                if (rowsAffected == 0)
                                {
                                    MessageBox.Show("Erreur lors de l'enregistrement.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }

                        MessageBox.Show("Inscription enregistrée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Mettre à jour les listes
                        lbxListeMembreNonInsc.Items.Remove(lbxListeMembreNonInsc.SelectedItem);
                        lbxListeMembreInsc.Items.Add(nom + " " + prenom);
                        btnEnregistrerInsc.Visible = false; // Masquer le bouton après l'enregistrement
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            // Réinitialisation des CheckBox et de la ComboBox après l'enregistrement
            chbxMatin.Checked = false;
            chbxApresMidi.Checked = false;
            cbxActivite.SelectedIndex = -1; // Réinitialiser la sélection de la ComboBox
        }
        #endregion

        #region Annuler
        private void btnAnnulerInsc_Click(object sender, EventArgs e)
        {
            btnEnregistrerInsc.Visible = false;
            btnAnnulerInsc.Visible = false;
            btnModifierInsc.Visible = false;
            btnSupprimerInsc.Visible = false;

            chbxMatin.Checked = false;
            chbxApresMidi.Checked = false;

            cbxLigueInsc.SelectedItem = null;
            cbxActivite.SelectedItem = null;

            lbxListeMembreInsc.Items.Clear();
            lbxListeMembreNonInsc.Items.Clear();
        }
        #endregion

        #region Supprimer
        private void btnSupprimerInsc_Click(object sender, EventArgs e)
        {
            // Vérifier si un membre est bien sélectionné dans la liste des inscrits
            if (lbxListeMembreInsc.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner un membre à supprimer.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string membreSelectionne = lbxListeMembreInsc.SelectedItem.ToString();
            string[] nomPrenom = membreSelectionne.Split(' ');

            if (nomPrenom.Length < 2)
            {
                MessageBox.Show("Sélection invalide.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string nom = nomPrenom[0];
            string prenom = nomPrenom[1];

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Récupérer le codeMembre correspondant au nom et prénom sélectionnés
                    string getCodeMembreQuery = @"SELECT codeMembre
                                                  FROM MEMBRE
                                                  WHERE nom = @nom
                                                  AND prénom = @prenom";
                    OleDbCommand getCodeMembreCommand = new OleDbCommand(getCodeMembreQuery, connection);
                    getCodeMembreCommand.Parameters.AddWithValue("@nom", nom);
                    getCodeMembreCommand.Parameters.AddWithValue("@prenom", prenom);
                    object codeMembreResult = getCodeMembreCommand.ExecuteScalar();

                    if (codeMembreResult == null)
                    {
                        MessageBox.Show("Erreur : membre non trouvé.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string codeMembre = codeMembreResult.ToString();

                    // Demander confirmation avant de supprimer
                    DialogResult confirm = MessageBox.Show("Voulez-vous vraiment supprimer cette inscription ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (confirm == DialogResult.No) return;

                    // Supprimer l'inscription du membre dans la table PARTICIPER
                    string deleteQuery = @"DELETE
                                           FROM PARTICIPER
                                           WHERE codeMembre = @codeMembre";
                    OleDbCommand deleteCommand = new OleDbCommand(deleteQuery, connection);
                    deleteCommand.Parameters.AddWithValue("@codeMembre", codeMembre);

                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Inscription supprimée avec succès.", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Rafraîchir les listes après suppression
                        lbxListeMembreInsc.Items.Remove(membreSelectionne);
                        lbxListeMembreNonInsc.Items.Add(membreSelectionne);

                        // Réinitialiser les champs
                        chbxMatin.Checked = false;
                        chbxApresMidi.Checked = false;
                        cbxActivite.SelectedIndex = -1; // Désélectionner l'activité

                        // Cacher les boutons inutiles
                        btnSupprimerInsc.Visible = false;
                        btnModifierInsc.Visible = false;
                        btnAnnulerInsc.Visible = false;
                        btnEnregistrerInsc.Visible = true;
                    }
                    else
                    {
                        MessageBox.Show("Erreur lors de la suppression.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region ComboBox
        private void cbxLigueInsc_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string nomLigue = cbxLigueInsc.Text;

                    // Requête pour récupérer les membres INSCRITS à la ligue sélectionnée
                    string queryInsc = @"SELECT nom, prénom
                                         FROM MEMBRE, LIGUES, PARTICIPER
                                         WHERE MEMBRE.codeLigue = LIGUES.codeLigue
                                         AND MEMBRE.codeMembre = PARTICIPER.codeMembre
                                         AND LIGUES.nomLigue = @nomLigue";

                    // Requête pour récupérer les membres NON INSCRITS à la ligue sélectionnée
                    string queryNonInsc = @"SELECT MEMBRE.nom, MEMBRE.prénom
                                            FROM MEMBRE, LIGUES
                                            WHERE MEMBRE.codeLigue = LIGUES.codeLigue
                                            AND LIGUES.nomLigue = @nomLigue
                                            AND MEMBRE.codeMembre NOT IN (SELECT codeMembre 
                                                                          FROM PARTICIPER)";

                    // Récupération des membres inscrits
                    using (OleDbCommand commandInsc = new OleDbCommand(queryInsc, connection))
                    {
                        commandInsc.Parameters.AddWithValue("@nomLigue", nomLigue);
                        using (OleDbDataReader reader = commandInsc.ExecuteReader())
                        {
                            lbxListeMembreInsc.Items.Clear();
                            while (reader.Read())
                            {
                                string nomPrenom = $"{reader["nom"]} {reader["prénom"]}";
                                lbxListeMembreInsc.Items.Add(nomPrenom);
                            }
                        }
                    }

                    // Récupération des membres non-inscrits
                    using (OleDbCommand commandNonInsc = new OleDbCommand(queryNonInsc, connection))
                    {
                        commandNonInsc.Parameters.AddWithValue("@nomLigue", nomLigue);
                        using (OleDbDataReader reader = commandNonInsc.ExecuteReader())
                        {
                            lbxListeMembreNonInsc.Items.Clear();
                            while (reader.Read())
                            {
                                string nomPrenom = $"{reader["nom"]} {reader["prénom"]}";
                                lbxListeMembreNonInsc.Items.Add(nomPrenom);
                            }
                        }
                    }
                    // Réinitialiser la sélection et masquer le bouton
                    lbxListeMembreNonInsc.ClearSelected();
                    btnEnregistrerInsc.Visible = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region ListBox

        #region Membre non inscrit
        private void lbxListeMembreNonInsc_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Vérifier si un élément est sélectionné
            if (lbxListeMembreNonInsc.SelectedIndex != -1)
            {
                btnEnregistrerInsc.Visible = true;
                btnAnnulerInsc.Visible = true;
                btnModifierInsc.Visible = false;
                btnSupprimerInsc.Visible = false;

                chbxMatin.Checked = false;
                chbxApresMidi.Checked = false;

                cbxActivite.SelectedItem = null;
            }
        }
        #endregion

        #region Membre inscrit
        private void lbxListeMembreInsc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxListeMembreInsc.SelectedItem == null) return;

            string membreSelectionne = lbxListeMembreInsc.SelectedItem.ToString();
            string[] nomPrenom = membreSelectionne.Split(' ');

            if (nomPrenom.Length < 2) return;

            string nom = nomPrenom[0];
            string prenom = nomPrenom[1];

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Récupérer le codeMembre
                    string getCodeMembreQuery = @"SELECT codeMembre
                                                  FROM MEMBRE
                                                  WHERE nom = @nom
                                                  AND prénom = @prenom";
                    OleDbCommand getCodeMembreCommand = new OleDbCommand(getCodeMembreQuery, connection);
                    getCodeMembreCommand.Parameters.AddWithValue("@nom", nom);
                    getCodeMembreCommand.Parameters.AddWithValue("@prenom", prenom);
                    object codeMembreResult = getCodeMembreCommand.ExecuteScalar();

                    if (codeMembreResult == null) return;
                    string codeMembre = codeMembreResult.ToString();

                    // Récupérer le(s) créneau(x) du membre
                    string getCreneauxQuery = @"SELECT libelléCréneau
                                                FROM PARTICIPER, CRENEAU
                                                WHERE CRENEAU.codeCréneau = PARTICIPER.codeCréneau
                                                AND PARTICIPER.codeMembre = @codeMembre";
                    OleDbCommand getCreneauxCommand = new OleDbCommand(getCreneauxQuery, connection);
                    getCreneauxCommand.Parameters.AddWithValue("@codeMembre", codeMembre);

                    chbxMatin.Checked = false;
                    chbxApresMidi.Checked = false;

                    using (OleDbDataReader reader = getCreneauxCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string libelleCreneau = reader["libelléCréneau"].ToString();
                            if (libelleCreneau == "Matin") chbxMatin.Checked = true;
                            if (libelleCreneau == "Après midi") chbxApresMidi.Checked = true;
                        }
                    }

                    // Récupérer l'activité du membre
                    string getActiviteQuery = @"SELECT LibelleActiv
                                                FROM PARTICIPER, ACTIVITE
                                                WHERE PARTICIPER.codeActivité = ACTIVITE.codeActiv
                                                AND PARTICIPER.codeMembre = @codeMembre";
                    OleDbCommand getActiviteCommand = new OleDbCommand(getActiviteQuery, connection);
                    getActiviteCommand.Parameters.AddWithValue("@codeMembre", codeMembre);

                    object activiteResult = getActiviteCommand.ExecuteScalar();
                    cbxActivite.SelectedItem = activiteResult != null ? activiteResult.ToString() : null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            btnSupprimerInsc.Visible = true;
            btnModifierInsc.Visible = true;
            btnAnnulerInsc.Visible = true;
            btnEnregistrerInsc.Visible = false;
        }
        #endregion

        #endregion

        #region checkBox
        private void chbxMatin_CheckedChanged(object sender, EventArgs e)
        {
            MettreAJourListesMembres();
        }

        private void chbxApresMidi_CheckedChanged(object sender, EventArgs e)
        {
            MettreAJourListesMembres();
        }

        private void MettreAJourListesMembres()
        {
            if (lbxListeMembreNonInsc.SelectedItem != null)
            {
                return; // Si un membre est sélectionné, ne rien faire
            }

            string nomLigue = cbxLigueInsc.Text;
            if (string.IsNullOrEmpty(nomLigue))
            {
                MessageBox.Show("Veuillez sélectionner une ligue.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Récupérer le code de la ligue sélectionnée
                    string getCodeLigueQuery = @"SELECT codeLigue
                                                 FROM LIGUES
                                                 WHERE nomLigue = @nomLigue";
                    OleDbCommand getCodeLigueCommand = new OleDbCommand(getCodeLigueQuery, connection);
                    getCodeLigueCommand.Parameters.AddWithValue("@nomLigue", nomLigue);
                    object codeLigueResult = getCodeLigueCommand.ExecuteScalar();

                    if (codeLigueResult == null)
                    {
                        MessageBox.Show("Erreur : Ligue introuvable.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    string codeLigue = codeLigueResult.ToString();

                    // Déterminer le créneau sélectionné
                    List<string> selectedCreneaux = new List<string>();
                    if (chbxMatin.Checked) selectedCreneaux.Add("Matin");
                    if (chbxApresMidi.Checked) selectedCreneaux.Add("Après midi");

                    // Si aucun créneau n'est sélectionné, vider les ListBox et sortir
                    if (selectedCreneaux.Count == 0)
                    {
                        lbxListeMembreInsc.Items.Clear();
                        lbxListeMembreNonInsc.Items.Clear();
                        return;
                    }

                    // Construction de la requête pour récupérer les membres inscrits et non inscrits
                    string creneauFiltre = string.Join("' OR libelléCréneau = '", selectedCreneaux);

                    // Requête pour récupérer les membres INSCRITS au(x) créneau(x) sélectionné(s)
                    string queryInsc = $@"SELECT DISTINCT nom, prénom
                                          FROM MEMBRE, PARTICIPER, CRENEAU
                                          WHERE MEMBRE.codeMembre = PARTICIPER.codeMembre
                                          AND PARTICIPER.codeCréneau = CRENEAU.codeCréneau
                                          AND MEMBRE.codeLigue = @codeLigue
                                          AND (libelléCréneau = '{creneauFiltre}')";

                    OleDbCommand commandInsc = new OleDbCommand(queryInsc, connection);
                    commandInsc.Parameters.AddWithValue("@codeLigue", codeLigue);

                    // Exécuter la requête pour les membres inscrits
                    lbxListeMembreInsc.Items.Clear();
                    using (OleDbDataReader reader = commandInsc.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lbxListeMembreInsc.Items.Add($"{reader["nom"]} {reader["prénom"]}");
                        }
                    }

                    // Requête pour récupérer les membres NON INSCRITS au(x) créneau(x) sélectionné(s)
                    string queryNonInsc = $@"SELECT DISTINCT nom, prénom
                                             FROM MEMBRE
                                             WHERE codeLigue = @codeLigue
                                             AND codeMembre NOT IN (SELECT PARTICIPER.codeMembre
                                                                    FROM PARTICIPER, CRENEAU
                                                                    WHERE PARTICIPER.codeCréneau = CRENEAU.codeCréneau
                                                                    AND libelléCréneau = '{creneauFiltre}')";

                    OleDbCommand commandNonInsc = new OleDbCommand(queryNonInsc, connection);
                    commandNonInsc.Parameters.AddWithValue("@codeLigue", codeLigue);

                    // Exécuter la requête pour les membres non inscrits
                    lbxListeMembreNonInsc.Items.Clear();
                    using (OleDbDataReader reader = commandNonInsc.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lbxListeMembreNonInsc.Items.Add($"{reader["nom"]} {reader["prénom"]}");
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
    }
}