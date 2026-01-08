
namespace jpo
{
    partial class frmEnregistrementLigues
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbxLigues = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxRechercheLigues = new System.Windows.Forms.TextBox();
            this.tbxNomLigue = new System.Windows.Forms.TextBox();
            this.tbxAdresseLigue = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.btnAnnulerLigue = new System.Windows.Forms.Button();
            this.btnAjouterLigue = new System.Windows.Forms.Button();
            this.btnSupprimerLigue = new System.Windows.Forms.Button();
            this.btnModifierLigue = new System.Windows.Forms.Button();
            this.btnEnregistrerLigue = new System.Windows.Forms.Button();
            this.tbxDisciplines = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(299, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(199, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enregistrement ligues";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lbxLigues
            // 
            this.lbxLigues.FormattingEnabled = true;
            this.lbxLigues.Location = new System.Drawing.Point(229, 136);
            this.lbxLigues.Name = "lbxLigues";
            this.lbxLigues.Size = new System.Drawing.Size(121, 134);
            this.lbxLigues.TabIndex = 1;
            this.lbxLigues.SelectedIndexChanged += new System.EventHandler(this.lbxLigues_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(401, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Nom";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(380, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Adresse";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(371, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Discipline";
            // 
            // tbxRechercheLigues
            // 
            this.tbxRechercheLigues.Location = new System.Drawing.Point(228, 107);
            this.tbxRechercheLigues.Name = "tbxRechercheLigues";
            this.tbxRechercheLigues.Size = new System.Drawing.Size(121, 20);
            this.tbxRechercheLigues.TabIndex = 12;
            this.tbxRechercheLigues.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // tbxNomLigue
            // 
            this.tbxNomLigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbxNomLigue.Location = new System.Drawing.Point(448, 152);
            this.tbxNomLigue.Name = "tbxNomLigue";
            this.tbxNomLigue.Size = new System.Drawing.Size(121, 26);
            this.tbxNomLigue.TabIndex = 13;
            this.tbxNomLigue.TextChanged += new System.EventHandler(this.tbxNomLigue_TextChanged);
            this.tbxNomLigue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxNomLigue_KeyPress);
            // 
            // tbxAdresseLigue
            // 
            this.tbxAdresseLigue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbxAdresseLigue.Location = new System.Drawing.Point(448, 194);
            this.tbxAdresseLigue.Name = "tbxAdresseLigue";
            this.tbxAdresseLigue.Size = new System.Drawing.Size(121, 26);
            this.tbxAdresseLigue.TabIndex = 14;
            this.tbxAdresseLigue.TextChanged += new System.EventHandler(this.tbxAdresseLigue_TextChanged);
            this.tbxAdresseLigue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxAdresseLigue_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(425, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 16);
            this.label5.TabIndex = 16;
            this.label5.Text = "Informations ligues :";
            // 
            // btnAnnulerLigue
            // 
            this.btnAnnulerLigue.Location = new System.Drawing.Point(347, 285);
            this.btnAnnulerLigue.Name = "btnAnnulerLigue";
            this.btnAnnulerLigue.Size = new System.Drawing.Size(110, 35);
            this.btnAnnulerLigue.TabIndex = 45;
            this.btnAnnulerLigue.Text = "Annuler";
            this.btnAnnulerLigue.UseVisualStyleBackColor = true;
            this.btnAnnulerLigue.Click += new System.EventHandler(this.btnAnnulerLigue_Click);
            // 
            // btnAjouterLigue
            // 
            this.btnAjouterLigue.Location = new System.Drawing.Point(231, 285);
            this.btnAjouterLigue.Name = "btnAjouterLigue";
            this.btnAjouterLigue.Size = new System.Drawing.Size(110, 35);
            this.btnAjouterLigue.TabIndex = 44;
            this.btnAjouterLigue.Text = "Ajouter";
            this.btnAjouterLigue.UseVisualStyleBackColor = true;
            this.btnAjouterLigue.Click += new System.EventHandler(this.btnAjouterLigue_Click);
            // 
            // btnSupprimerLigue
            // 
            this.btnSupprimerLigue.Location = new System.Drawing.Point(457, 285);
            this.btnSupprimerLigue.Name = "btnSupprimerLigue";
            this.btnSupprimerLigue.Size = new System.Drawing.Size(110, 35);
            this.btnSupprimerLigue.TabIndex = 43;
            this.btnSupprimerLigue.Text = "Supprimer";
            this.btnSupprimerLigue.UseVisualStyleBackColor = true;
            this.btnSupprimerLigue.Click += new System.EventHandler(this.btnSupprimerLigue_Click);
            // 
            // btnModifierLigue
            // 
            this.btnModifierLigue.Location = new System.Drawing.Point(347, 285);
            this.btnModifierLigue.Name = "btnModifierLigue";
            this.btnModifierLigue.Size = new System.Drawing.Size(110, 35);
            this.btnModifierLigue.TabIndex = 42;
            this.btnModifierLigue.Text = "Modifier";
            this.btnModifierLigue.UseVisualStyleBackColor = true;
            this.btnModifierLigue.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnEnregistrerLigue
            // 
            this.btnEnregistrerLigue.Location = new System.Drawing.Point(457, 285);
            this.btnEnregistrerLigue.Name = "btnEnregistrerLigue";
            this.btnEnregistrerLigue.Size = new System.Drawing.Size(110, 35);
            this.btnEnregistrerLigue.TabIndex = 41;
            this.btnEnregistrerLigue.Text = "Enregistrer";
            this.btnEnregistrerLigue.UseVisualStyleBackColor = true;
            this.btnEnregistrerLigue.Click += new System.EventHandler(this.btnEnregistrerLigue_Click);
            // 
            // tbxDisciplines
            // 
            this.tbxDisciplines.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbxDisciplines.Location = new System.Drawing.Point(448, 236);
            this.tbxDisciplines.Name = "tbxDisciplines";
            this.tbxDisciplines.Size = new System.Drawing.Size(121, 26);
            this.tbxDisciplines.TabIndex = 46;
            this.tbxDisciplines.TextChanged += new System.EventHandler(this.tbxDisciplines_TextChanged_1);
            // 
            // frmEnregistrementLigues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tbxDisciplines);
            this.Controls.Add(this.btnAnnulerLigue);
            this.Controls.Add(this.btnAjouterLigue);
            this.Controls.Add(this.btnSupprimerLigue);
            this.Controls.Add(this.btnModifierLigue);
            this.Controls.Add(this.btnEnregistrerLigue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxAdresseLigue);
            this.Controls.Add(this.tbxNomLigue);
            this.Controls.Add(this.tbxRechercheLigues);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbxLigues);
            this.Controls.Add(this.label1);
            this.Name = "frmEnregistrementLigues";
            this.Text = "Enregistrement ligues";
            this.Load += new System.EventHandler(this.frmEnregistrementLigues_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxLigues;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxRechercheLigues;
        private System.Windows.Forms.TextBox tbxNomLigue;
        private System.Windows.Forms.TextBox tbxAdresseLigue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Button btnAnnulerLigue;
        private System.Windows.Forms.Button btnAjouterLigue;
        private System.Windows.Forms.Button btnSupprimerLigue;
        private System.Windows.Forms.Button btnModifierLigue;
        private System.Windows.Forms.Button btnEnregistrerLigue;
        private System.Windows.Forms.TextBox tbxDisciplines;
    }
}