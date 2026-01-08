using championnat.Modele.DAO;
using championnat.Modele.Metier;
using System;
using System.Windows.Forms;

namespace championnat.Formulaires.fonction
{
    public partial class GestionFonction : Form
    {
        private bool ajout;
        private Fonction fonction;

        public GestionFonction()
        {
            InitializeComponent();
            this.fonction = new Fonction();
            this.ajout = true;

            lblTitre.Text = "Création fonction";
            btnDelete.Visible = false;
        }

        public GestionFonction(Fonction fonction)
        {
            InitializeComponent();
            this.fonction = fonction;
            this.ajout = false;

            lblTitre.Text = "Modification fonction";
            tbxNumero.Text = fonction.Code;
            tbxNumero.Enabled = false;
            tbxNom.Text = fonction.Libelle;

            btnDelete.Visible = true;
        }

        private void retourListeFonctions()
        {
            ((Application)this.MdiParent).changerFormInterne(new AffichageFonction());
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            Fonction fonctionFromValues = new Fonction(
                tbxNumero.Text,
                tbxNom.Text
            );

            if (ajout)
            {
                FonctionDAO.CreateFonction(fonctionFromValues);
            }
            else
            {
                FonctionDAO.UpdateFonction(fonctionFromValues);
            }

            this.retourListeFonctions();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.retourListeFonctions();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            FonctionDAO.DeleteFonctionByCode(fonction.Code);
            this.retourListeFonctions();
        }

        private void tbxNumero_TextChanged(object sender, EventArgs e) { }

        private void tbxNom_TextChanged(object sender, EventArgs e) { }

        private void lblTitre_Click(object sender, EventArgs e) { }
    }
}
