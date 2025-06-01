namespace TimeTableGenerator.Forms.ProgramSemesterForms
{
    partial class frmSemesterSections
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
            txtCapacity = new TextBox();
            label1 = new Label();
            groupBox4 = new GroupBox();
            cmbSemesters = new ComboBox();
            cmsedit = new ToolStripMenuItem();
            cmsOptions = new ContextMenuStrip(components);
            groupBox2 = new GroupBox();
            txtTitle = new TextBox();
            dgvSections = new DataGridView();
            btnUpdate = new Button();
            btnCancel = new Button();
            btnClear = new Button();
            btnSave = new Button();
            groupBox1 = new GroupBox();
            txtSearch = new TextBox();
            deleteToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)ep).BeginInit();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            cmsOptions.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSections).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // ep
            // 
            ep.ContainerControl = this;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(txtCapacity);
            groupBox5.Location = new Point(12, 164);
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
            txtCapacity.TextChanged += txtCapacity_TextChanged;
            txtCapacity.KeyPress += txtCapacity_KeyPress;
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
            // groupBox4
            // 
            groupBox4.Controls.Add(cmbSemesters);
            groupBox4.Location = new Point(12, 93);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(257, 65);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "Select Semester";
            // 
            // cmbSemesters
            // 
            cmbSemesters.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSemesters.Font = new Font("Segoe UI", 12F);
            cmbSemesters.FormattingEnabled = true;
            cmbSemesters.Location = new Point(11, 19);
            cmbSemesters.Name = "cmbSemesters";
            cmbSemesters.Size = new Size(240, 29);
            cmbSemesters.TabIndex = 0;
            // 
            // cmsedit
            // 
            cmsedit.Name = "cmsedit";
            cmsedit.Size = new Size(180, 22);
            cmsedit.Text = "Edit";
            cmsedit.Click += cmsedit_Click;
            // 
            // cmsOptions
            // 
            cmsOptions.Items.AddRange(new ToolStripItem[] { cmsedit, deleteToolStripMenuItem });
            cmsOptions.Name = "cmsOptions";
            cmsOptions.Size = new Size(181, 70);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtTitle);
            groupBox2.Location = new Point(12, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(257, 65);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Section Title";
            // 
            // txtTitle
            // 
            txtTitle.Font = new Font("Segoe UI", 12F);
            txtTitle.Location = new Point(11, 22);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(240, 29);
            txtTitle.TabIndex = 0;
            // 
            // dgvSections
            // 
            dgvSections.AllowUserToAddRows = false;
            dgvSections.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSections.ContextMenuStrip = cmsOptions;
            dgvSections.Location = new Point(296, 82);
            dgvSections.MultiSelect = false;
            dgvSections.Name = "dgvSections";
            dgvSections.ReadOnly = true;
            dgvSections.RowHeadersVisible = false;
            dgvSections.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSections.Size = new Size(495, 357);
            dgvSections.TabIndex = 39;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Yellow;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(206, 295);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(64, 28);
            btnUpdate.TabIndex = 6;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Visible = false;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(123, 295);
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
            btnClear.Location = new Point(123, 261);
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
            btnSave.Location = new Point(206, 261);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(64, 28);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(groupBox4);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Location = new Point(8, 1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(282, 449);
            groupBox1.TabIndex = 38;
            groupBox1.TabStop = false;
            groupBox1.Text = "Semester Section Details";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(297, 45);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(495, 23);
            txtSearch.TabIndex = 40;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // deleteToolStripMenuItem
            // 
            deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            deleteToolStripMenuItem.Size = new Size(180, 22);
            deleteToolStripMenuItem.Text = "Delete";
            deleteToolStripMenuItem.Click += deleteToolStripMenuItem_Click;
            // 
            // frmSemesterSections
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(dgvSections);
            Controls.Add(groupBox1);
            Controls.Add(txtSearch);
            Name = "frmSemesterSections";
            Text = "Semester Sections";
            Load += frmSemesterSections_Load;
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            cmsOptions.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSections).EndInit();
            groupBox1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ErrorProvider ep;
        private Label label1;
        private DataGridView dgvSections;
        private ContextMenuStrip cmsOptions;
        private ToolStripMenuItem cmsedit;
        private GroupBox groupBox1;
        private GroupBox groupBox5;
        private TextBox txtCapacity;
        private GroupBox groupBox4;
        private ComboBox cmbSemesters;
        private GroupBox groupBox2;
        private TextBox txtTitle;
        private Button btnUpdate;
        private Button btnCancel;
        private Button btnClear;
        private Button btnSave;
        private TextBox txtSearch;
        private ToolStripMenuItem deleteToolStripMenuItem;
    }
}