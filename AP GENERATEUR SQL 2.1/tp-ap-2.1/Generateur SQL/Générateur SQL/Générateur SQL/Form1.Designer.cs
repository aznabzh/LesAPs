namespace Générateur_SQL
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            lblTitre = new Label();
            pictureBox1 = new PictureBox();
            lbxListeFichiers = new ListBox();
            FBD = new FolderBrowserDialog();
            btnOFD = new Button();
            OFD = new OpenFileDialog();
            lbxContenuFichier = new ListBox();
            btnSFD = new Button();
            tbxMonTexte = new TextBox();
            SFD = new SaveFileDialog();
            btnGenererSQL = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitre
            // 
            lblTitre.AutoSize = true;
            lblTitre.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitre.Location = new Point(312, 24);
            lblTitre.Name = "lblTitre";
            lblTitre.Size = new Size(173, 40);
            lblTitre.TabIndex = 0;
            lblTitre.Text = "Générateur";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(482, 24);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(59, 40);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // lbxListeFichiers
            // 
            lbxListeFichiers.FormattingEnabled = true;
            lbxListeFichiers.ItemHeight = 15;
            lbxListeFichiers.Location = new Point(324, 387);
            lbxListeFichiers.Name = "lbxListeFichiers";
            lbxListeFichiers.Size = new Size(201, 214);
            lbxListeFichiers.TabIndex = 2;
            // 
            // btnOFD
            // 
            btnOFD.BackColor = SystemColors.GradientActiveCaption;
            btnOFD.FlatStyle = FlatStyle.Flat;
            btnOFD.Font = new Font("Segoe UI", 12F);
            btnOFD.Location = new Point(50, 99);
            btnOFD.Name = "btnOFD";
            btnOFD.Size = new Size(201, 50);
            btnOFD.TabIndex = 5;
            btnOFD.Text = "Ouvrir contenu du fichier";
            btnOFD.UseVisualStyleBackColor = false;
            btnOFD.Click += btnOFD_Click;
            // 
            // OFD
            // 
            OFD.FileName = "openFileDialog1";
            // 
            // lbxContenuFichier
            // 
            lbxContenuFichier.FormattingEnabled = true;
            lbxContenuFichier.ItemHeight = 15;
            lbxContenuFichier.Location = new Point(50, 155);
            lbxContenuFichier.Name = "lbxContenuFichier";
            lbxContenuFichier.Size = new Size(201, 244);
            lbxContenuFichier.TabIndex = 6;
            // 
            // btnSFD
            // 
            btnSFD.BackColor = SystemColors.GradientActiveCaption;
            btnSFD.FlatStyle = FlatStyle.Flat;
            btnSFD.Font = new Font("Segoe UI", 12F);
            btnSFD.Location = new Point(605, 99);
            btnSFD.Name = "btnSFD";
            btnSFD.Size = new Size(240, 50);
            btnSFD.TabIndex = 7;
            btnSFD.Text = "Sauvegarder fichier";
            btnSFD.UseVisualStyleBackColor = false;
            btnSFD.Click += btnSFD_Click;
            // 
            // tbxMonTexte
            // 
            tbxMonTexte.Cursor = Cursors.IBeam;
            tbxMonTexte.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbxMonTexte.Location = new Point(605, 156);
            tbxMonTexte.MaximumSize = new Size(394, 264);
            tbxMonTexte.Multiline = true;
            tbxMonTexte.Name = "tbxMonTexte";
            tbxMonTexte.Size = new Size(240, 244);
            tbxMonTexte.TabIndex = 8;
            // 
            // btnGenererSQL
            // 
            btnGenererSQL.BackColor = SystemColors.GradientActiveCaption;
            btnGenererSQL.FlatStyle = FlatStyle.Flat;
            btnGenererSQL.Font = new Font("Segoe UI", 12F);
            btnGenererSQL.Location = new Point(324, 237);
            btnGenererSQL.Name = "btnGenererSQL";
            btnGenererSQL.Size = new Size(201, 50);
            btnGenererSQL.TabIndex = 9;
            btnGenererSQL.Text = "Générer SQL";
            btnGenererSQL.UseVisualStyleBackColor = false;
            btnGenererSQL.Click += btnGenererSQL_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(336, 344);
            label1.Name = "label1";
            label1.Size = new Size(161, 40);
            label1.TabIndex = 10;
            label1.Text = "Historique";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LemonChiffon;
            ClientSize = new Size(886, 613);
            Controls.Add(label1);
            Controls.Add(btnGenererSQL);
            Controls.Add(tbxMonTexte);
            Controls.Add(btnSFD);
            Controls.Add(lbxContenuFichier);
            Controls.Add(btnOFD);
            Controls.Add(lbxListeFichiers);
            Controls.Add(pictureBox1);
            Controls.Add(lblTitre);
            ForeColor = SystemColors.ActiveCaptionText;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "SQL Generator by CCD";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnGenererSQL;
        private System.Windows.Forms.Label lblTitre;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ListBox lbxListeFichiers;
        private System.Windows.Forms.FolderBrowserDialog FBD;
        private System.Windows.Forms.Button btnOFD;
        private System.Windows.Forms.OpenFileDialog OFD;
        private System.Windows.Forms.ListBox lbxContenuFichier;
        private System.Windows.Forms.Button btnSFD;
        private System.Windows.Forms.TextBox tbxMonTexte;
        private SaveFileDialog SFD;
        private Label label1;
    }
}
