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

                var result = MessageBox.Show("Would you like to export to Excel or print the timetable?",
                                           "Timetable Options",
                                           MessageBoxButtons.YesNoCancel,
                                           MessageBoxIcon.Question,
                                           MessageBoxDefaultButton.Button1);

                if (result == DialogResult.Yes)
                {
                    // Export to Excel with professional formatting
                    string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=Auto Time TableDb;Integrated Security=True";
                    DataTable dt = new DataTable();

                    using (SqlConnection conn = new SqlConnection(connStr))
                    using (SqlCommand cmd = new SqlCommand("GenerateTimeTablesForAllSession", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add the required parameters
                        cmd.Parameters.Add("@StartDate", SqlDbType.Date).Value = dtpStartDate.Value;
                        cmd.Parameters.Add("@EndDate", SqlDbType.Date).Value = dtpEndDate.Value;

                        // Add the output parameter
                        SqlParameter messageParam = new SqlParameter("@Message", SqlDbType.NVarChar, 100);
                        messageParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(messageParam);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }

                    using (var wb = new XLWorkbook())
                    {
                        var ws = wb.Worksheets.Add(dt, "TimeTable");

                        // Add a title row
                        ws.Row(1).InsertRowsAbove(2);
                        ws.Cell(1, 1).Value = "INSTITUTION TIMETABLE";
                        ws.Cell(1, 1).Style.Font.Bold = true;
                        ws.Cell(1, 1).Style.Font.FontSize = 16;
                        ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(1, 1, 1, dt.Columns.Count).Merge();

                        // Add date range
                        ws.Cell(2, 1).Value = $"Date Range: {dtpStartDate.Value:dd-MMM-yyyy} to {dtpEndDate.Value:dd-MMM-yyyy}";
                        ws.Cell(2, 1).Style.Font.Italic = true;
                        ws.Cell(2, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        ws.Range(2, 1, 2, dt.Columns.Count).Merge();

                        // Format headers
                        var headerRange = ws.Range(3, 1, 3, dt.Columns.Count);
                        headerRange.Style.Font.Bold = true;
                        headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
                        headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        headerRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        // Format data cells
                        var dataRange = ws.Range(4, 1, dt.Rows.Count + 3, dt.Columns.Count);
                        dataRange.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        dataRange.Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                        dataRange.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;

                        // Set column widths
                        ws.Column(1).Width = 10; // TimeTableID
                        ws.Column(2).Width = 25; // TimeTableTitle
                        ws.Column(3).Width = 20; // SemesterTitle
                        ws.Column(4).Width = 25; // SessionTitle
                        ws.Column(5).Width = 30; // SubjectTitle
                        ws.Column(6).Width = 15; // Location
                        ws.Column(7).Width = 15; // Day
                        ws.Column(8).Width = 15; // StartTime
                        ws.Column(9).Width = 15; // EndTime
                        ws.Column(10).Width = 25; // Lecturer

                        // Format time columns
                        ws.Column(8).Style.NumberFormat.Format = "hh:mm AM/PM";
                        ws.Column(9).Style.NumberFormat.Format = "hh:mm AM/PM";

                        // Freeze headers
                        ws.SheetView.FreezeRows(3);

                        // Add alternating row colors
                        for (int i = 4; i <= dt.Rows.Count + 3; i++)
                        {
                            if (i % 2 == 0)
                                ws.Row(i).Style.Fill.BackgroundColor = XLColor.White;
                            else
                                ws.Row(i).Style.Fill.BackgroundColor = XLColor.LightBlue;
                        }

                        // Group by TimeTableID for better organization
                        int currentId = 0;
                        int startRow = 4;

                        for (int i = 4; i <= dt.Rows.Count + 3; i++)
                        {
                            var id = ws.Cell(i, 1).GetValue<int>();
                            if (id != currentId)
                            {
                                if (currentId != 0)
                                {
                                    ws.Rows(startRow, i - 1).Group();
                                }
                                currentId = id;
                                startRow = i;
                            }
                        }

                        // Group the last section
                        if (currentId != 0)
                        {
                            ws.Rows(startRow, dt.Rows.Count + 3).Group();
                        }

                        // Save the file
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.Filter = "Excel Workbook|*.xlsx";
                        sfd.FileName = $"Timetable_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            wb.SaveAs(sfd.FileName);
                            MessageBox.Show($"Timetable successfully exported to:\n{sfd.FileName}",
                                            "Export Complete",
                                            MessageBoxButtons.OK,
                                            MessageBoxIcon.Information);

                            // Optionally open the file
                            if (MessageBox.Show("Would you like to open the exported file now?",
                                              "Open File",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                System.Diagnostics.Process.Start(sfd.FileName);
                            }
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void frmGenerateTimeTables_Load(object sender, EventArgs e)
        {

        }

    }
}
