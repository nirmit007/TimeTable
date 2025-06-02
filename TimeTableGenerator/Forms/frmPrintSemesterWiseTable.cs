using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTableGenerator.Forms
{
    public class SemesterTimeTableGroup
    {
        public string SemesterTitle { get; set; }
        public int TimeTableID { get; set; }
        public List<DataRow> Rows { get; set; }
    }

    public partial class frmPrintSemesterWiseTable : Form
    {
        // Define the days of the week in order
        private readonly string[] DaysOfWeek = {
            "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY",
            "FRIDAY", "SATURDAY", "SUNDAY"
        };

        private readonly string[] DayColumns = {
            "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY",
            "FRIDAY", "SATURDAY", "SUNDAY"
        };

        public frmPrintSemesterWiseTable()
        {
            InitializeComponent();
        }

        private DataTable GetSemesterWiseTimeTableData(string connectionString)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand("sp_PrintSemesterwiseTimeTables", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving semester-wise timetable data: {ex.Message}", ex);
            }

            return dataTable;
        }

        private void CreateSemesterWiseTimeTableExport(DataTable timetableData)
        {
            try
            {
                // Check if timetableData is null
                if (timetableData == null)
                {
                    MessageBox.Show("No data available to export.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Group the data by semester - Updated to use SEMESTER column from SP
                var semesterGroups = timetableData.AsEnumerable()
                    .Where(row => row != null) // Filter out null rows
                    .GroupBy(row => new
                    {
                        SemesterTitle = row.Field<string>("SEMESTER") ?? "Unknown Semester", // Handle null values
                        TimeTableID = row.Field<int?>("TimeTableID") ?? 0 // Handle null TimeTableID
                    })
                    .Select(g => new SemesterTimeTableGroup
                    {
                        SemesterTitle = g.Key.SemesterTitle,
                        TimeTableID = g.Key.TimeTableID,
                        Rows = g.ToList()
                    })
                    .OrderBy(g => g.SemesterTitle)
                    .ToList();

                if (!semesterGroups.Any())
                {
                    MessageBox.Show("No semester data found to export.",
                                  "Information",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    return;
                }

                // Create Excel workbook
                using (var workbook = new XLWorkbook())
                {
                    // Create overview sheet
                    var overviewWs = workbook.Worksheets.Add("Overview");
                    CreateOverviewSheet(overviewWs, semesterGroups);

                    // Keep track of used sheet names to handle duplicates
                    HashSet<string> usedSheetNames = new HashSet<string> { "Overview" };

                    // Create individual semester sheets
                    foreach (var semesterGroup in semesterGroups)
                    {
                        if (semesterGroup != null && !string.IsNullOrEmpty(semesterGroup.SemesterTitle))
                        {
                            // Clean the semester title for sheet name (remove invalid characters)
                            string baseSheetName = CleanSheetName(semesterGroup.SemesterTitle);
                            string uniqueSheetName = GetUniqueSheetName(baseSheetName, usedSheetNames);

                            // Add to used names
                            usedSheetNames.Add(uniqueSheetName);

                            var semesterWs = workbook.Worksheets.Add(uniqueSheetName);
                            CreateSemesterTimeTableSheet(semesterWs, semesterGroup.Rows, semesterGroup.SemesterTitle);
                        }
                    }

                    // Save the file
                    SaveFileDialog saveDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        Title = "Save Semester-wise Timetable",
                        FileName = $"SemesterWise_Timetable_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
                    };

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveDialog.FileName);
                        MessageBox.Show($"Semester-wise timetable exported successfully!\n\nFile saved at: {saveDialog.FileName}",
                                      "Export Complete",
                                      MessageBoxButtons.OK,
                                      MessageBoxIcon.Information);

                        // Ask if the user wants to open the file
                        if (MessageBox.Show("Would you like to open the exported file?",
                                          "Open File",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(saveDialog.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating semester-wise timetable export: {ex.Message}",
                              "Export Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        private void CreateOverviewSheet(IXLWorksheet overviewWs, List<SemesterTimeTableGroup> semesterGroups)
        {
            if (overviewWs == null || semesterGroups == null)
                return;

            int currentRow = 1;

            // Title
            overviewWs.Cell(currentRow, 1).Value = "SEMESTER-WISE TIMETABLE OVERVIEW";
            overviewWs.Cell(currentRow, 1).Style.Font.FontSize = 18;
            overviewWs.Cell(currentRow, 1).Style.Font.Bold = true;
            overviewWs.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            overviewWs.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.DarkBlue;
            overviewWs.Cell(currentRow, 1).Style.Font.FontColor = XLColor.White;
            overviewWs.Range(currentRow, 1, currentRow, 5).Merge();
            overviewWs.Range(currentRow, 1, currentRow, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            currentRow += 2;

            // Generation info
            overviewWs.Cell(currentRow, 1).Value = "Generated On:";
            overviewWs.Cell(currentRow, 1).Style.Font.Bold = true;
            overviewWs.Cell(currentRow, 2).Value = DateTime.Now.ToString("dd MMM yyyy, hh:mm tt");
            currentRow += 2;

            // Headers
            overviewWs.Cell(currentRow, 1).Value = "SEMESTER";
            overviewWs.Cell(currentRow, 2).Value = "TOTAL PERIODS";
            overviewWs.Cell(currentRow, 3).Value = "OCCUPIED PERIODS";
            overviewWs.Cell(currentRow, 4).Value = "FREE PERIODS";
            overviewWs.Cell(currentRow, 5).Value = "UTILIZATION %";

            // Style headers
            for (int col = 1; col <= 5; col++)
            {
                overviewWs.Cell(currentRow, col).Style.Font.Bold = true;
                overviewWs.Cell(currentRow, col).Style.Fill.BackgroundColor = XLColor.DarkGray;
                overviewWs.Cell(currentRow, col).Style.Font.FontColor = XLColor.White;
                overviewWs.Cell(currentRow, col).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                overviewWs.Cell(currentRow, col).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            }
            currentRow++;

            // Data rows
            foreach (var semester in semesterGroups)
            {
                if (semester != null && semester.Rows != null)
                {
                    var stats = CalculateSemesterStatistics(semester.Rows);

                    overviewWs.Cell(currentRow, 1).Value = semester.SemesterTitle ?? "Unknown";
                    overviewWs.Cell(currentRow, 2).Value = stats.TotalSlots;
                    overviewWs.Cell(currentRow, 3).Value = stats.OccupiedSlots;
                    overviewWs.Cell(currentRow, 4).Value = stats.FreeSlots;
                    overviewWs.Cell(currentRow, 5).Value = $"{stats.UtilizationPercentage:F1}%";

                    // Style data rows
                    for (int col = 1; col <= 5; col++)
                    {
                        overviewWs.Cell(currentRow, col).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        overviewWs.Cell(currentRow, col).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    }
                    currentRow++;
                }
            }

            // Adjust column widths
            overviewWs.Column(1).Width = 30;
            overviewWs.Column(2).Width = 15;
            overviewWs.Column(3).Width = 18;
            overviewWs.Column(4).Width = 15;
            overviewWs.Column(5).Width = 15;
        }

        private (int TotalSlots, int OccupiedSlots, int FreeSlots, double UtilizationPercentage) CalculateSemesterStatistics(List<DataRow> semesterData)
        {
            if (semesterData == null || !semesterData.Any())
                return (0, 0, 0, 0);

            int totalSlots = semesterData.Count * 7; // 7 days
            int occupiedSlots = 0;
            int breakSlots = 0;

            foreach (DataRow row in semesterData)
            {
                if (row == null) continue;

                for (int i = 0; i < DayColumns.Length; i++)
                {
                    string dayValue = row.Field<string>(DayColumns[i]) ?? "";
                    if (!string.IsNullOrEmpty(dayValue))
                    {
                        if (dayValue == "Break")
                        {
                            breakSlots++;
                        }
                        else
                        {
                            occupiedSlots++;
                        }
                    }
                }
            }

            int freeSlots = totalSlots - occupiedSlots - breakSlots;
            double utilizationPercentage = totalSlots > breakSlots ?
                (occupiedSlots * 100.0 / (totalSlots - breakSlots)) : 0;

            return (totalSlots, occupiedSlots, freeSlots, utilizationPercentage);
        }

        private string CleanSheetName(string sheetName)
        {
            if (string.IsNullOrEmpty(sheetName))
                return "Sheet1";

            // Remove invalid characters for Excel sheet names
            char[] invalidChars = { '\\', '/', '*', '[', ']', ':', '?' };
            string cleanName = sheetName;

            foreach (char c in invalidChars)
            {
                cleanName = cleanName.Replace(c, '_');
            }

            // Ensure sheet name is not too long (Excel limit is 31 characters)
            if (cleanName.Length > 31)
            {
                cleanName = cleanName.Substring(0, 31);
            }

            return cleanName;
        }

        private string GetUniqueSheetName(string baseSheetName, HashSet<string> usedNames)
        {
            string uniqueName = baseSheetName;
            int counter = 1;

            // If the name is already used, append a number
            while (usedNames.Contains(uniqueName))
            {
                // Calculate the suffix length to ensure we don't exceed 31 characters
                string suffix = $"_{counter}";
                int maxBaseLength = 31 - suffix.Length;

                if (baseSheetName.Length > maxBaseLength)
                {
                    uniqueName = baseSheetName.Substring(0, maxBaseLength) + suffix;
                }
                else
                {
                    uniqueName = baseSheetName + suffix;
                }

                counter++;

                // Safety check to prevent infinite loop
                if (counter > 100)
                {
                    uniqueName = $"Sheet_{DateTime.Now:HHmmss}_{counter}";
                    break;
                }
            }

            return uniqueName;
        }

        // Alternative method: Delete existing sheet if it exists
        private IXLWorksheet AddOrReplaceWorksheet(XLWorkbook workbook, string sheetName)
        {
            // Check if worksheet already exists
            if (workbook.Worksheets.Any(ws => ws.Name.Equals(sheetName, StringComparison.OrdinalIgnoreCase)))
            {
                // Delete the existing worksheet
                workbook.Worksheets.Delete(sheetName);
            }

            // Add the new worksheet
            return workbook.Worksheets.Add(sheetName);
        }

        private void CreateSemesterTimeTableSheet(IXLWorksheet worksheet, List<DataRow> semesterData, string semesterTitle)
        {
            if (worksheet == null || semesterData == null || string.IsNullOrEmpty(semesterTitle))
                return;

            int currentRow = 1;

            // Header Section
            worksheet.Cell(currentRow, 1).Value = $"{semesterTitle.ToUpper()} TIMETABLE";
            worksheet.Cell(currentRow, 1).Style.Font.FontSize = 20;
            worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.DarkBlue;
            worksheet.Cell(currentRow, 1).Style.Font.FontColor = XLColor.White;
            worksheet.Range(currentRow, 1, currentRow, 8).Merge();
            worksheet.Range(currentRow, 1, currentRow, 8).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            currentRow += 2;

            // Semester Information
            worksheet.Cell(currentRow, 1).Value = "Semester:";
            worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 1).Style.Font.FontSize = 12;
            worksheet.Cell(currentRow, 2).Value = semesterTitle;
            worksheet.Cell(currentRow, 2).Style.Font.FontSize = 12;

            worksheet.Cell(currentRow, 6).Value = "Generated On:";
            worksheet.Cell(currentRow, 6).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 7).Value = DateTime.Now.ToString("dd MMM yyyy, hh:mm tt");
            currentRow += 2;

            // Create timetable headers
            worksheet.Cell(currentRow, 1).Value = "TIME";
            worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.DarkGray;
            worksheet.Cell(currentRow, 1).Style.Font.FontColor = XLColor.White;
            worksheet.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            worksheet.Cell(currentRow, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;

            // Add day headers
            for (int i = 0; i < DaysOfWeek.Length; i++)
            {
                worksheet.Cell(currentRow, i + 2).Value = DaysOfWeek[i];
                worksheet.Cell(currentRow, i + 2).Style.Font.Bold = true;
                worksheet.Cell(currentRow, i + 2).Style.Fill.BackgroundColor = XLColor.DarkGray;
                worksheet.Cell(currentRow, i + 2).Style.Font.FontColor = XLColor.White;
                worksheet.Cell(currentRow, i + 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(currentRow, i + 2).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                worksheet.Cell(currentRow, i + 2).Style.Alignment.WrapText = true;
            }
            currentRow++;

            // Sort the semester data by time before displaying
            var sortedSemesterData = semesterData
                .Where(row => row != null) // Filter out null rows
                .OrderBy(row => ParseTimeSlot(row.Field<string>("TIME")))
                .ToList();

            // Fill timetable data
            foreach (DataRow row in sortedSemesterData)
            {
                if (row == null) continue;

                string timeSlot = row.Field<string>("TIME") ?? "";

                // Time column
                worksheet.Cell(currentRow, 1).Value = timeSlot;
                worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
                worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                worksheet.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                worksheet.Cell(currentRow, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                // Fill day columns
                for (int dayIndex = 0; dayIndex < DayColumns.Length; dayIndex++)
                {
                    var cell = worksheet.Cell(currentRow, dayIndex + 2);
                    string dayValue = row.Field<string>(DayColumns[dayIndex]) ?? "";

                    if (!string.IsNullOrEmpty(dayValue) && dayValue != "Break")
                    {
                        cell.Value = dayValue;
                        cell.Style.Alignment.WrapText = true;

                        // Color coding based on content
                        if (dayValue.ToLower().Contains("lab"))
                        {
                            cell.Style.Fill.BackgroundColor = XLColor.LightGreen;
                        }
                        else if (dayValue != "Break")
                        {
                            cell.Style.Fill.BackgroundColor = XLColor.LightYellow;
                        }
                    }
                    else if (dayValue == "Break")
                    {
                        cell.Value = "Break";
                        cell.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        cell.Style.Font.FontColor = XLColor.DarkBlue;
                        cell.Style.Font.Bold = true;
                    }
                    else
                    {
                        cell.Value = "Free";
                        cell.Style.Fill.BackgroundColor = XLColor.White;
                        cell.Style.Font.FontColor = XLColor.Gray;
                        cell.Style.Font.Italic = true;
                    }

                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    cell.Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                }
                currentRow++;
            }

            // Add legend
            currentRow += 2;
            worksheet.Cell(currentRow, 1).Value = "LEGEND:";
            worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
            worksheet.Cell(currentRow, 1).Style.Font.FontSize = 12;
            currentRow++;

            // Regular classes legend
            worksheet.Cell(currentRow, 1).Value = "Regular Classes";
            worksheet.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.LightYellow;
            worksheet.Cell(currentRow, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Lab classes legend  
            worksheet.Cell(currentRow, 3).Value = "Laboratory Classes";
            worksheet.Cell(currentRow, 3).Style.Fill.BackgroundColor = XLColor.LightGreen;
            worksheet.Cell(currentRow, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell(currentRow, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Break periods legend
            worksheet.Cell(currentRow, 5).Value = "Break Time";
            worksheet.Cell(currentRow, 5).Style.Fill.BackgroundColor = XLColor.LightBlue;
            worksheet.Cell(currentRow, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell(currentRow, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Free periods legend
            worksheet.Cell(currentRow, 7).Value = "Free Periods";
            worksheet.Cell(currentRow, 7).Style.Fill.BackgroundColor = XLColor.White;
            worksheet.Cell(currentRow, 7).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell(currentRow, 7).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Statistics (use sorted data for accurate count)
            currentRow += 2;
            int totalSlots = sortedSemesterData.Count * 7; // 7 days
            int occupiedSlots = 0;
            int labSlots = 0;
            int breakSlots = 0;

            foreach (DataRow row in sortedSemesterData)
            {
                if (row == null) continue;

                for (int i = 0; i < DayColumns.Length; i++)
                {
                    string dayValue = row.Field<string>(DayColumns[i]) ?? "";
                    if (!string.IsNullOrEmpty(dayValue))
                    {
                        if (dayValue == "Break")
                        {
                            breakSlots++;
                        }
                        else
                        {
                            occupiedSlots++;
                            if (dayValue.ToLower().Contains("lab"))
                            {
                                labSlots++;
                            }
                        }
                    }
                }
            }

            worksheet.Cell(currentRow, 1).Value = "STATISTICS:";
            worksheet.Cell(currentRow, 1).Style.Font.Bold = true;
            currentRow++;

            worksheet.Cell(currentRow, 1).Value = $"Total Time Slots: {totalSlots}";
            worksheet.Cell(currentRow, 2).Value = $"Classes: {occupiedSlots}";
            worksheet.Cell(currentRow, 3).Value = $"Labs: {labSlots}";
            worksheet.Cell(currentRow, 4).Value = $"Breaks: {breakSlots}";
            worksheet.Cell(currentRow, 5).Value = $"Free: {totalSlots - occupiedSlots - breakSlots}";
            worksheet.Cell(currentRow, 6).Value = $"Utilization: {(totalSlots > breakSlots ? (occupiedSlots * 100.0 / (totalSlots - breakSlots)) : 0):F1}%";

            // Adjust column widths
            worksheet.Column(1).Width = 20; // Time column
            for (int col = 2; col <= 8; col++)
            {
                worksheet.Column(col).Width = 25; // Day columns
            }

            // Set row heights for better readability
            for (int row = 1; row <= currentRow; row++)
            {
                if (worksheet.Row(row).Height < 30)
                {
                    worksheet.Row(row).Height = 30;
                }
            }
        }

        // Add this helper method to parse and sort time slots properly
        private DateTime ParseTimeSlot(string timeSlot)
        {
            if (string.IsNullOrEmpty(timeSlot))
                return DateTime.MaxValue; // Put empty slots at the end

            try
            {
                // Handle time range format like "09:00 AM - 09:50 AM"
                string[] parts = timeSlot.Split('-');
                if (parts.Length >= 1)
                {
                    string startTime = parts[0].Trim();

                    // Convert to 24-hour format for proper sorting
                    if (DateTime.TryParse(startTime, out DateTime parsedTime))
                    {
                        return parsedTime;
                    }
                }
            }
            catch
            {
                // If parsing fails, return a default time
            }

            return DateTime.MaxValue; // Put unparseable times at the end
        }

        private void btnSemWise_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=Auto Time TableDb;Integrated Security=True";

                // Get the semester-wise timetable data using the stored procedure
                DataTable timetableData = GetSemesterWiseTimeTableData(connStr);

                if (timetableData == null || timetableData.Rows.Count == 0)
                {
                    MessageBox.Show("No timetable data found in the database.",
                                  "Information",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    return;
                }

                // Create semester-wise Excel export
                CreateSemesterWiseTimeTableExport(timetableData);
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show($"Database error: {sqlEx.Message}",
                              "Database Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating timetable: {ex.Message}",
                              "Error",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }
    }
}