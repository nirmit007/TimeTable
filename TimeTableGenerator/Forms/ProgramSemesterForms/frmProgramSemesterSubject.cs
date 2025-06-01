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
    public partial class frmProgramSemesterSubject : Form
    {
        public frmProgramSemesterSubject()
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
                    query = "select [ProgramSemesterSubjectID] [ID] ,[ProgramID], [Program], ProgramSemesterID,Title[Semester], LectureSubjectID,SSTitle[Subject], Capacity, IsSubjectActive[Status]  from v_AllSemestersSubjects where [ProgramSemesterisActive] = 1 and [ProgramisActive] =1 and [SemesterisActive] =1 and [SubjectisActive] =1 order by ProgramSemesterID";

                }
                else
                {
                    query = "select [ProgramSemesterSubjectID] [ID] ,[ProgramID], [Program], ProgramSemesterID,Title[Semester], LectureSubjectID,SSTitle[Subject], Capacity, IsSubjectActive[Status]  from v_AllSemestersSubjects where [ProgramSemesterisActive] = 1 and [ProgramisActive]=1 and [SemesterisActive]=1 and [SubjectisActive] =1 and (Program + ' ' +Title + ' ' +SSTitle) like '%" + searchvalue + "%' order by ProgramSemesterID   ";
                }
                DataTable semesterlist = DatabaseLayer.Retrive(query);
                dgvTeacherSubjects.DataSource = semesterlist;

                if (dgvTeacherSubjects.Rows.Count > 0)
                {
                    dgvTeacherSubjects.Columns[0].Visible = false;
                    dgvTeacherSubjects.Columns[1].Visible = false;
                    dgvTeacherSubjects.Columns[2].Width = 120;
                    dgvTeacherSubjects.Columns[3].Visible = false;
                    dgvTeacherSubjects.Columns[4].Width = 150;
                    dgvTeacherSubjects.Columns[5].Visible = false;
                    dgvTeacherSubjects.Columns[6].Width = 300;
                    dgvTeacherSubjects.Columns[7].Width = 80;
                    dgvTeacherSubjects.Columns[8].Width = 80;

                    dgvTeacherSubjects.ClearSelection();
                }
            }
            catch
            {
                MessageBox.Show("Error in loading data");
            }
        }


        private void cmbSubjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTitle.Text = cmbSubjects.SelectedIndex == 0 ? string.Empty : cmbSubjects.Text;
        }

        private void txtSemesterName_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmProgramSemesterSubject_Load(object sender, EventArgs e)
        {
            ComboHelper.AllProgramSemesters(cmbSemesters);
            ComboHelper.AllTeachersSubject(cmbSubjects);
            FillGrid(string.Empty);
        }

        private void FormClear()
        {
            txtTitle.Clear();
            cmbSubjects.SelectedIndex = 0;

        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            FormClear();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtTitle.Text.Trim().Length == 0)
            {
                ep.SetError(txtTitle, "Please enter Semester Subject value");
                txtTitle.Focus();
                txtTitle.SelectAll();
                return;
            }

            if (cmbSemesters.SelectedIndex == 0)
            {
                ep.SetError(cmbSemesters, "Please select Semester");
                cmbSemesters.Focus();
                return;
            }

            if (cmbSubjects.SelectedIndex == 0)
            {
                ep.SetError(cmbSubjects, "Please select Subject");
                cmbSubjects.Focus();
                return;
            }

            string checkquery = "Select * from ProgramSemesterSubjectTable where ProgramSemesterID = '" + cmbSemesters.SelectedValue + "' and LectureSubjectID = '" + cmbSubjects.SelectedValue + "'";
            DataTable dt = DatabaseLayer.Retrive(checkquery);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    ep.SetError(cmbSubjects, "Already Exist!!");
                    return;
                }
            }

            string insertquery = string.Format("insert into ProgramSemesterSubjectTable (SSTitle, ProgramSemesterID, LectureSubjectID) values('{0}', '{1}', '{2}')", txtTitle.Text.Trim(), cmbSemesters.SelectedValue, cmbSubjects.SelectedValue);
            bool result = DatabaseLayer.Insert(insertquery);
            if (result == true)
            {
                FillGrid(string.Empty);
                FormClear();
            }
            else
            {
                MessageBox.Show("Error in inserting data!!");
            }
        }

        private void cmsedit_Click(object sender, EventArgs e)
        {
            if (dgvTeacherSubjects != null)
            {
                if (dgvTeacherSubjects.Rows.Count > 0)
                {
                    if (dgvTeacherSubjects.SelectedRows.Count == 1)
                    {
                        if (MessageBox.Show("Are you sure to edit this record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            bool existstatus = Convert.ToBoolean(dgvTeacherSubjects.CurrentRow.Cells[8].Value);
                            int semestersubjectid = Convert.ToInt32(dgvTeacherSubjects.CurrentRow.Cells[0].Value);
                            bool status = false;
                            if (existstatus == true)
                            {
                                status = false;
                            }
                            else
                            {
                                status = true;
                            }
                            string updatequery = string.Format("update ProgramSemesterSubjectTable set IsSubjectActive = '{0}' where ProgramSemesterSubjectID = '{1}'", status, semestersubjectid);
                            bool result = DatabaseLayer.Update(updatequery);
                            if (result == true)
                            {
                                MessageBox.Show("Status Updated Successfully!!");
                                FillGrid(string.Empty);
                            }
                            else
                            {
                                MessageBox.Show("Please Try Again!!");
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("Please select one record to edit!!");
                    }
                }
                else
                {  
                    MessageBox.Show("No record found!!");
                }
            }
            else
            {
                MessageBox.Show("No record found!!");
            }

        }
    }
}