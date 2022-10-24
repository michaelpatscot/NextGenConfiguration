
namespace EGDCONFIGURATOR
{
    partial class SelectTCWForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectTCWForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxProject = new System.Windows.Forms.TextBox();
            this.buttonBrowseProject = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvDevices = new System.Windows.Forms.DataGridView();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DeviceType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectDevice = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkbxMarkVIeSDeviceList = new System.Windows.Forms.CheckedListBox();
            this.chkbxMarkVIeDeviceList = new System.Windows.Forms.CheckedListBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewComboBoxColumn1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBoxProject, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonBrowseProject, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonOK, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(613, 348);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 2);
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 73);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(607, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "DEVICES SELECTION";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.label2, 2);
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(607, 34);
            this.label2.TabIndex = 1;
            this.label2.Text = "Select the ToolboxST project file (*.tcw).";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxProject
            // 
            this.textBoxProject.AllowDrop = true;
            this.textBoxProject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxProject.Location = new System.Drawing.Point(3, 45);
            this.textBoxProject.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.textBoxProject.Name = "textBoxProject";
            this.textBoxProject.Size = new System.Drawing.Size(512, 20);
            this.textBoxProject.TabIndex = 2;
            this.textBoxProject.TextChanged += new System.EventHandler(this.textBoxProject_TextChanged);
            // 
            // buttonBrowseProject
            // 
            this.buttonBrowseProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBrowseProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowseProject.Location = new System.Drawing.Point(521, 43);
            this.buttonBrowseProject.Name = "buttonBrowseProject";
            this.buttonBrowseProject.Size = new System.Drawing.Size(89, 24);
            this.buttonBrowseProject.TabIndex = 3;
            this.buttonBrowseProject.Text = "BROWSE";
            this.buttonBrowseProject.UseVisualStyleBackColor = true;
            this.buttonBrowseProject.Click += new System.EventHandler(this.buttonBrowseProject_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDevices);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkbxMarkVIeSDeviceList);
            this.panel1.Controls.Add(this.chkbxMarkVIeDeviceList);
            this.panel1.Location = new System.Drawing.Point(3, 103);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(512, 233);
            this.panel1.TabIndex = 5;
            this.panel1.Visible = false;
            // 
            // dgvDevices
            // 
            this.dgvDevices.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dgvDevices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDevices.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDevices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDevices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeviceName,
            this.DeviceType,
            this.SelectDevice});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDevices.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvDevices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDevices.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvDevices.Location = new System.Drawing.Point(0, 0);
            this.dgvDevices.Name = "dgvDevices";
            this.dgvDevices.Size = new System.Drawing.Size(512, 233);
            this.dgvDevices.TabIndex = 5;
            this.dgvDevices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // DeviceName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            this.DeviceName.DefaultCellStyle = dataGridViewCellStyle2;
            this.DeviceName.HeaderText = "Device Name";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            this.DeviceName.Width = 175;
            // 
            // DeviceType
            // 
            this.DeviceType.HeaderText = "Device Type";
            this.DeviceType.Name = "DeviceType";
            this.DeviceType.ReadOnly = true;
            this.DeviceType.Width = 175;
            // 
            // SelectDevice
            // 
            this.SelectDevice.HeaderText = "Select Device";
            this.SelectDevice.Name = "SelectDevice";
            this.SelectDevice.Width = 118;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(38, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(121, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "MARKVIE Devices";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(322, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "MARKVIE-S Devices";
            // 
            // chkbxMarkVIeSDeviceList
            // 
            this.chkbxMarkVIeSDeviceList.CheckOnClick = true;
            this.chkbxMarkVIeSDeviceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbxMarkVIeSDeviceList.FormattingEnabled = true;
            this.chkbxMarkVIeSDeviceList.Location = new System.Drawing.Point(325, 27);
            this.chkbxMarkVIeSDeviceList.Name = "chkbxMarkVIeSDeviceList";
            this.chkbxMarkVIeSDeviceList.Size = new System.Drawing.Size(169, 164);
            this.chkbxMarkVIeSDeviceList.TabIndex = 1;
            // 
            // chkbxMarkVIeDeviceList
            // 
            this.chkbxMarkVIeDeviceList.CheckOnClick = true;
            this.chkbxMarkVIeDeviceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbxMarkVIeDeviceList.FormattingEnabled = true;
            this.chkbxMarkVIeDeviceList.Location = new System.Drawing.Point(38, 27);
            this.chkbxMarkVIeDeviceList.Name = "chkbxMarkVIeDeviceList";
            this.chkbxMarkVIeDeviceList.Size = new System.Drawing.Size(169, 164);
            this.chkbxMarkVIeDeviceList.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonOK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(528, 306);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 31);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Visible = false;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click_1);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "DEVICE";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "TYPE";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewComboBoxColumn1
            // 
            this.dataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewComboBoxColumn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dataGridViewComboBoxColumn1.HeaderText = "TOOLBOXST DEVICE";
            this.dataGridViewComboBoxColumn1.MinimumWidth = 150;
            this.dataGridViewComboBoxColumn1.Name = "dataGridViewComboBoxColumn1";
            this.dataGridViewComboBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "GUID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // SelectTCWForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 348);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectTCWForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SELECT PROJECT";
            this.Load += new System.EventHandler(this.SelectTCWForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDevices)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewComboBoxColumn dataGridViewComboBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxProject;
        private System.Windows.Forms.Button buttonBrowseProject;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckedListBox chkbxMarkVIeDeviceList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckedListBox chkbxMarkVIeSDeviceList;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.DataGridView dgvDevices;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectDevice;
    }
}