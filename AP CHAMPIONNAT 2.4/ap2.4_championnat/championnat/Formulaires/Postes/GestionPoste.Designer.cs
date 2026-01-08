namespace championnat.Formulaires.Postes
{
    partial class GestionPoste
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
            this.lblcode = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbxCode = new System.Windows.Forms.TextBox();
            this.lblLibelle = new System.Windows.Forms.Label();
            this.tbxLibelle = new System.Windows.Forms.TextBox();
            this.btnValider = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(183, 16);
            this.lblTitre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(139, 25);
            this.lblTitre.TabIndex = 0;
            this.lblTitre.Text = "Edition Poste";
            this.lblTitre.Click += new System.EventHandler(this.lblTitre_Click);
            // 
            // lblcode
            // 
            this.lblcode.AutoSize = true;
            this.lblcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcode.Location = new System.Drawing.Point(2, 0);
            this.lblcode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblcode.Name = "lblcode";
            this.lblcode.Size = new System.Drawing.Size(47, 20);
            this.lblcode.TabIndex = 1;
            this.lblcode.Text = "Code";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tbxCode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblcode, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLibelle, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbxLibelle, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(87, 56);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(272, 72);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tbxCode
            // 
            this.tbxCode.Location = new System.Drawing.Point(68, 2);
            this.tbxCode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxCode.Name = "tbxCode";
            this.tbxCode.Size = new System.Drawing.Size(199, 20);
            this.tbxCode.TabIndex = 0;
            // 
            // lblLibelle
            // 
            this.lblLibelle.AutoSize = true;
            this.lblLibelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLibelle.Location = new System.Drawing.Point(2, 36);
            this.lblLibelle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLibelle.Name = "lblLibelle";
            this.lblLibelle.Size = new System.Drawing.Size(62, 20);
            this.lblLibelle.TabIndex = 3;
            this.lblLibelle.Text = "Libelle :";
            // 
            // tbxLibelle
            // 
            this.tbxLibelle.Location = new System.Drawing.Point(68, 38);
            this.tbxLibelle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbxLibelle.Name = "tbxLibelle";
            this.tbxLibelle.Size = new System.Drawing.Size(199, 20);
            this.tbxLibelle.TabIndex = 1;
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnValider.Location = new System.Drawing.Point(92, 154);
            this.btnValider.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(85, 30);
            this.btnValider.TabIndex = 2;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAnnuler.Location = new System.Drawing.Point(271, 154);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(85, 30);
            this.btnAnnuler.TabIndex = 3;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.Location = new System.Drawing.Point(373, 56);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 44);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Supprimer poste";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // GestionPoste
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 221);
            this.ControlBox = false;
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.lblTitre);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GestionPoste";
            this.Text = "EditionPoste";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Label lblcode;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblLibelle;
        private System.Windows.Forms.TextBox tbxLibelle;
        private System.Windows.Forms.TextBox tbxCode;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnDelete;
    }
}