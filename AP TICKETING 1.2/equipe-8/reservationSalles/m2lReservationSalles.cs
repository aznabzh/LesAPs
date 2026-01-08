using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reservationSalles2018
{
    public partial class frmM2LReservationSalles : Form
    {

        public static DataSet reservationsSallesDataSet;
        public frmM2LReservationSalles()
        {
            InitializeComponent();
        }


        private void M2LReservationSalles_Load(object sender, EventArgs e)
        {
            dbConnexion.setDataSet();
            reservationsSallesDataSet = dbConnexion.getDataSet();
        }


        private void sallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.Text != "salles")
            {
                this.ActiveMdiChild.Close();
            }

            if (this.ActiveMdiChild == null)
            {
                frmSalles Fsalles = new frmSalles();
                Fsalles.MdiParent = this;
                Fsalles.WindowState = FormWindowState.Maximized;
                Fsalles.Show();
            }

        }


      


     

        private void réservantsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.Text != "reservants")
            {
                this.ActiveMdiChild.Close();
            }

            if (this.ActiveMdiChild == null)
            {
                frmReservants Freservants = new frmReservants();
                Freservants.MdiParent = this;
                Freservants.WindowState = FormWindowState.Maximized;
                Freservants.Show();

            }

        }

        private void réservationsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.Text != "reservations")
            {
                this.ActiveMdiChild.Close();
            }

            if (this.ActiveMdiChild == null)
            {
                frmReservations Freservantions = new frmReservations();
                Freservantions.MdiParent = this;
                Freservantions.WindowState = FormWindowState.Maximized;
                Freservantions.Show();

            }
        }

        private void quitterToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

      

      

        private void liguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.Text != "ligues")
            {
                this.ActiveMdiChild.Close();
            }

            if (this.ActiveMdiChild == null)
            {
                frmLigues fLigues = new frmLigues();
                fLigues.MdiParent = this;
                fLigues.WindowState = FormWindowState.Maximized;
                fLigues.Show();

            }
        }

        private void equipementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.Text != "equipements")
            {
                this.ActiveMdiChild.Close();
            }

            if (this.ActiveMdiChild == null)
            {
                frmEquipements fEquipements = new frmEquipements();
                fEquipements.MdiParent = this;
                fEquipements.WindowState = FormWindowState.Maximized;
                fEquipements.Show();

            }
        }

        private void diponibilitésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.Text != "disponibilites")
            {
                this.ActiveMdiChild.Close();
            }

            if (this.ActiveMdiChild == null)
            {
                frmDisponibilites fDisponibilites = new frmDisponibilites();
                fDisponibilites.MdiParent = this;
                fDisponibilites.WindowState = FormWindowState.Maximized;
                fDisponibilites.Show();
            }
        }

        private void facturationRéservationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.Text != "facturation")
            {
                this.ActiveMdiChild.Close();
            }

            if (this.ActiveMdiChild == null)
            {
                frmFacturationReservations fFacturationReservations = new frmFacturationReservations();
                fFacturationReservations.MdiParent = this;
                fFacturationReservations.WindowState = FormWindowState.Maximized;
                fFacturationReservations.Show();
            }
        }

        private void statistiquesSallesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.Text != "statistiquesSalles")
            {
                this.ActiveMdiChild.Close();
            }

            if (this.ActiveMdiChild == null)
            {
                frmStatistiquesSalles fstatistiquesSalles = new frmStatistiquesSalles();
                fstatistiquesSalles.MdiParent = this;
                fstatistiquesSalles.WindowState = FormWindowState.Maximized;
                fstatistiquesSalles.Show();
            }
        }

        private void statistiquesTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.ActiveMdiChild != null && this.ActiveMdiChild.Text != "statistiquesTypes")
            {
                this.ActiveMdiChild.Close();
            }

            if (this.ActiveMdiChild == null)
            {
                frmStatistiquesTypes fstatistiquesSalles = new frmStatistiquesTypes();
                fstatistiquesSalles.MdiParent = this;
                fstatistiquesSalles.WindowState = FormWindowState.Maximized;
                fstatistiquesSalles.Show();
            }
        }
    }
}
