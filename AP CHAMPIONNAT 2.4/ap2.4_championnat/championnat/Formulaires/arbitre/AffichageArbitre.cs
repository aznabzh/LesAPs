using championnat.Modele.DAO;
using championnat.Modele.Metier;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace championnat.Formulaires.arbitre
{
    public partial class AffichageArbitre : Form
    {
        private List<Arbitre> lesArbitres;

        public AffichageArbitre()
        {
            InitializeComponent();
            lesArbitres = ArbitreDAO.ReadAllArbitres();
            initializeDGV();
        }

        private void initializeDGV()
        {
            dgvArbitres.AutoGenerateColumns = false;
            dgvArbitres.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvArbitres.MultiSelect = false;

            dgvArbitres.Columns.Clear();

            dgvArbitres.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CodeA",
                HeaderText = "Code",
                DataPropertyName = "Code"
            });

            dgvArbitres.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NomA",
                HeaderText = "Nom",
                DataPropertyName = "Nom"
            });

            dgvArbitres.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "PrenomA",
                HeaderText = "Prénom",
                DataPropertyName = "Prenom"
            });

            dgvArbitres.DataSource = lesArbitres;
        }

        private void dgvArbitres_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvArbitres.SelectedRows.Count > 0)
            {
               Arbitre arbitreSelectionne = (Arbitre)dgvArbitres.SelectedRows[0].DataBoundItem;
               ((Application)this.MdiParent).changerFormInterne(new GestionArbitre(arbitreSelectionne));
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Application)this.MdiParent).changerFormInterne(new GestionArbitre());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvArbitres_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
