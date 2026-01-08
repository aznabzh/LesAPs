
namespace reservationSalles2018
{
    partial class frmLigues
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLigues));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxMailLigue = new System.Windows.Forms.TextBox();
            this.tbxTelephoneLigue = new System.Windows.Forms.TextBox();
            this.tbxNomLigue = new System.Windows.Forms.TextBox();
            this.btnAjouterLigue = new System.Windows.Forms.Button();
            this.btnEnregistrerLigue = new System.Windows.Forms.Button();
            this.btnSupprimerLigue = new System.Windows.Forms.Button();
            this.btnAnnulerLigue = new System.Windows.Forms.Button();
            this.btnModifierLigue = new System.Windows.Forms.Button();
            this.btnRechercherLigue = new System.Windows.Forms.Button();
            this.tbxRechercherLigue = new System.Windows.Forms.TextBox();
            this.lbxLigues = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(446, 234);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 73;
            this.label4.Text = "Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(446, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 20);
            this.label3.TabIndex = 72;
            this.label3.Text = "Téléphone";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(446, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 71;
            this.label2.Text = "Nom";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(441, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(274, 33);
            this.label1.TabIndex = 70;
            this.label1.Text = "Gestion des ligues";
            // 
            // tbxMailLigue
            // 
            this.tbxMailLigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxMailLigue.Location = new System.Drawing.Point(579, 231);
            this.tbxMailLigue.Name = "tbxMailLigue";
            this.tbxMailLigue.Size = new System.Drawing.Size(241, 26);
            this.tbxMailLigue.TabIndex = 69;
            // 
            // tbxTelephoneLigue
            // 
            this.tbxTelephoneLigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTelephoneLigue.Location = new System.Drawing.Point(579, 175);
            this.tbxTelephoneLigue.Name = "tbxTelephoneLigue";
            this.tbxTelephoneLigue.Size = new System.Drawing.Size(241, 26);
            this.tbxTelephoneLigue.TabIndex = 68;
            // 
            // tbxNomLigue
            // 
            this.tbxNomLigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxNomLigue.Location = new System.Drawing.Point(579, 119);
            this.tbxNomLigue.Name = "tbxNomLigue";
            this.tbxNomLigue.Size = new System.Drawing.Size(241, 26);
            this.tbxNomLigue.TabIndex = 67;
            this.tbxNomLigue.Validating += new System.ComponentModel.CancelEventHandler(this.tbxNomLigue_Validating);
            // 
            // btnAjouterLigue
            // 
            this.btnAjouterLigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAjouterLigue.Location = new System.Drawing.Point(794, 314);
            this.btnAjouterLigue.Name = "btnAjouterLigue";
            this.btnAjouterLigue.Size = new System.Drawing.Size(116, 42);
            this.btnAjouterLigue.TabIndex = 66;
            this.btnAjouterLigue.Text = "Ajouter";
            this.btnAjouterLigue.UseVisualStyleBackColor = true;
            this.btnAjouterLigue.Click += new System.EventHandler(this.btnAjouterLigue_Click);
            // 
            // btnEnregistrerLigue
            // 
            this.btnEnregistrerLigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnregistrerLigue.Location = new System.Drawing.Point(745, 339);
            this.btnEnregistrerLigue.Name = "btnEnregistrerLigue";
            this.btnEnregistrerLigue.Size = new System.Drawing.Size(116, 42);
            this.btnEnregistrerLigue.TabIndex = 65;
            this.btnEnregistrerLigue.Text = "Enregistrer";
            this.btnEnregistrerLigue.UseVisualStyleBackColor = true;
            this.btnEnregistrerLigue.Click += new System.EventHandler(this.btnEnregistrerLigue_Click);
            // 
            // btnSupprimerLigue
            // 
            this.btnSupprimerLigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSupprimerLigue.Location = new System.Drawing.Point(594, 339);
            this.btnSupprimerLigue.Name = "btnSupprimerLigue";
            this.btnSupprimerLigue.Size = new System.Drawing.Size(116, 42);
            this.btnSupprimerLigue.TabIndex = 64;
            this.btnSupprimerLigue.Text = "Supprimer";
            this.btnSupprimerLigue.UseVisualStyleBackColor = true;
            this.btnSupprimerLigue.Click += new System.EventHandler(this.btnSupprimerLigue_Click);
            // 
            // btnAnnulerLigue
            // 
            this.btnAnnulerLigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnnulerLigue.Location = new System.Drawing.Point(594, 339);
            this.btnAnnulerLigue.Name = "btnAnnulerLigue";
            this.btnAnnulerLigue.Size = new System.Drawing.Size(116, 42);
            this.btnAnnulerLigue.TabIndex = 63;
            this.btnAnnulerLigue.Text = "Annuler";
            this.btnAnnulerLigue.UseVisualStyleBackColor = true;
            this.btnAnnulerLigue.Click += new System.EventHandler(this.btnAnnulerLigue_Click);
            // 
            // btnModifierLigue
            // 
            this.btnModifierLigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModifierLigue.Location = new System.Drawing.Point(447, 339);
            this.btnModifierLigue.Name = "btnModifierLigue";
            this.btnModifierLigue.Size = new System.Drawing.Size(116, 42);
            this.btnModifierLigue.TabIndex = 62;
            this.btnModifierLigue.Text = "Modifier";
            this.btnModifierLigue.UseVisualStyleBackColor = true;
            this.btnModifierLigue.Click += new System.EventHandler(this.btnModifierLigue_Click);
            // 
            // btnRechercherLigue
            // 
            this.btnRechercherLigue.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRechercherLigue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRechercherLigue.Image = ((System.Drawing.Image)(resources.GetObject("btnRechercherLigue.Image")));
            this.btnRechercherLigue.Location = new System.Drawing.Point(300, 32);
            this.btnRechercherLigue.Name = "btnRechercherLigue";
            this.btnRechercherLigue.Size = new System.Drawing.Size(35, 38);
            this.btnRechercherLigue.TabIndex = 61;
            this.btnRechercherLigue.TabStop = false;
            this.btnRechercherLigue.UseVisualStyleBackColor = true;
            this.btnRechercherLigue.Click += new System.EventHandler(this.btnRechercherLigue_Click);
            // 
            // tbxRechercherLigue
            // 
            this.tbxRechercherLigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRechercherLigue.Location = new System.Drawing.Point(35, 37);
            this.tbxRechercherLigue.Name = "tbxRechercherLigue";
            this.tbxRechercherLigue.Size = new System.Drawing.Size(244, 26);
            this.tbxRechercherLigue.TabIndex = 60;
            // 
            // lbxLigues
            // 
            this.lbxLigues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbxLigues.FormattingEnabled = true;
            this.lbxLigues.ItemHeight = 20;
            this.lbxLigues.Location = new System.Drawing.Point(35, 92);
            this.lbxLigues.Name = "lbxLigues";
            this.lbxLigues.Size = new System.Drawing.Size(300, 304);
            this.lbxLigues.TabIndex = 59;
            this.lbxLigues.SelectedIndexChanged += new System.EventHandler(this.lbxLigues_SelectedIndexChanged);
            // 
            // frmLigues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 450);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxMailLigue);
            this.Controls.Add(this.tbxTelephoneLigue);
            this.Controls.Add(this.tbxNomLigue);
            this.Controls.Add(this.btnAjouterLigue);
            this.Controls.Add(this.btnEnregistrerLigue);
            this.Controls.Add(this.btnSupprimerLigue);
            this.Controls.Add(this.btnAnnulerLigue);
            this.Controls.Add(this.btnModifierLigue);
            this.Controls.Add(this.btnRechercherLigue);
            this.Controls.Add(this.tbxRechercherLigue);
            this.Controls.Add(this.lbxLigues);
            this.Name = "frmLigues";
            this.Text = "ligues";
            this.Load += new System.EventHandler(this.frmLigues_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxMailLigue;
        private System.Windows.Forms.TextBox tbxTelephoneLigue;
        private System.Windows.Forms.TextBox tbxNomLigue;
        private System.Windows.Forms.Button btnAjouterLigue;
        private System.Windows.Forms.Button btnEnregistrerLigue;
        private System.Windows.Forms.Button btnSupprimerLigue;
        private System.Windows.Forms.Button btnAnnulerLigue;
        private System.Windows.Forms.Button btnModifierLigue;
        private System.Windows.Forms.Button btnRechercherLigue;
        private System.Windows.Forms.TextBox tbxRechercherLigue;
        private System.Windows.Forms.ListBox lbxLigues;
    }
}