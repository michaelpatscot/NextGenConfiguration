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
    public partial class EditEGDPage : Form
    {
        DataTable dtProperties = new DataTable();
        public List<string> Values = new List<string>();
        public EditEGDPage(DataTable dtProps)
        {
            InitializeComponent();
            dtProperties = dtProps;

            #region Apply Default Props
            txtbxName.Text = dtProperties.Rows[0]["Name"].ToString();
            txtnxMinExchangeLength.Text = dtProperties.Rows[0]["MinimumExchangeLength"].ToString();
            txtbxSkew.Text = dtProperties.Rows[0]["Skew"].ToString();
            txtbxStartExchangeID.Text = dtProperties.Rows[0]["StartingExchangeId"].ToString();
            txtbxMultiplier.Text = dtProperties.Rows[0]["Multiplier"].ToString();
            cmbEthernet0.Text = dtProperties.Rows[0]["Ethernet0"].ToString();
            cmbLayoutMode.Text = dtProperties.Rows[0]["LayoutMode"].ToString();
            cmbDestination.Text = dtProperties.Rows[0]["Destination"].ToString();

            #endregion

        }

        #region Formating
        private void txtnxMinExchangeLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char ch = e.KeyChar;
                if (!char.IsDigit(ch) && ch != 8)
                    e.Handled = true;
            }
            catch (Exception ex)
            {

            }
        }
        private void txtbxMultiplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char ch = e.KeyChar;
                if (!char.IsDigit(ch) && ch != 8)
                    e.Handled = true;
            }
            catch (Exception ex)
            {

            }
        }
        private void txtbxSkew_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char ch = e.KeyChar;
                if (!char.IsDigit(ch) && ch != 8)
                    e.Handled = true;
            }
            catch (Exception ex)
            {

            }
        }
        private void txtbxStartExchangeID_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                char ch = e.KeyChar;
                if (!char.IsDigit(ch) && ch != 8)
                    e.Handled = true;
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Values.Add(txtbxName.Text);//0
                Values.Add(txtnxMinExchangeLength.Text);//1
                Values.Add(txtbxSkew.Text);//2
                Values.Add(txtbxStartExchangeID.Text);//3
                Values.Add(txtbxMultiplier.Text);//4
                Values.Add(cmbEthernet0.SelectedItem.ToString());//5
                Values.Add(cmbLayoutMode.SelectedItem.ToString());//6
                Values.Add(cmbDestination.SelectedItem.ToString());//7
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.Close();
            }
        }
    }
}
