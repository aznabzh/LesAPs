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
    public partial class frmEquipements : Form
    {

        DataTable tableEquipements;

        Boolean enregModifierEquipement;

        public frmEquipements()
        {
            InitializeComponent();
        }

        private void frmEquipements_Load(object sender, EventArgs e)
        {
            tableEquipements = frmM2LReservationSalles.reservationsSallesDataSet.Tables["Equipements"];



            lbxEquipements.DataSource = tableEquipements;
            lbxEquipements.DisplayMember = tableEquipements.Columns[1].ToString();
            lbxEquipements.ValueMember = tableEquipements.Columns[0].ToString();

            tbxNomEquipement.Enabled = false;
            tbxQuantiteEquipement.Enabled = false;
            tbxPrixEquipement.Enabled = false;


            btnEnregistrerEquipement.Visible = false;
            btnAnnulerEquipement.Visible = false;
        }

       

        private void lbxEquipements_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxEquipements.SelectedIndex != -1)
            {
                tbxNomEquipement.Text = tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[1].ToString();
                tbxQuantiteEquipement.Text = tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[2].ToString();
                tbxPrixEquipement.Text = tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[3].ToString();

            }
        }

        private void btnAjouterEquipement_Click(object sender, EventArgs e)
        {
            tbxNomEquipement.Text = "";
            tbxQuantiteEquipement.Text = "";
            tbxPrixEquipement.Text = "";



            tbxNomEquipement.Enabled = true;
            tbxQuantiteEquipement.Enabled = true;
            tbxPrixEquipement.Enabled = true;
           


            btnAjouterEquipement.Visible = false;
            btnSupprimerEquipement.Visible = false;
            btnModifierEquipement.Enabled = false;
            tbxRechercherEquipement.Enabled = false;
            btnRechercherEquipement.Enabled = false;

            lbxEquipements.Enabled = false;

            btnEnregistrerEquipement.Visible = true;
            btnAnnulerEquipement.Visible = true;


            enregModifierEquipement = false;
        }

        private void btnEnregistrerEquipement_Click(object sender, EventArgs e)
        {
            int idEquipement;
            short indice;

            indice = 0;


            tbxNomEquipement.Text = tbxNomEquipement.Text.Trim();
            tbxQuantiteEquipement.Text = tbxQuantiteEquipement.Text.Trim();
            tbxPrixEquipement.Text = tbxPrixEquipement.Text.Trim();


            try
            {

                if (enregModifierEquipement == false)
                {
                    dbConnexion.ajouterEquipement(tbxNomEquipement.Text, Convert.ToInt32(tbxQuantiteEquipement.Text), Convert.ToSingle(tbxPrixEquipement.Text));
                }
                else
                {
                    idEquipement = Convert.ToInt32(tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[0]);
                    dbConnexion.modifierEquipement(idEquipement, tbxNomEquipement.Text, Convert.ToInt32(tbxQuantiteEquipement.Text), Convert.ToSingle(tbxPrixEquipement.Text));
                    indice = Convert.ToInt16(lbxEquipements.SelectedIndex);

                }

                dbConnexion.miseJourDataSet();

                lbxEquipements.DataSource = tableEquipements;
                lbxEquipements.DisplayMember = tableEquipements.Columns[1].ToString();
                lbxEquipements.ValueMember = tableEquipements.Columns[0].ToString();


                if (enregModifierEquipement == true)
                {
                    lbxEquipements.SelectedIndex = indice;
                    enregModifierEquipement = false;
                }
                else
                {
                    lbxEquipements.SelectedIndex = lbxEquipements.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            tbxNomEquipement.Enabled = false;
            tbxQuantiteEquipement.Enabled = false;
            tbxPrixEquipement.Enabled = false;


            btnAjouterEquipement.Visible = true;
            btnSupprimerEquipement.Visible = true;
            btnModifierEquipement.Enabled = true;

            btnEnregistrerEquipement.Visible = false;
            btnAnnulerEquipement.Visible = false;

            lbxEquipements.Enabled = true;
            tbxRechercherEquipement.Enabled = true;
            btnRechercherEquipement.Enabled = true;

            if (lbxEquipements.SelectedIndex != -1)
            {
                tbxNomEquipement.Text = tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[1].ToString();
                tbxQuantiteEquipement.Text = tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[2].ToString();
                tbxPrixEquipement.Text = tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[3].ToString();

            } 
        }

        private void btnAnnulerEquipement_Click(object sender, EventArgs e)
        {
            enregModifierEquipement = false;

            tbxNomEquipement.Enabled = false;
            tbxQuantiteEquipement.Enabled = false;
            tbxPrixEquipement.Enabled = false;

            btnAjouterEquipement.Visible = true;
            btnSupprimerEquipement.Visible = true;
            btnModifierEquipement.Enabled = true;

            btnEnregistrerEquipement.Visible = false;
            btnAnnulerEquipement.Visible = false;

            lbxEquipements.Enabled = true;
            tbxRechercherEquipement.Enabled = true;
            btnRechercherEquipement.Enabled = true;

            if (lbxEquipements.SelectedIndex != -1)
            {
                tbxNomEquipement.Text = tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[1].ToString();
                tbxQuantiteEquipement.Text = tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[2].ToString();
                tbxPrixEquipement.Text = tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[3].ToString();
            }
        }

        private void btnModifierEquipement_Click(object sender, EventArgs e)
        {
            if (tbxNomEquipement.Text != "")
            {
                enregModifierEquipement = true;
                tbxNomEquipement.Enabled = true;
                tbxQuantiteEquipement.Enabled = true;
                tbxPrixEquipement.Enabled = true;


                btnAjouterEquipement.Visible = false;
                btnSupprimerEquipement.Visible = false;
                btnModifierEquipement.Enabled = false;

                btnEnregistrerEquipement.Visible = true;
                btnAnnulerEquipement.Visible = true;

                lbxEquipements.Enabled = false;
                tbxRechercherEquipement.Enabled = false;
                btnRechercherEquipement.Enabled = false;
            }
        }

        private void btnSupprimerEquipement_Click(object sender, EventArgs e)
        {
            int idEquipement;
            try
            {
                if (lbxEquipements.SelectedIndex >= 0)
                {
                    idEquipement = Convert.ToInt32(tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[0]);
                    dbConnexion.supprimerEquipement(idEquipement);
                    dbConnexion.miseJourDataSet();

                    if (lbxEquipements.SelectedIndex != -1)
                    {
                        tbxNomEquipement.Text = tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[1].ToString();
                        tbxQuantiteEquipement.Text = tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[2].ToString();
                        tbxPrixEquipement.Text = tableEquipements.Rows[lbxEquipements.SelectedIndex].ItemArray[3].ToString();

                    }
                    else
                    {
                        tbxNomEquipement.Text = "";
                        tbxQuantiteEquipement.Text = "";
                        tbxPrixEquipement.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez sélectionner un équipement");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
    }
}
