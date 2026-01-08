namespace championnat.Formulaires.Joueurs
{
    partial class GestionJoueur
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
            this.lblTitre = new System.Windows.Forms.Label();
            this.lblForNumero = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbxNumero = new System.Windows.Forms.TextBox();
            this.lblJoueurs = new System.Windows.Forms.Label();
            this.tbxLicence = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxDateNaiss = new System.Windows.Forms.TextBox();
            this.lblDateNaiss = new System.Windows.Forms.Label();
            this.tbxPrenom = new System.Windows.Forms.TextBox();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.tbxNom = new System.Windows.Forms.TextBox();
            this.cbxPoste = new System.Windows.Forms.ComboBox();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNextNumero = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(336, 30);
            this.lblTitre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(252, 39);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Edition Joueur";
            // 
            // lblForNumero
            // 
            this.lblForNumero.AutoSize = true;
            this.lblForNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForNumero.Location = new System.Drawing.Point(4, 0);
            this.lblForNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForNumero.Name = "lblForNumero";
            this.lblForNumero.Size = new System.Drawing.Size(129, 32);
            this.lblForNumero.TabIndex = 1;
            this.lblForNumero.Text = "Numéro :";
            this.lblForNumero.Click += new System.EventHandler(this.lblForNumero_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tbxNumero, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblJoueurs, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbxLicence, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbxDateNaiss, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDateNaiss, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbxPrenom, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblPrenom, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblForNumero, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNom, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbxNom, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbxPoste, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(160, 103);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(656, 268);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tbxNumero
            // 
            this.tbxNumero.Location = new System.Drawing.Point(277, 4);
            this.tbxNumero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxNumero.Name = "tbxNumero";
            this.tbxNumero.Size = new System.Drawing.Size(362, 29);
            this.tbxNumero.TabIndex = 0;
            this.tbxNumero.TextChanged += new System.EventHandler(this.tbxNumero_TextChanged);
            this.tbxNumero.Enter += new System.EventHandler(this.tbxNumero_Enter);
            this.tbxNumero.Leave += new System.EventHandler(this.tbxNumero_Leave);
            // 
            // lblJoueurs
            // 
            this.lblJoueurs.AutoSize = true;
            this.lblJoueurs.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJoueurs.Location = new System.Drawing.Point(4, 185);
            this.lblJoueurs.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblJoueurs.Name = "lblJoueurs";
            this.lblJoueurs.Size = new System.Drawing.Size(101, 32);
            this.lblJoueurs.TabIndex = 11;
            this.lblJoueurs.Text = "Joueur";
            // 
            // tbxLicence
            // 
            this.tbxLicence.Location = new System.Drawing.Point(277, 152);
            this.tbxLicence.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLicence.Name = "tbxLicence";
            this.tbxLicence.Size = new System.Drawing.Size(365, 29);
            this.tbxLicence.TabIndex = 4;
            this.tbxLicence.TextChanged += new System.EventHandler(this.tbxLicence_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Numéro de licence :";
            // 
            // tbxDateNaiss
            // 
            this.tbxDateNaiss.Location = new System.Drawing.Point(277, 115);
            this.tbxDateNaiss.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxDateNaiss.Name = "tbxDateNaiss";
            this.tbxDateNaiss.Size = new System.Drawing.Size(362, 29);
            this.tbxDateNaiss.TabIndex = 3;
            this.tbxDateNaiss.TextChanged += new System.EventHandler(this.tbxDateNaiss_TextChanged);
            // 
            // lblDateNaiss
            // 
            this.lblDateNaiss.AutoSize = true;
            this.lblDateNaiss.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateNaiss.Location = new System.Drawing.Point(4, 111);
            this.lblDateNaiss.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateNaiss.Name = "lblDateNaiss";
            this.lblDateNaiss.Size = new System.Drawing.Size(264, 32);
            this.lblDateNaiss.TabIndex = 7;
            this.lblDateNaiss.Text = "Date de naissance :";
            // 
            // tbxPrenom
            // 
            this.tbxPrenom.Location = new System.Drawing.Point(277, 78);
            this.tbxPrenom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxPrenom.Name = "tbxPrenom";
            this.tbxPrenom.Size = new System.Drawing.Size(362, 29);
            this.tbxPrenom.TabIndex = 2;
            this.tbxPrenom.TextChanged += new System.EventHandler(this.tbxPrenom_TextChanged);
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrenom.Location = new System.Drawing.Point(4, 74);
            this.lblPrenom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(135, 32);
            this.lblPrenom.TabIndex = 5;
            this.lblPrenom.Text = "Prénom : ";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(4, 37);
            this.lblNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(95, 32);
            this.lblNom.TabIndex = 3;
            this.lblNom.Text = "Nom : ";
            // 
            // tbxNom
            // 
            this.tbxNom.Location = new System.Drawing.Point(277, 41);
            this.tbxNom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxNom.Name = "tbxNom";
            this.tbxNom.Size = new System.Drawing.Size(362, 29);
            this.tbxNom.TabIndex = 1;
            this.tbxNom.TextChanged += new System.EventHandler(this.tbxNom_TextChanged);
            // 
            // cbxPoste
            // 
            this.cbxPoste.FormattingEnabled = true;
            this.cbxPoste.Location = new System.Drawing.Point(277, 189);
            this.cbxPoste.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxPoste.Name = "cbxPoste";
            this.cbxPoste.Size = new System.Drawing.Size(362, 32);
            this.cbxPoste.TabIndex = 5;
            this.cbxPoste.SelectedIndexChanged += new System.EventHandler(this.cbxPoste_SelectedIndexChanged);
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnValider.Location = new System.Drawing.Point(279, 391);
            this.btnValider.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(156, 55);
            this.btnValider.TabIndex = 6;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAnnuler.Location = new System.Drawing.Point(493, 391);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(156, 55);
            this.btnAnnuler.TabIndex = 7;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.Location = new System.Drawing.Point(836, 15);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 70);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Supprimer joueur";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNextNumero
            // 
            this.btnNextNumero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNextNumero.Location = new System.Drawing.Point(836, 103);
            this.btnNextNumero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNextNumero.Name = "btnNextNumero";
            this.btnNextNumero.Size = new System.Drawing.Size(126, 111);
            this.btnNextNumero.TabIndex = 9;
            this.btnNextNumero.Text = "Générer prochain numéro disponible";
            this.btnNextNumero.UseVisualStyleBackColor = false;
            this.btnNextNumero.Visible = false;
            this.btnNextNumero.Click += new System.EventHandler(this.btnNextNumero_Click);
            // 
            // GestionJoueur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 528);
            this.ControlBox = false;
            this.Controls.Add(this.btnNextNumero);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblTitre);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "GestionJoueur";
            this.Text = "EditionJoueur";
            this.Load += new System.EventHandler(this.GestionJoueur_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblForNumero;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.TextBox tbxNom;
        private System.Windows.Forms.TextBox tbxLicence;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxDateNaiss;
        private System.Windows.Forms.Label lblDateNaiss;
        private System.Windows.Forms.TextBox tbxPrenom;
        private System.Windows.Forms.Label lblJoueurs;
        private System.Windows.Forms.TextBox tbxNumero;
        private System.Windows.Forms.ComboBox cbxPoste;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNextNumero;
    }
}