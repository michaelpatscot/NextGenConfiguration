
namespace EGDCONFIGURATOR
{
    partial class VersionSelector
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionSelector));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lstbxInstalledVersions = new System.Windows.Forms.ListBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblMinVersion = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLSWV = new System.Windows.Forms.Label();
            this.lblFile = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.lstbxInstalledVersions);
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Location = new System.Drawing.Point(12, 228);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 222);
            this.panel1.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(264, 186);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 29);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lstbxInstalledVersions
            // 
            this.lstbxInstalledVersions.FormattingEnabled = true;
            this.lstbxInstalledVersions.Location = new System.Drawing.Point(10, 7);
            this.lstbxInstalledVersions.Name = "lstbxInstalledVersions";
            this.lstbxInstalledVersions.Size = new System.Drawing.Size(329, 173);
            this.lstbxInstalledVersions.TabIndex = 0;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(183, 186);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 29);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMinVersion
            // 
            this.lblMinVersion.AutoSize = true;
            this.lblMinVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinVersion.Location = new System.Drawing.Point(19, 125);
            this.lblMinVersion.Name = "lblMinVersion";
            this.lblMinVersion.Size = new System.Drawing.Size(95, 13);
            this.lblMinVersion.TabIndex = 1;
            this.lblMinVersion.Text = "Minimum Version : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 204);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "ToolboxST Versions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 26);
            this.label3.TabIndex = 3;
            this.label3.Text = "Select the ToolboxST Version to use to open\r\nthis .tcw file.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Image = global::EGDCONFIGURATOR.Properties.Resources.ToolboxST;
            this.label4.Location = new System.Drawing.Point(15, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 39);
            this.label4.TabIndex = 4;
            this.label4.Text = "        \r\n       \r\n       ";
            // 
            // lblLSWV
            // 
            this.lblLSWV.AutoSize = true;
            this.lblLSWV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLSWV.Location = new System.Drawing.Point(19, 162);
            this.lblLSWV.Name = "lblLSWV";
            this.lblLSWV.Size = new System.Drawing.Size(133, 13);
            this.lblLSWV.TabIndex = 5;
            this.lblLSWV.Text = "Last Saved With Version : ";
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.Location = new System.Drawing.Point(19, 88);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(32, 13);
            this.lblFile.TabIndex = 6;
            this.lblFile.Text = "File : ";
            // 
            // VersionSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 489);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.lblLSWV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblMinVersion);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VersionSelector";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToolboxST Version Selector";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VersionSelector_FormClosing);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ListBox lstbxInstalledVersions;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblMinVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLSWV;
        private System.Windows.Forms.Label lblFile;
    }
}