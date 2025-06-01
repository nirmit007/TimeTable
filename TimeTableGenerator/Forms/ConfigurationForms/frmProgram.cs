using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTableGenerator.Forms.ConfigurationForms
{
    public partial class frmProgram : Form
    {
        public frmProgram()
        {
            InitializeComponent();
        }

        public void FillGrid(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchvalue.Trim()))
                {
                    query = "select ProgramID[ID], Name [Program], isActive [Status] from ProgramTable";

                }
                else
                {
                    query = "select ProgramID[ID], Name [Program],  isActive [Status] from ProgramTable where Name like '%" + searchvalue.Trim() + "%'";
                }

                DataTable programlist = DatabaseLayer.Retrive(query);
                dgvProgram.DataSource = programlist;
                if (dgvProgram.Rows.Count > 0)
                {
                    dgvProgram.Columns[0].Width = 80;
                    dgvProgram.Columns[1].Width = 150;
                    dgvProgram.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }
            }
            catch
            {

                MessageBox.Show("Unexpexted error!!!");
            }
        }
        private void frmProgram_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtProgramName.Text.Trim().Length == 0)
            {
                ep.SetError(txtProgramName, "Length is long");
                txtProgramName.Focus();
                txtProgramName.SelectAll();
                return;
            }

            DataTable checktitle = DatabaseLayer.Retrive("select * from ProgramTable where Name = '" + txtProgramName.Text.Trim() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    ep.SetError(txtProgramName, "Already Exist");
                    txtProgramName.Focus();
                    txtProgramName.SelectAll();
                    return;
                }
            }

            string insertquery = string.Format("insert into ProgramTable(Name, isActive) values('{0}', '{1}')",
                                txtProgramName.Text.Trim(), chkStatus.Checked);
            bool result = DatabaseLayer.Insert(insertquery);
            if (result == true)
            {
                MessageBox.Show("Save Successfully!");
                DisableComponents();
            }
            else
            {
                MessageBox.Show("Please Provide the Correct Semester Details");
            }
        }

        public void EnableComponents()
        {
            dgvProgram.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSearch.Visible = false;

        }

        public void DisableComponents()
        {
            dgvProgram.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtSearch.Visible = true;
            FillGrid(String.Empty);
            ClearForm();

        }

        public void ClearForm()
        {
            txtProgramName.Clear();
            chkStatus.Checked = false;
            FillGrid(string.Empty);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableComponents();
        }

        private void cmsedit_Click(object sender, EventArgs e)
        {
            if (dgvProgram != null)
            {
                if (dgvProgram.Rows.Count > 0)
                {
                    if (dgvProgram.SelectedRows.Count == 1)
                    {
                        txtProgramName.Text = Convert.ToString(dgvProgram.CurrentRow.Cells[1].Value);
                        chkStatus.Checked = Convert.ToBoolean(dgvProgram.CurrentRow.Cells[2].Value);
                        EnableComponents();
                    }
                    else
                    {
                        MessageBox.Show("PLease Select one!!");
                    }
                }
                else
                {
                    MessageBox.Show("List is empty");
                }

            }
            else
            {
                MessageBox.Show("List is empty");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtProgramName.Text.Trim().Length == 0)
            {
                ep.SetError(txtProgramName, "Length is long");
                txtProgramName.Focus();
                txtProgramName.SelectAll();
                return;
            }

            DataTable checktitle = DatabaseLayer.Retrive("select * from ProgramTable where Name = '" + txtProgramName.Text.Trim() + "' and ProgramID != '" + Convert.ToString(dgvProgram.CurrentRow.Cells[0].Value) + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    ep.SetError(txtProgramName, "Already Exist");
                    txtProgramName.Focus();
                    txtProgramName.SelectAll();
                    return;
                }
            }

            string updatequery = string.Format("update ProgramTable set Name = '{0}', isActive = '{1}' where ProgramID = '{2}'", txtProgramName.Text.Trim(), chkStatus.Checked, Convert.ToString(dgvProgram.CurrentRow.Cells[0].Value));
            bool result = DatabaseLayer.Update(updatequery);
            if (result == true)
            {
                MessageBox.Show("Updated Successfully!");
                DisableComponents();
            }
            else
            {
                MessageBox.Show("Please Provide the Correct Semester Details");
            }
        }
    }
}
