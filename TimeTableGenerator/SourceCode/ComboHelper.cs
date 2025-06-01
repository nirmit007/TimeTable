
using System.Data;
using System.Windows.Forms;

namespace TimeTableGenerator.SourceCode
{
    public class ComboHelper
    {

        public static void Semesters(ComboBox cmb)
        {
            DataTable dtSemester = new DataTable();
            dtSemester.Columns.Add("SemesterID");
            dtSemester.Columns.Add("SemesterName");
            dtSemester.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrive("Select SemesterID, SemesterName from SemesterTable where isActive = 1");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow semester in dt.Rows)
                        {
                            dtSemester.Rows.Add(semester["SemesterID"], semester["SemesterNAme"]);
                        }
                    }
                }
                cmb.DataSource = dtSemester;
                cmb.ValueMember = "SemesterID";
                cmb.DisplayMember = "SemesterName";
            }
            catch
            {
                cmb.DataSource = dtSemester;
            }
        }

        public static void Programs(ComboBox cmb)
        {
            DataTable dtProgram = new DataTable();
            dtProgram.Columns.Add("ProgramID");
            dtProgram.Columns.Add("Name");
            dtProgram.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrive("Select ProgramID, Name from ProgramTable where isActive = 1 ORDER BY Name ASC");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow program in dt.Rows)
                        {
                            dtProgram.Rows.Add(program["ProgramID"], program["Name"]);
                        }
                    }
                }
                cmb.DataSource = dtProgram;
                cmb.ValueMember = "ProgramID";
                cmb.DisplayMember = "Name";
            }
            catch
            {
                cmb.DataSource = dtProgram;
            }
        }

        public static void RoomTypes(ComboBox cmb)
        {
            DataTable dtTypes = new DataTable();
            dtTypes.Columns.Add("RoomTypeID");
            dtTypes.Columns.Add("TypeName");
            dtTypes.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrive("Select RoomTypeID, TypeName from RoomTypeTable ");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow type in dt.Rows)
                        {
                            dtTypes.Rows.Add(type["RoomTypeID"], type["TypeName"]);
                        }
                    }
                }
                cmb.DataSource = dtTypes;
                cmb.ValueMember = "RoomTypeID";
                cmb.DisplayMember = "TypeName";
            }
            catch
            {
                cmb.DataSource = dtTypes;
            }
        }

        public static void AllDays(ComboBox cmb)
        {
            DataTable dtList = new DataTable();
            dtList.Columns.Add("DayID");
            dtList.Columns.Add("Name");
            dtList.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrive("Select DayID, Name from DayTable where isActive = 1");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow type in dt.Rows)
                        {
                            dtList.Rows.Add(type["DayID"], type["Name"]);
                        }
                    }
                }
                cmb.DataSource = dtList;
                cmb.ValueMember = "DayID";
                cmb.DisplayMember = "Name";
            }
            catch
            {
                cmb.DataSource = dtList;
            }
        }

        public static void AllTeachers(ComboBox cmb)
        {
            DataTable dtList = new DataTable();
            dtList.Columns.Add("LectureID");
            dtList.Columns.Add("FullName");
            dtList.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrive("Select LectureID, FullName from LectureTable where isActive = 1 ORDER BY FullName ASC");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow type in dt.Rows)
                        {
                            dtList.Rows.Add(type["LectureID"], type["FullName"]);
                        }
                    }
                }
                cmb.DataSource = dtList;
                cmb.ValueMember = "LectureID";
                cmb.DisplayMember = "FullName";
            }
            catch
            {
                cmb.DataSource = dtList;
            }
        }

        public static void AllSubjects(ComboBox cmb)
        {
            DataTable dtList = new DataTable();
            dtList.Columns.Add("CourseID");
            dtList.Columns.Add("Title");
            dtList.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrive("Select CourseID, Title from CourseTable where isActive = 1 ORDER BY Title ASC");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow type in dt.Rows)
                        {
                            dtList.Rows.Add(type["CourseID"], type["Title"]);
                        }
                    }
                }
                cmb.DataSource = dtList;
                cmb.ValueMember = "CourseID";
                cmb.DisplayMember = "Title";
            }
            catch
            {
                cmb.DataSource = dtList;
            }
        }

        public static void AllProgramSemesters(ComboBox cmb)
        {
            DataTable dtList = new DataTable();
            dtList.Columns.Add("ProgramSemesterID");
            dtList.Columns.Add("Title");
            dtList.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrive("Select ProgramSemesterID, Title from v_ProgramSemesterActiveList where ProgramSemesterisActive = 1");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow type in dt.Rows)
                        {
                            dtList.Rows.Add(type["ProgramSemesterID"], type["Title"]);
                        }
                    }
                }
                cmb.DataSource = dtList;
                cmb.ValueMember = "ProgramSemesterID";
                cmb.DisplayMember = "Title";
            }
            catch
            {
                cmb.DataSource = dtList;
            }
        }

        public static void AllTeachersSubject(ComboBox cmb)
        {
            DataTable dtList = new DataTable();
            dtList.Columns.Add("LectureSubjectID");
            dtList.Columns.Add("SubjectTitle");
            dtList.Rows.Add("0", "---Select---");
            try
            {
                DataTable dt = DatabaseLayer.Retrive("Select LectureSubjectID, SubjectTitle from v_AllSubjectsTeachers where isActive = 1");
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow type in dt.Rows)
                        {
                            dtList.Rows.Add(type["LectureSubjectID"], type["SubjectTitle"]);
                        }
                    }
                }
                cmb.DataSource = dtList;
                cmb.ValueMember = "LectureSubjectID";
                cmb.DisplayMember = "SubjectTitle";
            }
            catch
            {
                cmb.DataSource = dtList;
            }
        }
        public static void TimeSlotNumbers(ComboBox cmb)
        {
            DataTable dtList = new DataTable();
            dtList.Columns.Add("ID");
            dtList.Columns.Add("Number");
            dtList.Rows.Add("0", "--SELECT--");
            dtList.Rows.Add("1", "1");
            dtList.Rows.Add("2", "2");
            dtList.Rows.Add("3", "3");
            dtList.Rows.Add("4", "4");
            dtList.Rows.Add("5", "5");
            dtList.Rows.Add("6", "6");
            dtList.Rows.Add("7", "7");
            dtList.Rows.Add("8", "8");
            dtList.Rows.Add("9", "9");
            dtList.Rows.Add("10","10");
            dtList.Rows.Add("11","11");
            dtList.Rows.Add("12","12");
            dtList.Rows.Add("13","13");
            dtList.Rows.Add("14","14");
            dtList.Rows.Add("15","15");
            dtList.Rows.Add("16","16");
            dtList.Rows.Add("17","17");
            dtList.Rows.Add("18","18");
            dtList.Rows.Add("19","19");
            dtList.Rows.Add("20","20");
            dtList.Rows.Add("21","21");
            dtList.Rows.Add("22","22");
            dtList.Rows.Add("23","23");
            dtList.Rows.Add("24","24");
            dtList.Rows.Add("25","25");
            dtList.Rows.Add("26","26");
            dtList.Rows.Add("27","27");
            dtList.Rows.Add("28","28");
            dtList.Rows.Add("29","29");
            dtList.Rows.Add("30","30");
            dtList.Rows.Add("31","31");
            dtList.Rows.Add("32","32");
            dtList.Rows.Add("33","33");
            dtList.Rows.Add("34","34");
            dtList.Rows.Add("35","35");
            dtList.Rows.Add("36","36");
            dtList.Rows.Add("37","37");
            dtList.Rows.Add("38","38");
            dtList.Rows.Add("39","39");
            dtList.Rows.Add("40", "40");
 
                cmb.DataSource = dtList;
                cmb.ValueMember = "ID";
                cmb.DisplayMember = "Number";

        }
    }
}
