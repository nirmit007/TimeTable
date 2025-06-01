using System.Data;
using TimeTableGenerator.SourceCode;

namespace TimeTableGenerator.Forms.ConfigurationForms
{
    public partial class frmCourses : Form
    {
        public frmCourses()
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
                    query = "select CourseID, Title , CrHrs, RoomTypeID, TypeName, isActive from v_AllSubjects";

                }
                else
                {
                    query = "select CourseID, Title , CrHrs, RoomTypeID, TypeName, isActive from v_AllSubjects where (Title + ' ' + TypeName) like '%" + searchvalue.Trim() + "%'";
                }

                DataTable lablist = DatabaseLayer.Retrive(query);
                dgvCourses.DataSource = lablist;
                if (dgvCourses.Rows.Count > 0)
                {
                    dgvCourses.Columns[0].Width = 80;
                    dgvCourses.Columns[1].Width = 250;
                    dgvCourses.Columns[2].Width = 60;
                    dgvCourses.Columns[3].Visible = false;
                    dgvCourses.Columns[4].Width = 250;
                    dgvCourses.Columns[5].Width = 80;

                }
            }
            catch
            {

                MessageBox.Show("Unexpexted error!!!");
            }
        }
        private void frmCourses_Load(object sender, EventArgs e)
        {
            cmbCrHrs.SelectedIndex = 0;
            ComboHelper.RoomTypes(cmbSelectType);
            FillGrid(string.Empty);
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtsibjectTitle.Text.Trim().Length == 0)
            {
                ep.SetError(txtsibjectTitle, "Select Again!!");
                txtsibjectTitle.Focus();
                txtsibjectTitle.SelectAll();
                return;
            }

            if (cmbSelectType.SelectedIndex == 0)
            {
                ep.SetError(cmbSelectType, "Please Select Program");
                cmbSelectType.Focus();
                return;
            }

            DataTable checktitle = DatabaseLayer.Retrive("select * from CourseTable where Title = '" + txtsibjectTitle.Text.Trim() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    ep.SetError(txtsibjectTitle, "Already Exist");
                    txtsibjectTitle.Focus();
                    txtsibjectTitle.SelectAll();
                    return;
                }
            }

            string insertquery = string.Format("insert into CourseTable (Title, CrHrs, RoomTypeID, isActive) values('{0}', '{1}', {2}, '{3}')",
                                txtsibjectTitle.Text.Trim(), cmbCrHrs.Text, cmbSelectType.SelectedValue, chkStatus.Checked);
            bool result = DatabaseLayer.Insert(insertquery);
            if (result == true)
            {
                MessageBox.Show("Save Successfully!");
                SaveClearForm();
            }
            else
            {
                MessageBox.Show("Please Provide the Correct Details");
            }

        }
        public void EnableComponents()
        {
            dgvCourses.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSearch.Visible = false;

        }

        public void DisableComponents()
        {
            dgvCourses.Enabled = true;
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
            txtsibjectTitle.Clear();
            cmbSelectType.SelectedIndex = 0;
            cmbCrHrs.SelectedIndex = 0;
            chkStatus.Checked = false;

        }
        public void SaveClearForm()
        {
            txtsibjectTitle.Clear();
            chkStatus.Checked = true;
            FillGrid(string.Empty);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableComponents();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void cmsedit_Click(object sender, EventArgs e)
        {
            if (dgvCourses != null)
            {
                if (dgvCourses.Rows.Count > 0)
                {
                    if (dgvCourses.SelectedRows.Count == 1)
                    {
                        txtsibjectTitle.Text = Convert.ToString(dgvCourses.CurrentRow.Cells[1].Value);
                        chkStatus.Checked = Convert.ToBoolean(dgvCourses.CurrentRow.Cells[5].Value);
                        cmbSelectType.SelectedValue = Convert.ToString(dgvCourses.CurrentRow.Cells[3].Value);
                        cmbCrHrs.Text = Convert.ToString(dgvCourses.CurrentRow.Cells[2].Value);

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
            if (txtsibjectTitle.Text.Trim().Length == 0)
            {
                ep.SetError(txtsibjectTitle, "Select Again!!");
                txtsibjectTitle.Focus();
                txtsibjectTitle.SelectAll();
                return;
            }

            if (cmbSelectType.SelectedIndex == 0)
            {
                ep.SetError(cmbSelectType, "Please Select Program");
                cmbSelectType.Focus();
                return;
            }



            DataTable checktitle = DatabaseLayer.Retrive("select * from CourseTable where Title = '" + txtsibjectTitle.Text.Trim() + "' and CourseID != '" + Convert.ToString(dgvCourses.CurrentRow.Cells[0].Value));
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    ep.SetError(txtsibjectTitle, "Already Exist");
                    txtsibjectTitle.Focus();
                    txtsibjectTitle.SelectAll();
                    return;
                }
            }
            string updatequery = string.Format("update CourseTable set Title = '{0}', CrHrs='{1}', RoomTypeID = '{2}', isActive = '{3}' where CourseID = '{4}'",
                                txtsibjectTitle.Text.Trim(), cmbCrHrs.Text, cmbSelectType.SelectedValue, chkStatus.Checked, Convert.ToString(dgvCourses.CurrentRow.Cells[0].Value));
            bool result = DatabaseLayer.Update(updatequery);
            if (result == true)
            {
                MessageBox.Show("Updated Successfully!");
                DisableComponents();
            }
            else
            {
                MessageBox.Show("Please Provide Details");
            }
        }

        private void txtLecturer_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
