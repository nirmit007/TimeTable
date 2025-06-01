namespace TimeTableGenerator.Forms.ConfigurationForms
{
    partial class frmCourses
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
            groupBox4 = new GroupBox();
            cmbCrHrs = new ComboBox();
            label1 = new Label();
            groupBox3 = new GroupBox();
            cmbSelectType = new ComboBox();
            cmsedit = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            txtsibjectTitle = new TextBox();
            cmsOptions = new ContextMenuStrip(components);
            btnUpdate = new Button();
            dgvCourses = new DataGridView();
            btnCancel = new Button();
            btnSave = new Button();
            chkStatus = new CheckBox();
            txtSearch = new TextBox();
            btnClear = new Button();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)ep).BeginInit();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            cmsOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCourses).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // ep
            // 
            ep.ContainerControl = this;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(cmbCrHrs);
            groupBox4.Location = new Point(9, 182);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(257, 65);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Select Course Hours / Week";
            groupBox4.Enter += groupBox4_Enter;
            // 
            // cmbCrHrs
            // 
            cmbCrHrs.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCrHrs.Font = new Font("Segoe UI", 12F);
            cmbCrHrs.FormattingEnabled = true;
            cmbCrHrs.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            cmbCrHrs.Location = new Point(8, 18);
            cmbCrHrs.Name = "cmbCrHrs";
            cmbCrHrs.Size = new Size(240, 29);
            cmbCrHrs.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(297, 19);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 41;
            label1.Text = "Search";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(cmbSelectType);
            groupBox3.Location = new Point(9, 111);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(257, 65);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Select Room/Lab";
            // 
            // cmbSelectType
            // 
            cmbSelectType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelectType.Font = new Font("Segoe UI", 12F);
            cmbSelectType.FormattingEnabled = true;
            cmbSelectType.Location = new Point(11, 19);
            cmbSelectType.Name = "cmbSelectType";
            cmbSelectType.Size = new Size(240, 29);
            cmbSelectType.TabIndex = 0;
            // 
            // cmsedit
            // 
            cmsedit.Name = "cmsedit";
            cmsedit.Size = new Size(94, 22);
            cmsedit.Text = "Edit";
            cmsedit.Click += cmsedit_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtsibjectTitle);
            groupBox2.Location = new Point(9, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(257, 83);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Subjects";
            // 
            // txtsibjectTitle
            // 
            txtsibjectTitle.Font = new Font("Segoe UI", 12F);
            txtsibjectTitle.Location = new Point(11, 22);
            txtsibjectTitle.Multiline = true;
            txtsibjectTitle.Name = "txtsibjectTitle";
            txtsibjectTitle.Size = new Size(240, 55);
            txtsibjectTitle.TabIndex = 0;
            txtsibjectTitle.TextChanged += txtLecturer_TextChanged;
            // 
            // cmsOptions
            // 
            cmsOptions.Items.AddRange(new ToolStripItem[] { cmsedit });
            cmsOptions.Name = "cmsOptions";
            cmsOptions.Size = new Size(95, 26);
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Yellow;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(199, 339);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(64, 28);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // dgvCourses
            // 
            dgvCourses.AllowUserToAddRows = false;
            dgvCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCourses.ContextMenuStrip = cmsOptions;
            dgvCourses.Location = new Point(296, 82);
            dgvCourses.MultiSelect = false;
            dgvCourses.Name = "dgvCourses";
            dgvCourses.ReadOnly = true;
            dgvCourses.RowHeadersVisible = false;
            dgvCourses.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCourses.Size = new Size(495, 357);
            dgvCourses.TabIndex = 39;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(116, 339);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(64, 28);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Visible = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Lime;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(199, 305);
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
            chkStatus.Location = new Point(9, 253);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(100, 19);
            chkStatus.TabIndex = 1;
            chkStatus.Text = "Subject Status";
            chkStatus.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(297, 45);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(495, 23);
            txtSearch.TabIndex = 40;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(0, 192, 192);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Location = new Point(116, 305);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(64, 28);
            btnClear.TabIndex = 4;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // groupBox1
            // 
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
            groupBox1.TabIndex = 38;
            groupBox1.TabStop = false;
            groupBox1.Text = "Enter Course Details";
            // 
            // frmCourses
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dgvCourses);
            Controls.Add(txtSearch);
            Controls.Add(groupBox1);
            Name = "frmCourses";
            Text = "Courses";
            Load += frmCourses_Load;
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            cmsOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvCourses).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ErrorProvider ep;
        private Label label1;
        private DataGridView dgvCourses;
        private ContextMenuStrip cmsOptions;
        private ToolStripMenuItem cmsedit;
        private TextBox txtSearch;
        private GroupBox groupBox1;
        private GroupBox groupBox4;
        private GroupBox groupBox3;
        private ComboBox cmbSelectType;
        private GroupBox groupBox2;
        private TextBox txtsibjectTitle;
        private Button btnUpdate;
        private Button btnCancel;
        private Button btnClear;
        private Button btnSave;
        private CheckBox chkStatus;
        private ComboBox cmbCrHrs;
    }
}