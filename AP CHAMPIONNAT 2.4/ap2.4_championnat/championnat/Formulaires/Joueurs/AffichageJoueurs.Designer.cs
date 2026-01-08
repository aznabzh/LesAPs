using System.Windows.Forms;

namespace championnat.Formulaires.Joueurs
{
    partial class AffichageJoueurs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvJoueurs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJoueurs)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvJoueurs
            // 
            this.dgvJoueurs.AllowUserToAddRows = false;
            this.dgvJoueurs.AllowUserToDeleteRows = false;
            this.dgvJoueurs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJoueurs.Location = new System.Drawing.Point(8, 100);
            this.dgvJoueurs.Margin = new System.Windows.Forms.Padding(2);
            this.dgvJoueurs.Name = "dgvJoueurs";
            this.dgvJoueurs.ReadOnly = true;
            this.dgvJoueurs.RowHeadersVisible = false;
            this.dgvJoueurs.RowHeadersWidth = 62;
            this.dgvJoueurs.RowTemplate.Height = 28;
            this.dgvJoueurs.Size = new System.Drawing.Size(320, 364);
            this.dgvJoueurs.TabIndex = 0;
            this.dgvJoueurs.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJoueurs_CellContentClick);
            this.dgvJoueurs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvJoueurs_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Les joueurs";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(332, 100);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Créer joueur";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button2.Location = new System.Drawing.Point(332, 142);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 38);
            this.button2.TabIndex = 3;
            this.button2.Text = "Retour";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 83);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pour modifier un  joueur, double-cliquez dessus";
            // 
            // AffichageJoueurs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 500);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvJoueurs);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AffichageJoueurs";
            this.Text = "AffichageJoueurs";
            ((System.ComponentModel.ISupportInitialize)(this.dgvJoueurs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvJoueurs;
        private Label label1;
        private Button button1;
        private Button button2;
        private Label label2;
    }
}