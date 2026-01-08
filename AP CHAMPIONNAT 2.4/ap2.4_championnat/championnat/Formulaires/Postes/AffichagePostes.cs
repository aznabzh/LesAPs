using System;
using System.Collections.Generic;
using System.Windows.Forms;
using championnat.Modele.DAO;
using championnat.Modele.Metier;

namespace championnat.Formulaires.Postes
{
    public partial class AffichagePostes : Form
    {

        private List<Poste> lesPostes;
        public AffichagePostes()
        {
            InitializeComponent();
            lesPostes = PosteDAO.ReadAllPostes();
            initializeDGV();
        }

        private void initializeDGV()
        {
            dgvPostes.AutoGenerateColumns = false;
            dgvPostes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPostes.MultiSelect = false;

            dgvPostes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Code",
                HeaderText = "Code",
                DataPropertyName = "Code"
            });
            dgvPostes.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Libelle",
                HeaderText = "Libellé",
                DataPropertyName = "Libelle"
            });
            dgvPostes.DataSource = lesPostes;
        }

        private void dgvPostes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Poste posteSelectionne = (Poste) dgvPostes.SelectedRows[0].DataBoundItem;
            ((Application)this.MdiParent).changerFormInterne(new GestionPoste(posteSelectionne));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Application)this.MdiParent).changerFormInterne(new GestionPoste());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPostes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
