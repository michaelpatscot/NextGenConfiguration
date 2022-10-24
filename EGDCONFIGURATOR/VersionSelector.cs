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

    public partial class VersionSelector : Form
    {
        string ToolboxSTSelectedVersion = string.Empty;
        string[] ToolboxSTInstalledVersion;
        public string VersionToReturn = string.Empty;
        string Path = @"C:\Program Files(x86)\GE Energy\ToolboxST";
        public string RetError = string.Empty;

        public VersionSelector(string Path, string SelectedVersion, string[] InstalledVersion)
        {
            InitializeComponent();
            ToolboxSTSelectedVersion = SelectedVersion;
            ToolboxSTInstalledVersion = InstalledVersion;
            foreach (string Version in ToolboxSTInstalledVersion)
                lstbxInstalledVersions.Items.Add("ToolboxST "+ Version);
            lblMinVersion.Text = "Minimum Version : " + ToolboxSTSelectedVersion + "";
            lblLSWV.Text = "Minimum Version : " + ToolboxSTSelectedVersion + "";
            lblFile.Text = "File : "+Path.Split('\\').Last().ToString();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstbxInstalledVersions.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select anyone version to continue.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    VersionToReturn = lstbxInstalledVersions.SelectedItem.ToString();
                    this.Close();
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
                RetError = "Closed";
                this.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void VersionSelector_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                RetError = "Closed";
            }
            catch (Exception ex)
            {

            }
        }
    }
}
