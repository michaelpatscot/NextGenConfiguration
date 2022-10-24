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
    public partial class OrganizeColumns : Form
    {

        public DataTable dtInput = new DataTable();
        public List<string> ShownColumns;
        public List<string> RemoveColumns;
        public OrganizeColumns(DataTable dtVariables)
        {
            InitializeComponent();
            dtInput = dtVariables;
            string[] columnNamesHidden = (from dc in dtVariables.Columns.Cast<DataColumn>()
                                          select dc.ColumnName).ToArray();
            string[] columnNamesShown = new string[] { "VarFrom", "ProgramName", "Name", "Alias", "DataType", "ArrayLength", "Description", "ChildAlarms", "Units", "Access", "ArrayValues", "InitialValue", "EgdPage", "FormatSpecification", "DisplayHigh", "DisplayLow", "Scope" };
            string[] ArrayExcept = columnNamesHidden.Except(columnNamesShown).ToArray();
            //lstbxHidden.Items.Add("");
            foreach (string Clmn in ArrayExcept)
                lstbxHidden.Items.Add(Clmn.ToString());
            lblHiddenClmns.Text = "Total Records: " + lstbxHidden.Items.Count.ToString() + "";
            lblShownClmns.Text = "Total Records: " + lstbxShown.Items.Count.ToString() + "";
            ShownColumns = new List<string>();
            RemoveColumns = new List<string>();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            try
            {
                lstbxShown.Items.Add(lstbxHidden.SelectedItem);
                lstbxHidden.Items.RemoveAt(lstbxHidden.SelectedIndex);
                lblHiddenClmns.Text = "Total Records: " + lstbxHidden.Items.Count.ToString() + "";
                lblShownClmns.Text = "Total Records: " + lstbxShown.Items.Count.ToString() + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void btnMoveAll_Click(object sender, EventArgs e)
        {
            try
            {

                for (int Index = 0; Index < lstbxHidden.Items.Count; Index++)
                {
                    lstbxHidden.SelectedItem = lstbxHidden.Items[Index];
                    lstbxShown.Items.Add(lstbxHidden.Items[Index].ToString());
                }
                lstbxHidden.Items.Clear();
                lblHiddenClmns.Text = "Total Records: " + lstbxHidden.Items.Count.ToString() + "";
                lblShownClmns.Text = "Total Records: " + lstbxShown.Items.Count.ToString() + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                lstbxHidden.Items.Add(lstbxShown.SelectedItem);
                lstbxShown.Items.RemoveAt(lstbxShown.SelectedIndex);
                lblHiddenClmns.Text = "Total Records: " + lstbxHidden.Items.Count.ToString() + "";
                lblShownClmns.Text = "Total Records: " + lstbxShown.Items.Count.ToString() + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            try
            {
                for (int Index = 0; Index < lstbxShown.Items.Count; Index++)
                {
                    lstbxShown.SelectedItem = lstbxShown.Items[Index];
                    lstbxHidden.Items.Add(lstbxShown.Items[Index].ToString());
                }
                lstbxShown.Items.Clear();
                lblHiddenClmns.Text = "Total Records: " + lstbxHidden.Items.Count.ToString() + "";
                lblShownClmns.Text = "Total Records: " + lstbxShown.Items.Count.ToString() + "";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                for (int Index = 0; Index < lstbxShown.Items.Count; Index++)
                    ShownColumns.Add(lstbxShown.Items[Index].ToString());

                for (int Index = 0; Index < lstbxHidden.Items.Count; Index++)
                    RemoveColumns.Add(lstbxHidden.Items[Index].ToString());

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }
    }
}
