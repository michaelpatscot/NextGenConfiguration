
namespace EGDCONFIGURATOR
{
    partial class OrganizeColumns
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrganizeColumns));
            this.lstbxHidden = new System.Windows.Forms.ListBox();
            this.lstbxShown = new System.Windows.Forms.ListBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnMoveAll = new System.Windows.Forms.Button();
            this.btnRemoveAll = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AddSelected = new System.Windows.Forms.ToolTip(this.components);
            this.AddAll = new System.Windows.Forms.ToolTip(this.components);
            this.RemoveSelected = new System.Windows.Forms.ToolTip(this.components);
            this.RemoveAll = new System.Windows.Forms.ToolTip(this.components);
            this.lblHiddenClmns = new System.Windows.Forms.Label();
            this.lblShownClmns = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstbxHidden
            // 
            this.lstbxHidden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbxHidden.FormattingEnabled = true;
            this.lstbxHidden.ItemHeight = 15;
            this.lstbxHidden.Location = new System.Drawing.Point(30, 88);
            this.lstbxHidden.Name = "lstbxHidden";
            this.lstbxHidden.Size = new System.Drawing.Size(220, 259);
            this.lstbxHidden.TabIndex = 0;
            // 
            // lstbxShown
            // 
            this.lstbxShown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstbxShown.FormattingEnabled = true;
            this.lstbxShown.ItemHeight = 15;
            this.lstbxShown.Items.AddRange(new object[] {
            "VarFrom",
            "ProgramName",
            "Name",
            "Alias",
            "DataType",
            "ArrayLength",
            "Description",
            "ChildAlarms",
            "Units",
            "Access",
            "ArrayValues",
            "InitialValue",
            "EgdPage",
            "FormatSpecification",
            "DisplayHigh",
            "DisplayLow",
            "Scope"});
            this.lstbxShown.Location = new System.Drawing.Point(382, 88);
            this.lstbxShown.Name = "lstbxShown";
            this.lstbxShown.Size = new System.Drawing.Size(220, 259);
            this.lstbxShown.TabIndex = 1;
            // 
            // btnMove
            // 
            this.btnMove.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMove.Image = global::EGDCONFIGURATOR.Properties.Resources.Forward;
            this.btnMove.Location = new System.Drawing.Point(290, 88);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(54, 34);
            this.btnMove.TabIndex = 2;
            this.AddSelected.SetToolTip(this.btnMove, "Add Selected");
            this.btnMove.UseVisualStyleBackColor = false;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnMoveAll
            // 
            this.btnMoveAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMoveAll.Image = global::EGDCONFIGURATOR.Properties.Resources.Forward2;
            this.btnMoveAll.Location = new System.Drawing.Point(290, 164);
            this.btnMoveAll.Name = "btnMoveAll";
            this.btnMoveAll.Size = new System.Drawing.Size(54, 34);
            this.btnMoveAll.TabIndex = 3;
            this.AddAll.SetToolTip(this.btnMoveAll, "Add All");
            this.btnMoveAll.UseVisualStyleBackColor = false;
            this.btnMoveAll.Click += new System.EventHandler(this.btnMoveAll_Click);
            // 
            // btnRemoveAll
            // 
            this.btnRemoveAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRemoveAll.Image = global::EGDCONFIGURATOR.Properties.Resources.Backward2;
            this.btnRemoveAll.Location = new System.Drawing.Point(290, 318);
            this.btnRemoveAll.Name = "btnRemoveAll";
            this.btnRemoveAll.Size = new System.Drawing.Size(54, 34);
            this.btnRemoveAll.TabIndex = 5;
            this.RemoveAll.SetToolTip(this.btnRemoveAll, "Remove All");
            this.btnRemoveAll.UseVisualStyleBackColor = false;
            this.btnRemoveAll.Click += new System.EventHandler(this.btnRemoveAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnRemove.Image = global::EGDCONFIGURATOR.Properties.Resources.Backward;
            this.btnRemove.Location = new System.Drawing.Point(290, 238);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(54, 34);
            this.btnRemove.TabIndex = 4;
            this.RemoveSelected.SetToolTip(this.btnRemove, "Remove Selected");
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(27, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hidden Columns:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(379, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Shown Columns:";
            // 
            // AddSelected
            // 
            this.AddSelected.ToolTipTitle = "Add Selected";
            // 
            // AddAll
            // 
            this.AddAll.ToolTipTitle = "Add All";
            // 
            // RemoveSelected
            // 
            this.RemoveSelected.ToolTipTitle = "Remove Selected";
            // 
            // RemoveAll
            // 
            this.RemoveAll.ToolTipTitle = "Remove All";
            // 
            // lblHiddenClmns
            // 
            this.lblHiddenClmns.AutoSize = true;
            this.lblHiddenClmns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHiddenClmns.Location = new System.Drawing.Point(55, 364);
            this.lblHiddenClmns.Name = "lblHiddenClmns";
            this.lblHiddenClmns.Size = new System.Drawing.Size(89, 15);
            this.lblHiddenClmns.TabIndex = 8;
            this.lblHiddenClmns.Text = "Total Records: ";
            // 
            // lblShownClmns
            // 
            this.lblShownClmns.AutoSize = true;
            this.lblShownClmns.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShownClmns.Location = new System.Drawing.Point(425, 364);
            this.lblShownClmns.Name = "lblShownClmns";
            this.lblShownClmns.Size = new System.Drawing.Size(89, 15);
            this.lblShownClmns.TabIndex = 9;
            this.lblShownClmns.Text = "Total Records: ";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(273, 382);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(87, 36);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // OrganizeColumns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 430);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblShownClmns);
            this.Controls.Add(this.lblHiddenClmns);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRemoveAll);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnMoveAll);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.lstbxShown);
            this.Controls.Add(this.lstbxHidden);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrganizeColumns";
            this.Text = "Organize Columns";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstbxHidden;
        private System.Windows.Forms.ListBox lstbxShown;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Button btnMoveAll;
        private System.Windows.Forms.Button btnRemoveAll;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip AddSelected;
        private System.Windows.Forms.ToolTip AddAll;
        private System.Windows.Forms.ToolTip RemoveSelected;
        private System.Windows.Forms.ToolTip RemoveAll;
        private System.Windows.Forms.Label lblHiddenClmns;
        private System.Windows.Forms.Label lblShownClmns;
        private System.Windows.Forms.Button btnSubmit;
    }
}