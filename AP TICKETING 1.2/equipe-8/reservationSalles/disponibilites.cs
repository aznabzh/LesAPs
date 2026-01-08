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
    public partial class frmDisponibilites : Form
    {

        DataTable tableTypes;
        public frmDisponibilites()
        {
            InitializeComponent();
        }

        private void frmDisponibilites_Load(object sender, EventArgs e)
        {
            tableTypes = frmM2LReservationSalles.reservationsSallesDataSet.Tables["Types"];

            cbxTypeSalles.DataSource = tableTypes;
            cbxTypeSalles.DisplayMember = tableTypes.Columns[1].ToString();
            cbxTypeSalles.ValueMember = tableTypes.Columns[0].ToString();



            cbxLPlages.Items.Add("Matin");
            cbxLPlages.Items.Add("Après midi");
            cbxLPlages.SelectedIndex = 0;
        }
    }
}
