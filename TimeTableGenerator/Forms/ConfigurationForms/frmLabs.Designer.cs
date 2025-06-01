namespace TimeTableGenerator.Forms.ConfigurationForms
{
    partial class frmLabs
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
            txtCapacity = new TextBox();
            groupBox2 = new GroupBox();
            txtLabNo = new TextBox();
            btnUpdate = new Button();
            btnCancel = new Button();
            btnClear = new Button();
            btnSave = new Button();
            chkStatus = new CheckBox();
            dgvLabs = new DataGridView();
            cmsOptions = new ContextMenuStrip(components);
            cmsedit = new ToolStripMenuItem();
            label1 = new Label();
            txtSearch = new TextBox();
            ep = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLabs).BeginInit();
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
            groupBox1.TabIndex = 26;
            groupBox1.TabStop = false;
            groupBox1.Text = "Enter Lab Details";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(txtCapacity);
            groupBox3.Location = new Point(12, 93);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(257, 65);
            groupBox3.TabIndex = 7;
            groupBox3.TabStop = false;
            groupBox3.Text = "Lab Capacity";
            // 
            // txtCapacity
            // 
            txtCapacity.Font = new Font("Segoe UI", 12F);
            txtCapacity.Location = new Point(11, 22);
            txtCapacity.Name = "txtCapacity";
            txtCapacity.Size = new Size(240, 29);
            txtCapacity.TabIndex = 0;
            txtCapacity.KeyPress += txtCapacity_KeyPress;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtLabNo);
            groupBox2.Location = new Point(12, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(257, 65);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Lab Number";
            // 
            // txtLabNo
            // 
            txtLabNo.Font = new Font("Segoe UI", 12F);
            txtLabNo.Location = new Point(11, 22);
            txtLabNo.Name = "txtLabNo";
            txtLabNo.Size = new Size(240, 29);
            txtLabNo.TabIndex = 0;
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
            chkStatus.Size = new Size(80, 19);
            chkStatus.TabIndex = 1;
            chkStatus.Text = "Lab Status";
            chkStatus.UseVisualStyleBackColor = true;
            // 
            // dgvLabs
            // 
            dgvLabs.AllowUserToAddRows = false;
            dgvLabs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLabs.ContextMenuStrip = cmsOptions;
            dgvLabs.Location = new Point(296, 82);
            dgvLabs.MultiSelect = false;
            dgvLabs.Name = "dgvLabs";
            dgvLabs.ReadOnly = true;
            dgvLabs.RowHeadersVisible = false;
            dgvLabs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLabs.Size = new Size(495, 357);
            dgvLabs.TabIndex = 27;
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
            label1.TabIndex = 29;
            label1.Text = "Search";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(297, 45);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(495, 23);
            txtSearch.TabIndex = 28;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // ep
            // 
            ep.ContainerControl = this;
            // 
            // frmLabs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(groupBox1);
            Controls.Add(dgvLabs);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Name = "frmLabs";
            Text = "frmLabs";
            Load += frmLabs_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLabs).EndInit();
            cmsOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private TextBox txtCapacity;
        private GroupBox groupBox2;
        private TextBox txtLabNo;
        private Button btnUpdate;
        private Button btnCancel;
        private Button btnClear;
        private Button btnSave;
        private CheckBox chkStatus;
        private DataGridView dgvLabs;
        private ContextMenuStrip cmsOptions;
        private ToolStripMenuItem cmsedit;
        private Label label1;
        private TextBox txtSearch;
        private ErrorProvider ep;
    }
}