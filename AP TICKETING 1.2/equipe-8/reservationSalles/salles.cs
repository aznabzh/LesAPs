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
    public partial class frmSalles : Form
    {
        DataTable tableSalles , tableTypes;
       
        Boolean enregModifierSalle;

        DataRelation sallesTypes = frmM2LReservationSalles.reservationsSallesDataSet.Relations["EquiJoinSalleType"];


        public frmSalles()
        {
            InitializeComponent();
        }

        private void salles_Load(object sender, EventArgs e)
        {

            tableSalles = frmM2LReservationSalles.reservationsSallesDataSet.Tables["Salles"];
            tableTypes = frmM2LReservationSalles.reservationsSallesDataSet.Tables["Types"];
         

            lbxSalles.DataSource = tableSalles;
            lbxSalles.DisplayMember = tableSalles.Columns[1].ToString();
            lbxSalles.ValueMember = tableSalles.Columns[0].ToString();

            cbxTypeSalle.DataSource = tableTypes;
            cbxTypeSalle.DisplayMember = tableTypes.Columns[1].ToString();
            cbxTypeSalle.ValueMember = tableTypes.Columns[0].ToString();

            tbxNomSalle.Enabled = false;
            cbxTypeSalle.Enabled = false;
            tbxSurfaceSalle.Enabled = false;
            tbxCapaciteSalle.Enabled = false;
            tbxPrixLocationSalle.Enabled = false;

            btnEnregistrerSalle.Visible = false;
            btnAnnulerSalle.Visible = false;
        }

        private void lbxSalles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxSalles.SelectedIndex != -1)
            {
                tbxNomSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[1].ToString();
                cbxTypeSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].GetParentRow(sallesTypes)["libelleType"].ToString();
                tbxSurfaceSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[3].ToString();
                tbxCapaciteSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[4].ToString();
                tbxPrixLocationSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[5].ToString();
            }
        }

        private void btnRechercheSalle_Click(object sender, EventArgs e)
        {
            int index = lbxSalles.FindString(tbxRechercherSalle.Text);
            if (index == -1)
            {
                MessageBox.Show("Salle introuvable.");
            }
            else
            {
                lbxSalles.SetSelected(index, true);
            }
        }

        private void btnModifierSalle_Click(object sender, EventArgs e)
        {
            if (tbxNomSalle.Text != "")
            {
                enregModifierSalle = true;
                tbxNomSalle.Enabled = true;
                cbxTypeSalle.Enabled = true;
                tbxSurfaceSalle.Enabled = true;
                tbxCapaciteSalle.Enabled = true;
                tbxPrixLocationSalle.Enabled = true;

                btnAjouterSalle.Visible = false;
                btnSupprimerSalle.Visible = false;
                btnModifierSalle.Enabled = false;

                btnEnregistrerSalle.Visible = true;
                btnAnnulerSalle.Visible = true;

                lbxSalles.Enabled = false;
                tbxRechercherSalle.Enabled = false;
            }
        }

        private void btnAnnulerSalle_Click(object sender, EventArgs e)
        {
            enregModifierSalle = false;

            tbxNomSalle.Enabled = false;
            cbxTypeSalle.Enabled = false;
            tbxSurfaceSalle.Enabled = false;
            tbxCapaciteSalle.Enabled = false;
            tbxPrixLocationSalle.Enabled = false;

            btnAjouterSalle.Visible = true;
            btnSupprimerSalle.Visible = true;
            btnModifierSalle.Enabled = true;

            btnEnregistrerSalle.Visible = false;
            btnAnnulerSalle.Visible = false;

            lbxSalles.Enabled = true;
            tbxRechercherSalle.Enabled = true;

            if (lbxSalles.SelectedIndex != -1)
            {
                tbxNomSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[1].ToString();
                cbxTypeSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].GetParentRow(sallesTypes)["libelleType"].ToString();
                tbxSurfaceSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[3].ToString();
                tbxCapaciteSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[4].ToString();
                tbxPrixLocationSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[5].ToString();
            }
        }

        private void btnAjouterSalle_Click(object sender, EventArgs e)
        {
            tbxNomSalle.Text = "";
            cbxTypeSalle.SelectedIndex = 0;
            tbxSurfaceSalle.Text = "";
            tbxCapaciteSalle.Text = "";
            tbxPrixLocationSalle.Text = "";


            tbxNomSalle.Enabled = true;
            cbxTypeSalle.Enabled = true;
            tbxSurfaceSalle.Enabled = true;
            tbxCapaciteSalle.Enabled = true;
            tbxPrixLocationSalle.Enabled = true;

            btnAjouterSalle.Visible = false;
            btnSupprimerSalle.Visible = false;
            btnModifierSalle.Enabled = false;

            btnEnregistrerSalle.Visible = true;
            btnAnnulerSalle.Visible = true;

            lbxSalles.Enabled = false;
            tbxRechercherSalle.Enabled = false;
        }

        private void btnEnregistrerSalle_Click(object sender, EventArgs e)
        {
            int idSalle;
            short indice;

            indice = 0;



            tbxNomSalle.Text = tbxNomSalle.Text.Trim();
            cbxTypeSalle.Text = cbxTypeSalle.Text.Trim();

            try
            {

                if (enregModifierSalle == false)
                {
                    dbConnexion.ajouterSalle(tbxNomSalle.Text, Convert.ToInt32(cbxTypeSalle.SelectedValue), Convert.ToInt16(tbxSurfaceSalle.Text), Convert.ToInt16(tbxCapaciteSalle.Text), Convert.ToSingle(tbxPrixLocationSalle.Text));
                }
                else
                {
                    idSalle = Convert.ToInt32(tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[0]);
                    dbConnexion.modifierSalle(idSalle, tbxNomSalle.Text, Convert.ToInt32(cbxTypeSalle.SelectedValue), Convert.ToInt16(tbxSurfaceSalle.Text), Convert.ToInt16(tbxCapaciteSalle.Text), Convert.ToSingle(tbxPrixLocationSalle.Text));
                    indice = Convert.ToInt16(lbxSalles.SelectedIndex);
                }

                dbConnexion.miseJourDataSet();
                lbxSalles.DataSource = tableSalles;
                lbxSalles.DisplayMember = tableSalles.Columns[1].ToString();

                if (enregModifierSalle == true)
                {
                    lbxSalles.SelectedIndex = indice;
                    enregModifierSalle = false;
                }
                else
                {
                    lbxSalles.SelectedIndex = lbxSalles.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            tbxNomSalle.Enabled = false;
            cbxTypeSalle.Enabled = false;
            tbxSurfaceSalle.Enabled = false;
            tbxCapaciteSalle.Enabled = false;
            tbxPrixLocationSalle.Enabled = false;

            btnAjouterSalle.Visible = true;
            btnSupprimerSalle.Visible = true;
            btnModifierSalle.Enabled = true;

            btnEnregistrerSalle.Visible = false;
            btnAnnulerSalle.Visible = false;

            lbxSalles.Enabled = true;
            tbxRechercherSalle.Enabled = true;
            if (lbxSalles.SelectedIndex != -1)
            {
                tbxNomSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[1].ToString();
                cbxTypeSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].GetParentRow(sallesTypes)["libelleType"].ToString();
                tbxSurfaceSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[3].ToString();
                tbxCapaciteSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[4].ToString();
                tbxPrixLocationSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[5].ToString();


            }
        }

        private void btnSupprimerSalle_Click(object sender, EventArgs e)
        {
            int idSalle;
            try
            {
                if (lbxSalles.SelectedIndex >= 0)
                {
                    idSalle = Convert.ToInt32(tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[0]);
                    dbConnexion.supprimerSalle(idSalle);
                    dbConnexion.miseJourDataSet();

                    if (lbxSalles.SelectedIndex != -1)
                    {
                        tbxNomSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[1].ToString();
                        cbxTypeSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].GetParentRow(sallesTypes)["libelleType"].ToString();
                        tbxSurfaceSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[3].ToString();
                        tbxCapaciteSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[4].ToString();
                        tbxPrixLocationSalle.Text = tableSalles.Rows[lbxSalles.SelectedIndex].ItemArray[5].ToString();

                    }
                    else
                    {
                        tbxNomSalle.Text = "";
                        cbxTypeSalle.Text = "";
                        tbxSurfaceSalle.Text = "";
                        tbxCapaciteSalle.Text = "";
                        tbxPrixLocationSalle.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Vous devez sélectionner une salle");
                }
            }
             catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
      
            }
        }
    }
}
