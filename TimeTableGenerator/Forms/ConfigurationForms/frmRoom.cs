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
    public partial class frmRoom : Form
    {
        public frmRoom()
        {
            InitializeComponent();
        }

        private void textCapacity_TextChanged(object sender, EventArgs e)
        {

        }

        private void textCapacity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void FillGrid(string searchvalue)
        {
            try
            {
                string query = string.Empty;
                if (string.IsNullOrEmpty(searchvalue.Trim()))
                {
                    query = "select RoomID[ID], RoomNo[Room], Capacity, isActive [Status] from RoomTable";

                }
                else
                {
                    query = "select RoomID[ID], RoomNo [Room],  Capacity, isActive [Status] from RoomTable where RoomNo like '%" + searchvalue.Trim() + "%'";
                }

                DataTable roomlist = DatabaseLayer.Retrive(query);
                dgvRooms.DataSource = roomlist;
                if (dgvRooms.Rows.Count > 0)
                {
                    dgvRooms.Columns[0].Width = 80;
                    dgvRooms.Columns[1].Width = 150;
                    dgvRooms.Columns[2].Width = 100;
                    dgvRooms.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                }
            }
            catch
            {

                MessageBox.Show("Unexpexted error!!!");
            }
        }

        private void frmRoom_Load(object sender, EventArgs e)
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
            if (txtRoomNo.Text.Trim().Length == 0 || txtRoomNo.Text.Length > 10)
            {
                ep.SetError(txtRoomNo, "Please Enter Valid Room No/Name !!");
                txtRoomNo.Focus();
                txtRoomNo.SelectAll();
                return;
            }

            if (txtCapacity.Text.Trim().Length == 0)
            {
                ep.SetError(txtCapacity, "Invalid Capacity!!");
                txtCapacity.Focus();
                txtCapacity.SelectAll();
                return;
            }

            DataTable checktitle = DatabaseLayer.Retrive("select * from RoomTable where RoomNo = '" + txtRoomNo.Text.Trim() + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    ep.SetError(txtRoomNo, "Already Exist");
                    txtRoomNo.Focus();
                    txtRoomNo.SelectAll();
                    return;
                }
            }

            string insertquery = string.Format("insert into RoomTable(RoomNo, Capacity, isActive) values('{0}', '{1}', '{2}')",
                                txtRoomNo.Text.Trim(), txtCapacity.Text.Trim(), chkStatus.Checked);
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
            dgvRooms.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSearch.Visible = false;

        }

        public void DisableComponents()
        {
            dgvRooms.Enabled = true;
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
            txtRoomNo.Clear();
            txtCapacity.Clear();
            chkStatus.Checked = false;
            FillGrid(string.Empty);
        }

        private void cmsedit_Click(object sender, EventArgs e)
        {
            if (dgvRooms != null)
            {
                if (dgvRooms.Rows.Count > 0)
                {
                    if (dgvRooms.SelectedRows.Count == 1)
                    {
                        txtRoomNo.Text = Convert.ToString(dgvRooms.CurrentRow.Cells[1].Value);
                        txtCapacity.Text = Convert.ToString(dgvRooms.CurrentRow.Cells[2].Value);
                        chkStatus.Checked = Convert.ToBoolean(dgvRooms.CurrentRow.Cells[3].Value);
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
            if (txtRoomNo.Text.Trim().Length == 0 || txtRoomNo.Text.Length > 10)
            {
                ep.SetError(txtRoomNo, "Please Enter Valid Room No/Name !!");
                txtRoomNo.Focus();
                txtRoomNo.SelectAll();
                return;
            }

            if (txtCapacity.Text.Trim().Length == 0)
            {
                ep.SetError(txtCapacity, "Invalid Capacity!!");
                txtCapacity.Focus();
                txtCapacity.SelectAll();
                return;
            }

            DataTable checktitle = DatabaseLayer.Retrive("select * from RoomTable where RoomNo = '" + txtRoomNo.Text.Trim() + "' and RoomID != '" + Convert.ToString(dgvRooms.CurrentRow.Cells[0].Value) + "'");
            if (checktitle != null)
            {
                if (checktitle.Rows.Count > 0)
                {
                    ep.SetError(txtRoomNo, "Already Exist");
                    txtRoomNo.Focus();
                    txtRoomNo.SelectAll();
                    return;
                }
            }

            string updatequery = string.Format("update RoomTable set RoomNo = '{0}',Capacity = '{1}' ,isActive = '{2}' where RoomID = '{3}'", 
                                 txtRoomNo.Text.Trim(),txtCapacity.Text.Trim() ,chkStatus.Checked, Convert.ToString(dgvRooms.CurrentRow.Cells[0].Value));
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
