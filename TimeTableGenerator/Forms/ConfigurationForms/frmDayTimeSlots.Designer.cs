namespace TimeTableGenerator.Forms.ConfigurationForms
{
    partial class frmDayTimeSlots
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
            groupBox5 = new GroupBox();
            cmbNumberofTimeSlot = new ComboBox();
            groupBox4 = new GroupBox();
            dtpEndTime = new DateTimePicker();
            groupBox3 = new GroupBox();
            dtpStartTime = new DateTimePicker();
            groupBox2 = new GroupBox();
            cmbDays = new ComboBox();
            btnUpdate = new Button();
            btnCancel = new Button();
            btnClear = new Button();
            btnSave = new Button();
            chkStatus = new CheckBox();
            dgvSlots = new DataGridView();
            cmsOptions = new ContextMenuStrip(components);
            cmsedit = new ToolStripMenuItem();
            label1 = new Label();
            txtSearch = new TextBox();
            ep = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSlots).BeginInit();
            cmsOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ep).BeginInit();
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
            groupBox1.Location = new Point(8, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(282, 438);
            groupBox1.TabIndex = 10;
            groupBox1.TabStop = false;
            groupBox1.Text = "Time Slots";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(cmbNumberofTimeSlot);
            groupBox5.Location = new Point(12, 235);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(257, 65);
            groupBox5.TabIndex = 9;
            groupBox5.TabStop = false;
            groupBox5.Text = "Number of Time Slot";
            // 
            // cmbNumberofTimeSlot
            // 
            cmbNumberofTimeSlot.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNumberofTimeSlot.Font = new Font("Segoe UI", 12F);
            cmbNumberofTimeSlot.FormattingEnabled = true;
            cmbNumberofTimeSlot.Location = new Point(6, 22);
            cmbNumberofTimeSlot.Name = "cmbNumberofTimeSlot";
            cmbNumberofTimeSlot.Size = new Size(240, 29);
            cmbNumberofTimeSlot.TabIndex = 2;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(dtpEndTime);
            groupBox4.Location = new Point(12, 164);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(257, 65);
            groupBox4.TabIndex = 8;
            groupBox4.TabStop = false;
            groupBox4.Text = "End Time";
            // 
            // dtpEndTime
            // 
            dtpEndTime.CustomFormat = "hh:mm tt";
            dtpEndTime.Format = DateTimePickerFormat.Custom;
            dtpEndTime.Location = new Point(6, 23);
            dtpEndTime.Name = "dtpEndTime";
            dtpEndTime.ShowUpDown = true;
            dtpEndTime.Size = new Size(200, 23);
            dtpEndTime.TabIndex = 7;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(dtpStartTime);
            groupBox3.Location = new Point(12, 93);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(257, 65);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Start Time";
            // 
            // dtpStartTime
            // 
            dtpStartTime.CustomFormat = "hh:mm tt";
            dtpStartTime.Format = DateTimePickerFormat.Custom;
            dtpStartTime.Location = new Point(6, 23);
            dtpStartTime.Name = "dtpStartTime";
            dtpStartTime.ShowUpDown = true;
            dtpStartTime.Size = new Size(200, 23);
            dtpStartTime.TabIndex = 7;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(cmbDays);
            groupBox2.Location = new Point(12, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(257, 65);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Select Day";
            // 
            // cmbDays
            // 
            cmbDays.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbDays.Font = new Font("Segoe UI", 12F);
            cmbDays.FormattingEnabled = true;
            cmbDays.Location = new Point(6, 23);
            cmbDays.Name = "cmbDays";
            cmbDays.Size = new Size(240, 29);
            cmbDays.TabIndex = 1;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Yellow;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(208, 402);
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
            btnCancel.Location = new Point(125, 402);
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
            btnClear.Location = new Point(125, 368);
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
            btnSave.Location = new Point(208, 368);
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
            chkStatus.Location = new Point(18, 316);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(103, 19);
            chkStatus.TabIndex = 1;
            chkStatus.Text = "Session  Status";
            chkStatus.UseVisualStyleBackColor = true;
            // 
            // dgvSlots
            // 
            dgvSlots.AllowUserToAddRows = false;
            dgvSlots.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSlots.ContextMenuStrip = cmsOptions;
            dgvSlots.Location = new Point(297, 81);
            dgvSlots.MultiSelect = false;
            dgvSlots.Name = "dgvSlots";
            dgvSlots.ReadOnly = true;
            dgvSlots.RowHeadersVisible = false;
            dgvSlots.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSlots.Size = new Size(495, 357);
            dgvSlots.TabIndex = 11;
            // 
            // cmsOptions
            // 
            cmsOptions.Items.AddRange(new ToolStripItem[] { cmsedit });
            cmsOptions.Name = "cmsOptions";
            cmsOptions.Size = new Size(134, 26);
            cmsOptions.Opening += cmsOptions_Opening;
            // 
            // cmsedit
            // 
            cmsedit.Name = "cmsedit";
            cmsedit.Size = new Size(133, 22);
            cmsedit.Text = "Break Time";
            cmsedit.Click += cmsedit_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(297, 19);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 13;
            label1.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(297, 45);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(495, 23);
            txtSearch.TabIndex = 12;
            // 
            // ep
            // 
            ep.ContainerControl = this;
            // 
            // frmDayTimeSlots
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(dgvSlots);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Name = "frmDayTimeSlots";
            Text = "frmDayTimeSlots";
            Load += frmDayTimeSlots_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSlots).EndInit();
            cmsOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnUpdate;
        private Button btnCancel;
        private Button btnClear;
        private Button btnSave;
        private CheckBox chkStatus;
        private DataGridView dgvSlots;
        private ContextMenuStrip cmsOptions;
        private ToolStripMenuItem cmsedit;
        private Label label1;
        private TextBox txtSearch;
        private ErrorProvider ep;
        private GroupBox groupBox4;
        private DateTimePicker dtpEndTime;
        private GroupBox groupBox3;
        private DateTimePicker dtpStartTime;
        private ComboBox cmbDays;
        private GroupBox groupBox5;
        private ComboBox cmbNumberofTimeSlot;
    }
}