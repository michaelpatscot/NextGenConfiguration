using GeCss.Automation;
using System;
using System.Collections;
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
    public partial class AddEGDPage : Form
    {
        string[] AllEGDPages;
        public string EGDPageName = string.Empty;
        public string FilePath = string.Empty;
        public string Error = string.Empty;
        public string Device_Name = string.Empty;
        Hashtable hshDevices = new Hashtable();
        public AddEGDPage(string[] EGDPages, Hashtable hshDevice, string Path, string DeviceName)
        {
            InitializeComponent();
            AllEGDPages = EGDPages;
            hshDevices = hshDevice;
            FilePath = Path;
            Device_Name = DeviceName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbxEGDPage.Text != null && txtbxEGDPage.Text != "")
                {
                    if (AllEGDPages.Contains(txtbxEGDPage.Text))
                    {
                        EGDPageName = txtbxEGDPage.Text;
                        DialogResult result = MessageBox.Show("The entered EGD page is already available.\nDo you want to edit the properties for the EGD Page " + EGDPageName + " now? ", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (result == DialogResult.OK)
                        {
                            Error = "Existing EGD Page";
                            //WrapperFunctions wrapperFunctions = new WrapperFunctions(FilePath);
                            //DataTable dtEGDPages = wrapperFunctions.GetEgdPageWithProps((IDevice)hshDevices[Device_Name], ref Error);
                            //DataTable dtEGDPage = dtEGDPages.AsEnumerable().Where(xx => xx["Name"].ToString().Equals(txtbxEGDPage.Text)).Select(xx => xx).CopyToDataTable();
                            //EditEGDPage editEGDPage = new EditEGDPage(dtEGDPage);
                            //editEGDPage.ShowDialog();
                            //List<string> UpdatedValues = editEGDPage.Values;
                            //EGDProps eGDProps = new EGDProps();
                            //eGDProps.Destination = UpdatedValues[7].ToString();
                            //eGDProps.LayoutMode = UpdatedValues[6].ToString();
                            //eGDProps.Ethernet0 = UpdatedValues[5].ToString();
                            //eGDProps.Multiplier = UpdatedValues[4].ToString();
                            //eGDProps.StartingExchangeId = UpdatedValues[3].ToString();
                            //eGDProps.Skew = UpdatedValues[2].ToString();
                            //eGDProps.MinimumExchangeLength = UpdatedValues[1].ToString();
                            //eGDProps.Name = UpdatedValues[0].ToString();
                            //wrapperFunctions.SetEGDPage((IDevice)hshDevices[Device_Name], UpdatedValues[0].ToString(), ref Error, eGDProps);
                            //MessageBox.Show("The properties updated successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }

                    }
                    else
                    {
                        WrapperFunctions wrapperFunctions = new WrapperFunctions(FilePath);
                        bool AddEGD = wrapperFunctions.SetEGDPage((IDevice)hshDevices[Device_Name], txtbxEGDPage.Text, ref Error);
                        if (AddEGD)
                        {
                            MessageBox.Show("The EGD Page is added successfully. Kindly refresh the EGD Pages now.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                            MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Kindly enter a valid EGD page name", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                //DialogResult Result = MessageBox.Show("Are you sure want to close?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                //if (Result == DialogResult.OK)
                //{
                //    this.Close();
                //}
            }
            catch (Exception ex)
            {

            }
        }
    }
}
