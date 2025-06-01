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

namespace TimeTableGenerator.Forms.LectureSubjectForms
{
    public partial class frmLectureSubjectForms : Form
    {
        public frmLectureSubjectForms()
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
                    query = "select LectureSubjectID [ID], SubjectTitle [Subject Title], LectureID, FullName [Lecture], CourseID, " +
                            "Title [Course], isActive [Status] from v_AllSubjectsTeachers";
                }
                else
                {
                    query = "select LectureSubjectID [ID], SubjectTitle [Subject Title], LectureID, FullName [Lecture], CourseID, " +
                            "Title [Course], isActive [Status] from v_AllSubjectsTeachers" +
                            "where (SubjectTitle + ' ' + FullName + ' ' + Title) like '%" + searchvalue.Trim() + "%'";

                }

                DataTable semesterlist = DatabaseLayer.Retrive(query);
                dgvTeacherSubjects.DataSource = semesterlist;
                if (dgvTeacherSubjects.Rows.Count > 0)
                {
                    dgvTeacherSubjects.Columns[0].Visible = false;
                    dgvTeacherSubjects.Columns[1].Width = 200;
                    dgvTeacherSubjects.Columns[2].Visible = false;
                    dgvTeacherSubjects.Columns[3].Width = 150;
                    dgvTeacherSubjects.Columns[4].Visible = false;
                    dgvTeacherSubjects.Columns[5].Width = 300;
                    dgvTeacherSubjects.Columns[6].Width = 100;

                }
            }
            catch
            {

                MessageBox.Show("Unexpexted error!!!");
            }
        }

        public void EnableComponents()
        {
            dgvTeacherSubjects.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSearch.Visible = false;

        }

        public void DisableComponents()
        {
            dgvTeacherSubjects.Enabled = true;
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

            cmbTeachers.SelectedIndex = 0;
            cmbSubjects.SelectedIndex = 0;
            chkStatus.Checked = true;

        }

        private void frmLectureSubjectForms_Load(object sender, EventArgs e)
        {
            ComboHelper.AllSubjects(cmbSubjects);
            ComboHelper.AllTeachers(cmbTeachers);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                ep.Clear();
                if (cmbTeachers.SelectedIndex == 0)
                {
                    ep.SetError(cmbTeachers, "Select Teacher!!!");
                    cmbTeachers.Focus();
                    return;
                }

                if (cmbSubjects.SelectedIndex == 0)
                {
                    ep.SetError(cmbSubjects, "Select Subject!!!"); 
                    cmbSubjects.Focus();
                    return;
                }

                DataTable dt = DatabaseLayer.Retrive("select * from LectureSubjectTable where LectureID = '" + cmbTeachers.SelectedValue + "'and CourseID = '" + cmbSubjects.SelectedValue + "'");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        ep.SetError(cmbSubjects, "This Subject is already assigned to this Teacher!!!");

                        cmbSubjects.Focus();
                        return;
                    }
                }
                string insertquery = string.Format("insert into LectureSubjectTable (SubjectTitle, LectureID, CourseID, isActive) values ('{0}', '{1}', '{2}', '{3}')",
                    cmbSubjects.Text + "(" + cmbTeachers.Text + ")", cmbTeachers.SelectedValue, cmbSubjects.SelectedValue, chkStatus.Checked);
                bool result = DatabaseLayer.Insert(insertquery);
                if (result == true)
                {
                    FillGrid(string.Empty);
                    return;
                }
                else
                {
                    MessageBox.Show("Record not Inserted!!!");
                }
            }
            catch
            {

                MessageBox.Show("Server error!!!");
            }

        }

        private void cmsedit_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTeacherSubjects != null)
                {
                    if (dgvTeacherSubjects.Rows.Count > 0)
                    {
                        if (dgvTeacherSubjects.SelectedRows.Count == 1)
                        {
                            string id = Convert.ToString(dgvTeacherSubjects.CurrentRow.Cells[0].Value);
                            bool status = (Convert.ToBoolean(dgvTeacherSubjects.CurrentRow.Cells[6].Value) == true ? false : true);

                            string updatequery = "update LectureSubjectTable set isActive = '" + status + "' where LectureSubjectID = '" + id + "'";

                            bool result = DatabaseLayer.Update(updatequery);
                            if (result == true)
                            {
                                //MessageBox.Show("Record Updated Successfully!!!");
                                FillGrid(string.Empty);
                            }
                            else
                            {
                                MessageBox.Show("Record not Updated!!!");
                                return;
                            }
                        }
                    }
                }
            }
            catch 
            {


            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }
    }
}
