using championnat.Formulaires.arbitre;
using championnat.Modele.DAO;
using championnat.Modele.Metier;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace championnat.Formulaires.fonction
{
    public partial class AffichageFonction : Form
    {
        private List<Fonction> lesFonctions;

        public AffichageFonction()
        {
            InitializeComponent();
            lesFonctions = FonctionDAO.ReadAllFonctions();
            initializeDGV();
        }

        private void initializeDGV()
        {
            dgvFonctions.AutoGenerateColumns = false;
            dgvFonctions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFonctions.MultiSelect = false;

            dgvFonctions.Columns.Clear();

            dgvFonctions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CodeF",
                HeaderText = "Code",
                DataPropertyName = "Code"
            });

            dgvFonctions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LibelleF",
                HeaderText = "Libellé",
                DataPropertyName = "Libelle"
            });

            dgvFonctions.DataSource = lesFonctions;
        }

        private void dgvFonctions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFonctions.SelectedRows.Count > 0)
            {
                Fonction fonctionSelectionnee = (Fonction)dgvFonctions.SelectedRows[0].DataBoundItem;
                ((Application)this.MdiParent).changerFormInterne(new GestionFonction(fonctionSelectionnee));
            }
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            ((Application)this.MdiParent).changerFormInterne(new GestionFonction());
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }





        private void button1_Click(object sender, EventArgs e)
        {
            ((Application)this.MdiParent).changerFormInterne(new GestionFonction());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvFonctions_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

