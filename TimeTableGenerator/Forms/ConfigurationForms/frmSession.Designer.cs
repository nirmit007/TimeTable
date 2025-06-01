namespace TimeTableGenerator.Forms.ConfigurationForms
{
    partial class frmSession
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
            groupBox2 = new GroupBox();
            txtSessionTitle = new MaskedTextBox();
            btnUpdate = new Button();
            btnCancel = new Button();
            btnClear = new Button();
            btnSave = new Button();
            chkStatus = new CheckBox();
            dgvSession = new DataGridView();
            cmsOptions = new ContextMenuStrip(components);
            cmsedit = new ToolStripMenuItem();
            txtSearch = new TextBox();
            label1 = new Label();
            ep = new ErrorProvider(components);
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSession).BeginInit();
            cmsOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ep).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(btnUpdate);
            groupBox1.Controls.Add(btnCancel);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(btnSave);
            groupBox1.Controls.Add(chkStatus);
            groupBox1.Location = new Point(5, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(282, 449);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Enter Session";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(txtSessionTitle);
            groupBox2.Location = new Point(12, 22);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(257, 65);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Session";
            // 
            // txtSessionTitle
            // 
            txtSessionTitle.BorderStyle = BorderStyle.None;
            txtSessionTitle.Font = new Font("Segoe UI", 16F);
            txtSessionTitle.Location = new Point(6, 22);
            txtSessionTitle.Mask = "0000-0000";
            txtSessionTitle.Name = "txtSessionTitle";
            txtSessionTitle.Size = new Size(245, 29);
            txtSessionTitle.TabIndex = 2;
            txtSessionTitle.MaskInputRejected += maskedTextBox1_MaskInputRejected;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Yellow;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Location = new Point(202, 203);
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
            btnCancel.Location = new Point(119, 203);
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
            btnClear.Location = new Point(119, 169);
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
            btnSave.Location = new Point(202, 169);
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
            chkStatus.Location = new Point(12, 117);
            chkStatus.Name = "chkStatus";
            chkStatus.Size = new Size(103, 19);
            chkStatus.TabIndex = 1;
            chkStatus.Text = "Session  Status";
            chkStatus.UseVisualStyleBackColor = true;
            // 
            // dgvSession
            // 
            dgvSession.AllowUserToAddRows = false;
            dgvSession.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSession.ContextMenuStrip = cmsOptions;
            dgvSession.Location = new Point(293, 81);
            dgvSession.MultiSelect = false;
            dgvSession.Name = "dgvSession";
            dgvSession.ReadOnly = true;
            dgvSession.RowHeadersVisible = false;
            dgvSession.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSession.Size = new Size(495, 357);
            dgvSession.TabIndex = 7;
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
            // txtSearch
            // 
            txtSearch.Location = new Point(294, 44);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(495, 23);
            txtSearch.TabIndex = 8;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(294, 18);
            label1.Name = "label1";
            label1.Size = new Size(42, 15);
            label1.TabIndex = 9;
            label1.Text = "Search";
            // 
            // ep
            // 
            ep.ContainerControl = this;
            // 
            // frmSession
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(txtSearch);
            Controls.Add(dgvSession);
            Controls.Add(groupBox1);
            Name = "frmSession";
            Text = "Session";
            Load += frmSession_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSession).EndInit();
            cmsOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)ep).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private CheckBox chkStatus;
        private Button btnClear;
        private Button btnSave;
        private MaskedTextBox txtSessionTitle;
        private Button btnCancel;
        private Button btnUpdate;
        private GroupBox groupBox2;
        private DataGridView dgvSession;
        private TextBox txtSearch;
        private Label label1;
        private ContextMenuStrip cmsOptions;
        private ToolStripMenuItem cmsedit;
        private ErrorProvider ep;
    }
}