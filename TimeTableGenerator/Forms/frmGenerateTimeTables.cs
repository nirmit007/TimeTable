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
using ClosedXML.Excel;
using System.Data.SqlClient;


namespace TimeTableGenerator.Forms
{
    public partial class frmGenerateTimeTables : Form
    {
        public frmGenerateTimeTables()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerateTimeTables_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                string message = GenerateTimeTable.AutoGenerateTimeTable(dtpStartDate.Value, dtpEndDate.Value);
                MessageBox.Show(message);

                // Ask user if they want to export to Excel or print
                var result = MessageBox.Show("Would you like to export to Excel or print the timetable?",
                                           "Timetable Options",
                                           MessageBoxButtons.YesNoCancel,
                                           MessageBoxIcon.Question,
                                           MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    // Existing Excel export code
                    string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=Auto Time TableDb;Integrated Security=True";
                    DataTable dt = new DataTable();

                    using (SqlConnection conn = new SqlConnection(connStr))
                    using (SqlCommand cmd = new SqlCommand("GenerateTimeTablesForAllSession", conn))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        adapter.Fill(dt);
                    }

                    using (var wb = new ClosedXML.Excel.XLWorkbook())
                    {
                        wb.Worksheets.Add(dt, "TimeTable");
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Excel Workbook|*.xlsx";
                        sfd.FileName = "SemesterWiseTimeTable.xlsx";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            wb.SaveAs(sfd.FileName);
                            MessageBox.Show("Exported to Excel: " + sfd.FileName);
                        }
                    }
                }
                else if (result == DialogResult.No)
                {
                    // Print the timetable
                    string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=Auto Time TableDb;Integrated Security=True";
                    TimetablePrinter printer = new TimetablePrinter();

                    // Show print preview first
                    PrintPreviewDialog preview = new PrintPreviewDialog();
                    preview.Document = printer.GetPrintDocument(connStr);
                    preview.ShowDialog();

                    // Or print directly without preview:
                    // printer.PrintTimetable(connStr);
                }
                // If DialogResult.Cancel, do nothing
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmGenerateTimeTables_Load(object sender, EventArgs e)
        {

        }



        //private void btnGenerateTimeTables_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        ep.Clear();
        //        string message = GenerateTimeTable.AutoGenerateTimeTable(dtpStartDate.Value, dtpEndDate.Value);
        //        MessageBox.Show(message);
        //        return;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
