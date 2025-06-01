namespace TimeTableGenerator.Forms
{
    partial class frmGenerateTimeTables
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
            components = new System.ComponentModel.Container();
            groupBox1 = new GroupBox();
            dtpStartDate = new DateTimePicker();
            groupBox2 = new GroupBox();
            dtpEndDate = new DateTimePicker();
            btnGenerateTimeTables = new Button();
            ep = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ep).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpStartDate);
            groupBox1.Location = new Point(10, 10);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(427, 62);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Start  Date";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "dd MMM yyyy";
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(6, 22);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(401, 23);
            dtpStartDate.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dtpEndDate);
            groupBox2.Location = new Point(10, 78);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(427, 62);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "End Date";
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "dd MMM yyyy";
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(6, 22);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(401, 23);
            dtpEndDate.TabIndex = 0;
            // 
            // btnGenerateTimeTables
            // 
            btnGenerateTimeTables.FlatStyle = FlatStyle.Flat;
            btnGenerateTimeTables.Location = new Point(16, 166);
            btnGenerateTimeTables.Name = "btnGenerateTimeTables";
            btnGenerateTimeTables.Size = new Size(401, 54);
            btnGenerateTimeTables.TabIndex = 2;
            btnGenerateTimeTables.Text = "Generate Time Table";
            btnGenerateTimeTables.UseVisualStyleBackColor = true;
            btnGenerateTimeTables.Click += btnGenerateTimeTables_Click;
            // 
            // ep
            // 
            ep.ContainerControl = this;
            // 
            // frmGenerateTimeTables
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 253);
            Controls.Add(btnGenerateTimeTables);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "frmGenerateTimeTables";
            Text = "Generate Time Tables";
            Load += frmGenerateTimeTables_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private DateTimePicker dtpStartDate;
        private GroupBox groupBox2;
        private DateTimePicker dtpEndDate;
        private Button btnGenerateTimeTables;
        private ErrorProvider ep;
    }
}