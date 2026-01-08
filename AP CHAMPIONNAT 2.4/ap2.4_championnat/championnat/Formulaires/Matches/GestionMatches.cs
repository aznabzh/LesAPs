using championnat.Formulaires.Joueurs;
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
using championnat.Modele.DAO;


namespace championnat.Formulaires.Matches
{
    public partial class GestionMatches : Form
    {
        private bool ajout;
        private MetierMatch match;

        public GestionMatches()
        {
            InitializeComponent();
            this.match = new MetierMatch();
            this.ajout = true;

            lblTitre.Text = "Creation Match";
        }

        public GestionMatches(MetierMatch match)
        {
            InitializeComponent();
            this.match = match;
            this.ajout = false;

            lblTitre.Text = "Modification match";
            tbxNumero.Text = match.CodeM;
            tbxNumero.Enabled = false;
            tbxDateMatch.Text = match.Date.ToString("yyyy-MM-dd");
            tbxLieuMatch.Text = match.Lieu;
            tbxScoreEquipe1.Text = match.ScoreE1.ToString();
            tbxScoreEquipe2.Text = match.ScoreE2.ToString();

            // Remplacement des ComboBox par TextBox
            tbxCodeEquipe1.Text = match.CodeE1;
            tbxCodeEquipe2.Text = match.CodeE2;

            btnDelete.Visible = true;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            MetierMatch matchFromValues = new MetierMatch(
                tbxNumero.Text,
                DateTime.Parse(tbxDateMatch.Text),
                tbxLieuMatch.Text,
                int.Parse(tbxScoreEquipe1.Text),
                int.Parse(tbxScoreEquipe2.Text),
                tbxCodeEquipe1.Text,    // <-- utilisation du TextBox
                tbxCodeEquipe2.Text     // <-- utilisation du TextBox
            );

            if (ajout)
            {
                MatchDAO.CreateMatch(matchFromValues);
            }
            else
            {
                MatchDAO.UpdateMatch(matchFromValues);
            }

            this.retourListeMatches();
        }


        private void lblTitre_Click(object sender, EventArgs e)
        {

        }

        private void tbxNumero_Enter(object sender, EventArgs e)
        {
            if (ajout)
            {
                btnNextNumero.Visible = true;
            }
        }


        private void tbxNumero_Leave(object sender, EventArgs e)
        {
            //btnNextNumero.Visible = false;
        }

        private void btnNextNumero_Click(object sender, EventArgs e)
        {
            int maxNumero = MatchDAO.GetMaxNumero();
            tbxNumero.Text = "M" + (maxNumero + 1).ToString();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            MatchDAO.DeleteMatchByCode(match.CodeM);
            this.retourListeMatches();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.retourListeMatches();
        }

        private void retourListeMatches()
        {
            ((Application)this.MdiParent).changerFormInterne(new AffichageMatches());
        }


        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GestionMatches_Load(object sender, EventArgs e)
        {

        }

        private void lblDateNaiss_Click(object sender, EventArgs e)
        {

        }

        

        private void tbxDateMatch_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void tbxLieuMatch_TextChanged(object sender, EventArgs e)
        {
            //
        }

        private void tbxScoreEquipe1_TextChanged_1(object sender, EventArgs e)
        {
            //
        }

        private void tbxScoreEquipe2_TextChanged_1(object sender, EventArgs e)
        {
            //
        }

        private void cbxEquipe2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void cbxEquipe1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void cbxCodeEquipe1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void cbxCodeEquipe2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }


        //NE PAS TOUCHER, CE SONT LES ARBITRES, A FAIRE PLUS TARD

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void tbxNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxCodeEquipe1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxCodeEquipe2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
