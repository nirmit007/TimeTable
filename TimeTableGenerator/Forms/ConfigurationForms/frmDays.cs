using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TimeTableGenerator.Forms.ConfigurationForms
{
    public partial class frmDays : Form
    {
        public frmDays()
        {
            InitializeComponent();
        }

        public void FillGrid(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchvalue.Trim()))
                {
                    query = "select DayID[ID], Name [Day], isActive [Status] from DayTable";

                }
                else
                {
                    query = "select DayID[ID], Name [Day],  isActive [Status] from DayTable where Name like '%" + searchvalue.Trim() + "%'";
                }

                DataTable daylist = DatabaseLayer.Retrive(query);
                dgvDay.DataSource = daylist;
                if (dgvDay.Rows.Count > 0)
                {
                    dgvDay.Columns[0].Width = 80;
                    dgvDay.Columns[1].Width = 150;
                    dgvDay.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }
            }
            catch
            {

                MessageBox.Show("Unexpexted error!!!");
            }
        }
        private void frmDays_Load(object sender, EventArgs e)
        {
            FillGrid(string.Empty);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FillGrid(txtSearch.Text.Trim());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtDayName.Text.Trim().Length == 0)
            {
                ep.SetError(txtDayName, "Length is long");
                txtDayName.Focus();
                txtDayName.SelectAll();
                return;
            }

            DataTable checktitle = DatabaseLayer.Retrive("select * from DayTable where Name = '" + txtDayName.Text.Trim() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    ep.SetError(txtDayName, "Already Exist");
                    txtDayName.Focus();
                    txtDayName.SelectAll();
                    return;
                }
            }

            string insertquery = string.Format("insert into DayTable(Name, isActive) values('{0}', '{1}')",
                                txtDayName.Text.Trim(), chkStatus.Checked);
            bool result = DatabaseLayer.Insert(insertquery);
            if (result == true)
            {
                MessageBox.Show("Save Successfully!");
                DisableComponents();
            }
            else
            {
                MessageBox.Show("Please Provide the Correct Semester Details");
            }
        }

        public void EnableComponents()
        {
            dgvDay.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSearch.Visible = false;

        }

        public void DisableComponents()
        {
            dgvDay.Enabled = true;
            btnClear.Visible = true;
            btnSave.Visible = true;
            btnCancel.Visible = false;
            btnUpdate.Visible = false;
            txtSearch.Visible = true;
            FillGrid(String.Empty);
            ClearForm();

        }

        public void ClearForm()
        {
            txtDayName.Clear();
            chkStatus.Checked = false;
            FillGrid(string.Empty);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void cmsedit_Click(object sender, EventArgs e)
        {
            if (dgvDay != null)
            {
                if (dgvDay.Rows.Count > 0)
                {
                    if (dgvDay.SelectedRows.Count == 1)
                    {
                        txtDayName.Text = Convert.ToString(dgvDay.CurrentRow.Cells[1].Value);
                        chkStatus.Checked = Convert.ToBoolean(dgvDay.CurrentRow.Cells[2].Value);
                        EnableComponents();
                    }
                    else
                    {
                        MessageBox.Show("PLease Select one!!");
                    }
                }
                else
                {
                    MessageBox.Show("List is empty");
                }

            }
            else
            {
                MessageBox.Show("List is empty");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtDayName.Text.Trim().Length == 0)
            {
                ep.SetError(txtDayName, "Length is long");
                txtDayName.Focus();
                txtDayName.SelectAll();
                return;
            }

            DataTable checktitle = DatabaseLayer.Retrive("select * from DayTable where Name = '" + txtDayName.Text.Trim() + "' and DayID != '" + Convert.ToString(dgvDay.CurrentRow.Cells[0].Value) + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    ep.SetError(txtDayName, "Already Exist");
                    txtDayName.Focus();
                    txtDayName.SelectAll();
                    return;
                }
            }

            string updatequery = string.Format("update DayTable set Name = '{0}', isActive = '{1}' where DayID = '{2}'", txtDayName.Text.Trim(), chkStatus.Checked, Convert.ToString(dgvDay.CurrentRow.Cells[0].Value));
            bool result = DatabaseLayer.Update(updatequery);
            if (result == true)
            {
                MessageBox.Show("Updated Successfully!");
                DisableComponents();
            }
            else
            {
                MessageBox.Show("Please Provide the Correct Semester Details");
            }
        }
    }
}
