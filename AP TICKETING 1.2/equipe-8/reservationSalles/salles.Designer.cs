namespace reservationSalles2018
{
    partial class frmSalles
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalles));
            this.btnAjouterSalle = new System.Windows.Forms.Button();
            this.btnEnregistrerSalle = new System.Windows.Forms.Button();
            this.btnSupprimerSalle = new System.Windows.Forms.Button();
            this.btnAnnulerSalle = new System.Windows.Forms.Button();
            this.btnModifierSalle = new System.Windows.Forms.Button();
            this.btnRechercheSalle = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxCapaciteSalle = new System.Windows.Forms.TextBox();
            this.tbxSurfaceSalle = new System.Windows.Forms.TextBox();
            this.tbxNomSalle = new System.Windows.Forms.TextBox();
            this.tbxRechercherSalle = new System.Windows.Forms.TextBox();
            this.lbxSalles = new System.Windows.Forms.ListBox();
            this.cbxTypeSalle = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxPrixLocationSalle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAjouterSalle
            // 
            this.btnAjouterSalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouterSalle.Location = new System.Drawing.Point(782, 350);
            this.btnAjouterSalle.Name = "btnAjouterSalle";
            this.btnAjouterSalle.Size = new System.Drawing.Size(116, 42);
            this.btnAjouterSalle.TabIndex = 33;
            this.btnAjouterSalle.Text = "Ajouter";
            this.btnAjouterSalle.UseVisualStyleBackColor = true;
            this.btnAjouterSalle.Click += new System.EventHandler(this.btnAjouterSalle_Click);
            // 
            // btnEnregistrerSalle
            // 
            this.btnEnregistrerSalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrerSalle.Location = new System.Drawing.Point(782, 350);
            this.btnEnregistrerSalle.Name = "btnEnregistrerSalle";
            this.btnEnregistrerSalle.Size = new System.Drawing.Size(116, 42);
            this.btnEnregistrerSalle.TabIndex = 32;
            this.btnEnregistrerSalle.Text = "Enregistrer";
            this.btnEnregistrerSalle.UseVisualStyleBackColor = true;
            this.btnEnregistrerSalle.Click += new System.EventHandler(this.btnEnregistrerSalle_Click);
            // 
            // btnSupprimerSalle
            // 
            this.btnSupprimerSalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerSalle.Location = new System.Drawing.Point(631, 350);
            this.btnSupprimerSalle.Name = "btnSupprimerSalle";
            this.btnSupprimerSalle.Size = new System.Drawing.Size(116, 42);
            this.btnSupprimerSalle.TabIndex = 31;
            this.btnSupprimerSalle.Text = "Supprimer";
            this.btnSupprimerSalle.UseVisualStyleBackColor = true;
            this.btnSupprimerSalle.Click += new System.EventHandler(this.btnSupprimerSalle_Click);
            // 
            // btnAnnulerSalle
            // 
            this.btnAnnulerSalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnulerSalle.Location = new System.Drawing.Point(631, 350);
            this.btnAnnulerSalle.Name = "btnAnnulerSalle";
            this.btnAnnulerSalle.Size = new System.Drawing.Size(116, 42);
            this.btnAnnulerSalle.TabIndex = 30;
            this.btnAnnulerSalle.Text = "Annuler";
            this.btnAnnulerSalle.UseVisualStyleBackColor = true;
            this.btnAnnulerSalle.Click += new System.EventHandler(this.btnAnnulerSalle_Click);
            // 
            // btnModifierSalle
            // 
            this.btnModifierSalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifierSalle.Location = new System.Drawing.Point(477, 350);
            this.btnModifierSalle.Name = "btnModifierSalle";
            this.btnModifierSalle.Size = new System.Drawing.Size(116, 42);
            this.btnModifierSalle.TabIndex = 29;
            this.btnModifierSalle.Text = "Modifier";
            this.btnModifierSalle.UseVisualStyleBackColor = true;
            this.btnModifierSalle.Click += new System.EventHandler(this.btnModifierSalle_Click);
            // 
            // btnRechercheSalle
            // 
            this.btnRechercheSalle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRechercheSalle.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRechercheSalle.Image = ((System.Drawing.Image)(resources.GetObject("btnRechercheSalle.Image")));
            this.btnRechercheSalle.Location = new System.Drawing.Point(322, 33);
            this.btnRechercheSalle.Name = "btnRechercheSalle";
            this.btnRechercheSalle.Size = new System.Drawing.Size(35, 38);
            this.btnRechercheSalle.TabIndex = 28;
            this.btnRechercheSalle.TabStop = false;
            this.btnRechercheSalle.UseVisualStyleBackColor = true;
            this.btnRechercheSalle.Click += new System.EventHandler(this.btnRechercheSalle_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(453, 250);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 27;
            this.label5.Text = "Capacité";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(453, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "Surface en m²";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(453, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 25;
            this.label3.Text = "Type Salle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(453, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 24;
            this.label2.Text = "Nom salle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(451, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 33);
            this.label1.TabIndex = 23;
            this.label1.Text = "Gestion des salles";
            // 
            // tbxCapaciteSalle
            // 
            this.tbxCapaciteSalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxCapaciteSalle.Location = new System.Drawing.Point(589, 247);
            this.tbxCapaciteSalle.Name = "tbxCapaciteSalle";
            this.tbxCapaciteSalle.Size = new System.Drawing.Size(241, 26);
            this.tbxCapaciteSalle.TabIndex = 22;
            // 
            // tbxSurfaceSalle
            // 
            this.tbxSurfaceSalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSurfaceSalle.Location = new System.Drawing.Point(589, 201);
            this.tbxSurfaceSalle.Name = "tbxSurfaceSalle";
            this.tbxSurfaceSalle.Size = new System.Drawing.Size(241, 26);
            this.tbxSurfaceSalle.TabIndex = 21;
            // 
            // tbxNomSalle
            // 
            this.tbxNomSalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNomSalle.Location = new System.Drawing.Point(589, 107);
            this.tbxNomSalle.Name = "tbxNomSalle";
            this.tbxNomSalle.Size = new System.Drawing.Size(241, 26);
            this.tbxNomSalle.TabIndex = 19;
            // 
            // tbxRechercherSalle
            // 
            this.tbxRechercherSalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRechercherSalle.Location = new System.Drawing.Point(98, 36);
            this.tbxRechercherSalle.Name = "tbxRechercherSalle";
            this.tbxRechercherSalle.Size = new System.Drawing.Size(198, 26);
            this.tbxRechercherSalle.TabIndex = 18;
            // 
            // lbxSalles
            // 
            this.lbxSalles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxSalles.FormattingEnabled = true;
            this.lbxSalles.ItemHeight = 20;
            this.lbxSalles.Location = new System.Drawing.Point(98, 91);
            this.lbxSalles.Name = "lbxSalles";
            this.lbxSalles.Size = new System.Drawing.Size(259, 304);
            this.lbxSalles.TabIndex = 17;
            this.lbxSalles.SelectedIndexChanged += new System.EventHandler(this.lbxSalles_SelectedIndexChanged);
            // 
            // cbxTypeSalle
            // 
            this.cbxTypeSalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTypeSalle.FormattingEnabled = true;
            this.cbxTypeSalle.Location = new System.Drawing.Point(589, 153);
            this.cbxTypeSalle.Name = "cbxTypeSalle";
            this.cbxTypeSalle.Size = new System.Drawing.Size(241, 28);
            this.cbxTypeSalle.TabIndex = 34;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(453, 296);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Prix Location";
            // 
            // tbxPrixLocationSalle
            // 
            this.tbxPrixLocationSalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPrixLocationSalle.Location = new System.Drawing.Point(589, 293);
            this.tbxPrixLocationSalle.Name = "tbxPrixLocationSalle";
            this.tbxPrixLocationSalle.Size = new System.Drawing.Size(241, 26);
            this.tbxPrixLocationSalle.TabIndex = 35;
            // 
            // frmSalles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 444);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxPrixLocationSalle);
            this.Controls.Add(this.cbxTypeSalle);
            this.Controls.Add(this.btnAjouterSalle);
            this.Controls.Add(this.btnEnregistrerSalle);
            this.Controls.Add(this.btnSupprimerSalle);
            this.Controls.Add(this.btnAnnulerSalle);
            this.Controls.Add(this.btnModifierSalle);
            this.Controls.Add(this.btnRechercheSalle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxCapaciteSalle);
            this.Controls.Add(this.tbxSurfaceSalle);
            this.Controls.Add(this.tbxNomSalle);
            this.Controls.Add(this.tbxRechercherSalle);
            this.Controls.Add(this.lbxSalles);
            this.Name = "frmSalles";
            this.Text = "Salles";
            this.Load += new System.EventHandler(this.salles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAjouterSalle;
        private System.Windows.Forms.Button btnEnregistrerSalle;
        private System.Windows.Forms.Button btnSupprimerSalle;
        private System.Windows.Forms.Button btnAnnulerSalle;
        private System.Windows.Forms.Button btnModifierSalle;
        private System.Windows.Forms.Button btnRechercheSalle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxCapaciteSalle;
        private System.Windows.Forms.TextBox tbxSurfaceSalle;
        private System.Windows.Forms.TextBox tbxNomSalle;
        private System.Windows.Forms.TextBox tbxRechercherSalle;
        private System.Windows.Forms.ListBox lbxSalles;
        private System.Windows.Forms.ComboBox cbxTypeSalle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxPrixLocationSalle;
    }
}