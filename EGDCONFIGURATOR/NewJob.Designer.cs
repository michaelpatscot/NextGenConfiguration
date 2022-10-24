
namespace EGDCONFIGURATOR
{
    partial class NewJob
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewJob));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtbxJobNumber = new System.Windows.Forms.TextBox();
            this.txtbxUser = new System.Windows.Forms.TextBox();
            this.txtbxCompany = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnSubmit);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(478, 177);
            this.panel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(182, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Enter the below job details:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(198, 142);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(88, 23);
            this.btnSubmit.TabIndex = 4;
            this.btnSubmit.Text = "SUBMIT";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(76, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "USER";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(49, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "COMPANY*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(32, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "JOB NUMBER*";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.txtbxJobNumber, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtbxUser, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtbxCompany, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(119, 50);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(326, 74);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtbxJobNumber
            // 
            this.txtbxJobNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbxJobNumber.Location = new System.Drawing.Point(3, 3);
            this.txtbxJobNumber.Name = "txtbxJobNumber";
            this.txtbxJobNumber.Size = new System.Drawing.Size(320, 20);
            this.txtbxJobNumber.TabIndex = 0;
            this.txtbxJobNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxJobNumber_KeyDown);
            this.txtbxJobNumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtbxJobNumber_KeyUp);
            // 
            // txtbxUser
            // 
            this.txtbxUser.Enabled = false;
            this.txtbxUser.Location = new System.Drawing.Point(3, 51);
            this.txtbxUser.Name = "txtbxUser";
            this.txtbxUser.Size = new System.Drawing.Size(320, 20);
            this.txtbxUser.TabIndex = 2;
            // 
            // txtbxCompany
            // 
            this.txtbxCompany.Location = new System.Drawing.Point(3, 27);
            this.txtbxCompany.Name = "txtbxCompany";
            this.txtbxCompany.Size = new System.Drawing.Size(320, 20);
            this.txtbxCompany.TabIndex = 1;
            this.txtbxCompany.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtbxCompany_KeyDown);
            // 
            // NewJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 177);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewJob";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JOB DETAILS";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtbxJobNumber;
        private System.Windows.Forms.TextBox txtbxUser;
        private System.Windows.Forms.TextBox txtbxCompany;
        private System.Windows.Forms.Label label4;
    }
}