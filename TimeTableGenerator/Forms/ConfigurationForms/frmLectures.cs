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
    public partial class frmLectures : Form
    {
        public frmLectures()
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
                    query = "select LectureID[ID], FullName[Lecturer], ContactNo, isActive [Status] from LectureTable";

                }
                else
                {
                    query = "select LectureID[ID], FullName[Lecturer], ContactNo, isActive [Status] from LectureTable where (FullName + '' + ContactNo) like '%" + searchvalue.Trim() + "%'";
                }

                DataTable lablist = DatabaseLayer.Retrive(query);
                dgvLecturer.DataSource = lablist;
                if (dgvLecturer.Rows.Count > 0)
                {
                    dgvLecturer.Columns[0].Width = 80;
                    dgvLecturer.Columns[1].Width = 150;
                    dgvLecturer.Columns[2].Width = 100;
                    dgvLecturer.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }
            }
            catch
            {

                MessageBox.Show("Unexpexted error!!!");
            }
        }
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void frmLectures_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtLecturer.Text.Trim().Length == 0 || txtLecturer.Text.Length > 50)
            {
                ep.SetError(txtLecturer, "Please Enter Valid Lab No/Name !!");
                txtLecturer.Focus();
                txtLecturer.SelectAll();
                return;
            }

            if (txtContactNo.Text.Trim().Length < 10)
            {
                ep.SetError(txtContactNo, "Invalid Capacity!!");
                txtContactNo.Focus();
                txtContactNo.SelectAll();
                return;
            }

            DataTable checktitle = DatabaseLayer.Retrive("select * from LectureTable where FullName = '" + txtLecturer.Text.Trim() + "' and ContactNo = '" + txtContactNo.Text.Trim());
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    ep.SetError(txtLecturer, "Already Exist");
                    txtLecturer.Focus();
                    txtLecturer.SelectAll();
                    return;
                }
            }

            string insertquery = string.Format("insert into LectureTable(FullName, ContactNo, isActive) values('{0}', '{1}', '{2}')",
                                txtLecturer.Text.Trim(), txtContactNo.Text.Trim(), chkStatus.Checked);
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
            dgvLecturer.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSearch.Visible = false;

        }

        public void DisableComponents()
        {
            dgvLecturer.Enabled = true;
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
            txtLecturer.Clear();
            txtContactNo.Clear();
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
            if (dgvLecturer != null)
            {
                if (dgvLecturer.Rows.Count > 0)
                {
                    if (dgvLecturer.SelectedRows.Count == 1)
                    {
                        txtLecturer.Text = Convert.ToString(dgvLecturer.CurrentRow.Cells[1].Value);
                        txtContactNo.Text = Convert.ToString(dgvLecturer.CurrentRow.Cells[2].Value);
                        chkStatus.Checked = Convert.ToBoolean(dgvLecturer.CurrentRow.Cells[3].Value);
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
            if (txtLecturer.Text.Trim().Length == 0 || txtLecturer.Text.Length > 50)
            {
                ep.SetError(txtLecturer, "Please Enter Valid Lab No/Name !!");
                txtLecturer.Focus();
                txtLecturer.SelectAll();
                return;
            }

            if (txtContactNo.Text.Trim().Length < 10)
            {
                ep.SetError(txtContactNo, "Invalid Capacity!!");
                txtContactNo.Focus();
                txtContactNo.SelectAll();
                return;
            }

            DataTable checktitle = DatabaseLayer.Retrive("select * from LectureTable where FullName = '" + txtLecturer.Text.Trim() + "'and ContactNo = '"+txtContactNo.Text.Trim()+"' and LectureID != '" + Convert.ToString(dgvLecturer.CurrentRow.Cells[0].Value) + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    ep.SetError(txtLecturer, "Already Exist");
                    txtLecturer.Focus();
                    txtLecturer.SelectAll();
                    return;
                }
            }

            string updatequery = string.Format("update LectureTable set FullName = '{0}',ContactNo = '{1}' ,isActive = '{2}' where LectureID = '{3}'",
                                 txtLecturer.Text.Trim(), txtContactNo.Text.Trim(), chkStatus.Checked, Convert.ToString(dgvLecturer.CurrentRow.Cells[0].Value));
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
