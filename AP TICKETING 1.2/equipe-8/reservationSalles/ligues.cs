using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace reservationSalles2018
{
    public partial class frmLigues : Form
    {

        DataTable tableLigues;

        Boolean enregModifierLigue;

        
        public frmLigues()
        {
            InitializeComponent();
        }

        private void frmLigues_Load(object sender, EventArgs e)
        {
            tableLigues = frmM2LReservationSalles.reservationsSallesDataSet.Tables["Ligues"];
           


            lbxLigues.DataSource = tableLigues;
            lbxLigues.DisplayMember = tableLigues.Columns[1].ToString();
            lbxLigues.ValueMember = tableLigues.Columns[0].ToString();

            tbxNomLigue.Enabled = false;
            tbxTelephoneLigue.Enabled = false;
            tbxMailLigue.Enabled = false;
         

            btnEnregistrerLigue.Visible = false;
            btnAnnulerLigue.Visible = false;
        }

        private void lbxLigues_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxLigues.SelectedIndex != -1)
            {
                tbxNomLigue.Text = tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[1].ToString();
                tbxTelephoneLigue.Text = tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[2].ToString();
                tbxMailLigue.Text = tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[3].ToString();
                
            }
        }

       

        private void btnRechercherLigue_Click(object sender, EventArgs e)
        {
            int index = lbxLigues.FindString(tbxRechercherLigue.Text);
            if (index == -1)
            {
                MessageBox.Show("Ligue introuvable.");
            }
            else
            {
                lbxLigues.SetSelected(index, true);
            }
        }

        private void btnModifierLigue_Click(object sender, EventArgs e)
        {
            if (tbxNomLigue.Text != "")
            {
                enregModifierLigue = true;
                tbxNomLigue.Enabled = true;
                tbxTelephoneLigue.Enabled = true;
                tbxMailLigue.Enabled = true;
           

                btnAjouterLigue.Visible = false;
                btnSupprimerLigue.Visible = false;
                btnModifierLigue.Enabled = false;

                btnEnregistrerLigue.Visible = true;
                btnAnnulerLigue.Visible = true;

                lbxLigues.Enabled = false;
                tbxRechercherLigue.Enabled = false;
            }
        }

        private void btnAnnulerLigue_Click(object sender, EventArgs e)
        {
            enregModifierLigue = false;

            tbxNomLigue.Enabled = false;
            tbxTelephoneLigue.Enabled = false;
            tbxMailLigue.Enabled = false;
           
            btnAjouterLigue.Visible = true;
            btnSupprimerLigue.Visible = true;
            btnModifierLigue.Enabled = true;

            btnEnregistrerLigue.Visible = false;
            btnAnnulerLigue.Visible = false;

            lbxLigues.Enabled = true;
            tbxRechercherLigue.Enabled = true;

            if (lbxLigues.SelectedIndex != -1)
            {
                tbxNomLigue.Text = tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[1].ToString();
                tbxTelephoneLigue.Text = tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[2].ToString();
                tbxMailLigue.Text = tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[3].ToString();
            }
        }

        private void btnAjouterLigue_Click(object sender, EventArgs e)
        {
            tbxNomLigue.Text = "";
            tbxTelephoneLigue.Text = "";
            tbxMailLigue.Text = "";
 


            tbxNomLigue.Enabled = true;
            tbxTelephoneLigue.Enabled = true;
            tbxMailLigue.Enabled = true;

            btnAjouterLigue.Visible = false;
            btnSupprimerLigue.Visible = false;
            btnModifierLigue.Enabled = false;

            btnEnregistrerLigue.Visible = true;
            btnAnnulerLigue.Visible = true;

            lbxLigues.Enabled = false;
            tbxRechercherLigue.Enabled = false;
        }

        private void btnEnregistrerLigue_Click(object sender, EventArgs e)
        {
            int idLigue;
            short indice;

            indice = 0;



            tbxNomLigue.Text = tbxNomLigue.Text.Trim();
            tbxTelephoneLigue.Text = tbxTelephoneLigue.Text.Trim();
            tbxMailLigue.Text = tbxMailLigue.Text.Trim();





            try
            {

                if (enregModifierLigue == false)
                {
                    dbConnexion.ajouterLigue(tbxNomLigue.Text, tbxTelephoneLigue.Text, tbxMailLigue.Text);
                }
                else
                {
                    idLigue = Convert.ToInt32(tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[0]);
                    dbConnexion.modifierLigue(idLigue, tbxNomLigue.Text, tbxTelephoneLigue.Text, tbxMailLigue.Text);
                    indice = Convert.ToInt16(lbxLigues.SelectedIndex);
                }

                dbConnexion.miseJourDataSet();
                lbxLigues.DataSource = tableLigues;
                lbxLigues.DisplayMember = tableLigues.Columns[1].ToString();

                if (enregModifierLigue == true)
                {
                    lbxLigues.SelectedIndex = indice;
                    enregModifierLigue = false;
                }
                else
                {
                    lbxLigues.SelectedIndex = lbxLigues.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            tbxNomLigue.Enabled = false;
            tbxTelephoneLigue.Enabled = false;
            tbxMailLigue.Enabled = false;
           

            btnAjouterLigue.Visible = true;
            btnSupprimerLigue.Visible = true;
            btnModifierLigue.Enabled = true;

            btnEnregistrerLigue.Visible = false;
            btnAnnulerLigue.Visible = false;

            lbxLigues.Enabled = true;
            tbxRechercherLigue.Enabled = true;
            if (lbxLigues.SelectedIndex != -1)
            {
                tbxNomLigue.Text = tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[1].ToString();
                tbxTelephoneLigue.Text = tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[2].ToString();
                tbxMailLigue.Text = tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[3].ToString();


            }
        }

        private void btnSupprimerLigue_Click(object sender, EventArgs e)
        {
            int idLigue;
            try
            {
                if (lbxLigues.SelectedIndex >= 0)
                {
                    idLigue = Convert.ToInt32(tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[0]);
                    dbConnexion.supprimerLigue(idLigue);
                    dbConnexion.miseJourDataSet();

                    if (lbxLigues.SelectedIndex != -1)
                    {
                        tbxNomLigue.Text = tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[1].ToString();
                        tbxTelephoneLigue.Text = tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[2].ToString();
                        tbxMailLigue.Text = tableLigues.Rows[lbxLigues.SelectedIndex].ItemArray[3].ToString();

                    }
                    else
                    {
                        tbxNomLigue.Text = "";
                        tbxTelephoneLigue.Text = "";
                        tbxMailLigue.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez sélectionner une ligue");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void tbxNomLigue_Validating(object sender, CancelEventArgs e)
        {

        }
    }
    
}
