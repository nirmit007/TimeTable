namespace TimeTableGenerator.Forms.ProgramSemesterForms
{
    partial class frmProgramSemesters
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
            groupBox4 = new GroupBox();
            cmbSelectSemester = new ComboBox();
            groupBox3 = new GroupBox();
            cmbSelectProgram = new ComboBox();
            groupBox2 = new GroupBox();
            txtSemesterTitle = new TextBox();
            btnUpdate = new Button();
            btnCancel = new Button();
            btnClear = new Button();
            btnSave = new Button();
            chkStatus = new CheckBox();
            dgvProgramSemesters = new DataGridView();
            cmsOptions = new ContextMenuStrip(components);
            cmsedit = new ToolStripMenuItem();
            label1 = new Label();
            txtSearch = new TextBox();
            ep = new ErrorProvider(components);
            groupBox5 = new GroupBox();
            txtCapacity = new TextBox();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProgramSemesters).BeginInit();
            cmsOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ep).BeginInit();
            groupBox5.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(chkStatus);
            groupBox1.Location = new Point(8, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(282, 449);
            groupBox1.TabIndex = 34;
            groupBox1.TabStop = false;
            groupBox1.Text = "Enter Program Details";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(cmbSelectSemester);
            groupBox4.Location = new Point(12, 164);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(257, 65);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Select Semester";
            // 
            // cmbSelectSemester
            // 
            cmbSelectSemester.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectSemester.Font = new Font("Segoe UI", 12F);
            cmbSelectSemester.FormattingEnabled = true;
            cmbSelectSemester.Location = new Point(11, 19);
            cmbSelectSemester.Name = "cmbSelectSemester";
            cmbSelectSemester.Size = new Size(240, 29);
            cmbSelectSemester.TabIndex = 0;
            cmbSelectSemester.SelectedIndexChanged += cmbSelectSemester_SelectedIndexChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cmbSelectProgram);
            groupBox3.Location = new Point(12, 93);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(257, 65);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Select Program";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // cmbSelectProgram
            // 
            cmbSelectProgram.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectProgram.Font = new Font("Segoe UI", 12F);
            cmbSelectProgram.FormattingEnabled = true;
            cmbSelectProgram.Location = new Point(11, 19);
            cmbSelectProgram.Name = "cmbSelectProgram";
            cmbSelectProgram.Size = new Size(240, 29);
            cmbSelectProgram.TabIndex = 0;
            cmbSelectProgram.SelectedIndexChanged += cmbSelectProgram_SelectedIndexChanged;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSemesterTitle);
            groupBox2.Location = new Point(12, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(257, 65);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Semester";
            // 
            // txtSemesterTitle
            // 
            txtSemesterTitle.Font = new Font("Segoe UI", 12F);
            txtSemesterTitle.Location = new Point(11, 22);
            txtSemesterTitle.Name = "txtSemesterTitle";
            txtSemesterTitle.ReadOnly = true;
            txtSemesterTitle.Size = new Size(240, 29);
            txtSemesterTitle.TabIndex = 0;
            txtSemesterTitle.TextChanged += txtLecturer_TextChanged;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Yellow;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(202, 397);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(64, 28);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(119, 397);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(64, 28);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(0, 192, 192);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(119, 363);
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
            btnSave.Location = new Point(202, 363);
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
            chkStatus.Location = new Point(12, 311);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(158, 19);
            chkStatus.TabIndex = 1;
            chkStatus.Text = "Program Semester Status";
            chkStatus.UseVisualStyleBackColor = true;
            chkStatus.CheckedChanged += chkStatus_CheckedChanged;
            // 
            // dgvProgramSemesters
            // 
            dgvProgramSemesters.AllowUserToAddRows = false;
            dgvProgramSemesters.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProgramSemesters.ContextMenuStrip = cmsOptions;
            dgvProgramSemesters.Location = new Point(296, 82);
            dgvProgramSemesters.MultiSelect = false;
            dgvProgramSemesters.Name = "dgvProgramSemesters";
            dgvProgramSemesters.ReadOnly = true;
            dgvProgramSemesters.RowHeadersVisible = false;
            dgvProgramSemesters.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProgramSemesters.Size = new Size(495, 357);
            dgvProgramSemesters.TabIndex = 35;
            // 
            // cmsOptions
            // 
            cmsOptions.Items.AddRange(new ToolStripItem[] { cmsedit });
            cmsOptions.Name = "cmsOptions";
            cmsOptions.Size = new Size(95, 26);
            // 
            // cmsedit
            // 
            cmsedit.Name = "cmsedit";
            cmsedit.Size = new Size(94, 22);
            cmsedit.Text = "Edit";
            cmsedit.Click += cmsedit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(297, 19);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 37;
            label1.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(297, 45);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(495, 23);
            txtSearch.TabIndex = 36;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // ep
            // 
            ep.ContainerControl = this;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(txtCapacity);
            groupBox5.Location = new Point(12, 235);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(257, 65);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "Enter Capacity";
            // 
            // txtCapacity
            // 
            txtCapacity.Font = new Font("Segoe UI", 12F);
            txtCapacity.Location = new Point(11, 22);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(240, 29);
            txtCapacity.TabIndex = 0;
            // 
            // frmProgramSemesters
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(dgvProgramSemesters);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Name = "frmProgramSemesters";
            Text = "Program Semester Details";
            Load += frmProgramSemesters_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProgramSemesters).EndInit();
            cmsOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox2;
        private TextBox txtSemesterTitle;
        private Button btnUpdate;
        private Button btnCancel;
        private Button btnClear;
        private Button btnSave;
        private CheckBox chkStatus;
        private DataGridView dgvProgramSemesters;
        private ContextMenuStrip cmsOptions;
        private ToolStripMenuItem cmsedit;
        private Label label1;
        private TextBox txtSearch;
        private ErrorProvider ep;
        private ComboBox cmbSelectProgram;
        private GroupBox groupBox4;
        private ComboBox cmbSelectSemester;
        private GroupBox groupBox5;
        private TextBox txtCapacity;
    }
}