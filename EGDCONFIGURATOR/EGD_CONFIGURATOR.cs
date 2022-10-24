using GeCss.Automation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zuby.ADGV;
using System.Xml;

namespace EGDCONFIGURATOR
{
    public partial class EGDConfigurator : Form
    {
        #region Global Things
        string Path = string.Empty;
        string txtInformation = string.Empty;
        //string SelectedDeviceName = string.Empty;
        string[] DeviceListMarkVIe;
        string[] SelectedMarkVIe;
        string[] DeviceListMarkVIeS;
        string[] SelectedMarkVIeS;
        List<DataTable> dtMarkVIe_Global = new List<DataTable>();
        List<DataTable> dtMarkVIe_EGD = new List<DataTable>();
        List<DataTable> dtMarkVIe_Local = new List<DataTable>();
        List<DataTable> dtMarkVIeS_Global = new List<DataTable>();
        List<DataTable> dtMarkVIeS_Local = new List<DataTable>();
        List<DataTable> dtMarkVIeS_EGD = new List<DataTable>();
        DataTable dtVariables = new DataTable();
        Hashtable hshDevices = new Hashtable();
        List<string> ShownColumns;
        List<string> RemoveColumns;
        List<string> SelectedDevices = new List<string>();
        string[] columnNamesShown = new string[] { "VarFrom", "ProgramName", "Name", "Alias", "DataType", "ArrayLength", "Description", "ChildAlarms", "Units", "Access", "ArrayValues", "InitialValue", "EgdPage", "FormatSpecification", "DisplayHigh", "DisplayLow", "Scope" };
        IDevice Device;
        string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name.Split('\\').Last();
        string JobNumber = string.Empty;
        string Company = string.Empty;
        List<string> EGDPagesMVIe = new List<string>();
        List<string> EGDPagesMVIeS = new List<string>();
        List<string> ExistingEGDPagesMVIe = new List<string>();
        List<string> ExistingEGDPagesMVIeS = new List<string>();
        bool blIsSave = false;
        #endregion
        public EGDConfigurator()
        {
            InitializeComponent();
            txtbxInfo.Text += "EGD Configurator is launched successfully.\r\n";
            TreeViewJobList.Size = new Size(221, 408);
            dgv_Properties.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void nEWToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                NewRemotePrj();
            }
            catch (Exception ex)
            {

            }
        }
        private void TreeViewJobList_MouseClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    if(e.Button == MouseButtons.Right)
            //        //TreeViewJobList.

            //    if (TreeViewJobList != null && TreeViewJobList.SelectedNode != null &&
            //        TreeViewJobList.SelectedNode.Tag != null && TreeViewJobList.SelectedNode.Tag.ToString() == "1" && e.Button == MouseButtons.Right)
            //    {
            //        contextMenuStrip1.Show(Cursor.Position);
            //    }
            //}
            //catch (Exception)
            //{

            //}
        }
        private void associateAToolboxSTProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {

                SelectTCWForm tcwSelect = new SelectTCWForm();
                tcwSelect.ShowDialog();
                Path = tcwSelect.FilePath.ToString();
                txtbxInfo.Text += "\r\nThe selected toolbox ST from path " + Path + " is opened successfully.\r\n";
                if (SelectTCWForm.SelectedMarkVIe != "")
                {
                    MessgageTextBoxOperation("The selected MarkVIe devices is/are " + SelectTCWForm.SelectedMarkVIe + "");
                    MessgageTextBoxOperation("The process of fetching variables of Global, Local and EGD Pages is going on.");
                }
                else
                {
                    MessgageTextBoxOperation("No MarkVIe devices is selected.");
                }
                if (SelectTCWForm.SelectedMarkVIeS != "")
                {
                    MessgageTextBoxOperation("The selected MarkVIe-S devices is/are " + SelectTCWForm.SelectedMarkVIeS + "");
                    MessgageTextBoxOperation("The process of fetching variables of Global, Local and EGD Pages is going on.");
                }
                else
                {
                    MessgageTextBoxOperation("No MarkVIe-S devices is selected.");
                }
                if (!bgw.IsBusy)
                {
                    PictureBoxFunctionsShow(pictureBox1);
                    bgw.RunWorkerAsync();
                }

            }
            catch (Exception)
            {

            }
        }
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {

                string Error = string.Empty;
                WrapperFunctions wrapperFunctions = new WrapperFunctions(Path.ToString());
                DeviceListMarkVIe = wrapperFunctions.GetDevicesList(WrapperFunctions.Devices.MarkVIe, WrapperFunctions.Mode.API, ref Error);
                DeviceListMarkVIeS = wrapperFunctions.GetDevicesList(WrapperFunctions.Devices.MarkVIeS, WrapperFunctions.Mode.API, ref Error);

            }
            catch (Exception ex)
            {

            }
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //if (blIsSave)
                //{
                //    PictureBoxFunctionsShow(pictureBox1);
                //    //pictureBox1.BringToFront();
                //    WrapperFunctions wrapperFunctions = new WrapperFunctions(Path);
                //    wrapperFunctions.SaveDevices(hshDevices);
                //}
                //else
                //{
                if (DeviceListMarkVIe.Count() == 0 && DeviceListMarkVIeS.Count() == 0)
                {
                    MessageBox.Show("No device(s) available in the selected tcw project", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TreeViewJobList.ExpandAll();
                    PictureBoxFunctionsHide(pictureBox1);
                }
                else
                {
                    //DeviceList dev = new DeviceList(DeviceListMarkVIe, DeviceListMarkVIeS);
                    //dev.ShowDialog();
                    string[] MarkVIeDeviceList = SelectTCWForm.SelectedMarkVIe.Split(',').ToArray();
                    string[] MarkVIeSDeviceList = SelectTCWForm.SelectedMarkVIeS.Split(',').ToArray();
                    foreach (string Device in MarkVIeDeviceList)
                    {
                        if (Device != null && Device != "")
                            SelectedDevices.Add(Device);
                    }
                    foreach (string Device in MarkVIeSDeviceList)
                    {
                        if (Device != null && Device != "")
                            SelectedDevices.Add(Device);
                    }
                    int TreeCount = 0;
                    if ((MarkVIeDeviceList.Count() > 0 && MarkVIeDeviceList[0] != "") || (MarkVIeSDeviceList.Count() > 0 && MarkVIeSDeviceList[0] != ""))
                    {
                        TreeViewJobList.Nodes[0].Nodes[0].Nodes.Add("", "ToolboxST", 6, 6);
                        if (MarkVIeDeviceList.Count() > 0 && MarkVIeDeviceList[0] != "")
                        {
                            foreach (string MVIE in MarkVIeDeviceList)
                            {
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes.Add("", (MVIE + "(MarkVIe)"), 1, 1);
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes.Add("Variables");
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[0].Nodes.Add("", "Global", 5, 5);
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[0].Nodes[0].Tag = MVIE + "-G";
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[0].Nodes.Add("", "Local", 5, 5);
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[0].Nodes[1].Tag = MVIE + "-L";
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes.Add("EGD Configuration");
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Tag = MVIE + "-E";
                                TreeCount++;
                            }
                        }
                        if (MarkVIeSDeviceList.Count() > 0 && MarkVIeSDeviceList[0] != "")
                        {
                            foreach (string MVIES in MarkVIeSDeviceList)
                            {
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes.Add("", (MVIES + "(MarkVIe-S)"), 4, 4);
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes.Add("Variables");
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[0].Nodes.Add("", "Global", 5, 5);
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[0].Nodes[0].Tag = MVIES + "-G";
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[0].Nodes.Add("", "Local", 5, 5);
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[0].Nodes[1].Tag = MVIES + "-L";
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes.Add("EGD Configuration");
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Tag = MVIES + "-E";
                                TreeCount++;
                            }
                        }
                    }
                    pictureBox1.BringToFront();

                    if (!bgw_GetVariables.IsBusy)
                    {
                        bgw_GetVariables.RunWorkerAsync();
                    }
                    //}
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GetVariables(string[] MarkVIe, string[] MarkVIeS)
        {
            string Error = string.Empty;
            try
            {
                WrapperFunctions wrapperFunctions = new WrapperFunctions(Path.ToString());
                //pictureBox1.Refresh();
                //pictureBox1.Show();
                //Getting the Global and Local Variables List for the selected device...
                foreach (string mVIe in MarkVIe)
                {
                    if (!string.IsNullOrEmpty(mVIe))
                    {
                        DataTable dtTemp = wrapperFunctions.GetVariablesWithProperties(mVIe, WrapperFunctions.VariableScope.Global, ref hshDevices, ref Error);
                        dtTemp.TableName = mVIe.ToString();
                        dtMarkVIe_Global.Add(dtTemp);

                        dtTemp = new DataTable();
                        dtTemp = wrapperFunctions.GetVariablesWithProperties(mVIe, WrapperFunctions.VariableScope.Local, ref hshDevices, ref Error);
                        dtTemp.TableName = mVIe.ToString();
                        dtMarkVIe_Local.Add(dtTemp);
                    }
                    if (hshDevices.ContainsKey(mVIe))
                    {
                        GetEGDPages((IDevice)hshDevices[mVIe]);
                    }
                }

                foreach (string mVIeS in MarkVIeS)
                {
                    if (!string.IsNullOrEmpty(mVIeS))
                    {
                        DataTable dtTemp = wrapperFunctions.GetVariablesWithProperties(mVIeS, WrapperFunctions.VariableScope.Global, ref hshDevices, ref Error);
                        dtTemp.TableName = mVIeS.ToString();
                        dtMarkVIeS_Global.Add(dtTemp);
                        dtTemp = new DataTable();
                        dtTemp = wrapperFunctions.GetVariablesWithProperties(mVIeS, WrapperFunctions.VariableScope.Local, ref hshDevices, ref Error);
                        dtTemp.TableName = mVIeS.ToString();
                        dtMarkVIeS_Local.Add(dtTemp);
                    }
                    if (hshDevices.ContainsKey(mVIeS))
                    {
                        GetEGDPages((IDevice)hshDevices[mVIeS]);
                    }
                    Device = null;
                }
            }
            catch (Exception ex)
            {

            }

        }
        private void GetEGDPages(IDevice Device)
        {
            string Error = string.Empty;
            try
            {
                WrapperFunctions wrapperFunctions = new WrapperFunctions(Path.ToString());
                DataTable dtTemp = wrapperFunctions.GetEgdPageWithProps(Device, ref Error);
                dtTemp.TableName = Device.Name.ToString();
                if (Device.DeviceType.ToString().ToUpper() == "MARKVIE")
                    dtMarkVIe_EGD.Add(dtTemp);
                else
                    dtMarkVIeS_EGD.Add(dtTemp);

            }
            catch (Exception ex)
            {

            }

        }
        private void PictureBoxFunctionsShow(PictureBox pictureBox)
        {
            try
            {
                pictureBox.Visible = true;
                //pictureBox.Dock = DockStyle.Fill;
                pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                pictureBox.Location = new Point((ClientSize.Width / 2) - (pictureBox.Width / 2), (ClientSize.Height / 2) - (pictureBox.Height / 2));
                //pictureBox.BackColor = Color.Transparent;
                pictureBox.Show();
            }
            catch (Exception ex)
            {

            }
        }
        private void PictureBoxFunctionsHide(PictureBox pictureBox)
        {
            try
            {
                pictureBox1.Enabled = false;
                pictureBox1.Visible = false;
            }
            catch (Exception ex)
            {

            }
        }
        private void bgw_GetVariables_DoWork(object sender, DoWorkEventArgs e)
        {
            string Error = string.Empty;
            try
            {
                string[] MarkVIeDeviceList = SelectTCWForm.SelectedMarkVIe.Split(',').ToArray();
                string[] MarkVIeSDeviceList = SelectTCWForm.SelectedMarkVIeS.Split(',').ToArray();
                GetVariables(MarkVIeDeviceList, MarkVIeSDeviceList);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void bgw_GetVariables_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                MessgageTextBoxOperation("The process of fetching variables of Global and Local is completed.");
                MessgageTextBoxOperation("The process of fetching EGD Pages are completed.");
                PictureBoxFunctionsHide(pictureBox1);
                TreeViewJobList.ExpandAll();
                MessageBox.Show("All the selected devices added successfully.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessgageTextBoxOperation("All the selected devices added successfully.");
                int TreeCount = 0;
                foreach (DataTable dtTmp in dtMarkVIe_EGD)
                {
                    for (int Ind = 0; Ind < dtTmp.Rows.Count; Ind++)
                    {
                        TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes.Add(dtTmp.Rows[Ind]["Name"].ToString());
                        TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes[Ind].Tag = dtTmp.Rows[Ind]["DeviceName"].ToString();
                        EGDPagesMVIe.Add(dtTmp.Rows[Ind]["Name"].ToString());
                        ExistingEGDPagesMVIe.Add(dtTmp.Rows[Ind]["Name"].ToString());
                        //DeviceName
                    }
                    TreeCount++;
                }
                foreach (DataTable dtTmp in dtMarkVIeS_EGD)
                {
                    for (int Ind = 0; Ind < dtTmp.Rows.Count; Ind++)
                    {
                        TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes.Add(dtTmp.Rows[Ind]["Name"].ToString());
                        TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes[Ind].Tag = dtTmp.Rows[Ind]["DeviceName"].ToString();
                        EGDPagesMVIeS.Add(dtTmp.Rows[Ind]["Name"].ToString());
                        ExistingEGDPagesMVIeS.Add(dtTmp.Rows[Ind]["Name"].ToString());
                    }
                    TreeCount++;
                }
                TreeViewJobList.ExpandAll();
            }
            catch (Exception ex)
            {

            }
        }
        private void TreeViewJobList_Click(object sender, EventArgs e)
        {
            try
            {
                //if (TreeViewJobList.SelectedNode != null && TreeViewJobList.SelectedNode.Text != null)
                //    MessageBox.Show(TreeViewJobList.SelectedNode.Text);
            }
            catch (Exception ex)
            {

            }
        }
        private void TreeViewJobList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (TreeViewJobList.SelectedNode != null && TreeViewJobList.SelectedNode.Text != null)
                {
                    if (TreeViewJobList.SelectedNode.Text.Contains("Job Configuration"))
                    {
                        //AllignGridViews(advancedDataGridView: dgvAllData, propertyGrid: pgBase, PGView: true);
                        pgBase.Height = 388;
                        pgBase.Width = 1031;
                        dgvAllData.Visible = false;
                        lblHeading.Text = "JOB DETAILS";
                        Jobdetails jobdetails = new Jobdetails();
                        jobdetails.Company = Company;
                        jobdetails.Errors = string.Empty;
                        jobdetails.Filepath = Path;
                        jobdetails.JobNumber = JobNumber;
                        jobdetails.Messages = string.Empty;
                        jobdetails.User = userName;
                        jobdetails.Warnings = string.Empty;
                        pgBase.SelectedObject = jobdetails;
                        pgBase.Visible = true;
                        lblHeading.Visible = true;
                        lblTotalRecords.Visible = false;

                    }
                    else if (TreeViewJobList.SelectedNode.Text.Contains("ToolboxST"))
                    {
                        //AllignGridViews(advancedDataGridView: dgvAllData, propertyGrid: pgBase, PGView: true);
                        pgBase.Height = 388;
                        pgBase.Width = 1031;
                        pgBase.Location = new Point(230, 77);
                        lblHeading.Text = "TOOLBOX ST SOFTWARE";
                        dgvAllData.Visible = false;
                        ToolboxST toolboxST = new ToolboxST();
                        toolboxST.APPVersion = "";
                        toolboxST.Errors = "";
                        toolboxST.Filepath = Path;
                        toolboxST.Messages = "";
                        toolboxST.TCWVersion = "";
                        toolboxST.Warnings = "";
                        pgBase.SelectedObject = toolboxST;
                        pgBase.Visible = true;
                        lblHeading.Visible = true;
                        lblTotalRecords.Visible = false;

                    }
                    else if (TreeViewJobList.SelectedNode.Text.Contains("MarkVIe") || TreeViewJobList.SelectedNode.Text.Contains("MarkVIe-S"))
                    {

                        string DeviceName = TreeViewJobList.SelectedNode.Text.Replace("(MarkVIe-S)", "").Replace("(MarkVIe)", "");
                        if (hshDevices.ContainsKey(DeviceName))
                        {
                            WrapperFunctions wrapperFunctions = new WrapperFunctions(Path);
                            string deviceVersion = wrapperFunctions.GetDeviceVersion((IDevice)hshDevices[DeviceName]);
                            string deviceType = wrapperFunctions.GetDeviceType((IDevice)hshDevices[DeviceName]);
                            DeviceDetails deviceDetails = new DeviceDetails();
                            deviceDetails.DeviceName = DeviceName;
                            deviceDetails.DeviceType = deviceType;
                            deviceDetails.DeviceVersion = deviceVersion;
                            deviceDetails.Errors = string.Empty;
                            deviceDetails.Messages = string.Empty;
                            deviceDetails.Warnings = string.Empty;
                            pgBase.SelectedObject = deviceDetails;

                            pgBase.Height = 388;
                            pgBase.Width = 1133;
                            pgBase.Visible = true;
                            dgvAllData.Visible = false;
                            pgBase.Location = new Point(230, 77);
                            lblHeading.Text = DeviceName;
                            lblHeading.Visible = true;
                            lblTotalRecords.Visible = false;


                        }
                        else
                        {
                            dgvAllData.Visible = false;
                            pgBase.Visible = false;
                            lblHeading.Visible = false;
                            pictureBox1.Visible = false;
                            dgvAllData1.Visible = false;
                            //pgBase.Visible = true;
                            pgBase.SelectedObject = new object();
                            lblTotalRecords.Visible = false;
                        }

                    }
                    else if ((TreeViewJobList.SelectedNode.Text.ToUpper().Contains("GLOBAL") || TreeViewJobList.SelectedNode.Text.ToUpper().Contains("LOCAL")))
                    {
                        DataTable dtTempVar = new DataTable();
                        //AllignGridViews(advancedDataGridView: dgvAllData, propertyGrid: pgBase, ADGVView: true);
                        dgvAllData.Height = 388;
                        dgvAllData.Width = 1133;
                        dgvAllData.Location = new Point(230, 77);
                        pgBase.Visible = false;
                        if (TreeViewJobList.SelectedNode.Tag.ToString().Split('-').Last() == "L")
                        {
                            DataTable dtTmp = new DataTable();
                            bool blMarkVIe = false;
                            foreach (DataTable dt in dtMarkVIe_Local)
                            {
                                if (dt.TableName == TreeViewJobList.SelectedNode.Tag.ToString().Split('-').First())
                                {
                                    dgvAllData.DataSource = dt;
                                    dtVariables = new DataTable();
                                    dtTempVar = dt.Copy();
                                    dtVariables = dt.Copy();
                                    dtTempVar = VariableWithLimitedColumns(dtTempVar);
                                    //dgvAllData.DataSource = dtTempVar;
                                    blMarkVIe = true;
                                }
                            }
                            if (!blMarkVIe)
                            {
                                foreach (DataTable dt in dtMarkVIeS_Local)
                                {
                                    if (dt.TableName == TreeViewJobList.SelectedNode.Tag.ToString().Split('-').First())
                                    {
                                        dgvAllData.DataSource = dt;
                                        dtVariables = new DataTable();
                                        dtVariables = dt.Copy();
                                        dtTempVar = dt.Copy();
                                        dtTempVar = VariableWithLimitedColumns(dtTempVar);
                                        //dgvAllData.DataSource = dtTempVar;
                                        blMarkVIe = true;
                                    }
                                }
                            }
                            lblHeading.Text = TreeViewJobList.SelectedNode.Tag.ToString().Split('-').First() + " - LOCAL VARIABLES";
                        }
                        else
                        {

                            DataTable dtTmp = new DataTable();
                            bool blMarkVIe = false;
                            foreach (DataTable dt in dtMarkVIe_Global)
                            {
                                if (dt.TableName == TreeViewJobList.SelectedNode.Tag.ToString().Split('-').First())
                                {
                                    dgvAllData.DataSource = dt;
                                    dtVariables = new DataTable();
                                    dtVariables = dt.Copy();
                                    dtTempVar = dt.Copy();
                                    dtTempVar = VariableWithLimitedColumns(dtTempVar);
                                    //dgvAllData.DataSource = dtTempVar;
                                    blMarkVIe = true;
                                }
                            }
                            if (!blMarkVIe)
                            {
                                foreach (DataTable dt in dtMarkVIeS_Global)
                                {
                                    if (dt.TableName == TreeViewJobList.SelectedNode.Tag.ToString().Split('-').First())
                                    {
                                        dgvAllData.DataSource = dt;
                                        dtVariables = new DataTable();
                                        dtVariables = dt.Copy();
                                        dtTempVar = dt.Copy();
                                        dtTempVar = VariableWithLimitedColumns(dtTempVar);
                                        //dgvAllData.DataSource = dtTempVar;
                                        blMarkVIe = true;
                                    }
                                }
                            }
                            lblHeading.Text = TreeViewJobList.SelectedNode.Tag.ToString().Split('-').First() + " - GLOBAL VARIABLES";
                        }
                        dgvAllData.Visible = true;
                        lblHeading.Visible = true;
                        lblTotalRecords.Visible = true;
                        lblTotalRecords.Text = "TOTAL RECORDS : " + dgvAllData.Rows.Count + "";

                    }
                    else if (TreeViewJobList.SelectedNode.Parent.Text == "EGD Configuration")
                    {
                        string Txt = TreeViewJobList.SelectedNode.Tag != null && TreeViewJobList.SelectedNode.Tag.ToString() != "" ? TreeViewJobList.SelectedNode.Tag.ToString() : "";
                        DataTable dtTmp = new DataTable();
                        bool blMarkVIe = false;
                        bool blMarkVIeS = false;
                        foreach (DataTable dt in dtMarkVIe_EGD)
                        {
                            if (dt.TableName == Txt)
                            {
                                EGDPropertyGrid(pgBase, TreeViewJobList.SelectedNode.Text, dt);
                                //dgvAllData.DataSource = dt.AsEnumerable().Where(xx => xx["Name"].ToString().Equals(TreeViewJobList.SelectedNode.Text)).Select(xx => xx).CopyToDataTable();
                                blMarkVIe = true;
                            }
                        }
                        if (!blMarkVIe)
                        {
                            foreach (DataTable dt in dtMarkVIeS_EGD)
                            {
                                if (dt.TableName == Txt)
                                {
                                    EGDPropertyGrid(pgBase, TreeViewJobList.SelectedNode.Text, dt);
                                    //dgvAllData.DataSource = dt.AsEnumerable().Where(xx => xx["Name"].ToString().Equals(TreeViewJobList.SelectedNode.Text)).Select(xx => xx).CopyToDataTable();
                                    blMarkVIeS = true;
                                }
                            }
                        }
                        if (blMarkVIeS || blMarkVIe)
                        {
                            pgBase.Height = 388;
                            pgBase.Width = 1133;
                            pgBase.Visible = true;
                            dgvAllData.Visible = false;
                            pgBase.Location = new Point(230, 77);
                            //AllignGridViews(advancedDataGridView: dgvAllData, propertyGrid: pgBase, ADGVView: true);
                            lblHeading.Text = TreeViewJobList.SelectedNode.Tag.ToString().Split('-').First() + " - EGD PAGE";
                            lblHeading.Visible = true;
                            lblTotalRecords.Visible = false;

                            //dgvAllData.Height = 388;
                            //dgvAllData.Width = 1133;
                            //pgBase.Visible = false;
                            //dgvAllData.Visible = true;
                            //dgvAllData.Location = new Point(230, 77);
                            ////AllignGridViews(advancedDataGridView: dgvAllData, propertyGrid: pgBase, ADGVView: true);
                            //lblHeading.Text = TreeViewJobList.SelectedNode.Tag.ToString().Split('-').First() + " - EGD PAGE";
                            //lblHeading.Visible = true;
                        }
                        //}
                    }
                    else if (TreeViewJobList.SelectedNode.Text.Equals("Variables"))
                    {
                        pgBase.SelectedObject = new object();
                        pgBase.Height = 388;
                        pgBase.Width = 1133;
                        pgBase.Visible = true;
                        dgvAllData.Visible = false;
                        pgBase.Location = new Point(230, 77);
                        lblHeading.Text = "Variables";
                        lblHeading.Visible = true;
                        lblTotalRecords.Visible = false;
                    }
                    else if (TreeViewJobList.SelectedNode.Text.Equals("EGD Configuration"))
                    {
                        pgBase.SelectedObject = new object();
                        pgBase.Height = 388;
                        pgBase.Width = 1133;
                        pgBase.Visible = true;
                        dgvAllData.Visible = false;
                        pgBase.Location = new Point(230, 77);
                        lblHeading.Text = "Ethernet Global Data";
                        lblHeading.Visible = true;
                        lblTotalRecords.Visible = false;
                    }
                    else
                    {
                        dgvAllData.Visible = false;
                        pgBase.Visible = false;
                        lblHeading.Visible = false;
                        pictureBox1.Visible = false;
                        dgvAllData1.Visible = false;
                        //pgBase.Visible = true;
                        pgBase.SelectedObject = new object();
                        lblTotalRecords.Visible = false;

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Exception");
            }
        }
        private void NewRemotePrj()
        {
            try
            {
                if (TreeViewJobList.Nodes.Count == 0)
                {

                    NewJob newJob = new NewJob(userName);
                    newJob.ShowDialog();
                    JobNumber = newJob.JobNumber;
                    Company = newJob.Company;

                    TreeViewJobList.Nodes.Add("Job Configuration :: " + JobNumber + "");
                    TreeViewJobList.Nodes[0].Nodes.Add("PLC");
                    TreeViewJobList.Nodes[0].Nodes[0].Tag = 1;
                    TreeViewJobList.Nodes[0].Nodes.Add("HMI");
                    TreeViewJobList.Nodes[0].Nodes[1].Tag = 2;
                    TreeViewJobList.Nodes[0].Nodes.Add("Serial List");
                    TreeViewJobList.Nodes[0].Nodes[2].Tag = 3;
                    TreeViewJobList.Nodes[0].Nodes.Add("OSM List");
                    TreeViewJobList.Nodes[0].Nodes[3].Tag = 4;
                    TreeViewJobList.ExpandAll();
                    txtbxInfo.Text += "\nNew Job with job number " + JobNumber + " is created successfully.\n";
                }
                else
                {
                    DialogResult result = MessageBox.Show("Already job is created. If proceed to create new job, the existing data will lost.\nAre you sure want to continue?", "NEW JOB", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (result == DialogResult.OK)
                    {
                        NewJob newJob = new NewJob(userName);
                        newJob.ShowDialog();
                        JobNumber = newJob.JobNumber;
                        Company = newJob.Company;
                        TreeViewJobList.Nodes.Clear();

                        JobNumber = newJob.JobNumber;
                        TreeViewJobList.Nodes.Add("Job Configuration :: " + newJob.JobNumber + "");
                        TreeViewJobList.Nodes[0].Nodes.Add("PLC");
                        TreeViewJobList.Nodes[0].Nodes[0].Tag = 1;
                        TreeViewJobList.Nodes[0].Nodes.Add("HMI");
                        TreeViewJobList.Nodes[0].Nodes[1].Tag = 2;
                        TreeViewJobList.Nodes[0].Nodes.Add("Serial List");
                        TreeViewJobList.Nodes[0].Nodes[2].Tag = 3;
                        TreeViewJobList.Nodes[0].Nodes.Add("OSM List");
                        TreeViewJobList.Nodes[0].Nodes[3].Tag = 4;
                        TreeViewJobList.ExpandAll();

                        txtbxInfo.Text += "\r\nNew Job with job number " + newJob.JobNumber + " is created successfully.\r\n";

                        dgvAllData.Visible = false;
                        pgBase.Visible = false;
                        lblHeading.Visible = false;
                        pictureBox1.Visible = false;
                        dgvAllData1.Visible = false;
                        pgBase.SelectedObject = new object();

                    }
                }


            }
            catch (Exception ex)
            {

            }
        }
        private void tsbNewPrj_Click(object sender, EventArgs e)
        {
            try
            {
                NewRemotePrj();
            }
            catch (Exception ex)
            {

            }
        }
        private void EGDConfigurator_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            object sender = new object();
            EventArgs e = new EventArgs();
            //if (keyData == (Keys.Alt | Keys.F4))
            //{
            //    pbxLogout_Click(sender, e);//Logout
            //    return true;
            //}

            //else if (keyData == (Keys.F10))
            //{
            //    pbxLogout_Click(sender, e);//Logout
            //    return true;
            //}
            try
            {


                if (keyData == (Keys.Control | Keys.N))
                {
                    tsbNewPrj.PerformClick();
                    return true;
                }
                else if (keyData == (Keys.Control | Keys.S))
                {
                    //tsbNewPrj.PerformClick();
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void TreeViewJobList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                    TreeViewJobList.SelectedNode = e.Node;

                if (TreeViewJobList != null && TreeViewJobList.SelectedNode != null &&
                    TreeViewJobList.SelectedNode.Tag != null && TreeViewJobList.SelectedNode.Tag.ToString() == "1" && e.Button == MouseButtons.Right)
                {
                    contextMenuStrip1.Show(Cursor.Position);
                }
                else if (TreeViewJobList != null && TreeViewJobList.SelectedNode != null &&
                    TreeViewJobList.SelectedNode.Tag != null && TreeViewJobList.SelectedNode.Tag.ToString().Split('-').Last().ToString() == "E" && e.Button == MouseButtons.Right)
                {
                    cmsEGDConfig.Show(Cursor.Position);
                }
                else if (TreeViewJobList != null && TreeViewJobList.SelectedNode != null &&
                    TreeViewJobList.SelectedNode.Tag != null && (EGDPagesMVIe.Contains(TreeViewJobList.SelectedNode.Text) || EGDPagesMVIeS.Contains(TreeViewJobList.SelectedNode.Text)) && e.Button == MouseButtons.Right)
                {
                    cmsRemoveEGD.Show(Cursor.Position);
                    removeEGDPageToolStripMenuItem.Enabled = true;
                    if (ExistingEGDPagesMVIe.Contains(TreeViewJobList.SelectedNode.Text) || ExistingEGDPagesMVIeS.Contains(TreeViewJobList.SelectedNode.Text))
                    {
                        cloneEGDPageToolStripMenuItem.Enabled = true;
                        removeEGDPageToolStripMenuItem.Enabled = false;
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        private void dgvAllData_SortStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.SortEventArgs e)
        {

        }
        private void dgvAllData_FilterStringChanged(object sender, Zuby.ADGV.AdvancedDataGridView.FilterEventArgs e)
        {

        }
        private void AllignGridViews([Optional] AdvancedDataGridView advancedDataGridView, [Optional] PropertyGrid propertyGrid, [Optional] bool ADGVView, [Optional] bool PGView)
        {
            try
            {
                advancedDataGridView.Height = 388;
                advancedDataGridView.Width = 1031;
                propertyGrid.Visible = false;
                advancedDataGridView.Visible = ADGVView;
                advancedDataGridView.Location = new Point(230, 77);
                propertyGrid.Height = 388;
                propertyGrid.Width = 1031;
                advancedDataGridView.Visible = false;
                propertyGrid.Visible = PGView;
                propertyGrid.Location = new Point(230, 77);

            }
            catch (Exception ex)
            {

            }
        }
        private void MessgageTextBoxOperation(string Text)
        {
            try
            {
                txtbxInfo.Text += "" + Text + "\r\n";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void organizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //OrganizeColumns organizeColumns = new OrganizeColumns(dtVariables);
                //organizeColumns.ShowDialog();
                //ShownColumns = organizeColumns.ShownColumns;
                //dgvAllData = new AdvancedDataGridView();
                //dgvAllData.AutoGenerateColumns = false;
                //dgvAllData.ColumnCount = ShownColumns.Count;
                //int ColumnCount = 0;
                //foreach (string ColumnName in ShownColumns)
                //{
                //    dgvAllData.Columns[ColumnCount].HeaderText = ColumnName;
                //    dgvAllData.Columns[ColumnCount].DataPropertyName = ColumnName;
                //    ColumnCount++;
                //}
                //dgvAllData.DataSource = dtVariables;
            }
            catch (Exception ex)
            {

            }
        }
        private bool EGDPropertyGrid(PropertyGrid propertyGrid, string Name, DataTable dataTable)
        {
            try
            {
                EGDProperies eGDProperies = new EGDProperies(Name);
                var Res = from Value in dataTable.AsEnumerable()
                          where Value["Name"].ToString() == Name
                          select new
                          {
                              Name = Value["Name"].ToString(),
                              DeviceName = Value["DeviceName"].ToString(),
                              StatusPage = Value["StatusPage"].ToString(),
                              AllowEdits = Value["AllowEdits"].ToString(),
                              AutoConfigure = Value["AutoConfigure"].ToString(),
                              Available = Value["Available"].ToString(),
                              DefaultPage = Value["DefaultPage"].ToString(),
                              Description = Value["Description"].ToString(),
                              DestinationAddresses = Value["DestinationAddresses"].ToString(),
                              DirectedIPAddress = Value["DirectedIPAddress"].ToString(),
                              Ethernet0 = Value["Ethernet0"].ToString(),
                              Ethernet1 = Value["Ethernet1"].ToString(),
                              Ethernet2 = Value["Ethernet2"].ToString(),
                              Ethernet3 = Value["Ethernet3"].ToString(),
                              Exchanges = Value["Exchanges"].ToString(),
                              HealthTimeoutMultiplier = Value["HealthTimeoutMultiplier"].ToString(),
                              IndexableChildren = Value["IndexableChildren"].ToString(),
                              IndexableProperties = Value["IndexableProperties"].ToString(),
                              Location = Value["Location"].ToString(),
                              LocatorID = Value["LocatorID"].ToString(),
                              MinimumExchangeLength = Value["MinimumExchangeLength"].ToString(),
                              LayoutMode = Value["LayoutMode"].ToString(),
                              Multiplier = Value["Multiplier"].ToString(),
                              NumExchanges = Value["NumExchanges"].ToString(),
                              ParentObject = Value["ParentObject"].ToString(),
                              Period = Value["Period"].ToString(),
                              PrimaryProducerName = Value["PrimaryProducerName"].ToString(),
                              ReattachPageVarsAfterPageRename = Value["ReattachPageVarsAfterPageRename"].ToString(),
                              SecondaryProducerId = Value["SecondaryProducerId"].ToString(),
                              Skew = Value["Skew"].ToString(),
                              StartingExchangeId = Value["StartingExchangeId"].ToString(),
                              UseVarAtOffsetZeroForHealth = Value["UseVarAtOffsetZeroForHealth"].ToString(),
                              ExchangeId = Value["ExchangeId"].ToString(),
                              ConfigurationTime = Value["ConfigurationTime"].ToString(),
                              DataLength = Value["DataLength"].ToString(),
                              SignatureMajor = Value["SignatureMajor"].ToString(),
                              SignatureMinor = Value["SignatureMinor"].ToString(),
                              Mode = Value["Mode"].ToString(),

                          };

                if (Res != null && Res.Count() > 0)
                {
                    eGDProperies.AllowEdits = Res.First().AllowEdits;
                    eGDProperies.AutoConfigure = Res.First().AutoConfigure;
                    eGDProperies.Available = Res.First().Available;
                    eGDProperies.DefaultPage = Res.First().DefaultPage;
                    eGDProperies.Description = Res.First().Description;
                    eGDProperies.Destination = Res.First().AutoConfigure;
                    eGDProperies.DestinationAddresses = Res.First().DestinationAddresses;
                    eGDProperies.DeviceName = Res.First().DeviceName;
                    eGDProperies.DirectedIPAddress = Res.First().DirectedIPAddress;
                    eGDProperies.Ethernet0 = Convert.ToBoolean(Res.First().Ethernet0.ToString());
                    eGDProperies.Ethernet1 = Res.First().Ethernet1;
                    eGDProperies.Ethernet2 = Res.First().Ethernet2;
                    eGDProperies.Ethernet3 = Res.First().Ethernet3;
                    eGDProperies.Exchanges = Res.First().Exchanges;
                    eGDProperies.HealthTimeoutMultiplier = Res.First().HealthTimeoutMultiplier;
                    //eGDProperies.IndexableChildren = Res.First().IndexableChildren;
                    //eGDProperies.IndexableProperties = Res.First().IndexableProperties;
                    eGDProperies.LayoutMode = Res.First().LayoutMode.ToUpper() == "AUTO" ? EGDProperies.layoutmode.Auto : EGDProperies.layoutmode.Manual;
                    eGDProperies.Mode = Res.First().Mode.ToUpper() == "BROADCAST" ? EGDProperies.mode.Broadcast : Res.First().Mode.ToUpper() == "UNICAST" ? EGDProperies.mode.Unicast : EGDProperies.mode.Multicast;
                    eGDProperies.Location = Res.First().Location;
                    eGDProperies.LocatorID = Res.First().LocatorID;
                    eGDProperies.MinimumExchangeLength = Res.First().MinimumExchangeLength;
                    eGDProperies.Multiplier = Res.First().Multiplier;
                    eGDProperies.Name = Res.First().Name;
                    eGDProperies.NumExchanges = Res.First().NumExchanges;
                    //eGDProperies.ParentObject = Res.First().ParentObject;
                    eGDProperies.Period = Res.First().Period;
                    eGDProperies.PrimaryProducerName = Res.First().PrimaryProducerName;
                    eGDProperies.ReattachPageVarsAfterPageRename = Res.First().ReattachPageVarsAfterPageRename;
                    //eGDProperies.Redundancy = Res.First().Redundancy;
                    eGDProperies.SecondaryProducerId = Res.First().SecondaryProducerId;
                    eGDProperies.Skew = Res.First().Skew;
                    eGDProperies.StartingExchangeId = Res.First().StartingExchangeId;
                    eGDProperies.StatusPage = Res.First().StatusPage;
                    eGDProperies.UseVarAtOffsetZeroForHealth = Res.First().UseVarAtOffsetZeroForHealth;

                    eGDProperies.ExchangeId = Res.First().ExchangeId;
                    eGDProperies.ConfigurationTime = Res.First().ConfigurationTime;
                    eGDProperies.Length = Res.First().DataLength;
                    eGDProperies.Signature = Res.First().SignatureMajor + "." + Res.First().SignatureMinor;
                    propertyGrid.SelectedObject = eGDProperies;
                    return true;
                }
                else
                    return false;


            }
            catch (Exception ex)
            {
                return false;

            }
        }
        private DataTable VariableWithLimitedColumns(DataTable dtVariables)
        {
            DataTable dtRetuen = new DataTable();
            try
            {
                string[] AllColumns = (from dc in dtVariables.Columns.Cast<DataColumn>()
                                       select dc.ColumnName).ToArray();
                string[] ArrayExcept = AllColumns.Except(columnNamesShown).ToArray();

                foreach (string ExceptColumns in ArrayExcept)
                {
                    if (dtVariables.Columns.Contains(ExceptColumns))
                        dtVariables.Columns.Remove(ExceptColumns);
                }

                return dtRetuen = dtVariables;
            }
            catch (Exception ex)
            {
                return dtRetuen;
            }
        }
        private void addEGDPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string DeviceName = TreeViewJobList.SelectedNode.Tag.ToString();
                AddEGDPage addEGDPage = new AddEGDPage(EGDPagesMVIe.ToArray(), hshDevices, Path, DeviceName.Split('-').First());
                addEGDPage.ShowDialog();
                if (addEGDPage.Error == "Existing EGD Page")
                {

                }
                else
                    RefreshEGDPages(DeviceName.Split('-').First());
                blIsSave = true;
            }
            catch (Exception ex)
            {

            }
        }
        private void refreshEGDPagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Error = string.Empty;
            try
            {
                string DeviceName = TreeViewJobList.SelectedNode.Tag.ToString().Split('-').First();
                WrapperFunctions wrapperFunctions = new WrapperFunctions(Path);
                DataTable dtEGD = wrapperFunctions.GetEgdPageWithProps((IDevice)hshDevices[DeviceName], ref Error);
                dtEGD.TableName = DeviceName;

                DataTable dt = dtMarkVIe_EGD.Where(xx => xx.TableName == DeviceName).Select(xx => xx).FirstOrDefault();
                //bool blMarkVIe = Convert.ToBoolean(dtMarkVIe_EGD.Where(xx => xx.TableName == DeviceName).Select(xx => "true").ToString());
                if (dt != null && dt.Rows.Count > 0)
                {
                    #region MarkVIe
                    List<DataTable> dtLstTmp = new List<DataTable>();
                    foreach (DataTable dtTmp in dtMarkVIe_EGD)
                    {
                        if (dtTmp.TableName == DeviceName)
                        {
                            dtLstTmp.Add(dtEGD);
                        }
                        else
                            dtLstTmp.Add(dtTmp);
                    }

                    dtMarkVIe_EGD = new List<DataTable>();
                    dtMarkVIe_EGD = dtLstTmp;
                    dtLstTmp = new List<DataTable>();
                    int TreeCount = 0;
                    EGDPagesMVIe = new List<string>();
                    foreach (DataTable dtTmp in dtMarkVIe_EGD)
                    {
                        for (int Ind = 0; Ind < dtTmp.Rows.Count; Ind++)
                        {
                            TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes.Clear();
                        }
                        TreeCount++;
                    }

                    TreeCount = 0;
                    foreach (DataTable dtTmp in dtMarkVIe_EGD)
                    {
                        for (int Ind = 0; Ind < dtTmp.Rows.Count; Ind++)
                        {
                            TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes.Add(dtTmp.Rows[Ind]["Name"].ToString());
                            TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes[Ind].Tag = dtTmp.Rows[Ind]["DeviceName"].ToString();
                            EGDPagesMVIe.Add(dtTmp.Rows[Ind]["Name"].ToString());
                        }
                        TreeCount++;
                    }
                    #endregion
                }
                else
                {
                    #region MarkVIe-S
                    List<DataTable> dtLstTmp = new List<DataTable>();
                    foreach (DataTable dtTmp in dtMarkVIeS_EGD)
                    {
                        if (dtTmp.TableName == DeviceName)
                        {
                            dtLstTmp.Add(dtEGD);
                        }
                        else
                            dtLstTmp.Add(dtTmp);
                    }

                    dtMarkVIeS_EGD = new List<DataTable>();
                    dtMarkVIeS_EGD = dtLstTmp;
                    dtLstTmp = new List<DataTable>();
                    int TreeCount = 0;
                    EGDPagesMVIeS = new List<string>();
                    foreach (DataTable dtTmp in dtMarkVIeS_EGD)
                    {
                        for (int Ind = 0; Ind < dtTmp.Rows.Count; Ind++)
                        {
                            TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes.Clear();
                        }
                        TreeCount++;
                    }

                    TreeCount = 0;
                    foreach (DataTable dtTmp in dtMarkVIeS_EGD)
                    {
                        for (int Ind = 0; Ind < dtTmp.Rows.Count; Ind++)
                        {
                            TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes.Add(dtTmp.Rows[Ind]["Name"].ToString());
                            TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes[Ind].Tag = dtTmp.Rows[Ind]["DeviceName"].ToString();
                            EGDPagesMVIeS.Add(dtTmp.Rows[Ind]["Name"].ToString());
                        }
                        TreeCount++;
                    }
                    #endregion
                }

            }
            catch (Exception ex)
            {

            }
        }
        private void removeEGDPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Error = string.Empty;
            try
            {
                DialogResult Result = MessageBox.Show("Are you sure want to remove this EGD page?", "Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Result == DialogResult.OK)
                {
                    string DeviceName = TreeViewJobList.SelectedNode.Tag.ToString();
                    WrapperFunctions wrapperFunctions = new WrapperFunctions(Path);
                    bool blRemoveEGD = wrapperFunctions.RemoveEGDPage((IDevice)hshDevices[DeviceName], TreeViewJobList.SelectedNode.Text.ToString(), ref Error);
                    if (blRemoveEGD)
                        MessageBox.Show("The EGD Page " + TreeViewJobList.SelectedNode.Text.ToString() + " is removed successfully from the controller " + DeviceName + ".", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshEGDPages(DeviceName);

                    dgvAllData.Visible = false;
                    pgBase.Visible = false;
                    lblHeading.Visible = false;
                    pictureBox1.Visible = false;
                    dgvAllData1.Visible = false;
                    //pgBase.Visible = true;
                    pgBase.SelectedObject = new object();
                    lblTotalRecords.Visible = false;

                }

            }
            catch (Exception ex)
            {

            }
        }
        private void RefreshEGDPages(string deviceName, [Optional] string FullPath)
        {
            string Error = string.Empty;
            try
            {

                int TreeCount = 0;
                //string DeviceName = deviceName;
                WrapperFunctions wrapperFunctions = new WrapperFunctions(Path);
                string AddedDevice = string.Empty;
                foreach (string DeviceName in SelectedDevices)
                {
                    if (AddedDevice.Split(',').Contains(DeviceName))
                        continue;

                    DataTable dtEGD = wrapperFunctions.GetEgdPageWithProps((IDevice)hshDevices[DeviceName], ref Error);
                    dtEGD.TableName = DeviceName;

                    DataTable dt = dtMarkVIe_EGD.Where(xx => xx.TableName == DeviceName).Select(xx => xx).FirstOrDefault();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        #region MarkVIe
                        List<DataTable> dtLstTmp = new List<DataTable>();
                        foreach (DataTable dtTmp in dtMarkVIe_EGD)
                        {
                            if (dtTmp.TableName == DeviceName)
                            {
                                dtLstTmp.Add(dtEGD);
                                AddedDevice += dtTmp.TableName + ",";
                            }
                            else
                            {
                                dtLstTmp.Add(dtTmp);
                                AddedDevice += dtTmp.TableName + ",";
                            }
                        }

                        dtMarkVIe_EGD = new List<DataTable>();
                        dtMarkVIe_EGD = dtLstTmp;
                        dtLstTmp = new List<DataTable>();

                        EGDPagesMVIe = new List<string>();
                        foreach (DataTable dtTmp in dtMarkVIe_EGD)
                        {
                            for (int Ind = 0; Ind < dtTmp.Rows.Count; Ind++)
                            {
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes.Clear();
                            }
                            TreeCount++;
                        }

                        TreeCount = 0;
                        foreach (DataTable dtTmp in dtMarkVIe_EGD)
                        {
                            for (int Ind = 0; Ind < dtTmp.Rows.Count; Ind++)
                            {
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes.Add(dtTmp.Rows[Ind]["Name"].ToString());
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes[Ind].Tag = dtTmp.Rows[Ind]["DeviceName"].ToString();
                                EGDPagesMVIe.Add(dtTmp.Rows[Ind]["Name"].ToString());
                            }
                            TreeCount++;
                        }
                        #endregion
                    }
                    else
                    {
                        #region MarkVIe-S
                        List<DataTable> dtLstTmp = new List<DataTable>();
                        foreach (DataTable dtTmp in dtMarkVIeS_EGD)
                        {
                            if (dtTmp.TableName == DeviceName)
                            {
                                dtLstTmp.Add(dtEGD);
                                AddedDevice += dtTmp.TableName + ",";
                            }
                            else
                            {
                                dtLstTmp.Add(dtTmp);
                                AddedDevice += dtTmp.TableName + ",";
                            }
                        }

                        dtMarkVIeS_EGD = new List<DataTable>();
                        dtMarkVIeS_EGD = dtLstTmp;
                        dtLstTmp = new List<DataTable>();
                        int TmpTreeCount = TreeCount;
                        EGDPagesMVIeS = new List<string>();

                        foreach (DataTable dtTmp in dtMarkVIeS_EGD)
                        {
                            for (int Ind = 0; Ind < dtTmp.Rows.Count; Ind++)
                            {
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TreeCount].Nodes[1].Nodes.Clear();
                            }
                            TreeCount++;
                        }

                        //TreeCount = 0;
                        foreach (DataTable dtTmp in dtMarkVIeS_EGD)
                        {
                            for (int Ind = 0; Ind < dtTmp.Rows.Count; Ind++)
                            {
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TmpTreeCount].Nodes[1].Nodes.Add(dtTmp.Rows[Ind]["Name"].ToString());
                                TreeViewJobList.Nodes[0].Nodes[0].Nodes[0].Nodes[TmpTreeCount].Nodes[1].Nodes[Ind].Tag = dtTmp.Rows[Ind]["DeviceName"].ToString();
                                EGDPagesMVIeS.Add(dtTmp.Rows[Ind]["Name"].ToString());
                            }
                            TmpTreeCount++;
                        }
                        #endregion
                    }
                }
                TreeViewJobList.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void pgBase_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            string Error = string.Empty;
            try
            {
                WrapperFunctions wrapperFunctions = new WrapperFunctions(Path);
                TreeView treeView = TreeViewJobList;
                TreeNode treeNode = treeView.SelectedNode;
                if (TreeViewJobList.SelectedNode.Parent.Text == "EGD Configuration")
                {
                    string DeviceName = TreeViewJobList.SelectedNode.Tag.ToString();
                    string ChangedValue = e != null && e.ChangedItem != null && e.ChangedItem.Value != null ? e.ChangedItem.Value.ToString() : "";
                    string ChangeFor = e != null && e.ChangedItem != null && e.ChangedItem.Label != null ? e.ChangedItem.Label.ToString() : "";
                    EGDProps eGDProps = new EGDProps();
                    switch (ChangeFor)
                    {
                        case "LayoutMode":
                            eGDProps.LayoutMode = ChangedValue;
                            break;
                        case "Destination":
                            eGDProps.Destination = ChangedValue;
                            break;
                        case "Ethernet0":
                            eGDProps.Ethernet0 = ChangedValue;
                            break;
                        case "MinimumExchangeLength":
                            eGDProps.MinimumExchangeLength = ChangedValue;
                            break;
                        case "Multiplier":
                            eGDProps.Multiplier = ChangedValue;
                            break;
                        case "Name":
                            eGDProps.Name = ChangedValue;
                            break;
                        case "Skew":
                            eGDProps.Skew = ChangedValue;
                            break;
                        case "StartingExchangeId":
                            eGDProps.StartingExchangeId = ChangedValue;
                            break;
                        case "Mode":
                            eGDProps.Destination = ChangedValue;
                            break;
                        case "Description":
                            eGDProps.Description = ChangedValue;
                            break;

                        default:
                            break;
                    }
                    if (eGDProps != null)
                    {
                        if (!wrapperFunctions.SetEGDPage((IDevice)hshDevices[DeviceName], TreeViewJobList.SelectedNode.Text, ref Error, eGDProps))
                        {
                            MessageBox.Show(Error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    RefreshEGDPages(DeviceName);
                    TreeViewJobList.SelectedNode = this.TreeViewJobList.SelectedNode;
                    blIsSave = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void cloneEGDPageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void cloneEGDPageToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            try
            {
                string EGDPageName = TreeViewJobList.SelectedNode.Text.ToString();
                CloneEGDPage cloneEGDPage = new CloneEGDPage(EGDPageName, hshDevices, TreeViewJobList.SelectedNode.Tag.ToString(), Path, EGDPagesMVIe);
                cloneEGDPage.ShowDialog();
                RefreshEGDPages(TreeViewJobList.SelectedNode.Tag.ToString());
            }
            catch (Exception ex)
            {

            }
        }
        private void EGDConfigurator_FormClosing(object sender, FormClosingEventArgs e)
        {
            //blIsSave = true;
            if (!blIsSave)
            {
                DialogResult Result = MessageBox.Show("Are you sure want to close?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Result == DialogResult.OK)
                {

                }
                else
                    e.Cancel = true;
            }
            else
            {
                DateTime dt = DateTime.Now;
                DialogResult Result = MessageBox.Show("Save changes before closing?", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (Result == DialogResult.Yes)
                {
                    if (!bgw_Save.IsBusy)
                    {
                        //PictureBoxFunctionsShow(pictureBox1);
                        pictureBox1.BringToFront();
                        pictureBox1.Visible = true;
                        bgw_Save.RunWorkerAsync();
                    }

                }
                else if (Result == DialogResult.No)
                {

                }
                else
                    e.Cancel = true;
                MessageBox.Show("Changes saved in " + DateTime.Now.Subtract(dt).TotalSeconds.ToString() + " seconds", "Message", MessageBoxButtons.OK);
            }
        }
        private void bgw_Save_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string xx = string.Empty;
            }
            catch (Exception ex)
            {

            }
        }
        private void bgw_Save_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                //WrapperFunctions wrapperFunctions = new WrapperFunctions(Path);
                //wrapperFunctions.SaveDevices(hshDevices);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
