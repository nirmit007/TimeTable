namespace TimeTableGenerator.Forms.Printing
{
    partial class frmPrintTimetable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btbPrintDayTable = new Button();
            SuspendLayout();
            // 
            // btbPrintDayTable
            // 
            btbPrintDayTable.Location = new Point(23, 12);
            btbPrintDayTable.Name = "btbPrintDayTable";
            btbPrintDayTable.Size = new Size(366, 72);
            btbPrintDayTable.TabIndex = 0;
            btbPrintDayTable.Text = "Print day wise";
            btbPrintDayTable.UseVisualStyleBackColor = true;
            btbPrintDayTable.Click += btbPrintDayTable_Click;
            // 
            // frmPrintTimetable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(401, 109);
            Controls.Add(btbPrintDayTable);
            Name = "frmPrintTimetable";
            Text = "frmPrintTimetable";
            ResumeLayout(false);
        }

        #endregion

        private Button btbPrintDayTable;
    }
}