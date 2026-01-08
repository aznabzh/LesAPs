using System.Runtime.CompilerServices;

namespace championnat
{
    partial class Application
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.barreMenu = new System.Windows.Forms.MenuStrip();
            this.joueursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.postesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matchsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.barreMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // barreMenu
            // 
            this.barreMenu.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.barreMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.barreMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joueursToolStripMenuItem,
            this.postesToolStripMenuItem,
            this.matchsToolStripMenuItem});
            this.barreMenu.Location = new System.Drawing.Point(0, 0);
            this.barreMenu.Name = "barreMenu";
            this.barreMenu.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.barreMenu.Size = new System.Drawing.Size(779, 38);
            this.barreMenu.TabIndex = 0;
            this.barreMenu.Text = "menuStrip1";
            // 
            // joueursToolStripMenuItem
            // 
            this.joueursToolStripMenuItem.Name = "joueursToolStripMenuItem";
            this.joueursToolStripMenuItem.Size = new System.Drawing.Size(102, 34);
            this.joueursToolStripMenuItem.Text = "Joueurs";
            this.joueursToolStripMenuItem.Click += new System.EventHandler(this.joueursToolStripMenuItem_Click);
            // 
            // postesToolStripMenuItem
            // 
            this.postesToolStripMenuItem.Name = "postesToolStripMenuItem";
            this.postesToolStripMenuItem.Size = new System.Drawing.Size(90, 34);
            this.postesToolStripMenuItem.Text = "Postes";
            this.postesToolStripMenuItem.Click += new System.EventHandler(this.postesToolStripMenuItem_Click);
            // 
            // matchsToolStripMenuItem
            // 
            this.matchsToolStripMenuItem.Name = "matchsToolStripMenuItem";
            this.matchsToolStripMenuItem.Size = new System.Drawing.Size(99, 34);
            this.matchsToolStripMenuItem.Text = "Matchs";
            this.matchsToolStripMenuItem.Click += new System.EventHandler(this.matchsToolStripMenuItem_Click);
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 923);
            this.Controls.Add(this.barreMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.barreMenu;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Application";
            this.Text = "Championnat";
            this.Load += new System.EventHandler(this.Application_Load);
            this.barreMenu.ResumeLayout(false);
            this.barreMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip barreMenu;
        private System.Windows.Forms.ToolStripMenuItem joueursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem postesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matchsToolStripMenuItem;
    }
}

