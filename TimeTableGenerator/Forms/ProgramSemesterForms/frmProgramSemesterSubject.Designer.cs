namespace TimeTableGenerator.Forms.ProgramSemesterForms
{
    partial class frmProgramSemesterSubject
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
            groupBox3 = new GroupBox();
            txtTitle = new TextBox();
            groupBox5 = new GroupBox();
            cmbSubjects = new ComboBox();
            groupBox2 = new GroupBox();
            cmbSemesters = new ComboBox();
            btnClear = new Button();
            btnSave = new Button();
            chkStatus = new CheckBox();
            ep = new ErrorProvider(components);
            label1 = new Label();
            cmsedit = new ToolStripMenuItem();
            cmsOptions = new ContextMenuStrip(components);
            dgvTeacherSubjects = new DataGridView();
            txtSearch = new TextBox();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ep).BeginInit();
            cmsOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeacherSubjects).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(chkStatus);
            groupBox1.Location = new Point(8, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(282, 426);
            groupBox1.TabIndex = 18;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lecturer and Subject";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtTitle);
            groupBox3.Location = new Point(10, 33);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(257, 120);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Subject Title";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 12F);
            txtTitle.Location = new Point(8, 22);
            txtTitle.Multiline = true;
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(240, 92);
            txtTitle.TabIndex = 10;
            txtTitle.TextChanged += txtSemesterName_TextChanged;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(cmbSubjects);
            groupBox5.Location = new Point(10, 247);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(257, 65);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "Select Subject";
            // 
            // cmbSubjects
            // 
            cmbSubjects.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSubjects.Font = new Font("Segoe UI", 12F);
            cmbSubjects.FormattingEnabled = true;
            cmbSubjects.Location = new Point(6, 22);
            cmbSubjects.Name = "cmbSubjects";
            cmbSubjects.Size = new Size(240, 29);
            cmbSubjects.TabIndex = 2;
            cmbSubjects.SelectedIndexChanged += cmbSubjects_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbSemesters);
            groupBox2.Location = new Point(10, 176);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(257, 65);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Select Semester";
            // 
            // cmbSemesters
            // 
            cmbSemesters.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSemesters.Font = new Font("Segoe UI", 12F);
            cmbSemesters.FormattingEnabled = true;
            cmbSemesters.Location = new Point(8, 23);
            cmbSemesters.Name = "cmbSemesters";
            cmbSemesters.Size = new Size(240, 29);
            cmbSemesters.TabIndex = 1;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(0, 192, 192);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(117, 392);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(64, 28);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Lime;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(200, 392);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(64, 28);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // chkStatus
            // 
            chkStatus.AutoSize = true;
            chkStatus.CheckAlign = ContentAlignment.MiddleRight;
            chkStatus.Checked = true;
            chkStatus.CheckState = CheckState.Checked;
            chkStatus.Location = new Point(10, 340);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(61, 19);
            chkStatus.TabIndex = 1;
            chkStatus.Text = " Status";
            chkStatus.UseVisualStyleBackColor = true;
            // 
            // ep
            // 
            ep.ContainerControl = this;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(297, 19);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 21;
            label1.Text = "Search";
            // 
            // cmsedit
            // 
            cmsedit.Name = "cmsedit";
            cmsedit.Size = new Size(180, 22);
            cmsedit.Text = "Status Change";
            cmsedit.Click += cmsedit_Click;
            // 
            // cmsOptions
            // 
            cmsOptions.Items.AddRange(new ToolStripItem[] { cmsedit });
            cmsOptions.Name = "cmsOptions";
            cmsOptions.Size = new Size(181, 48);
            // 
            // dgvTeacherSubjects
            // 
            dgvTeacherSubjects.AllowUserToAddRows = false;
            dgvTeacherSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeacherSubjects.ContextMenuStrip = cmsOptions;
            dgvTeacherSubjects.Location = new Point(297, 80);
            dgvTeacherSubjects.MultiSelect = false;
            dgvTeacherSubjects.Name = "dgvTeacherSubjects";
            dgvTeacherSubjects.ReadOnly = true;
            dgvTeacherSubjects.RowHeadersVisible = false;
            dgvTeacherSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeacherSubjects.Size = new Size(495, 358);
            dgvTeacherSubjects.TabIndex = 19;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(297, 45);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(495, 23);
            txtSearch.TabIndex = 20;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // frmProgramSemesterSubject
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(label1);
            Controls.Add(dgvTeacherSubjects);
            Controls.Add(txtSearch);
            Name = "frmProgramSemesterSubject";
            Text = "Program Semester Subject";
            Load += frmProgramSemesterSubject_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            cmsOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTeacherSubjects).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox5;
        private ComboBox cmbSubjects;
        private GroupBox groupBox2;
        private ComboBox cmbSemesters;
        private Button btnClear;
        private Button btnSave;
        private CheckBox chkStatus;
        private ErrorProvider ep;
        private Label label1;
        private DataGridView dgvTeacherSubjects;
        private ContextMenuStrip cmsOptions;
        private ToolStripMenuItem cmsedit;
        private TextBox txtSearch;
        private GroupBox groupBox3;
        private TextBox txtTitle;
    }
}