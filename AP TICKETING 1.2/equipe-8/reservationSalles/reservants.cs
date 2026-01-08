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
    public partial class frmReservants : Form
    {
        DataTable tableReservants = frmM2LReservationSalles.reservationsSallesDataSet.Tables["Reservants"];
        DataTable tableLigues = frmM2LReservationSalles.reservationsSallesDataSet.Tables["ligues"];
        Boolean enregModifierReservant;
       

        DataRelation reservantsLigues = frmM2LReservationSalles.reservationsSallesDataSet.Relations["EquiJoinReservantLigue"];

        public frmReservants()
        {
            InitializeComponent();
           
        }

        private void reservants_Load(object sender, EventArgs e)
        {



            




            lbxReservants.DataSource = tableReservants;
            lbxReservants.DisplayMember = "nomPrenom";
            lbxReservants.ValueMember = "idReservant";
        

            cbxLigueReservant.DataSource = tableLigues;
            cbxLigueReservant.DisplayMember = tableLigues.Columns[1].ToString();
            cbxLigueReservant.ValueMember = tableLigues.Columns[0].ToString();


            tbxInseeReservant.Enabled = false;
            tbxNomReservant.Enabled = false;
            tbxPrenomReservant.Enabled = false;
            tbxTelephoneReservant.Enabled = false;
            tbxMailReservant.Enabled = false;
            cbxLigueReservant.Enabled = false;
            tbxFonctionReservant.Enabled = false;

            btnEnregistrerReservant.Visible = false;
            btnAnnulerReservant.Visible = false;

            btnRechercherReservant.Enabled = true;
        }

        private void lbxReservants_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (lbxReservants.SelectedIndex != -1)
            {
                tbxInseeReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[1].ToString();
                tbxNomReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[2].ToString();
                tbxPrenomReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[3].ToString();
                tbxTelephoneReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[4].ToString();
                tbxMailReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[5].ToString();
                tbxFonctionReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[7].ToString();

                
                cbxLigueReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].GetParentRow(reservantsLigues)["nomLigue"].ToString();
                
            }
        }

        private void btnRechercherReservant_Click(object sender, EventArgs e)
        {
            int index = lbxReservants.FindString(tbxRechercherReservant.Text);
            if (index == -1)
            {
                MessageBox.Show("Reéservant introuvable.");
            }
            else
            {
                lbxReservants.SetSelected(index, true);
            }
        }


        private void btnModifierReservant_Click(object sender, EventArgs e)
        {
            if (tbxNomReservant.Text != "")
            {
                enregModifierReservant = true;
                tbxInseeReservant.Enabled = true;
                tbxNomReservant.Enabled = true;
                tbxPrenomReservant.Enabled = true;
                tbxTelephoneReservant.Enabled = true;
                tbxMailReservant.Enabled = true;
                cbxLigueReservant.Enabled = true;
                tbxFonctionReservant.Enabled = true;

                btnAjouterReservant.Visible = false;
                btnSupprimerReservant.Visible = false;
                btnModifierReservant.Enabled = false;

                btnEnregistrerReservant.Visible = true;
                btnAnnulerReservant.Visible = true;

                lbxReservants.Enabled = false;
                tbxRechercherReservant.Enabled = false;
                btnRechercherReservant.Enabled = false;
            }
        }

        private void btnAnnulerReservant_Click(object sender, EventArgs e)
        {

            enregModifierReservant = false;

            tbxInseeReservant.Enabled = false;
            tbxNomReservant.Enabled = false;
            tbxPrenomReservant.Enabled = false;
            tbxTelephoneReservant.Enabled = false;
            tbxMailReservant.Enabled = false;
            cbxLigueReservant.Enabled = false;
            tbxFonctionReservant.Enabled = false;

            btnAjouterReservant.Visible = true;
            btnSupprimerReservant.Visible = true;
            btnModifierReservant.Enabled = true;

            btnEnregistrerReservant.Visible = false;
            btnAnnulerReservant.Visible = false;

            lbxReservants.Enabled = true;
            tbxRechercherReservant.Enabled = true;
            btnRechercherReservant.Enabled = true;

            if (lbxReservants.SelectedIndex != -1)
            {
                tbxInseeReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[1].ToString();
                tbxNomReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[2].ToString();
                tbxPrenomReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[3].ToString();
                tbxTelephoneReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[4].ToString();
                tbxMailReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[5].ToString();
                tbxFonctionReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[7].ToString();


                cbxLigueReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].GetParentRow(reservantsLigues)["nomLigue"].ToString();

            }
        }


        private void btnAjouterReservant_Click(object sender, EventArgs e)
        {

            tbxInseeReservant.Text = "";
            tbxNomReservant.Text = "";
            tbxPrenomReservant.Text = "";
            tbxTelephoneReservant.Text = "";
            tbxMailReservant.Text = "";
            tbxFonctionReservant.Text = "";
            cbxLigueReservant.SelectedIndex = 0;

            btnRechercherReservant.Enabled = false;
            tbxRechercherReservant.Enabled = false;

            btnAjouterReservant.Visible = false;
            btnSupprimerReservant.Visible = false;
            btnModifierReservant.Enabled = false;

            lbxReservants.Enabled = false;

            btnEnregistrerReservant.Visible = true;
            btnAnnulerReservant.Visible = true;


            enregModifierReservant = false;
            tbxInseeReservant.Enabled = true;
            tbxNomReservant.Enabled = true;
            tbxPrenomReservant.Enabled = true;
            tbxTelephoneReservant.Enabled = true;
            tbxMailReservant.Enabled = true;
            cbxLigueReservant.Enabled = true;
            tbxFonctionReservant.Enabled = true;
        }

        private void btnEnregistrerReservant_Click(object sender, EventArgs e)
        {


            int idReservant;
            short indice;

            indice = 0;


            tbxInseeReservant.Text = tbxInseeReservant.Text.Trim();
            tbxNomReservant.Text = tbxNomReservant.Text.Trim();
            tbxPrenomReservant.Text = tbxPrenomReservant.Text.Trim();
            tbxTelephoneReservant.Text = tbxTelephoneReservant.Text.Trim();
            tbxMailReservant.Text = tbxMailReservant.Text.Trim();
            tbxFonctionReservant.Text = tbxFonctionReservant.Text.Trim();


            


                try
                {

                    if (enregModifierReservant == false)
                    {
                        dbConnexion.ajouterReservant(tbxInseeReservant.Text, tbxNomReservant.Text, tbxPrenomReservant.Text, tbxTelephoneReservant.Text, tbxMailReservant.Text, Convert.ToInt32(cbxLigueReservant.SelectedValue), tbxFonctionReservant.Text);
                    }
                    else
                    {
                        idReservant = Convert.ToInt32(tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[0]);
                        dbConnexion.modifierReservant(idReservant, tbxInseeReservant.Text, tbxNomReservant.Text, tbxPrenomReservant.Text, tbxTelephoneReservant.Text, tbxMailReservant.Text, Convert.ToInt32(cbxLigueReservant.SelectedValue), tbxFonctionReservant.Text);

                        indice = Convert.ToInt16(lbxReservants.SelectedIndex);

                    }

                    dbConnexion.miseJourDataSet();
                  
                    lbxReservants.DataSource = tableReservants;
                    lbxReservants.DisplayMember = "nomPrenom";


                    if (enregModifierReservant == true)
                    {
                        lbxReservants.SelectedIndex = indice;
                        enregModifierReservant = false;
                    }
                    else
                    {
                        lbxReservants.SelectedIndex = lbxReservants.Items.Count - 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                tbxInseeReservant.Enabled = false;
                tbxNomReservant.Enabled = false;
                tbxPrenomReservant.Enabled = false;
                tbxTelephoneReservant.Enabled = false;
                tbxMailReservant.Enabled = false;
                cbxLigueReservant.Enabled = false;
                tbxFonctionReservant.Enabled = false;

                btnAjouterReservant.Visible = true;
                btnSupprimerReservant.Visible = true;
                btnModifierReservant.Enabled = true;

                btnEnregistrerReservant.Visible = false;
                btnAnnulerReservant.Visible = false;

                lbxReservants.Enabled = true;
                tbxRechercherReservant.Enabled = true;
                btnRechercherReservant.Enabled = true;

                if (lbxReservants.SelectedIndex != -1)
                {
                    tbxInseeReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[1].ToString();
                    tbxNomReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[2].ToString();
                    tbxPrenomReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[3].ToString();
                    tbxTelephoneReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[4].ToString();
                    tbxMailReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[5].ToString();
                    tbxFonctionReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[7].ToString();


                    cbxLigueReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].GetParentRow(reservantsLigues)["nomLigue"].ToString();

                }
            
        }

        private void btnSupprimerReservant_Click(object sender, EventArgs e)
        {

            int idReservant;

            if (lbxReservants.SelectedIndex >= 0)
            {
                        idReservant = Convert.ToInt32(tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[0]);
                        dbConnexion.supprimerReservant(idReservant);
                        dbConnexion.miseJourDataSet();

                if (lbxReservants.SelectedIndex != -1)
                {
                    tbxInseeReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[1].ToString();
                    tbxNomReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[2].ToString();
                    tbxPrenomReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[3].ToString();
                    tbxTelephoneReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[4].ToString();
                    tbxMailReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[5].ToString();
                    tbxFonctionReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].ItemArray[7].ToString();

                    cbxLigueReservant.Text = tableReservants.Rows[lbxReservants.SelectedIndex].GetParentRow(reservantsLigues)["nomLigue"].ToString();
                }
                else
                {
                    tbxInseeReservant.Text = "";
                    tbxNomReservant.Text = "";
                    tbxPrenomReservant.Text = "";
                    tbxTelephoneReservant.Text = "";
                    tbxMailReservant.Text = "";
                    tbxFonctionReservant.Text = "";
                    cbxLigueReservant.SelectedIndex = 0;

                }

            }
            else
            {
                MessageBox.Show("Vous devez sélectionner un réservant");
            }




        }


    }
}
