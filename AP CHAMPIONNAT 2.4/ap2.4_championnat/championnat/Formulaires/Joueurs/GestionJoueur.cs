using System;
using System.Collections.Generic;
using System.Windows.Forms;
using championnat.Modele.DAO;
using championnat.Modele.Metier;

namespace championnat.Formulaires.Joueurs
{
    public partial class GestionJoueur : Form
    {
        private bool ajout;
        private Joueur joueur;

        public GestionJoueur()
        {
            InitializeComponent();
            this.joueur = new Joueur();
            this.ajout = true;

            lblTitre.Text = "Création joueur";
            initCbxPoste();
        }

        public GestionJoueur(Joueur joueur)
        {
            InitializeComponent();
            this.joueur = joueur;
            this.ajout = false;

            lblTitre.Text = "Modification joueur";
            tbxNumero.Text = joueur.Numero.ToString();
            tbxNumero.Enabled = false;
            tbxNom.Text = joueur.Nom;
            tbxPrenom.Text = joueur.Prenom;
            tbxDateNaiss.Text = joueur.DateDeNaissance.ToString();
            tbxLicence.Text = joueur.NumeroLicence;
            initCbxPoste();
            cbxPoste.SelectedValue = joueur.Poste.Code;
            btnDelete.Visible = true;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            Joueur joueurFromValues = new Joueur(
                int.Parse(tbxNumero.Text),
                tbxNom.Text,
                tbxPrenom.Text,
                DateTime.Parse(tbxDateNaiss.Text),
                tbxLicence.Text,
                cbxPoste.SelectedItem as Poste
            );
            if (ajout)
            {
                JoueurDAO.CreateJoueur(joueurFromValues);
            } else
            {
                JoueurDAO.UpdateJoueur(joueurFromValues);
            }
            this.retourListeJoueurs();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.retourListeJoueurs();
        }

        private void retourListeJoueurs()
        {
            ((Application)this.MdiParent).changerFormInterne(new AffichageJoueurs());
        }

        private void initCbxPoste()
        {
            List<Poste> lesPostes = PosteDAO.ReadAllPostes();
            cbxPoste.DataSource = lesPostes;
            cbxPoste.DisplayMember = "Libelle";
            cbxPoste.ValueMember = "Code";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            JoueurDAO.DeleteJoueurByNumero(joueur.Numero);
            this.retourListeJoueurs();
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
            int maxNumero = JoueurDAO.GetMaxNumero();
            tbxNumero.Text = (maxNumero + 1).ToString();
        }

        private void GestionJoueur_Load(object sender, EventArgs e)
        {

        }

        private void cbxPoste_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbxNumero_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblForNumero_Click(object sender, EventArgs e)
        {

        }

        private void tbxLicence_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxDateNaiss_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxPrenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxNom_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
