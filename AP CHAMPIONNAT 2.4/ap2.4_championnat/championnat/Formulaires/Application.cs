using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using championnat.Formulaires.Joueurs;
using championnat.Formulaires.Matches;
using championnat.Formulaires.Postes;

namespace championnat
{
    public partial class Application : Form
    {
        public Application()
        {
            InitializeComponent();
            MemoryStream ms = new MemoryStream(Properties.Resources.icone);
            this.Icon = new Icon(ms);
        }

        public void changerFormInterne(Form form)
        {
            if (this.ActiveMdiChild != null) this.ActiveMdiChild.Close();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Maximized;
            this.Size = form.Size;
            form.Show();
        }

        private void joueursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.changerFormInterne(new AffichageJoueurs());
        }

        private void postesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.changerFormInterne(new AffichagePostes());
        }

        private void matchsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.changerFormInterne(new AffichageMatches());
        }

        private void arbitresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.changerFormInterne(new championnat.Formulaires.arbitre.AffichageArbitre());
        }

        private void fonctionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.changerFormInterne(new championnat.Formulaires.fonction.AffichageFonction());
        }

        private void Application_Load(object sender, EventArgs e)
        {
            ToolStripMenuItem arbitresToolStripMenuItem = new ToolStripMenuItem("Arbitres");
            arbitresToolStripMenuItem.Click += arbitresToolStripMenuItem_Click;
            matchsToolStripMenuItem.DropDownItems.Add(arbitresToolStripMenuItem);

            ToolStripMenuItem fonctionToolStripMenuItem = new ToolStripMenuItem("Fonctions");
            fonctionToolStripMenuItem.Click += fonctionsToolStripMenuItem_Click;
            matchsToolStripMenuItem.DropDownItems.Add(fonctionToolStripMenuItem);
        }

        private void arbitreToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
