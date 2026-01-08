using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Générateur_SQL
{
    public partial class Form1 : Form
    {
        private List<string> historiqueFichiers = new List<string>(); // Liste des fichiers SQL générés.

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Ajuster la taille du PictureBox
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Pour adapter l'image
            pictureBox1.Width = 50; // Largeur en pixels
            pictureBox1.Height = 50; // Hauteur en pixels
        }

        private void btnOFD_Click(object sender, EventArgs e)
        {
            String ligne;
            OFD.Title = "Les fichiers texte."; //titre de la boite de dialogue
            OFD.Filter = "Fichiers texte|*.txt";// Filtre : n'affiche que les fichiers ".txt"

            if (OFD.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    lbxContenuFichier.Items.Clear();  // vider la listbox
                    StreamReader SR = new StreamReader(OFD.OpenFile()); // Ouvrir le flux en lecture
                    while ((ligne = SR.ReadLine()) != null) //lire le fichier ligne par ligne 
                    {
                        lbxContenuFichier.Items.Add(ligne); // copier les lignes du fichier dans la listBox
                    }
                    SR.Close(); // fermer le flux
                }
                catch
                {
                    MessageBox.Show("Erreur: Lecture du fichier impossible");
                }
            }
        }

        private void btnSFD_Click(object sender, EventArgs e)
        {
            // Initialiser le répertoire par défaut et l'extension de fichier
            SFD.InitialDirectory = @"C:\"; // Répertoire par défaut
            SFD.DefaultExt = "sql"; // Extension par défaut
            SFD.Filter = "Fichiers SQL (*.sql)|*.sql"; // Filtrer les fichiers .sql

            // Afficher la boîte de dialogue de sauvegarde
            if (SFD.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sqlBuilder = new StringBuilder();
                string nomFichierSQL = SFD.FileName;

                try
                {
                    // Sauvegarder les requêtes SQL dans le fichier spécifié par l'utilisateur
                    File.WriteAllText(nomFichierSQL, sqlBuilder.ToString(), Encoding.UTF8);

                    // Ajouter le nom du fichier généré dans la ListBox lbxListeFichiers
                    lbxListeFichiers.Items.Add(nomFichierSQL);

                    MessageBox.Show($"Fichier SQL généré avec succès : {nomFichierSQL}");

                    // Ouvrir le fichier sélectionné en mode écriture
                    using (StreamWriter fsWriter = new StreamWriter(SFD.OpenFile()))
                    {
                        // Sauvegarder le texte généré (les requêtes SQL)
                        fsWriter.Write(tbxMonTexte.Text);
                    }

                    MessageBox.Show("Fichier sauvegardé avec succès !");
                }

                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur : {ex.Message}");
                }
            }
        }


        private void btnGenererSQL_Click(object sender, EventArgs e)
        {
            if (lbxContenuFichier.Items.Count == 0)
            {
                MessageBox.Show("Veuillez d'abord charger un fichier texte.");
                return;
            }

            try
            {
                // Récupérer le nom du fichier sans extension et le convertir en majuscules
                string fileName = Path.GetFileNameWithoutExtension(OFD.FileName);
                string tableName = fileName.ToUpper(); // Convertir le nom du fichier en majuscules

                // La première ligne contient les colonnes
                string firstLine = lbxContenuFichier.Items[0].ToString();
                string[] columns = firstLine.Split(';');

                // Préparer les requêtes SQL
                StringBuilder sqlBuilder = new StringBuilder();
                for (int i = 1; i < lbxContenuFichier.Items.Count; i++)
                {
                    string[] values = lbxContenuFichier.Items[i].ToString().Split(';');

                    if (values.Length != columns.Length)
                    {
                        throw new Exception($"Le nombre de colonnes ne correspond pas à la ligne {i + 1}.");
                    }

                    string query = GenerateInsertQuery(tableName, columns, values);
                    sqlBuilder.AppendLine(query);
                }

                // Afficher les requêtes générées dans la TextBox
                tbxMonTexte.Text = sqlBuilder.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}");
            }
        }

        // Méthode pour générer une requête SQL INSERT
        private string GenerateInsertQuery(string tableName, string[] columns, string[] values)
        {
            string columnsPart = string.Join(", ", columns);
            string valuesPart = string.Join(", ", values.Select(v => $"'{v.Replace("'", "''")}'"));
            return $"INSERT INTO `{tableName}` ({columnsPart}) VALUES ({valuesPart});";
        }




    }
}
