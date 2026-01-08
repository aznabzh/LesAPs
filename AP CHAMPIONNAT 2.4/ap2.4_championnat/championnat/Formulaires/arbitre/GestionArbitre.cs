using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using championnat.Formulaires.Joueurs;
using championnat.Modele.DAO;
using championnat.Modele.Metier;

namespace championnat.Formulaires.arbitre
{
    public partial class GestionArbitre : Form
    {
        private bool ajout;
        private Arbitre arbitre;
        public GestionArbitre()
        {
            InitializeComponent();
            this.arbitre = new Arbitre();
            this.ajout = true;

            lblTitre.Text = "Création arbitre";
        }

        public GestionArbitre(Arbitre arbitre)
        {
            InitializeComponent();
            this.arbitre = arbitre;
            this.ajout = false;

            lblTitre.Text = "Modification arnitre";
            tbxNumero.Text = arbitre.Code.ToString();
            tbxNumero.Enabled = false;
            tbxNom.Text = arbitre.Nom;
            tbxPrenom.Text = arbitre.Prenom;

            btnDelete.Visible = true;
        }

        private void tbxNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxPrenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void retourListeArbitres()
        {
            ((Application)this.MdiParent).changerFormInterne(new AffichageArbitre());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ArbitreDAO.DeleteArbitreByCode(arbitre.Code);
            this.retourListeArbitres();
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
            btnNextNumero.Visible = false;
        }

        private void btnNextNumero_Click(object sender, EventArgs e)
        {
            int maxNumero = ArbitreDAO.GetMaxNumero();
            tbxNumero.Text = "A" + (maxNumero + 1).ToString();
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            Arbitre arbitreFromValues = new Arbitre(
                tbxNumero.Text,
                tbxNom.Text,
                tbxPrenom.Text
            );
            if (ajout)
            {
                ArbitreDAO.CreateArbitre(arbitreFromValues);
            }
            else
            {
                ArbitreDAO.UpdateArbitre(arbitreFromValues);
            }
            this.retourListeArbitres();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.retourListeArbitres();
        }

        private void lblTitre_Click(object sender, EventArgs e)
        {

        }
    }
}
