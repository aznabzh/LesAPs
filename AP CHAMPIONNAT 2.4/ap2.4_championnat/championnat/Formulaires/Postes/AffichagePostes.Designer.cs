using System.Windows.Forms;

namespace championnat.Formulaires.Postes
{
    partial class AffichagePostes
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
            this.dgvPostes = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPostes
            // 
            this.dgvPostes.AllowUserToAddRows = false;
            this.dgvPostes.AllowUserToDeleteRows = false;
            this.dgvPostes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPostes.Location = new System.Drawing.Point(8, 100);
            this.dgvPostes.Margin = new System.Windows.Forms.Padding(2);
            this.dgvPostes.Name = "dgvPostes";
            this.dgvPostes.ReadOnly = true;
            this.dgvPostes.RowHeadersWidth = 62;
            this.dgvPostes.RowTemplate.Height = 28;
            this.dgvPostes.Size = new System.Drawing.Size(320, 364);
            this.dgvPostes.TabIndex = 0;
            this.dgvPostes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPostes_CellContentClick);
            this.dgvPostes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPostes_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(79, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Les postes";
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
            this.button1.Text = "Créer poste";
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
            this.label2.Location = new System.Drawing.Point(5, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(263, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Pour modifier un  poste, double-cliquez dessus";
            // 
            // AffichagePostes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 500);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvPostes);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AffichagePostes";
            this.Text = "AffichagePostes";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvPostes;
        private Label label1;
        private Button button1;
        private Button button2;
        private Label label2;
    }
}