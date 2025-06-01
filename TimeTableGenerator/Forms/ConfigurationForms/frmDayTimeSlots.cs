using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TimeTableGenerator.AllModels;
using TimeTableGenerator.SourceCode;

namespace TimeTableGenerator.Forms.ConfigurationForms
{
    public partial class frmDayTimeSlots : Form
    {
        public frmDayTimeSlots()
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
                    query = "select DayTimeSlotID, ROW_NUMBER() OVER (Order by DayTimeSlotID) AS [S No],DayID, Name, SlotTitle [Slot Title], StartTime[Start Time], EndTime [End Time], isActive [Status] from v_AllTimeSlot WHERE isActive = 1 ";

                }
                else
                {
                    query = "select DayTimeSlotID, ROW_NUMBER() OVER (Order by DayTimeSlotID) AS [S No], DayID, Name, SlotTitle [Slot Title], StartTime[Start Time], EndTime [End Time], isActive [Status] from v_AllTimeSlot" +
                        "WHERE isACtive = 1 AND (Name + ' ' + SlotTitle) like '%" + searchvalue.Trim() + "%'";
                }

                DataTable lablist = DatabaseLayer.Retrive(query);
                dgvSlots.DataSource = lablist;
                if (dgvSlots.Rows.Count > 0)
                {
                    dgvSlots.Columns[0].Visible = false;
                    dgvSlots.Columns[1].Width = 80;
                    dgvSlots.Columns[2].Visible = false;
                    dgvSlots.Columns[3].Width = 150;
                    dgvSlots.Columns[4].Width = 100;
                    dgvSlots.Columns[5].Width = 80;
                    dgvSlots.Columns[6].Width = 80;

                }
            }
            catch
            {

                MessageBox.Show("Unexpexted error!!!");
            }
        }

        public void EnableComponents()
        {
            dgvSlots.Enabled = false;
            btnClear.Visible = false;
            btnSave.Visible = false;
            btnCancel.Visible = true;
            btnUpdate.Visible = true;
            txtSearch.Visible = false;

        }

        public void DisableComponents()
        {
            dgvSlots.Enabled = true;
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

            cmbDays.SelectedIndex = 0;
            cmbNumberofTimeSlot.SelectedIndex = 0;
            chkStatus.Checked = true;

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmDayTimeSlots_Load(object sender, EventArgs e)
        {
            dtpStartTime.Value = new DateTime(2025, 12, 12, 9, 0, 0);
            dtpEndTime.Value = new DateTime(2025, 12, 12, 16, 30, 0);
            ComboHelper.AllDays(cmbDays);
            ComboHelper.TimeSlotNumbers(cmbNumberofTimeSlot);
            FillGrid(string.Empty);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DisableComponents();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (cmbDays.SelectedIndex == 0)
                {
                    ep.SetError(cmbDays, "Select Day!!");
                    cmbDays.Focus();
                    return;
                }

                if (cmbNumberofTimeSlot.SelectedIndex == 0)
                {
                    ep.SetError(cmbNumberofTimeSlot, "Please Select Days!!");
                    cmbNumberofTimeSlot.Focus();
                    return;
                }

                string Updatequery = "update  DayTimeSlotTable set isActive = 0 where DayID = '" + cmbDays.SelectedValue + "'";
                bool updateresult = DatabaseLayer.Update1(Updatequery);
                if (updateresult == true)
                {
                    List<TimeSlotsMV> timeslots = new List<TimeSlotsMV>();
                    TimeSpan time = dtpEndTime.Value - dtpStartTime.Value;
                    int totalminutes = (int)time.TotalMinutes;
                    int numberoftimeslot = Convert.ToInt32(cmbNumberofTimeSlot.SelectedValue);
                    int slot = totalminutes / numberoftimeslot;
                    TimeSpan starttime = dtpStartTime.Value.TimeOfDay;
                    int i = 0;
                    do
                    {
                        var timeslot = new TimeSlotsMV();
                        var FromTime = (dtpStartTime.Value).AddMinutes(slot * i);
                        i++;
                        var ToTime = (dtpStartTime.Value).AddMinutes(slot * i);
                        string title = FromTime.ToString("hh:mm tt") + " - " + ToTime.ToString("hh:mm tt");
                        timeslot.FromTime = FromTime;
                        timeslot.ToTime = ToTime;
                        timeslot.SlotTitle = title;
                        timeslots.Add(timeslot);

                    } while (i < numberoftimeslot);

                    bool insertstatus = true;
                    foreach (TimeSlotsMV slottime in timeslots)
                    {
                        string insertquery = string.Format("insert into DayTimeSlotTable (DayID, SlotTitle, StartTime, EndTime, isActive) values ('{0}', '{1}', '{2}', '{3}', '{4}')",
                                             cmbDays.SelectedValue, slottime.SlotTitle, slottime.FromTime, slottime.ToTime, chkStatus.Checked);
                        bool result = DatabaseLayer.Insert(insertquery);
                        if (result == false)
                        {
                            insertstatus = false;
                        }
                    }
                    if (insertstatus == true)
                    {
                        MessageBox.Show("Inserted Successfully!!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DisableComponents();
                    }
                    else
                    {
                        MessageBox.Show("Error Occured!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Update Error Occured!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {

                MessageBox.Show("Server Error!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsedit_Click(object sender, EventArgs e)
        {
            if (dgvSlots != null)
            {
                if (dgvSlots.Rows.Count > 0)
                {
                    if (dgvSlots.SelectedRows.Count == 1)
                    {
                        string slotid = Convert.ToString(dgvSlots.CurrentRow.Cells[0].Value);
                        string updatequery = "update DayTimeSlotTable set isActive = 0 where DayTimeSlotID = '" + Convert.ToString(dgvSlots.CurrentRow.Cells[0].Value) + "'";
                        bool result = DatabaseLayer.Update(updatequery);
                        if (result == true)
                        {
                            MessageBox.Show("Break Time is MArked!!");
                            DisableComponents();
                        }

                    }
                }
            }
        }

        private void cmsOptions_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
