
namespace EGDCONFIGURATOR
{
    partial class EGDConfigurator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EGDConfigurator));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fILEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nEWToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sAVEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lOADToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tOOLSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wORKSPEACEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cREATEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cLEANUPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uPDATEALLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbNewPrj = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.TreeViewJobList = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dgv_Properties = new System.Windows.Forms.DataGridView();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.associateAToolboxSTProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.associateANexusProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabError = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtbxInfo = new System.Windows.Forms.TextBox();
            this.bgw_GetVariables = new System.ComponentModel.BackgroundWorker();
            this.pgBase = new System.Windows.Forms.PropertyGrid();
            this.dgvAllData1 = new System.Windows.Forms.DataGridView();
            this.dgvAllData = new Zuby.ADGV.AdvancedDataGridView();
            this.cmsADGV = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.organizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblHeading = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTotalRecords = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsEGDConfig = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEGDPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsRemoveEGD = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeEGDPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneEGDPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bgw_Save = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Properties)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabError.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllData1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllData)).BeginInit();
            this.cmsADGV.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmsEGDConfig.SuspendLayout();
            this.cmsRemoveEGD.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.tOOLSToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1370, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nEWToolStripMenuItem,
            this.sAVEToolStripMenuItem,
            this.lOADToolStripMenuItem});
            this.fILEToolStripMenuItem.Name = "fILEToolStripMenuItem";
            this.fILEToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fILEToolStripMenuItem.Text = "FILE";
            // 
            // nEWToolStripMenuItem
            // 
            this.nEWToolStripMenuItem.Name = "nEWToolStripMenuItem";
            this.nEWToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.nEWToolStripMenuItem.Text = "NEW";
            this.nEWToolStripMenuItem.Click += new System.EventHandler(this.nEWToolStripMenuItem_Click);
            // 
            // sAVEToolStripMenuItem
            // 
            this.sAVEToolStripMenuItem.Name = "sAVEToolStripMenuItem";
            this.sAVEToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.sAVEToolStripMenuItem.Text = "SAVE";
            // 
            // lOADToolStripMenuItem
            // 
            this.lOADToolStripMenuItem.Name = "lOADToolStripMenuItem";
            this.lOADToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.lOADToolStripMenuItem.Text = "LOAD";
            // 
            // tOOLSToolStripMenuItem
            // 
            this.tOOLSToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wORKSPEACEToolStripMenuItem,
            this.uPDATEALLToolStripMenuItem});
            this.tOOLSToolStripMenuItem.Name = "tOOLSToolStripMenuItem";
            this.tOOLSToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.tOOLSToolStripMenuItem.Text = "TOOLS";
            // 
            // wORKSPEACEToolStripMenuItem
            // 
            this.wORKSPEACEToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cREATEToolStripMenuItem,
            this.cLEANUPToolStripMenuItem});
            this.wORKSPEACEToolStripMenuItem.Name = "wORKSPEACEToolStripMenuItem";
            this.wORKSPEACEToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.wORKSPEACEToolStripMenuItem.Text = "WORKSPACE";
            // 
            // cREATEToolStripMenuItem
            // 
            this.cREATEToolStripMenuItem.Name = "cREATEToolStripMenuItem";
            this.cREATEToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.cREATEToolStripMenuItem.Text = "CREATE";
            // 
            // cLEANUPToolStripMenuItem
            // 
            this.cLEANUPToolStripMenuItem.Name = "cLEANUPToolStripMenuItem";
            this.cLEANUPToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.cLEANUPToolStripMenuItem.Text = "CLEAN UP";
            // 
            // uPDATEALLToolStripMenuItem
            // 
            this.uPDATEALLToolStripMenuItem.Name = "uPDATEALLToolStripMenuItem";
            this.uPDATEALLToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.uPDATEALLToolStripMenuItem.Text = "UPDATE ALL";
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hELPToolStripMenuItem.Text = "HELP";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewPrj,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1370, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbNewPrj
            // 
            this.tsbNewPrj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbNewPrj.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewPrj.Image")));
            this.tsbNewPrj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewPrj.Name = "tsbNewPrj";
            this.tsbNewPrj.Size = new System.Drawing.Size(23, 22);
            this.tsbNewPrj.Text = "toolStripButton1";
            this.tsbNewPrj.ToolTipText = "NEW";
            this.tsbNewPrj.Click += new System.EventHandler(this.tsbNewPrj_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "SAVE";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "toolStripButton3";
            this.toolStripButton3.ToolTipText = "LOAD";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // TreeViewJobList
            // 
            this.TreeViewJobList.HideSelection = false;
            this.TreeViewJobList.ImageIndex = 0;
            this.TreeViewJobList.ImageList = this.imageList1;
            this.TreeViewJobList.Indent = 23;
            this.TreeViewJobList.ItemHeight = 20;
            this.TreeViewJobList.Location = new System.Drawing.Point(3, 49);
            this.TreeViewJobList.Name = "TreeViewJobList";
            this.TreeViewJobList.SelectedImageIndex = 0;
            this.TreeViewJobList.Size = new System.Drawing.Size(221, 252);
            this.TreeViewJobList.StateImageList = this.imageList1;
            this.TreeViewJobList.TabIndex = 2;
            this.TreeViewJobList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeViewJobList_AfterSelect);
            this.TreeViewJobList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeViewJobList_NodeMouseClick);
            this.TreeViewJobList.Click += new System.EventHandler(this.TreeViewJobList_Click);
            this.TreeViewJobList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TreeViewJobList_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Rack.png");
            this.imageList1.Images.SetKeyName(1, "BPCS.png");
            this.imageList1.Images.SetKeyName(2, "Folder.png");
            this.imageList1.Images.SetKeyName(3, "Rack.png");
            this.imageList1.Images.SetKeyName(4, "SAFETY.png");
            this.imageList1.Images.SetKeyName(5, "Variables.png");
            this.imageList1.Images.SetKeyName(6, "ToolboxST.png");
            // 
            // dgv_Properties
            // 
            this.dgv_Properties.AllowUserToAddRows = false;
            this.dgv_Properties.AllowUserToDeleteRows = false;
            this.dgv_Properties.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgv_Properties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Properties.Location = new System.Drawing.Point(3, 303);
            this.dgv_Properties.Name = "dgv_Properties";
            this.dgv_Properties.ReadOnly = true;
            this.dgv_Properties.Size = new System.Drawing.Size(219, 159);
            this.dgv_Properties.TabIndex = 3;
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            this.bgw.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_RunWorkerCompleted);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.associateAToolboxSTProjectToolStripMenuItem,
            this.associateANexusProjectToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(231, 48);
            // 
            // associateAToolboxSTProjectToolStripMenuItem
            // 
            this.associateAToolboxSTProjectToolStripMenuItem.Name = "associateAToolboxSTProjectToolStripMenuItem";
            this.associateAToolboxSTProjectToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.associateAToolboxSTProjectToolStripMenuItem.Text = "Associate a ToolboxST Project";
            this.associateAToolboxSTProjectToolStripMenuItem.Click += new System.EventHandler(this.associateAToolboxSTProjectToolStripMenuItem_Click);
            // 
            // associateANexusProjectToolStripMenuItem
            // 
            this.associateANexusProjectToolStripMenuItem.Enabled = false;
            this.associateANexusProjectToolStripMenuItem.Name = "associateANexusProjectToolStripMenuItem";
            this.associateANexusProjectToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.associateANexusProjectToolStripMenuItem.Text = "Associate a Nexus Project";
            // 
            // tabError
            // 
            this.tabError.Controls.Add(this.tabPage1);
            this.tabError.Location = new System.Drawing.Point(6, 469);
            this.tabError.Name = "tabError";
            this.tabError.SelectedIndex = 0;
            this.tabError.Size = new System.Drawing.Size(1352, 271);
            this.tabError.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtbxInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1344, 243);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Information";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtbxInfo
            // 
            this.txtbxInfo.Location = new System.Drawing.Point(4, 4);
            this.txtbxInfo.Multiline = true;
            this.txtbxInfo.Name = "txtbxInfo";
            this.txtbxInfo.ReadOnly = true;
            this.txtbxInfo.Size = new System.Drawing.Size(1334, 233);
            this.txtbxInfo.TabIndex = 0;
            // 
            // bgw_GetVariables
            // 
            this.bgw_GetVariables.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_GetVariables_DoWork);
            this.bgw_GetVariables.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_GetVariables_RunWorkerCompleted);
            // 
            // pgBase
            // 
            this.pgBase.Location = new System.Drawing.Point(230, 70);
            this.pgBase.Name = "pgBase";
            this.pgBase.Size = new System.Drawing.Size(265, 388);
            this.pgBase.TabIndex = 0;
            this.pgBase.Visible = false;
            this.pgBase.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgBase_PropertyValueChanged);
            // 
            // dgvAllData1
            // 
            this.dgvAllData1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvAllData1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllData1.Location = new System.Drawing.Point(230, 98);
            this.dgvAllData1.Name = "dgvAllData1";
            this.dgvAllData1.Size = new System.Drawing.Size(352, 359);
            this.dgvAllData1.TabIndex = 8;
            this.dgvAllData1.Visible = false;
            // 
            // dgvAllData
            // 
            this.dgvAllData.AllowUserToAddRows = false;
            this.dgvAllData.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dgvAllData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAllData.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvAllData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllData.ContextMenuStrip = this.cmsADGV;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllData.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAllData.FilterAndSortEnabled = true;
            this.dgvAllData.Location = new System.Drawing.Point(230, 124);
            this.dgvAllData.Name = "dgvAllData";
            this.dgvAllData.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dgvAllData.Size = new System.Drawing.Size(325, 275);
            this.dgvAllData.TabIndex = 10;
            this.dgvAllData.Visible = false;
            this.dgvAllData.SortStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.SortEventArgs>(this.dgvAllData_SortStringChanged);
            this.dgvAllData.FilterStringChanged += new System.EventHandler<Zuby.ADGV.AdvancedDataGridView.FilterEventArgs>(this.dgvAllData_FilterStringChanged);
            // 
            // cmsADGV
            // 
            this.cmsADGV.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.organizeToolStripMenuItem});
            this.cmsADGV.Name = "cmsADGV";
            this.cmsADGV.Size = new System.Drawing.Size(173, 26);
            // 
            // organizeToolStripMenuItem
            // 
            this.organizeToolStripMenuItem.Name = "organizeToolStripMenuItem";
            this.organizeToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.organizeToolStripMenuItem.Text = "Organize Columns";
            this.organizeToolStripMenuItem.Click += new System.EventHandler(this.organizeToolStripMenuItem_Click);
            // 
            // lblHeading
            // 
            this.lblHeading.AutoSize = true;
            this.lblHeading.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblHeading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeading.Location = new System.Drawing.Point(3, 0);
            this.lblHeading.Name = "lblHeading";
            this.lblHeading.Size = new System.Drawing.Size(857, 19);
            this.lblHeading.TabIndex = 11;
            this.lblHeading.Text = "HEADING";
            this.lblHeading.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 276F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lblHeading, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblTotalRecords, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(230, 51);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1139, 19);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.AutoSize = true;
            this.lblTotalRecords.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblTotalRecords.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalRecords.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalRecords.Location = new System.Drawing.Point(866, 0);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(270, 19);
            this.lblTotalRecords.TabIndex = 12;
            this.lblTotalRecords.Text = "TOTAL RECORDS :";
            this.lblTotalRecords.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Control;
            this.pictureBox1.Image = global::EGDCONFIGURATOR.Properties.Resources.WaitGif;
            this.pictureBox1.Location = new System.Drawing.Point(395, 156);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(147, 145);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // cmsEGDConfig
            // 
            this.cmsEGDConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEGDPageToolStripMenuItem});
            this.cmsEGDConfig.Name = "cmsEGDConfig";
            this.cmsEGDConfig.Size = new System.Drawing.Size(151, 26);
            // 
            // addEGDPageToolStripMenuItem
            // 
            this.addEGDPageToolStripMenuItem.Name = "addEGDPageToolStripMenuItem";
            this.addEGDPageToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.addEGDPageToolStripMenuItem.Text = "Add EGD Page";
            this.addEGDPageToolStripMenuItem.Click += new System.EventHandler(this.addEGDPageToolStripMenuItem_Click);
            // 
            // cmsRemoveEGD
            // 
            this.cmsRemoveEGD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeEGDPageToolStripMenuItem,
            this.cloneEGDPageToolStripMenuItem});
            this.cmsRemoveEGD.Name = "cmsRemoveEGD";
            this.cmsRemoveEGD.Size = new System.Drawing.Size(172, 48);
            // 
            // removeEGDPageToolStripMenuItem
            // 
            this.removeEGDPageToolStripMenuItem.Name = "removeEGDPageToolStripMenuItem";
            this.removeEGDPageToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.removeEGDPageToolStripMenuItem.Text = "Remove EGD Page";
            this.removeEGDPageToolStripMenuItem.Click += new System.EventHandler(this.removeEGDPageToolStripMenuItem_Click);
            // 
            // cloneEGDPageToolStripMenuItem
            // 
            this.cloneEGDPageToolStripMenuItem.Name = "cloneEGDPageToolStripMenuItem";
            this.cloneEGDPageToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.cloneEGDPageToolStripMenuItem.Text = "Clone EGD Page";
            this.cloneEGDPageToolStripMenuItem.Click += new System.EventHandler(this.cloneEGDPageToolStripMenuItem_Click_1);
            // 
            // bgw_Save
            // 
            this.bgw_Save.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_Save_DoWork);
            this.bgw_Save.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_Save_RunWorkerCompleted);
            // 
            // EGDConfigurator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dgvAllData);
            this.Controls.Add(this.dgvAllData1);
            this.Controls.Add(this.tabError);
            this.Controls.Add(this.dgv_Properties);
            this.Controls.Add(this.pgBase);
            this.Controls.Add(this.TreeViewJobList);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "EGDConfigurator";
            this.Text = "EGD CONFIGURATOR";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EGDConfigurator_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.EGDConfigurator_PreviewKeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Properties)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabError.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllData1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllData)).EndInit();
            this.cmsADGV.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmsEGDConfig.ResumeLayout(false);
            this.cmsRemoveEGD.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fILEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nEWToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sAVEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lOADToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tOOLSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wORKSPEACEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cREATEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cLEANUPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uPDATEALLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbNewPrj;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.TreeView TreeViewJobList;
        private System.Windows.Forms.DataGridView dgv_Properties;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem associateAToolboxSTProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem associateANexusProjectToolStripMenuItem;
        private System.Windows.Forms.TabControl tabError;
        private System.Windows.Forms.TabPage tabPage1;
        private System.ComponentModel.BackgroundWorker bgw_GetVariables;
        private System.Windows.Forms.TextBox txtbxInfo;
        private System.Windows.Forms.PropertyGrid pgBase;
        private System.Windows.Forms.DataGridView dgvAllData1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Zuby.ADGV.AdvancedDataGridView dgvAllData;
        private System.Windows.Forms.Label lblHeading;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip cmsADGV;
        private System.Windows.Forms.ToolStripMenuItem organizeToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsEGDConfig;
        private System.Windows.Forms.ToolStripMenuItem addEGDPageToolStripMenuItem;
        private System.Windows.Forms.Label lblTotalRecords;
        private System.Windows.Forms.ContextMenuStrip cmsRemoveEGD;
        private System.Windows.Forms.ToolStripMenuItem removeEGDPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneEGDPageToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bgw_Save;
    }
}

