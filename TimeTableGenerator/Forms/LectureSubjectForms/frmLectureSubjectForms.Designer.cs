namespace TimeTableGenerator.Forms.LectureSubjectForms
{
    partial class frmLectureSubjectForms
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
            ep = new ErrorProvider(components);
            groupBox5 = new GroupBox();
            cmbSubjects = new ComboBox();
            label1 = new Label();
            cmsedit = new ToolStripMenuItem();
            cmsOptions = new ContextMenuStrip(components);
            groupBox2 = new GroupBox();
            cmbTeachers = new ComboBox();
            dgvTeacherSubjects = new DataGridView();
            btnClear = new Button();
            btnSave = new Button();
            chkStatus = new CheckBox();
            groupBox1 = new GroupBox();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ep).BeginInit();
            groupBox5.SuspendLayout();
            cmsOptions.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTeacherSubjects).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // ep
            // 
            ep.ContainerControl = this;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(cmbSubjects);
            groupBox5.Location = new Point(12, 93);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(257, 65);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "Number of Time Slot";
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
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(301, 19);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 17;
            label1.Text = "Search";
            // 
            // cmsedit
            // 
            cmsedit.Name = "cmsedit";
            cmsedit.Size = new Size(150, 22);
            cmsedit.Text = "Status Change";
            cmsedit.Click += cmsedit_Click;
            // 
            // cmsOptions
            // 
            cmsOptions.Items.AddRange(new ToolStripItem[] { cmsedit });
            cmsOptions.Name = "cmsOptions";
            cmsOptions.Size = new Size(151, 26);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbTeachers);
            groupBox2.Location = new Point(12, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(257, 65);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Select Lecturer";
            // 
            // cmbTeachers
            // 
            cmbTeachers.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTeachers.Font = new Font("Segoe UI", 12F);
            cmbTeachers.FormattingEnabled = true;
            cmbTeachers.Location = new Point(6, 23);
            cmbTeachers.Name = "cmbTeachers";
            cmbTeachers.Size = new Size(240, 29);
            cmbTeachers.TabIndex = 1;
            // 
            // dgvTeacherSubjects
            // 
            dgvTeacherSubjects.AllowUserToAddRows = false;
            dgvTeacherSubjects.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTeacherSubjects.ContextMenuStrip = cmsOptions;
            dgvTeacherSubjects.Location = new Point(301, 80);
            dgvTeacherSubjects.MultiSelect = false;
            dgvTeacherSubjects.Name = "dgvTeacherSubjects";
            dgvTeacherSubjects.ReadOnly = true;
            dgvTeacherSubjects.RowHeadersVisible = false;
            dgvTeacherSubjects.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTeacherSubjects.Size = new Size(495, 358);
            dgvTeacherSubjects.TabIndex = 15;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(0, 192, 192);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(119, 238);
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
            btnSave.Location = new Point(202, 238);
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
            chkStatus.Location = new Point(12, 186);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(61, 19);
            chkStatus.TabIndex = 1;
            chkStatus.Text = " Status";
            chkStatus.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(chkStatus);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(282, 426);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Lecturer and Subject";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(301, 45);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(495, 23);
            txtSearch.TabIndex = 16;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // frmLectureSubjectForms
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dgvTeacherSubjects);
            Controls.Add(groupBox1);
            Controls.Add(txtSearch);
            Name = "frmLectureSubjectForms";
            Text = "Lecture Subjects";
            Load += frmLectureSubjectForms_Load;
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            groupBox5.ResumeLayout(false);
            cmsOptions.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTeacherSubjects).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ErrorProvider ep;
        private Label label1;
        private DataGridView dgvTeacherSubjects;
        private ContextMenuStrip cmsOptions;
        private ToolStripMenuItem cmsedit;
        private GroupBox groupBox1;
        private GroupBox groupBox5;
        private ComboBox cmbSubjects;
        private GroupBox groupBox2;
        private ComboBox cmbTeachers;
        private Button btnUpdate;
        private Button btnCancel;
        private Button btnClear;
        private Button btnSave;
        private CheckBox chkStatus;
        private TextBox txtSearch;
    }
}