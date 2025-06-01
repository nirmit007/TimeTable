using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

public class TimetablePrinter
{
    private DataTable timetableData;
    private int currentDayIndex = 0;
    private DataTable[] dayTables;
    private PrintDocument printDocument;
    private Font headerFont = new Font("Arial", 14, FontStyle.Bold);
    private Font roomFont = new Font("Arial", 10, FontStyle.Bold);
    private Font slotFont = new Font("Arial", 9);
    private Brush brush = Brushes.Black;
    private int yPos = 0;
    private int pageMargin = 50;
    private int rowHeight = 30;
    private int colWidth = 120;

    public void PrintTimetable(string connectionString)
    {
        // Step 1: Retrieve data from the stored procedure
        RetrieveTimetableData(connectionString);

        // Step 2: Split data by days
        PrepareDayWiseTables();

        // Step 3: Initialize printing
        printDocument = new PrintDocument();
        printDocument.PrintPage += new PrintPageEventHandler(PrintPageHandler);

        // Step 4: Show print dialog and start printing
        PrintDialog printDialog = new PrintDialog();
        printDialog.Document = printDocument;

        if (printDialog.ShowDialog() == DialogResult.OK)
        {
            printDocument.Print();
        }
    }

    private void RetrieveTimetableData(string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new SqlCommand("sp_PrintAllDaysTimeTablesOneByOne", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    timetableData = new DataTable();
                    adapter.Fill(timetableData);
                }
            }
        }
    }

    private void PrepareDayWiseTables()
    {
        if (timetableData == null || timetableData.Rows.Count == 0)
        {
            throw new Exception("No timetable data found.");
        }

        // Get distinct days from the data
        DataView view = new DataView(timetableData);
        DataTable distinctDays = view.ToTable(true, "DayTitle");

        dayTables = new DataTable[distinctDays.Rows.Count];

        for (int i = 0; i < distinctDays.Rows.Count; i++)
        {
            string day = distinctDays.Rows[i]["DayTitle"].ToString();
            dayTables[i] = timetableData.Select($"DayTitle = '{day}'").CopyToDataTable();
        }
    }

    private void PrintPageHandler(object sender, PrintPageEventArgs e)
    {
        if (currentDayIndex >= dayTables.Length)
        {
            e.HasMorePages = false;
            return;
        }

        DataTable currentDayTable = dayTables[currentDayIndex];
        yPos = pageMargin;

        // Print day header
        e.Graphics.DrawString(currentDayTable.Rows[0]["DayTitle"].ToString(),
                            headerFont, brush, pageMargin, yPos);
        yPos += 40;

        // Print column headers (time slots)
        int xPos = pageMargin + 150; // Leave space for room names

        string[] slotHeaders = { "09:00-09:50", "09:50-10:40", "10:40-11:30",
                               "11:30-12:20", "12:20-13:10", "13:10-14:00",
                               "14:00-14:50", "14:50-15:40", "15:40-16:30" };

        for (int i = 0; i < slotHeaders.Length; i++)
        {
            e.Graphics.DrawString(slotHeaders[i], roomFont, brush, xPos + (i * colWidth), yPos);
        }

        yPos += 30;

        // Print each room's timetable
        foreach (DataRow row in currentDayTable.Rows)
        {
            // Print room name
            e.Graphics.DrawString(row["LabRoomTitle"].ToString(), roomFont, brush, pageMargin, yPos);

            // Print slots
            for (int i = 1; i <= 9; i++)
            {
                string slotValue = row[$"Slot{i}"].ToString();
                e.Graphics.DrawString(slotValue, slotFont, brush,
                                      pageMargin + 150 + ((i - 1) * colWidth), yPos);
            }

            yPos += rowHeight;

            // Check if we need a new page
            if (yPos + rowHeight > e.PageBounds.Height - pageMargin)
            {
                e.HasMorePages = true;
                return;
            }
        }

        // Move to next day
        currentDayIndex++;
        yPos += 40; // Add space between days

        // Check if we have more days to print
        if (currentDayIndex < dayTables.Length)
        {
            e.HasMorePages = true;
        }
        else
        {
            e.HasMorePages = false;
        }
    }

    internal PrintDocument? GetPrintDocument(string connStr)
    {
        throw new NotImplementedException();
    }
}