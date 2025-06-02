namespace TimeTableGenerator.Forms
{
    partial class frmPrintSemesterWiseTable
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
            btnSemWise = new Button();
            SuspendLayout();
            // 
            // btnSemWise
            // 
            btnSemWise.Location = new Point(0, 12);
            btnSemWise.Name = "btnSemWise";
            btnSemWise.Size = new Size(319, 52);
            btnSemWise.TabIndex = 0;
            btnSemWise.Text = "SEMESTER WISE";
            btnSemWise.UseVisualStyleBackColor = true;
            btnSemWise.Click += btnSemWise_Click;
            // 
            // frmPrintSemesterWiseTable
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(331, 76);
            Controls.Add(btnSemWise);
            Name = "frmPrintSemesterWiseTable";
            Text = "frmPrintSemesterWiseTable";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSemWise;
    }
}