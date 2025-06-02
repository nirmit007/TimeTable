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
    public class DayTimeTableGroup
    {
        public string DayTitle { get; set; }
        public List<DataRow> Rows { get; set; }
    }

    public partial class frmPrintDayWiseTimeTable : Form
    {
        // Define the time slots according to your stored procedure
        private readonly string[] TimeSlots = {
            "09:00 AM - 09:50 AM",
            "09:50 AM - 10:40 AM",
            "10:40 AM - 11:30 AM",
            "11:30 AM - 12:20 PM",
            "12:20 PM - 01:10 PM",
            "01:10 PM - 02:00 PM",
            "02:00 PM - 02:50 PM",
            "02:50 PM - 03:40 PM",
            "03:40 PM - 04:30 PM"
        };

        private readonly string[] SlotColumns = {
            "Slot1", "Slot2", "Slot3", "Slot4", "Slot5",
            "Slot6", "Slot7", "Slot8", "Slot9"
        };

        public frmPrintDayWiseTimeTable()
        {
            InitializeComponent();
        }

        private void btbPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=Auto Time TableDb;Integrated Security=True";

                // Get the day-wise timetable data using your stored procedure
                DataTable timetableData = GetDayWiseTimeTableData(connStr);

                if (timetableData == null || timetableData.Rows.Count == 0)
                {
                    MessageBox.Show("No timetable data found in the database.",
                                  "Information",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    return;
                }

                // Create day-wise Excel export
                CreateDayWiseTimeTableExport(timetableData);
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

        private DataTable GetDayWiseTimeTableData(string connectionString)
        {
            DataTable dt = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_PrintAllDaysTimeTablesOneByOne", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        private void CreateDayWiseTimeTableExport(DataTable timetableData)
        {
            using (var wb = new XLWorkbook())
            {
                // Group data by day
                var dayGroups = timetableData.AsEnumerable()
                    .GroupBy(row => row.Field<string>("DayTitle"))
                    .OrderBy(g => GetDayOrder(g.Key))
                    .Select(g => new DayTimeTableGroup
                    {
                        DayTitle = g.Key,
                        Rows = g.ToList()
                    })
                    .ToList();

                if (dayGroups.Count == 0)
                {
                    MessageBox.Show("No valid day data found.",
                                  "Information",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                    return;
                }

                // Create a worksheet for each day
                foreach (var dayGroup in dayGroups)
                {
                    string sheetName = SanitizeSheetName(dayGroup.DayTitle);
                    var ws = wb.Worksheets.Add(sheetName);
                    CreateDayTimeTableSheet(ws, dayGroup.Rows, dayGroup.DayTitle);
                }

                // Create overview sheet with all days
                CreateOverviewSheet(wb, dayGroups);

                // Save the workbook
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Workbook|*.xlsx";
                sfd.FileName = $"Day_Wise_Timetable_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    wb.SaveAs(sfd.FileName);

                    if (MessageBox.Show("Day-wise timetable exported successfully. Would you like to open it now?",
                                      "Export Complete",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            System.Diagnostics.Process.Start(sfd.FileName);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Could not open file: {ex.Message}",
                                          "Error",
                                          MessageBoxButtons.OK,
                                          MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void CreateDayTimeTableSheet(IXLWorksheet ws, List<DataRow> dayData, string dayTitle)
        {
            int currentRow = 1;

            // Header Section
            ws.Cell(currentRow, 1).Value = $"{dayTitle.ToUpper()} TIMETABLE";
            ws.Cell(currentRow, 1).Style.Font.FontSize = 20;
            ws.Cell(currentRow, 1).Style.Font.Bold = true;
            ws.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.DarkBlue;
            ws.Cell(currentRow, 1).Style.Font.FontColor = XLColor.White;
            ws.Range(currentRow, 1, currentRow, 10).Merge();
            ws.Range(currentRow, 1, currentRow, 10).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
            currentRow += 2;

            // Day Information
            ws.Cell(currentRow, 1).Value = "Day:";
            ws.Cell(currentRow, 1).Style.Font.Bold = true;
            ws.Cell(currentRow, 1).Style.Font.FontSize = 12;
            ws.Cell(currentRow, 2).Value = dayTitle;
            ws.Cell(currentRow, 2).Style.Font.FontSize = 12;

            ws.Cell(currentRow, 8).Value = "Generated On:";
            ws.Cell(currentRow, 8).Style.Font.Bold = true;
            ws.Cell(currentRow, 9).Value = DateTime.Now.ToString("dd MMM yyyy, hh:mm tt");
            currentRow += 2;

            // Create timetable headers
            ws.Cell(currentRow, 1).Value = "Room/Lab";
            ws.Cell(currentRow, 1).Style.Font.Bold = true;
            ws.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.DarkGray;
            ws.Cell(currentRow, 1).Style.Font.FontColor = XLColor.White;
            ws.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            ws.Cell(currentRow, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;

            // Add time slot headers
            for (int i = 0; i < TimeSlots.Length; i++)
            {
                ws.Cell(currentRow, i + 2).Value = TimeSlots[i];
                ws.Cell(currentRow, i + 2).Style.Font.Bold = true;
                ws.Cell(currentRow, i + 2).Style.Fill.BackgroundColor = XLColor.DarkGray;
                ws.Cell(currentRow, i + 2).Style.Font.FontColor = XLColor.White;
                ws.Cell(currentRow, i + 2).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell(currentRow, i + 2).Style.Border.OutsideBorder = XLBorderStyleValues.Medium;
                ws.Cell(currentRow, i + 2).Style.Alignment.WrapText = true;
            }
            currentRow++;

            // Fill timetable data
            foreach (DataRow row in dayData)
            {
                string roomLab = row.Field<string>("LabRoomTitle");

                // Room/Lab column
                ws.Cell(currentRow, 1).Value = roomLab;
                ws.Cell(currentRow, 1).Style.Font.Bold = true;
                ws.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.LightGray;
                ws.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                ws.Cell(currentRow, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                // Fill time slots
                for (int slotIndex = 0; slotIndex < SlotColumns.Length; slotIndex++)
                {
                    var cell = ws.Cell(currentRow, slotIndex + 2);
                    string slotValue = row.Field<string>(SlotColumns[slotIndex]);

                    if (!string.IsNullOrEmpty(slotValue) && slotValue != "Break")
                    {
                        cell.Value = slotValue;
                        cell.Style.Alignment.WrapText = true;

                        // Color coding based on content
                        if (slotValue.Contains("Lab") || roomLab.ToLower().Contains("lab"))
                        {
                            cell.Style.Fill.BackgroundColor = XLColor.LightGreen;
                        }
                        else if (slotValue != "Break")
                        {
                            cell.Style.Fill.BackgroundColor = XLColor.LightYellow;
                        }
                        else
                        {
                            cell.Style.Fill.BackgroundColor = XLColor.LightBlue;
                        }
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
            ws.Cell(currentRow, 1).Value = "LEGEND:";
            ws.Cell(currentRow, 1).Style.Font.Bold = true;
            ws.Cell(currentRow, 1).Style.Font.FontSize = 12;
            currentRow++;

            // Regular classes legend
            ws.Cell(currentRow, 1).Value = "Regular Classes";
            ws.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.LightYellow;
            ws.Cell(currentRow, 1).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Lab classes legend
            ws.Cell(currentRow, 3).Value = "Laboratory Classes";
            ws.Cell(currentRow, 3).Style.Fill.BackgroundColor = XLColor.LightGreen;
            ws.Cell(currentRow, 3).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Cell(currentRow, 3).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Free periods legend
            ws.Cell(currentRow, 5).Value = "Free Periods";
            ws.Cell(currentRow, 5).Style.Fill.BackgroundColor = XLColor.White;
            ws.Cell(currentRow, 5).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            ws.Cell(currentRow, 5).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Statistics
            currentRow += 2;
            int totalSlots = dayData.Count * 9;
            int occupiedSlots = 0;
            int labSlots = 0;

            foreach (DataRow row in dayData)
            {
                for (int i = 0; i < SlotColumns.Length; i++)
                {
                    string slotValue = row.Field<string>(SlotColumns[i]);
                    if (!string.IsNullOrEmpty(slotValue) && slotValue != "Break")
                    {
                        occupiedSlots++;
                        if (slotValue.Contains("Lab") || row.Field<string>("LabRoomTitle").ToLower().Contains("lab"))
                        {
                            labSlots++;
                        }
                    }
                }
            }

            ws.Cell(currentRow, 1).Value = "STATISTICS:";
            ws.Cell(currentRow, 1).Style.Font.Bold = true;
            currentRow++;

            ws.Cell(currentRow, 1).Value = $"Total Time Slots: {totalSlots}";
            ws.Cell(currentRow, 3).Value = $"Occupied Slots: {occupiedSlots}";
            ws.Cell(currentRow, 5).Value = $"Lab Sessions: {labSlots}";
            ws.Cell(currentRow, 7).Value = $"Utilization: {(occupiedSlots * 100.0 / totalSlots):F1}%";

            // Adjust column widths
            ws.Column(1).Width = 15; // Room/Lab column
            for (int col = 2; col <= 10; col++)
            {
                ws.Column(col).Width = 18; // Time slot columns
            }

            // Set row heights for better readability
            for (int row = 1; row <= currentRow; row++)
            {
                if (ws.Row(row).Height < 25)
                {
                    ws.Row(row).Height = 25;
                }
            }
        }

        private void CreateOverviewSheet(XLWorkbook wb, List<DayTimeTableGroup> dayGroups)
        {
            var overviewWs = wb.Worksheets.Add("Weekly Overview");

            int currentRow = 1;

            // Title
            overviewWs.Cell(currentRow, 1).Value = "WEEKLY TIMETABLE OVERVIEW";
            overviewWs.Cell(currentRow, 1).Style.Font.FontSize = 20;
            overviewWs.Cell(currentRow, 1).Style.Font.Bold = true;
            overviewWs.Cell(currentRow, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            overviewWs.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.DarkBlue;
            overviewWs.Cell(currentRow, 1).Style.Font.FontColor = XLColor.White;
            overviewWs.Range(currentRow, 1, currentRow, 10).Merge();
            currentRow += 2;

            // Create consolidated timetable
            // Headers
            overviewWs.Cell(currentRow, 1).Value = "Time / Day";
            overviewWs.Cell(currentRow, 1).Style.Font.Bold = true;
            overviewWs.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.DarkGray;
            overviewWs.Cell(currentRow, 1).Style.Font.FontColor = XLColor.White;

            int colIndex = 2;
            foreach (var dayGroup in dayGroups)
            {
                overviewWs.Cell(currentRow, colIndex).Value = dayGroup.DayTitle;
                overviewWs.Cell(currentRow, colIndex).Style.Font.Bold = true;
                overviewWs.Cell(currentRow, colIndex).Style.Fill.BackgroundColor = XLColor.DarkGray;
                overviewWs.Cell(currentRow, colIndex).Style.Font.FontColor = XLColor.White;
                overviewWs.Cell(currentRow, colIndex).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                colIndex++;
            }
            currentRow++;

            // Time slots data
            for (int slotIndex = 0; slotIndex < TimeSlots.Length; slotIndex++)
            {
                overviewWs.Cell(currentRow, 1).Value = TimeSlots[slotIndex];
                overviewWs.Cell(currentRow, 1).Style.Font.Bold = true;
                overviewWs.Cell(currentRow, 1).Style.Fill.BackgroundColor = XLColor.LightGray;

                colIndex = 2;
                foreach (var dayGroup in dayGroups)
                {
                    // Count occupied rooms/labs for this time slot
                    int occupiedCount = 0;
                    foreach (DataRow row in dayGroup.Rows)
                    {
                        string slotValue = row.Field<string>(SlotColumns[slotIndex]);
                        if (!string.IsNullOrEmpty(slotValue) && slotValue != "Break")
                        {
                            occupiedCount++;
                        }
                    }

                    var cell = overviewWs.Cell(currentRow, colIndex);
                    if (occupiedCount > 0)
                    {
                        cell.Value = $"{occupiedCount} Classes";
                        cell.Style.Fill.BackgroundColor = XLColor.LightGreen;
                    }
                    else
                    {
                        cell.Value = "Free";
                        cell.Style.Fill.BackgroundColor = XLColor.White;
                        cell.Style.Font.FontColor = XLColor.Gray;
                    }

                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                    cell.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    colIndex++;
                }
                currentRow++;
            }

            // Weekly statistics
            currentRow += 2;
            overviewWs.Cell(currentRow, 1).Value = "WEEKLY STATISTICS:";
            overviewWs.Cell(currentRow, 1).Style.Font.Bold = true;
            overviewWs.Cell(currentRow, 1).Style.Font.FontSize = 12;
            currentRow++;

            colIndex = 1;
            foreach (var dayGroup in dayGroups)
            {
                int totalSlots = dayGroup.Rows.Count * 9;
                int occupiedSlots = 0;

                foreach (DataRow row in dayGroup.Rows)
                {
                    for (int i = 0; i < SlotColumns.Length; i++)
                    {
                        string slotValue = row.Field<string>(SlotColumns[i]);
                        if (!string.IsNullOrEmpty(slotValue) && slotValue != "Break")
                        {
                            occupiedSlots++;
                        }
                    }
                }

                overviewWs.Cell(currentRow, colIndex).Value = dayGroup.DayTitle;
                overviewWs.Cell(currentRow, colIndex).Style.Font.Bold = true;
                overviewWs.Cell(currentRow + 1, colIndex).Value = $"Utilization: {(occupiedSlots * 100.0 / totalSlots):F1}%";
                colIndex++;
            }

            overviewWs.Columns().AdjustToContents();
        }

        private int GetDayOrder(string dayName)
        {
            switch (dayName?.ToLower())
            {
                case "monday": return 1;
                case "tuesday": return 2;
                case "wednesday": return 3;
                case "thursday": return 4;
                case "friday": return 5;
                case "saturday": return 6;
                case "sunday": return 7;
                default: return 8;
            }
        }

        private string SanitizeSheetName(string name)
        {
            if (string.IsNullOrEmpty(name)) return "Sheet1";

            // Remove invalid characters for Excel sheet names
            char[] invalidChars = { '\\', '/', '*', '[', ']', ':', '?' };
            string sanitized = name;

            foreach (char c in invalidChars)
            {
                sanitized = sanitized.Replace(c, '-');
            }

            // Limit to 31 characters (Excel limit)
            if (sanitized.Length > 31)
            {
                sanitized = sanitized.Substring(0, 31);
            }

            return sanitized;
        }
    }
}