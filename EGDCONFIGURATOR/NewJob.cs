using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EGDCONFIGURATOR
{
    public partial class NewJob : Form
    {
        public string JobNumber = string.Empty;
        public string Company = string.Empty;
        public NewJob(string UserName)
        {
            InitializeComponent();
            txtbxUser.Text = UserName;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbxCompany.Text != "" && txtbxJobNumber.Text != "")
                {
                    JobNumber = txtbxJobNumber.Text;
                    Company = txtbxCompany.Text;
                    this.Close();
                }
                else
                    MessageBox.Show("Kindly enter all the required information", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {

            }

        }

        private void txtbxCompany_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(txtbxCompany.Text.ToString().Trim()!="" && e.KeyCode == Keys.Enter)
                {

                    btnSubmit.PerformClick();
                }
            }
            catch (Exception)
            {

              
            }
        }

        private void txtbxJobNumber_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtbxJobNumber_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtbxJobNumber.Text.ToString().Trim() != "" && e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(txtbxJobNumber, true, true, true, true);
            }
        }
    }
}
