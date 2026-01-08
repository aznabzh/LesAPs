using System;
using System.Collections.Generic;
using System.Windows.Forms;
using championnat.Modele.DAO;
using championnat.Modele.Metier;

namespace championnat.Formulaires.Joueurs
{
    public partial class AffichageJoueurs : Form
    {

        private List<Joueur> lesJoueurs;
        public AffichageJoueurs()
        {
            InitializeComponent();
            lesJoueurs = JoueurDAO.ReadAllJoueurs();
            initializeDGV();
        }

        private void initializeDGV()
        {
            dgvJoueurs.AutoGenerateColumns = false;
            dgvJoueurs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJoueurs.MultiSelect = false;

            dgvJoueurs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Numero",
                HeaderText = "Numéro",
                DataPropertyName = "Numero"
            });
            dgvJoueurs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Nom",
                HeaderText = "Nom",
                DataPropertyName = "Nom"
            });
            dgvJoueurs.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Prenom",
                HeaderText = "Prénom",
                DataPropertyName = "Prenom"
            });
            dgvJoueurs.DataSource = lesJoueurs;
        }

        private void dgvJoueurs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Joueur joueurSelectionne = (Joueur) dgvJoueurs.SelectedRows[0].DataBoundItem;
            ((Application)this.MdiParent).changerFormInterne(new GestionJoueur(joueurSelectionne));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Application)this.MdiParent).changerFormInterne(new GestionJoueur());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvJoueurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
