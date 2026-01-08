namespace championnat.Formulaires.Matches
{
    partial class GestionMatches
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
            this.btnNextNumero = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAnnuler = new System.Windows.Forms.Button();
            this.btnValider = new System.Windows.Forms.Button();
            this.lblForNumero = new System.Windows.Forms.Label();
            this.lblDateNaiss = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbxNumero = new System.Windows.Forms.TextBox();
            this.tbxScoreEquipe2 = new System.Windows.Forms.TextBox();
            this.tbxScoreEquipe1 = new System.Windows.Forms.TextBox();
            this.tbxLieuMatch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLieuMatch = new System.Windows.Forms.Label();
            this.lblPrenom = new System.Windows.Forms.Label();
            this.lblNom = new System.Windows.Forms.Label();
            this.tbxDateMatch = new System.Windows.Forms.TextBox();
            this.lblArbitres = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.tbxCodeEquipe1 = new System.Windows.Forms.TextBox();
            this.tbxCodeEquipe2 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitre
            // 
            this.lblTitre.AutoSize = true;
            this.lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitre.Location = new System.Drawing.Point(104, 168);
            this.lblTitre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitre.Name = "lblTitre";
            this.lblTitre.Size = new System.Drawing.Size(240, 39);
            this.lblTitre.TabIndex = 10;
            this.lblTitre.Text = "Edition Match";
            this.lblTitre.Click += new System.EventHandler(this.lblTitre_Click);
            // 
            // btnNextNumero
            // 
            this.btnNextNumero.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnNextNumero.Location = new System.Drawing.Point(572, 314);
            this.btnNextNumero.Margin = new System.Windows.Forms.Padding(4);
            this.btnNextNumero.Name = "btnNextNumero";
            this.btnNextNumero.Size = new System.Drawing.Size(126, 111);
            this.btnNextNumero.TabIndex = 15;
            this.btnNextNumero.Text = "Générer prochain numéro disponible";
            this.btnNextNumero.UseVisualStyleBackColor = false;
            this.btnNextNumero.Visible = false;
            this.btnNextNumero.Click += new System.EventHandler(this.btnNextNumero_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnDelete.Location = new System.Drawing.Point(572, 236);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(126, 70);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Supprimer Match";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAnnuler
            // 
            this.btnAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnAnnuler.Location = new System.Drawing.Point(409, 988);
            this.btnAnnuler.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnnuler.Name = "btnAnnuler";
            this.btnAnnuler.Size = new System.Drawing.Size(156, 55);
            this.btnAnnuler.TabIndex = 13;
            this.btnAnnuler.Text = "Annuler";
            this.btnAnnuler.UseVisualStyleBackColor = false;
            this.btnAnnuler.Click += new System.EventHandler(this.btnAnnuler_Click);
            // 
            // btnValider
            // 
            this.btnValider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnValider.Location = new System.Drawing.Point(156, 988);
            this.btnValider.Margin = new System.Windows.Forms.Padding(4);
            this.btnValider.Name = "btnValider";
            this.btnValider.Size = new System.Drawing.Size(156, 55);
            this.btnValider.TabIndex = 12;
            this.btnValider.Text = "Valider";
            this.btnValider.UseVisualStyleBackColor = false;
            this.btnValider.Click += new System.EventHandler(this.btnValider_Click);
            // 
            // lblForNumero
            // 
            this.lblForNumero.AutoSize = true;
            this.lblForNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblForNumero.Location = new System.Drawing.Point(4, 37);
            this.lblForNumero.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblForNumero.Name = "lblForNumero";
            this.lblForNumero.Size = new System.Drawing.Size(89, 32);
            this.lblForNumero.TabIndex = 1;
            this.lblForNumero.Text = "Date :";
            // 
            // lblDateNaiss
            // 
            this.lblDateNaiss.AutoSize = true;
            this.lblDateNaiss.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateNaiss.Location = new System.Drawing.Point(4, 111);
            this.lblDateNaiss.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateNaiss.Name = "lblDateNaiss";
            this.lblDateNaiss.Size = new System.Drawing.Size(142, 32);
            this.lblDateNaiss.TabIndex = 7;
            this.lblDateNaiss.Text = "Equipe 1 :";
            this.lblDateNaiss.Click += new System.EventHandler(this.lblDateNaiss_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(4, 148);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "Equipe 2 :";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.tbxCodeEquipe2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbxCodeEquipe1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbxNumero, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbxScoreEquipe2, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbxScoreEquipe1, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbxLieuMatch, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblForNumero, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLieuMatch, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblPrenom, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblDateNaiss, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblNom, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbxDateMatch, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(35, 236);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(530, 319);
            this.tableLayoutPanel1.TabIndex = 11;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // tbxNumero
            // 
            this.tbxNumero.Location = new System.Drawing.Point(242, 4);
            this.tbxNumero.Margin = new System.Windows.Forms.Padding(4);
            this.tbxNumero.Name = "tbxNumero";
            this.tbxNumero.Size = new System.Drawing.Size(266, 29);
            this.tbxNumero.TabIndex = 34;
            this.tbxNumero.TextChanged += new System.EventHandler(this.tbxNumero_TextChanged);
            this.tbxNumero.Enter += new System.EventHandler(this.tbxNumero_Enter);
            this.tbxNumero.Leave += new System.EventHandler(this.tbxNumero_Leave);
            // 
            // tbxScoreEquipe2
            // 
            this.tbxScoreEquipe2.Location = new System.Drawing.Point(242, 226);
            this.tbxScoreEquipe2.Margin = new System.Windows.Forms.Padding(4);
            this.tbxScoreEquipe2.Name = "tbxScoreEquipe2";
            this.tbxScoreEquipe2.Size = new System.Drawing.Size(266, 29);
            this.tbxScoreEquipe2.TabIndex = 31;
            this.tbxScoreEquipe2.TextChanged += new System.EventHandler(this.tbxScoreEquipe2_TextChanged_1);
            // 
            // tbxScoreEquipe1
            // 
            this.tbxScoreEquipe1.Location = new System.Drawing.Point(242, 189);
            this.tbxScoreEquipe1.Margin = new System.Windows.Forms.Padding(4);
            this.tbxScoreEquipe1.Name = "tbxScoreEquipe1";
            this.tbxScoreEquipe1.Size = new System.Drawing.Size(266, 29);
            this.tbxScoreEquipe1.TabIndex = 30;
            this.tbxScoreEquipe1.TextChanged += new System.EventHandler(this.tbxScoreEquipe1_TextChanged_1);
            // 
            // tbxLieuMatch
            // 
            this.tbxLieuMatch.Location = new System.Drawing.Point(242, 78);
            this.tbxLieuMatch.Margin = new System.Windows.Forms.Padding(4);
            this.tbxLieuMatch.Name = "tbxLieuMatch";
            this.tbxLieuMatch.Size = new System.Drawing.Size(266, 29);
            this.tbxLieuMatch.TabIndex = 27;
            this.tbxLieuMatch.TextChanged += new System.EventHandler(this.tbxLieuMatch_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(132, 32);
            this.label2.TabIndex = 12;
            this.label2.Text = "numéro : ";
            // 
            // lblLieuMatch
            // 
            this.lblLieuMatch.AutoSize = true;
            this.lblLieuMatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLieuMatch.Location = new System.Drawing.Point(4, 74);
            this.lblLieuMatch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLieuMatch.Name = "lblLieuMatch";
            this.lblLieuMatch.Size = new System.Drawing.Size(84, 32);
            this.lblLieuMatch.TabIndex = 10;
            this.lblLieuMatch.Text = "Lieu :";
            // 
            // lblPrenom
            // 
            this.lblPrenom.AutoSize = true;
            this.lblPrenom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrenom.Location = new System.Drawing.Point(4, 222);
            this.lblPrenom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrenom.Name = "lblPrenom";
            this.lblPrenom.Size = new System.Drawing.Size(223, 32);
            this.lblPrenom.TabIndex = 5;
            this.lblPrenom.Text = "Score Equipe 2 :";
            // 
            // lblNom
            // 
            this.lblNom.AutoSize = true;
            this.lblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNom.Location = new System.Drawing.Point(4, 185);
            this.lblNom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNom.Name = "lblNom";
            this.lblNom.Size = new System.Drawing.Size(230, 32);
            this.lblNom.TabIndex = 3;
            this.lblNom.Text = "Score Equipe 1 : ";
            // 
            // tbxDateMatch
            // 
            this.tbxDateMatch.Location = new System.Drawing.Point(242, 41);
            this.tbxDateMatch.Margin = new System.Windows.Forms.Padding(4);
            this.tbxDateMatch.Name = "tbxDateMatch";
            this.tbxDateMatch.Size = new System.Drawing.Size(266, 29);
            this.tbxDateMatch.TabIndex = 26;
            this.tbxDateMatch.TextChanged += new System.EventHandler(this.tbxDateMatch_TextChanged);
            // 
            // lblArbitres
            // 
            this.lblArbitres.AutoSize = true;
            this.lblArbitres.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArbitres.Location = new System.Drawing.Point(38, 620);
            this.lblArbitres.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblArbitres.Name = "lblArbitres";
            this.lblArbitres.Size = new System.Drawing.Size(95, 32);
            this.lblArbitres.TabIndex = 12;
            this.lblArbitres.Text = "arbitre";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(156, 618);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(246, 32);
            this.comboBox1.TabIndex = 17;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 670);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 32);
            this.label3.TabIndex = 19;
            this.label3.Text = "fonction";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(424, 751);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 42);
            this.button1.TabIndex = 20;
            this.button1.Text = "ajouter";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(424, 805);
            this.button3.Margin = new System.Windows.Forms.Padding(6);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button3.Size = new System.Drawing.Size(126, 42);
            this.button3.TabIndex = 22;
            this.button3.Text = "supprimer";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(46, 718);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 72;
            this.dataGridView1.Size = new System.Drawing.Size(359, 179);
            this.dataGridView1.TabIndex = 23;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(156, 674);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(6);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(246, 32);
            this.comboBox2.TabIndex = 24;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // tbxCodeEquipe1
            // 
            this.tbxCodeEquipe1.Location = new System.Drawing.Point(242, 115);
            this.tbxCodeEquipe1.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCodeEquipe1.Name = "tbxCodeEquipe1";
            this.tbxCodeEquipe1.Size = new System.Drawing.Size(266, 29);
            this.tbxCodeEquipe1.TabIndex = 35;
            this.tbxCodeEquipe1.TextChanged += new System.EventHandler(this.tbxCodeEquipe1_TextChanged);
            // 
            // tbxCodeEquipe2
            // 
            this.tbxCodeEquipe2.Location = new System.Drawing.Point(242, 152);
            this.tbxCodeEquipe2.Margin = new System.Windows.Forms.Padding(4);
            this.tbxCodeEquipe2.Name = "tbxCodeEquipe2";
            this.tbxCodeEquipe2.Size = new System.Drawing.Size(266, 29);
            this.tbxCodeEquipe2.TabIndex = 36;
            this.tbxCodeEquipe2.TextChanged += new System.EventHandler(this.tbxCodeEquipe2_TextChanged);
            // 
            // GestionMatches
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1016, 1119);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.lblArbitres);
            this.Controls.Add(this.lblTitre);
            this.Controls.Add(this.btnNextNumero);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAnnuler);
            this.Controls.Add(this.btnValider);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "GestionMatches";
            this.Text = "GestionMatches";
            this.Load += new System.EventHandler(this.GestionMatches_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.Button btnNextNumero;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAnnuler;
        private System.Windows.Forms.Button btnValider;
        private System.Windows.Forms.Label lblForNumero;
        private System.Windows.Forms.Label lblDateNaiss;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblPrenom;
        private System.Windows.Forms.Label lblNom;
        private System.Windows.Forms.Label lblLieuMatch;
        private System.Windows.Forms.Label lblArbitres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox tbxLieuMatch;
        private System.Windows.Forms.TextBox tbxDateMatch;
        private System.Windows.Forms.TextBox tbxScoreEquipe1;
        private System.Windows.Forms.TextBox tbxScoreEquipe2;
        private System.Windows.Forms.TextBox tbxNumero;
        private System.Windows.Forms.TextBox tbxCodeEquipe2;
        private System.Windows.Forms.TextBox tbxCodeEquipe1;
    }
}