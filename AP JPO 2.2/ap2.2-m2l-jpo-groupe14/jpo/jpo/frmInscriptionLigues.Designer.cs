
namespace jpo
{
    partial class frmInscriptionLigues
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
            this.tbxLongueurStand = new System.Windows.Forms.TextBox();
            this.tbxRechercheLiguesInscrites = new System.Windows.Forms.TextBox();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.btnModifier = new System.Windows.Forms.Button();
            this.btnEnregistrer = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbxLargeurStand = new System.Windows.Forms.TextBox();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.clbxEquipementSouhaite = new System.Windows.Forms.CheckedListBox();
            this.lbxLiguesNonInscrites = new System.Windows.Forms.ListBox();
            this.tbxRechercheLiguesNonInscrites = new System.Windows.Forms.TextBox();
            this.btnAjouter = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.lbxLiguesInscrites = new System.Windows.Forms.ListBox();
            this.tbxLiguesNonInscrites = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(321, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Inscription ligues";
            // 
            // tbxLongueurStand
            // 
            this.tbxLongueurStand.Location = new System.Drawing.Point(351, 153);
            this.tbxLongueurStand.Name = "tbxLongueurStand";
            this.tbxLongueurStand.Size = new System.Drawing.Size(50, 20);
            this.tbxLongueurStand.TabIndex = 26;
            this.tbxLongueurStand.TextChanged += new System.EventHandler(this.tbxLongueurStand_TextChanged);
            this.tbxLongueurStand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxLongueurStand_KeyPress);
            // 
            // tbxRechercheLiguesInscrites
            // 
            this.tbxRechercheLiguesInscrites.Location = new System.Drawing.Point(131, 98);
            this.tbxRechercheLiguesInscrites.Name = "tbxRechercheLiguesInscrites";
            this.tbxRechercheLiguesInscrites.Size = new System.Drawing.Size(121, 20);
            this.tbxRechercheLiguesInscrites.TabIndex = 25;
            this.tbxRechercheLiguesInscrites.TextChanged += new System.EventHandler(this.tbxRechercheLiguesInscrites_TextChanged);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.Location = new System.Drawing.Point(407, 312);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(110, 35);
            this.btnSupprimer.TabIndex = 21;
            this.btnSupprimer.Text = "Supprimer";
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // btnModifier
            // 
            this.btnModifier.Location = new System.Drawing.Point(280, 312);
            this.btnModifier.Name = "btnModifier";
            this.btnModifier.Size = new System.Drawing.Size(110, 35);
            this.btnModifier.TabIndex = 20;
            this.btnModifier.Text = "Modifier";
            this.btnModifier.UseVisualStyleBackColor = true;
            this.btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // 
            // btnEnregistrer
            // 
            this.btnEnregistrer.Location = new System.Drawing.Point(280, 312);
            this.btnEnregistrer.Name = "btnEnregistrer";
            this.btnEnregistrer.Size = new System.Drawing.Size(110, 35);
            this.btnEnregistrer.TabIndex = 19;
            this.btnEnregistrer.Text = "Enregistrer";
            this.btnEnregistrer.UseVisualStyleBackColor = true;
            this.btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(297, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "longueur";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(407, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "largeur";
            // 
            // tbxLargeurStand
            // 
            this.tbxLargeurStand.Location = new System.Drawing.Point(451, 153);
            this.tbxLargeurStand.Name = "tbxLargeurStand";
            this.tbxLargeurStand.Size = new System.Drawing.Size(50, 20);
            this.tbxLargeurStand.TabIndex = 32;
            this.tbxLargeurStand.TextChanged += new System.EventHandler(this.tbxLargeurStand_TextChanged);
            this.tbxLargeurStand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxLargeurStand_KeyPress);
            // 
            // clbxEquipementSouhaite
            // 
            this.clbxEquipementSouhaite.FormattingEnabled = true;
            this.clbxEquipementSouhaite.Location = new System.Drawing.Point(300, 210);
            this.clbxEquipementSouhaite.Name = "clbxEquipementSouhaite";
            this.clbxEquipementSouhaite.Size = new System.Drawing.Size(201, 94);
            this.clbxEquipementSouhaite.TabIndex = 35;
            this.clbxEquipementSouhaite.SelectedIndexChanged += new System.EventHandler(this.checkedListBox1_SelectedIndexChanged);
            // 
            // lbxLiguesNonInscrites
            // 
            this.lbxLiguesNonInscrites.FormattingEnabled = true;
            this.lbxLiguesNonInscrites.Location = new System.Drawing.Point(552, 131);
            this.lbxLiguesNonInscrites.Name = "lbxLiguesNonInscrites";
            this.lbxLiguesNonInscrites.Size = new System.Drawing.Size(121, 173);
            this.lbxLiguesNonInscrites.TabIndex = 37;
            this.lbxLiguesNonInscrites.SelectedIndexChanged += new System.EventHandler(this.lbxLiguesNonInscrites_SelectedIndexChanged);
            // 
            // tbxRechercheLiguesNonInscrites
            // 
            this.tbxRechercheLiguesNonInscrites.Location = new System.Drawing.Point(552, 98);
            this.tbxRechercheLiguesNonInscrites.Name = "tbxRechercheLiguesNonInscrites";
            this.tbxRechercheLiguesNonInscrites.Size = new System.Drawing.Size(121, 20);
            this.tbxRechercheLiguesNonInscrites.TabIndex = 38;
            this.tbxRechercheLiguesNonInscrites.TextChanged += new System.EventHandler(this.tbxRechercheLiguesNonInscrites_TextChanged);
            // 
            // btnAjouter
            // 
            this.btnAjouter.Location = new System.Drawing.Point(343, 312);
            this.btnAjouter.Name = "btnAjouter";
            this.btnAjouter.Size = new System.Drawing.Size(110, 35);
            this.btnAjouter.TabIndex = 39;
            this.btnAjouter.Text = "Ajouter";
            this.btnAjouter.UseVisualStyleBackColor = true;
            this.btnAjouter.Click += new System.EventHandler(this.btnAjouter_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.Location = new System.Drawing.Point(407, 312);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(110, 35);
            this.btnAnnuler.TabIndex = 40;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = true;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // lbxLiguesInscrites
            // 
            this.lbxLiguesInscrites.FormattingEnabled = true;
            this.lbxLiguesInscrites.Location = new System.Drawing.Point(131, 131);
            this.lbxLiguesInscrites.Name = "lbxLiguesInscrites";
            this.lbxLiguesInscrites.Size = new System.Drawing.Size(121, 173);
            this.lbxLiguesInscrites.TabIndex = 43;
            this.lbxLiguesInscrites.SelectedIndexChanged += new System.EventHandler(this.lbxLiguesInscrites_SelectedIndexChanged);
            // 
            // tbxLiguesNonInscrites
            // 
            this.tbxLiguesNonInscrites.AutoSize = true;
            this.tbxLiguesNonInscrites.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxLiguesNonInscrites.Location = new System.Drawing.Point(545, 75);
            this.tbxLiguesNonInscrites.Name = "tbxLiguesNonInscrites";
            this.tbxLiguesNonInscrites.Size = new System.Drawing.Size(140, 16);
            this.tbxLiguesNonInscrites.TabIndex = 42;
            this.tbxLiguesNonInscrites.Text = "ligues non inscrites";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(137, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 16);
            this.label7.TabIndex = 41;
            this.label7.Text = "ligues inscrites";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(325, 185);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(153, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Equipement(s) souhaité(s)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(323, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Taille du stand souhaitée";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(328, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 16);
            this.label5.TabIndex = 28;
            this.label5.Text = "Informations salles :";
            // 
            // frmInscriptionLigues
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbxLiguesInscrites);
            this.Controls.Add(this.tbxLiguesNonInscrites);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnAjouter);
            this.Controls.Add(this.tbxRechercheLiguesNonInscrites);
            this.Controls.Add(this.lbxLiguesNonInscrites);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.clbxEquipementSouhaite);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxLargeurStand);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxLongueurStand);
            this.Controls.Add(this.tbxRechercheLiguesInscrites);
            this.Controls.Add(this.btnSupprimer);
            this.Controls.Add(this.btnModifier);
            this.Controls.Add(this.btnEnregistrer);
            this.Controls.Add(this.label1);
            this.Name = "frmInscriptionLigues";
            this.Text = "Inscription ligues";
            this.Load += new System.EventHandler(this.frmInscriptionLigues_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxLongueurStand;
        private System.Windows.Forms.TextBox tbxRechercheLiguesInscrites;
        private System.Windows.Forms.Button btnSupprimer;
        private System.Windows.Forms.Button btnModifier;
        private System.Windows.Forms.Button btnEnregistrer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbxLargeurStand;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.CheckedListBox clbxEquipementSouhaite;
        private System.Windows.Forms.ListBox lbxLiguesNonInscrites;
        private System.Windows.Forms.TextBox tbxRechercheLiguesNonInscrites;
        private System.Windows.Forms.Button btnAjouter;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.ListBox lbxLiguesInscrites;
        private System.Windows.Forms.Label tbxLiguesNonInscrites;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
    }
}