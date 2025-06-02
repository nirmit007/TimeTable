namespace TimeTableGenerator.Forms
{
    partial class frmPrintDayWiseTimeTable
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
            btbPrint = new Button();
            SuspendLayout();
            // 
            // btbPrint
            // 
            btbPrint.Location = new Point(0, 12);
            btbPrint.Name = "btbPrint";
            btbPrint.Size = new Size(346, 60);
            btbPrint.TabIndex = 0;
            btbPrint.Text = "Print Semesterwise";
            btbPrint.UseVisualStyleBackColor = true;
            btbPrint.Click += btbPrint_Click;
            // 
            // frmPrintSemesterWiseTimeTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 84);
            Controls.Add(btbPrint);
            Name = "frmPrintSemesterWiseTimeTable";
            Text = "frmPrintSemesterWiseTimeTable";
            ResumeLayout(false);
        }

        #endregion

        private Button btbPrint;
    }
}