using championnat.Formulaires.Joueurs;
using championnat.Modele.DAO;
using championnat.Modele.Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using RegexMatch = System.Text.RegularExpressions.Match;
using MetierMatch = championnat.Modele.Metier.Match;


namespace championnat.Formulaires.Matches
{
    public partial class AffichageMatches : Form
    {
        private List<championnat.Modele.Metier.Match> lesMatches;
        
        public AffichageMatches()
        {
            InitializeComponent();
            initializeDGV();
        }
        private void initializeDGV()
        {
            dgvMatches.AutoGenerateColumns = false;
            dgvMatches.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMatches.MultiSelect = false;

            dgvMatches.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CodeM",
                HeaderText = "Code",
                DataPropertyName = "CodeM"
            });
            dgvMatches.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "DateM",
                HeaderText = "Date",
                DataPropertyName = "Date"
            });
            dgvMatches.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LieuM",
                HeaderText = "Lieu",
                DataPropertyName = "Lieu"
            });
            dgvMatches.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ScoreEquipe1",
                HeaderText = "Score Equipe 1",
                DataPropertyName = "ScoreE1"
            });
            dgvMatches.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ScoreEquipe2",
                HeaderText = "Score Equipe 2",
                DataPropertyName = "ScoreE2"
            });
            dgvMatches.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CodeEquipe1",
                HeaderText = "Code E1",
                DataPropertyName = "CodeE1"
            });
            dgvMatches.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CodeEquipe2",
                HeaderText = "Code E2",
                DataPropertyName = "CodeE2"
            });

            lesMatches = MatchDAO.ReadAllMatches();

            dgvMatches.DataSource = lesMatches;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Application)this.MdiParent).changerFormInterne(new GestionMatches());
        }

        private void dgvJoueurs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void dgvMatches_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MetierMatch matchSelectionne = (MetierMatch)dgvMatches.SelectedRows[0].DataBoundItem;
            ((Application)this.MdiParent).changerFormInterne(new GestionMatches(matchSelectionne));
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
