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
    public partial class DeviceList : Form
    {
        public static string SelectedMarkVIe;
        public static string SelectedMarkVIeS;
        public DeviceList(string[] MarkVIe, string[] MarkVIeS)
        {
            InitializeComponent();
            SelectedMarkVIe = "";
            SelectedMarkVIeS = "";
            foreach (string Device in MarkVIe)
                chkbxMarkVie.Items.Add(Device);
            foreach (string Device in MarkVIeS)
                chkbxMarkVieS.Items.Add(Device);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkbxMarkVie.SelectedItems.Count == 0 && chkbxMarkVieS.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select anyone device to continue.", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    for (int count = 0; count < chkbxMarkVie.Items.Count; count++)
                    {
                        if (chkbxMarkVie.GetItemChecked(count))
                            SelectedMarkVIe += chkbxMarkVie.Items[count].ToString() + ",";
                    }
                    for (int count = 0; count < chkbxMarkVieS.Items.Count; count++)
                    {
                        if (chkbxMarkVieS.GetItemChecked(count))
                            SelectedMarkVIeS += chkbxMarkVieS.Items[count].ToString() + ",";
                    }
                    SelectedMarkVIe = SelectedMarkVIe.TrimEnd(',');
                    SelectedMarkVIeS = SelectedMarkVIeS.TrimEnd(',');
                    this.Close();
                }
            }
            catch (Exception ex)
            {


            }
        }
    }
}
