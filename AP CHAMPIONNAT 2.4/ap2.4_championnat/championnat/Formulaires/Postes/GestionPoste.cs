using System;
using System.Collections.Generic;
using System.Windows.Forms;
using championnat.Modele.DAO;
using championnat.Modele.Metier;

namespace championnat.Formulaires.Postes
{
    public partial class GestionPoste : Form
    {
        private bool ajout;
        private Poste poste;

        public GestionPoste()
        {
            InitializeComponent();
            this.poste = new Poste();
            this.ajout = true;

            lblTitre.Text = "Création poste";
        }

        public GestionPoste(Poste poste)
        {
            InitializeComponent();
            this.poste = poste;
            this.ajout = false;

            lblTitre.Text = "Modification poste";
            tbxCode.Text = poste.Code;
            tbxLibelle.Text = poste.Libelle;
            btnDelete.Visible = true;
        }

        private void btnValider_Click(object sender, EventArgs e)
        {
            Poste posteFromValues = new Poste(
                tbxCode.Text,
                tbxLibelle.Text
            );
            if (ajout)
            {
                PosteDAO.CreatePoste(posteFromValues);
            } else
            {
                PosteDAO.UpdatePoste(posteFromValues);
            }
            this.retourListePostes();
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.retourListePostes();
        }

        private void retourListePostes()
        {
            ((Application)this.MdiParent).changerFormInterne(new AffichagePostes());
        }



        private void btnDelete_Click(object sender, EventArgs e)
        {
            PosteDAO.DeletePosteByCode(poste.Code);
            this.retourListePostes();
        }

        private void lblTitre_Click(object sender, EventArgs e)
        {

        }
    }
}
