using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTableGenerator.Forms.ConfigurationForms;
using TimeTableGenerator.Forms.LectureSubjectForms;
using TimeTableGenerator.Forms.ProgramSemesterForms;

namespace TimeTableGenerator.Forms
{
    public partial class HomeForm : Form
    {
        frmCourses CoursesForm;
        frmDays DaysForm;
        frmLabs LabsForm;
        frmLectures LecturesForm;
        frmProgram ProgramForm;
        frmRoom RoomForm;
        frmSemester SemestersForm;
        frmSession SessionForm;
        frmLectureSubjectForms LecturesSubjectForm;
        frmProgramSemesters ProgramSemestersForm;
        frmProgramSemesterSubject ProgramSemesterSubjectForm;
        frmDayTimeSlots DayTimeSlotsForm;
        frmSemesterSections SemesterSectionsForm;
        frmGenerateTimeTables GenerateTimeTableForm;

        public HomeForm()
        {
            InitializeComponent();
            tsslblDateTime.Text = DateTime.Now.ToString("dd MMMM yyyy ");
        }

        public frmSemester SemestersForm1 { get => SemestersForm; set => SemestersForm = value; }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (ProgramForm == null)
            {
                ProgramForm = new frmProgram();
            }
            ProgramForm.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (SessionForm == null)
            {
                SessionForm = new frmSession();
            }
            SessionForm.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (CoursesForm == null)
            {
                CoursesForm = new frmCourses();
            }
            CoursesForm.ShowDialog();

        }

        private void newLectureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LecturesForm == null)
            {
                LecturesForm = new frmLectures();
            }
            LecturesForm.ShowDialog();
        }

        private void assignSubjectsToLectureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LecturesSubjectForm == null)
            {
                LecturesSubjectForm = new frmLectureSubjectForms();
            }
            LecturesSubjectForm.ShowDialog();
        }

        private void addRoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LabsForm == null)
            {
                LabsForm = new frmLabs();
            }
            LabsForm.ShowDialog();
        }

        private void addLabsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LabsForm == null)
            {
                LabsForm = new frmLabs();
            }
            LabsForm.ShowDialog();
        }

        private void newSemestersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SemestersForm == null)
            {
                SemestersForm = new frmSemester();
            }
            SemestersForm.ShowDialog();
        }

        private void addSemesterSectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SemesterSectionsForm == null)
            {
                SemesterSectionsForm = new frmSemesterSections();
            }
            SemesterSectionsForm.ShowDialog();

        }

        private void assignSemesterToProgramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramSemestersForm == null)
            {
                ProgramSemestersForm = new frmProgramSemesters();
            }
            ProgramSemestersForm.ShowDialog();
        }

        private void assignSubjectToSemesterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProgramSemesterSubjectForm == null)
            {
                ProgramSemesterSubjectForm = new frmProgramSemesterSubject();
            }
            ProgramSemesterSubjectForm.ShowDialog();
        }

        private void addDaysToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DaysForm == null)
            {
                DaysForm = new frmDays();
            }
            DaysForm.ShowDialog();
        }

        private void dayTimeSlotToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DayTimeSlotsForm == null)
            {
                DayTimeSlotsForm = new frmDayTimeSlots();
            }
            DayTimeSlotsForm.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            if (GenerateTimeTableForm == null)
            {
                GenerateTimeTableForm = new frmGenerateTimeTables();
            }
            GenerateTimeTableForm.ShowDialog();
        }
    }
}
