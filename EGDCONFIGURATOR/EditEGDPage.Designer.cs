
namespace EGDCONFIGURATOR
{
    partial class EditEGDPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditEGDPage));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEthernet0 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDestination = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbLayoutMode = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtnxMinExchangeLength = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbxMultiplier = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtbxSkew = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtbxStartExchangeID = new System.Windows.Forms.TextBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.22951F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.77049F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 135F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 260F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtbxName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbEthernet0, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbDestination, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cmbLayoutMode, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtnxMinExchangeLength, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtbxMultiplier, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtbxSkew, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtbxStartExchangeID, 3, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.12281F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.87719F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(725, 112);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // txtbxName
            // 
            this.txtbxName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbxName.Location = new System.Drawing.Point(89, 3);
            this.txtbxName.Name = "txtbxName";
            this.txtbxName.Size = new System.Drawing.Size(237, 21);
            this.txtbxName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ethernet0";
            // 
            // cmbEthernet0
            // 
            this.cmbEthernet0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbEthernet0.FormattingEnabled = true;
            this.cmbEthernet0.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cmbEthernet0.Location = new System.Drawing.Point(89, 30);
            this.cmbEthernet0.Name = "cmbEthernet0";
            this.cmbEthernet0.Size = new System.Drawing.Size(237, 23);
            this.cmbEthernet0.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Destination";
            // 
            // cmbDestination
            // 
            this.cmbDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDestination.FormattingEnabled = true;
            this.cmbDestination.Items.AddRange(new object[] {
            "BroadCast",
            "UniCast",
            "MultiCast"});
            this.cmbDestination.Location = new System.Drawing.Point(89, 58);
            this.cmbDestination.Name = "cmbDestination";
            this.cmbDestination.Size = new System.Drawing.Size(237, 23);
            this.cmbDestination.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Layout Mode";
            // 
            // cmbLayoutMode
            // 
            this.cmbLayoutMode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLayoutMode.FormattingEnabled = true;
            this.cmbLayoutMode.Items.AddRange(new object[] {
            "Auto",
            "Manual"});
            this.cmbLayoutMode.Location = new System.Drawing.Point(89, 87);
            this.cmbLayoutMode.Name = "cmbLayoutMode";
            this.cmbLayoutMode.Size = new System.Drawing.Size(237, 23);
            this.cmbLayoutMode.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(334, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "Min Exchange Length";
            // 
            // txtnxMinExchangeLength
            // 
            this.txtnxMinExchangeLength.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtnxMinExchangeLength.Location = new System.Drawing.Point(467, 3);
            this.txtnxMinExchangeLength.Name = "txtnxMinExchangeLength";
            this.txtnxMinExchangeLength.Size = new System.Drawing.Size(255, 21);
            this.txtnxMinExchangeLength.TabIndex = 9;
            this.toolTip1.SetToolTip(this.txtnxMinExchangeLength, "Accepts only numbers.");
            this.txtnxMinExchangeLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtnxMinExchangeLength_KeyPress);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(403, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 15);
            this.label6.TabIndex = 10;
            this.label6.Text = "Multiplier";
            // 
            // txtbxMultiplier
            // 
            this.txtbxMultiplier.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbxMultiplier.Location = new System.Drawing.Point(467, 30);
            this.txtbxMultiplier.Name = "txtbxMultiplier";
            this.txtbxMultiplier.Size = new System.Drawing.Size(255, 21);
            this.txtbxMultiplier.TabIndex = 11;
            this.toolTip1.SetToolTip(this.txtbxMultiplier, "Accepts only numbers.");
            this.txtbxMultiplier.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxMultiplier_KeyPress);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(424, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 15);
            this.label7.TabIndex = 12;
            this.label7.Text = "Skew";
            // 
            // txtbxSkew
            // 
            this.txtbxSkew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbxSkew.Location = new System.Drawing.Point(467, 58);
            this.txtbxSkew.Name = "txtbxSkew";
            this.txtbxSkew.Size = new System.Drawing.Size(255, 21);
            this.txtbxSkew.TabIndex = 13;
            this.toolTip1.SetToolTip(this.txtbxSkew, "Accepts only numbers.");
            this.txtbxSkew.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxSkew_KeyPress);
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(339, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 15);
            this.label8.TabIndex = 14;
            this.label8.Text = "Starting Exchange ID";
            // 
            // txtbxStartExchangeID
            // 
            this.txtbxStartExchangeID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbxStartExchangeID.Location = new System.Drawing.Point(467, 87);
            this.txtbxStartExchangeID.Name = "txtbxStartExchangeID";
            this.txtbxStartExchangeID.Size = new System.Drawing.Size(255, 21);
            this.txtbxStartExchangeID.TabIndex = 15;
            this.toolTip1.SetToolTip(this.txtbxStartExchangeID, "Accepts only numbers.");
            this.txtbxStartExchangeID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtbxStartExchangeID_KeyPress);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(320, 178);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(102, 32);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "UPDATE";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // EditEGDPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 240);
            this.ControlBox = false;
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditEGDPage";
            this.Text = "Edit EGDPage";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtbxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEthernet0;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbDestination;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbLayoutMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtnxMinExchangeLength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtbxMultiplier;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtbxSkew;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtbxStartExchangeID;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}