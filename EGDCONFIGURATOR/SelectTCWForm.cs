using GeCss.Config.Device;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EGDCONFIGURATOR
{
    public partial class SelectTCWForm : Form
    {
        public string FilePath = string.Empty;
        public static string SelectedMarkVIe;
        public static string SelectedMarkVIeS;
        private List<Device> Devices = new List<Device>();
        public string toolboxFilePath = "";
        public Dictionary<string, string> toolboxDevices = new Dictionary<string, string>();
        public SelectTCWForm()
        {
            InitializeComponent();
            SelectedMarkVIe = "";
            SelectedMarkVIeS = "";
            //this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SelectTCWForm_FormClosing);
        }

        private void buttonBrowseProject_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "tcw file|*.tcw|All Files(*.*)|*.*",
                    Title = "Open a ToolboxST project.",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                DialogResult result = ofd.ShowDialog();
                if (result == DialogResult.OK) // Test result.
                {
                    textBoxProject.Text = ofd.FileName;
                    FilePath = ofd.FileName;
                    buttonOK.Enabled = true;
                }

                else { if (result != DialogResult.Cancel) { textBoxProject.Text = null; } }
            }
            catch (Exception ex)
            {

            }
        }

        private void GenerateTable(string path)
        {
            try
            {
                ArrayList row = new ArrayList();

                WrapperFunctions wrapperFunctions = new WrapperFunctions(path.ToString());
                string Error = string.Empty;
                string[] DeviceListMarkVIe = wrapperFunctions.GetDevicesList(WrapperFunctions.Devices.MarkVIe, WrapperFunctions.Mode.API, ref Error);
                string[] DeviceListMarkVIeS = wrapperFunctions.GetDevicesList(WrapperFunctions.Devices.MarkVIeS, WrapperFunctions.Mode.API, ref Error);
                foreach (string Device in DeviceListMarkVIe)
                {
                    //chkbxMarkVIeDeviceList.Items.Add(Device);
                    row.Add(Device);
                    row.Add("MarkVIe");
                    dgvDevices.Rows.Add(row.ToArray());
                    row = new ArrayList();
                }
                foreach (string Device in DeviceListMarkVIeS)
                {
                    row.Add(Device);
                    row.Add("MarkVIe-S");
                    dgvDevices.Rows.Add(row.ToArray());
                    row = new ArrayList();
                    //chkbxMarkVIeSDeviceList.Items.Add(Device);
                }
                panel1.Visible = true;
                buttonOK.Visible = true;
            }
            catch (Exception ex)
            {

            }
        }

        private void textBoxProject_TextChanged(object sender, EventArgs e)
        {
            try
            {

                WrapperFunctions wrapperFunctions = new WrapperFunctions(textBoxProject.Text);
                string Error = string.Empty;
                string SelectedToolboxSTVersion = wrapperFunctions.GetTcwVersion(WrapperFunctions.Mode.XML, ref Error);

                #region Getting All the installed Versions...
                string Key = string.Empty;
                string[] strInstalledVersions;
                if (Environment.Is64BitOperatingSystem)
                {
                    #region 64BitOS
                    Key = @"SOFTWARE\WOW6432Node\";
                    RegistryKey RKey = Registry.LocalMachine.OpenSubKey(Key + @"GE Energy\Installed\ToolboxST", false);
                    var SubKey = RKey.GetSubKeyNames();
                    strInstalledVersions = string.Join(",", SubKey.Select(xx => xx.ToString()).ToArray()).Split(',');

                    #endregion
                }
                else
                {
                    #region 32BitOS
                    Key = @"SOFTWARE\";
                    RegistryKey RKey = Registry.LocalMachine.OpenSubKey(Key + @"GE Energy\Installed\ToolboxST", false);
                    var SubKey = RKey.GetSubKeyNames();
                    strInstalledVersions = string.Join(",", SubKey.Select(xx => xx.ToString()).ToArray()).Split(',');
                    #endregion
                }
                #endregion
                this.Visible = false;
                VersionSelector versionSelector = new VersionSelector(textBoxProject.Text, SelectedToolboxSTVersion, strInstalledVersions);
                versionSelector.ShowDialog();
                string Version = versionSelector.VersionToReturn;
                string RetError = versionSelector.RetError;
                if (Version == "" && RetError == "Closed")
                    this.Close();
                this.Visible = true;
                if (string.IsNullOrWhiteSpace(textBoxProject.Text)) { return; }
                GenerateTable(textBoxProject.Text);
            }
            catch (Exception ex)
            {

            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            if (chkbxMarkVIeDeviceList.SelectedItems.Count == 0 && chkbxMarkVIeSDeviceList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select anyone device to continue.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                for (int count = 0; count < chkbxMarkVIeDeviceList.Items.Count; count++)
                {
                    if (chkbxMarkVIeDeviceList.GetItemChecked(count))
                        SelectedMarkVIe += chkbxMarkVIeDeviceList.Items[count].ToString() + ",";
                }
                for (int count = 0; count < chkbxMarkVIeSDeviceList.Items.Count; count++)
                {
                    if (chkbxMarkVIeSDeviceList.GetItemChecked(count))
                        SelectedMarkVIeS += chkbxMarkVIeSDeviceList.Items[count].ToString() + ",";
                }
                SelectedMarkVIe = SelectedMarkVIe.TrimEnd(',');
                SelectedMarkVIeS = SelectedMarkVIeS.TrimEnd(',');
                this.Close();
            }
        }

        private void ButtonOK_Click_1(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dgvDevices.Rows)
                {
                    if (row.Cells[2].Value != null && (bool)row.Cells[2].Value == true)
                    {
                        if (row.Cells[1].Value.ToString() == "MarkVIe")
                            SelectedMarkVIe += row.Cells[0].Value.ToString() + ",";
                        else
                            SelectedMarkVIeS += row.Cells[0].Value.ToString() + ",";
                    }
                }
                SelectedMarkVIe = SelectedMarkVIe.TrimEnd(',');
                SelectedMarkVIeS = SelectedMarkVIeS.TrimEnd(',');
                if (string.IsNullOrEmpty(SelectedMarkVIe) && string.IsNullOrEmpty(SelectedMarkVIeS))
                {
                    MessageBox.Show("Please select anyone device to continue.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    this.Close();

                //DialogResult = DialogResult.OK;
                //if (chkbxMarkVIeDeviceList.SelectedItems.Count == 0 && chkbxMarkVIeSDeviceList.SelectedItems.Count == 0)
                //{
                //    MessageBox.Show("Please select anyone device to continue.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    for (int count = 0; count < chkbxMarkVIeDeviceList.Items.Count; count++)
                //    {
                //        if (chkbxMarkVIeDeviceList.GetItemChecked(count))
                //            SelectedMarkVIe += chkbxMarkVIeDeviceList.Items[count].ToString() + ",";
                //    }
                //    for (int count = 0; count < chkbxMarkVIeSDeviceList.Items.Count; count++)
                //    {
                //        if (chkbxMarkVIeSDeviceList.GetItemChecked(count))
                //            SelectedMarkVIeS += chkbxMarkVIeSDeviceList.Items[count].ToString() + ",";
                //    }
                //    SelectedMarkVIe = SelectedMarkVIe.TrimEnd(',');
                //    SelectedMarkVIeS = SelectedMarkVIeS.TrimEnd(',');
                //    this.Close();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SelectTCWForm_Load(object sender, EventArgs e)
        {

        }

        //private void SelectTCWForm_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    //if (MessageBox.Show("Are you sure want to exit?", "Close Application", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
        //    //{
        //    e.Cancel = true;
        //    //}
        //}
    }
}
