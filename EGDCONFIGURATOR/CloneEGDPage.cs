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
    public partial class CloneEGDPage : Form
    {
        string PageName = string.Empty;
        string PathName = string.Empty;
        string DeviceName = string.Empty;
        Hashtable hshAllDevices = new Hashtable();
        List<string> EGDPages = new List<string>();
        public CloneEGDPage(string EGDPage, Hashtable hshDevices, string Device, string Path,List<string>ExistingEGDPages)
        {
            InitializeComponent();
            PageName = EGDPage;
            hshAllDevices = hshDevices;
            PathName = Path;
            DeviceName = Device;
            EGDPages = ExistingEGDPages;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Result = MessageBox.Show("Are you sure want to close?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Result == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                string NewEGDPage = string.Empty;
                string Error = string.Empty;
                if (txtbxEGDPage.Text != null && txtbxEGDPage.Text != "")
                {
                    if (EGDPages.Contains(txtbxEGDPage.Text))
                    {
                        MessageBox.Show("The EGD Page entered is already available. Please enter a unique EGD Page name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        NewEGDPage = txtbxEGDPage.Text.ToString();
                        WrapperFunctions wrapperFunctions = new WrapperFunctions(PathName);
                        wrapperFunctions.SetEGDPage((IDevice)hshAllDevices[DeviceName], NewEGDPage, ref Error);
                        DataTable dtEGD = wrapperFunctions.GetEgdPageWithProps((IDevice)hshAllDevices[DeviceName], ref Error);
                        EGDProps eGDProps = new EGDProps();
                        eGDProps.Destination = string.Join("", dtEGD.AsEnumerable().Where(xx => xx["Name"].ToString().Equals(PageName)).Select(xx => xx["Destination"]).ToArray());
                        eGDProps.Ethernet0 = string.Join("", dtEGD.AsEnumerable().Where(xx => xx["Name"].ToString().Equals(PageName)).Select(xx => xx["Ethernet0"]).ToArray());
                        eGDProps.LayoutMode = string.Join("", dtEGD.AsEnumerable().Where(xx => xx["Name"].ToString().Equals(PageName)).Select(xx => xx["LayoutMode"]).ToArray());
                        eGDProps.MinimumExchangeLength = string.Join("", dtEGD.AsEnumerable().Where(xx => xx["Name"].ToString().Equals(PageName)).Select(xx => xx["MinimumExchangeLength"]).ToArray());
                        eGDProps.Multiplier = string.Join("", dtEGD.AsEnumerable().Where(xx => xx["Name"].ToString().Equals(PageName)).Select(xx => xx["Multiplier"]).ToArray());
                        eGDProps.Skew = string.Join("", dtEGD.AsEnumerable().Where(xx => xx["Name"].ToString().Equals(PageName)).Select(xx => xx["Skew"]).ToArray());
                        eGDProps.StartingExchangeId = string.Join("", dtEGD.AsEnumerable().Where(xx => xx["Name"].ToString().Equals(PageName)).Select(xx => xx["StartingExchangeId"]).ToArray());
                        //eGDProps.Destination = string.Join("", dtEGD.AsEnumerable().Where(xx => xx["Name"].ToString().Equals(PageName)).Select(xx => xx["Destination"]).ToArray());
                        wrapperFunctions.SetEGDPage((IDevice)hshAllDevices[DeviceName], NewEGDPage, ref Error, eGDProps);
                        MessageBox.Show("The page is cloned successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
                else
                    MessageBox.Show("Please enter a unique page name to clone.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
