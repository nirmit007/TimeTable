namespace TimeTableGenerator.Forms.ConfigurationForms
{
    partial class frmLectures
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
            txtContactNo = new MaskedTextBox();
            groupBox2 = new GroupBox();
            txtLecturer = new TextBox();
            btnUpdate = new Button();
            btnCancel = new Button();
            btnClear = new Button();
            btnSave = new Button();
            chkStatus = new CheckBox();
            dgvLecturer = new DataGridView();
            cmsOptions = new ContextMenuStrip(components);
            cmsedit = new ToolStripMenuItem();
            label1 = new Label();
            txtSearch = new TextBox();
            ep = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLecturer).BeginInit();
            cmsOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ep).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
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
            groupBox1.TabIndex = 30;
            groupBox1.TabStop = false;
            groupBox1.Text = "Enter Lecturer Details";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtContactNo);
            groupBox3.Location = new Point(12, 93);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(257, 65);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Contact Number";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // txtContactNo
            // 
            txtContactNo.Font = new Font("Segoe UI", 12F);
            txtContactNo.Location = new Point(11, 22);
            txtContactNo.Mask = "0000000000";
            txtContactNo.Name = "txtContactNo";
            txtContactNo.Size = new Size(240, 29);
            txtContactNo.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtLecturer);
            groupBox2.Location = new Point(12, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(257, 65);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lecturer Name";
            // 
            // txtLecturer
            // 
            txtLecturer.Font = new Font("Segoe UI", 12F);
            txtLecturer.Location = new Point(11, 22);
            txtLecturer.Name = "txtLecturer";
            txtLecturer.Size = new Size(240, 29);
            txtLecturer.TabIndex = 0;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Yellow;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(202, 271);
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
            btnCancel.Location = new Point(119, 271);
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
            btnClear.Location = new Point(119, 237);
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
            btnSave.Location = new Point(202, 237);
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
            chkStatus.Location = new Point(12, 185);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(104, 19);
            chkStatus.TabIndex = 1;
            chkStatus.Text = "Lecturer Status";
            chkStatus.UseVisualStyleBackColor = true;
            // 
            // dgvLecturer
            // 
            dgvLecturer.AllowUserToAddRows = false;
            dgvLecturer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLecturer.ContextMenuStrip = cmsOptions;
            dgvLecturer.Location = new Point(296, 82);
            dgvLecturer.MultiSelect = false;
            dgvLecturer.Name = "dgvLecturer";
            dgvLecturer.ReadOnly = true;
            dgvLecturer.RowHeadersVisible = false;
            dgvLecturer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLecturer.Size = new Size(495, 357);
            dgvLecturer.TabIndex = 31;
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
            label1.TabIndex = 33;
            label1.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(297, 45);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(495, 23);
            txtSearch.TabIndex = 32;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // ep
            // 
            ep.ContainerControl = this;
            // 
            // frmLectures
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(dgvLecturer);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Name = "frmLectures";
            Text = " Lectures";
            Load += frmLectures_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLecturer).EndInit();
            cmsOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private MaskedTextBox txtContactNo;
        private GroupBox groupBox2;
        private TextBox txtLecturer;
        private Button btnUpdate;
        private Button btnCancel;
        private Button btnClear;
        private Button btnSave;
        private CheckBox chkStatus;
        private DataGridView dgvLecturer;
        private ContextMenuStrip cmsOptions;
        private ToolStripMenuItem cmsedit;
        private Label label1;
        private TextBox txtSearch;
        private ErrorProvider ep;
    }
}