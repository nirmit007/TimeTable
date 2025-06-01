using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTableGenerator.SourceCode;

namespace TimeTableGenerator.Forms.ProgramSemesterForms
{
    public partial class frmProgramSemesters : Form
    {
        public frmProgramSemesters()
        {
            InitializeComponent();
        }

        private void chkStatus_CheckedChanged(object sender, EventArgs e)
        {

        }
        public void FillGrid(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchvalue.Trim()))
                {
                    query = "select ProgramSemesterID [ID], Title,Capacity ,ProgramSemesterisActive [Status], ProgramID, SemesterID from v_ProgramSemesterActiveList";

                }
                else
                {
                    query = "select ProgramSemesterID [ID], Title,Capacity, ProgramSemesterisActive [Status], ProgramID, SemesterID from v_ProgramSemesterActiveList where Title like '%" + searchvalue.Trim() + "%'";
                }

                DataTable lablist = DatabaseLayer.Retrive(query);
                dgvProgramSemesters.DataSource = lablist;
                if (dgvProgramSemesters.Rows.Count > 0)
                {
                    dgvProgramSemesters.Columns[0].Width = 80;
                    dgvProgramSemesters.Columns[1].Width = 250;
                    dgvProgramSemesters.Columns[2].Width = 100;
                    dgvProgramSemesters.Columns[3].Width = 100;
                    dgvProgramSemesters.Columns[4].Visible = false;
                    dgvProgramSemesters.Columns[5].Visible = false;

                }
            }
            catch
            {

                MessageBox.Show("Unexpexted error!!!");
            }
        }
        private void frmProgramSemesters_Load(object sender, EventArgs e)
        {
            ComboHelper.Semesters(cmbSelectSemester);
            ComboHelper.Programs(cmbSelectProgram);
            FillGrid(string.Empty);
        }

        private void cmbSelectProgram_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbSelectProgram.Text.Contains("Select"))
            {
                if (cmbSelectSemester.SelectedIndex > 0)
                {
                    txtSemesterTitle.Text = cmbSelectProgram.Text + " " + cmbSelectSemester.Text;
                }

            }
        }

        private void cmbSelectSemester_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!cmbSelectSemester.Text.Contains("Select"))
            {
                if (cmbSelectProgram.SelectedIndex > 0)
                {
                    txtSemesterTitle.Text = cmbSelectProgram.Text + " " + cmbSelectSemester.Text;
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtSemesterTitle.Text.Trim().Length == 0)
            {
                ep.SetError(txtSemesterTitle, "Select Again!!");
                txtSemesterTitle.Focus();
                txtSemesterTitle.SelectAll();
                return;
            }

            if (cmbSelectProgram.SelectedIndex == 0)
            {
                ep.SetError(cmbSelectProgram, "Please Select Program");
                cmbSelectProgram.Focus();
                return;
            }

            if (cmbSelectSemester.SelectedIndex == 0)
            {
                ep.SetError(cmbSelectProgram, "Please Select Semester");
                cmbSelectSemester.Focus();
                return;
            }

            if(txtCapacity.Text.Trim().Length == 0)
            {
                ep.SetError(txtCapacity, "Please Enter Capacity");
                txtCapacity.Focus();
                return;
            }

            DataTable checktitle = DatabaseLayer.Retrive("select * from ProgramSemesterTable where ProgramID = '" + cmbSelectProgram.SelectedValue + "' and SemesterID = '" + cmbSelectSemester.SelectedValue );
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    ep.SetError(txtSemesterTitle, "Already Exist");
                    txtSemesterTitle.Focus();
                    txtSemesterTitle.SelectAll();
                    return;
                }
            }

            DataTable sessionDT = DatabaseLayer.Retrive("SELECT TOP 1 SessionID FROM SessionTable WHERE isActive = 1");

            if (sessionDT == null || sessionDT.Rows.Count == 0)
            {
                MessageBox.Show("No active session found. Please check the SessionTable.");
                return;
            }

            string sessionID = sessionDT.Rows[0]["SessionID"].ToString();
            ResetIdentity("ProgramSemesterTable");

            string insertquery = string.Format(
                "INSERT INTO ProgramSemesterTable (Title, ProgramID, SemesterID, isActive, Capacity, SessionID) VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')",
                txtSemesterTitle.Text.Trim(),
                cmbSelectProgram.SelectedValue,
                cmbSelectSemester.SelectedValue,
                chkStatus.Checked,
                txtCapacity.Text.Trim(),
                sessionID
            );
            bool result = DatabaseLayer.Insert(insertquery);
            if (result == true)
            {
                FillGrid(string.Empty);
                SaveClearForm();
            }
            else
            {
                MessageBox.Show("Please Provide the Correct Semester Details");
            }
        }

        private void ResetIdentity(string v)
        {
            throw new NotImplementedException();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }

        public void EnableComponents()
        {
            dgvProgramSemesters.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSearch.Visible = false;

        }

        public void DisableComponents()
        {
            dgvProgramSemesters.Enabled = true;
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
            txtSemesterTitle.Clear();
            cmbSelectSemester.SelectedIndex = 0;
            cmbSelectProgram.SelectedIndex = 0;
            chkStatus.Checked = false;
            FillGrid(string.Empty);
        }

        public void SaveClearForm()
        {
            txtSemesterTitle.Clear();
            cmbSelectSemester.SelectedIndex = 0;

            chkStatus.Checked = true;
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtSemesterTitle.Text.Trim().Length == 0 || txtSemesterTitle.Text.Length > 251)
            {
                ep.SetError(txtSemesterTitle, "Error!! Select Again");
                txtSemesterTitle.Focus();
                txtSemesterTitle.SelectAll();
                return;
            }

            if (cmbSelectProgram.SelectedIndex == 0)
            {
                ep.SetError(cmbSelectProgram, "Please Select Program");
                cmbSelectProgram.Focus();
                return;
            }

            if (cmbSelectSemester.SelectedIndex == 0)
            {
                ep.SetError(cmbSelectProgram, "Please Select Semester");
                cmbSelectSemester.Focus();
                return;
            }

            DataTable checktitle = DatabaseLayer.Retrive("select * from ProgramSemesterTable where ProgramID = '" + cmbSelectProgram.SelectedValue + "' and SemesterID = '" + cmbSelectSemester.SelectedValue + "'and ProgramSemesterID != '" + Convert.ToString(dgvProgramSemesters.CurrentRow.Cells[0].Value) + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    ep.SetError(txtSemesterTitle, "Already Exist");
                    txtSemesterTitle.Focus();
                    txtSemesterTitle.SelectAll();
                    return;
                }
            }

            string updatequery = string.Format("update ProgramSemesterTable set Title = '{0}', ProgramID='{1}', SemesterID = '{2}', isActive = '{3}', Capacity='{4}' where ProgramSemesterID = '{5}'",
                                txtSemesterTitle.Text.Trim(), cmbSelectProgram.SelectedValue, cmbSelectSemester.SelectedValue, chkStatus.Checked,txtCapacity.Text.Trim() ,Convert.ToString(dgvProgramSemesters.CurrentRow.Cells[0].Value));
            bool result = DatabaseLayer.Update(updatequery);
            if (result == true)
            {
                MessageBox.Show("Updated Successfully!");
                DisableComponents();
            }
            else
            {
                MessageBox.Show("Please Provide the Correct  Details");
            }
        }

        private void cmsedit_Click(object sender, EventArgs e)
        {
            if (dgvProgramSemesters != null)
            {
                if (dgvProgramSemesters.Rows.Count > 0)
                {
                    if (dgvProgramSemesters.SelectedRows.Count == 1)
                    {
                        txtSemesterTitle.Text = Convert.ToString(dgvProgramSemesters.CurrentRow.Cells[1].Value);
                        txtCapacity.Text = Convert.ToString(dgvProgramSemesters.CurrentRow.Cells[2].Value);
                        chkStatus.Checked = Convert.ToBoolean(dgvProgramSemesters.CurrentRow.Cells[3].Value);
                        cmbSelectProgram.SelectedValue = Convert.ToString(dgvProgramSemesters.CurrentRow.Cells[4].Value);
                        cmbSelectSemester.SelectedValue = Convert.ToString(dgvProgramSemesters.CurrentRow.Cells[5].Value);

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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtLecturer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
