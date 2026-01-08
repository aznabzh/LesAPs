namespace championnat.Formulaires.fonction
{
    partial class AffichageFonction
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
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvFonctions = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFonctions)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(265, 103);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(490, 25);
            this.label2.TabIndex = 14;
            this.label2.Text = "Pour modifier une fonction, double-cliquez dessus";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.button2.Location = new System.Drawing.Point(864, 223);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(160, 70);
            this.button2.TabIndex = 13;
            this.button2.Text = "Retour";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.button1.Location = new System.Drawing.Point(864, 146);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(160, 70);
            this.button1.TabIndex = 12;
            this.button1.Text = "Créer fonction";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(401, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 39);
            this.label1.TabIndex = 11;
            this.label1.Text = "Les fonction";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // dgvFonctions
            // 
            this.dgvFonctions.AllowUserToAddRows = false;
            this.dgvFonctions.AllowUserToDeleteRows = false;
            this.dgvFonctions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFonctions.Location = new System.Drawing.Point(236, 146);
            this.dgvFonctions.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFonctions.Name = "dgvFonctions";
            this.dgvFonctions.ReadOnly = true;
            this.dgvFonctions.RowHeadersWidth = 62;
            this.dgvFonctions.RowTemplate.Height = 28;
            this.dgvFonctions.Size = new System.Drawing.Size(587, 672);
            this.dgvFonctions.TabIndex = 16;
            this.dgvFonctions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFonctions_CellContentClick);

            this.dgvFonctions.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFonctions_CellContentClick);
            this.dgvFonctions.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFonctions_CellDoubleClick);

            // 
            // AffichageFonction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 831);
            this.Controls.Add(this.dgvFonctions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "AffichageFonction";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFonctions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFonctions;
    }
}