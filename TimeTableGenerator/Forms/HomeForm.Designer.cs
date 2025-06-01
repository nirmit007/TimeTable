namespace TimeTableGenerator.Forms
{
    partial class HomeForm
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
            toolStrip1 = new ToolStrip();
            toolStripButton1 = new ToolStripButton();
            toolStripButton2 = new ToolStripButton();
            toolStripButton3 = new ToolStripButton();
            toolStripSplitButton1 = new ToolStripSplitButton();
            newLectureToolStripMenuItem = new ToolStripMenuItem();
            assignSubjectsToLectureToolStripMenuItem = new ToolStripMenuItem();
            toolStripSplitButton2 = new ToolStripSplitButton();
            addRoomToolStripMenuItem = new ToolStripMenuItem();
            addLabsToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton4 = new ToolStripSplitButton();
            newSemestersToolStripMenuItem = new ToolStripMenuItem();
            addSemesterSectionsToolStripMenuItem = new ToolStripMenuItem();
            assignSemesterToProgramToolStripMenuItem = new ToolStripMenuItem();
            assignSubjectToSemesterToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton5 = new ToolStripSplitButton();
            addDaysToolStripMenuItem = new ToolStripMenuItem();
            dayTimeSlotToolStripMenuItem = new ToolStripMenuItem();
            toolStripButton6 = new ToolStripButton();
            toolStripSplitButton3 = new ToolStripSplitButton();
            printAllTimeTablesToolStripMenuItem = new ToolStripMenuItem();
            printAllTeacherTimeTablesToolStripMenuItem = new ToolStripMenuItem();
            printAllDaysWiseTimeTablesToolStripMenuItem = new ToolStripMenuItem();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            tsslblDateTime = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(35, 35);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButton1, toolStripButton2, toolStripButton3, toolStripSplitButton1, toolStripSplitButton2, toolStripButton4, toolStripButton5, toolStripButton6, toolStripSplitButton3 });
            toolStrip1.Location = new Point(0, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 57);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            toolStrip1.ItemClicked += toolStrip1_ItemClicked;
            // 
            // toolStripButton1
            // 
            toolStripButton1.Image = Properties.Resources.programicon;
            toolStripButton1.ImageTransparentColor = Color.Magenta;
            toolStripButton1.Name = "toolStripButton1";
            toolStripButton1.Size = new Size(57, 54);
            toolStripButton1.Text = "Program";
            toolStripButton1.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton1.Click += toolStripButton1_Click_1;
            // 
            // toolStripButton2
            // 
            toolStripButton2.Image = Properties.Resources.sessionicon;
            toolStripButton2.ImageTransparentColor = Color.Magenta;
            toolStripButton2.Name = "toolStripButton2";
            toolStripButton2.Size = new Size(50, 54);
            toolStripButton2.Text = "Session";
            toolStripButton2.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton2.Click += toolStripButton2_Click;
            // 
            // toolStripButton3
            // 
            toolStripButton3.Image = Properties.Resources.subjecticon;
            toolStripButton3.ImageTransparentColor = Color.Magenta;
            toolStripButton3.Name = "toolStripButton3";
            toolStripButton3.Size = new Size(50, 54);
            toolStripButton3.Text = "Subject";
            toolStripButton3.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton3.Click += toolStripButton3_Click;
            // 
            // toolStripSplitButton1
            // 
            toolStripSplitButton1.DropDownItems.AddRange(new ToolStripItem[] { newLectureToolStripMenuItem, assignSubjectsToLectureToolStripMenuItem });
            toolStripSplitButton1.Image = Properties.Resources.teachericon;
            toolStripSplitButton1.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton1.Name = "toolStripSplitButton1";
            toolStripSplitButton1.Size = new Size(64, 54);
            toolStripSplitButton1.Text = "Teacher";
            toolStripSplitButton1.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripSplitButton1.ButtonClick += toolStripSplitButton1_ButtonClick;
            // 
            // newLectureToolStripMenuItem
            // 
            newLectureToolStripMenuItem.Name = "newLectureToolStripMenuItem";
            newLectureToolStripMenuItem.Size = new Size(216, 22);
            newLectureToolStripMenuItem.Text = "New Lecture";
            newLectureToolStripMenuItem.Click += newLectureToolStripMenuItem_Click;
            // 
            // assignSubjectsToLectureToolStripMenuItem
            // 
            assignSubjectsToLectureToolStripMenuItem.Name = "assignSubjectsToLectureToolStripMenuItem";
            assignSubjectsToLectureToolStripMenuItem.Size = new Size(216, 22);
            assignSubjectsToLectureToolStripMenuItem.Text = "Assign Subjects to Lecturer";
            assignSubjectsToLectureToolStripMenuItem.Click += assignSubjectsToLectureToolStripMenuItem_Click;
            // 
            // toolStripSplitButton2
            // 
            toolStripSplitButton2.DropDownItems.AddRange(new ToolStripItem[] { addRoomToolStripMenuItem, addLabsToolStripMenuItem });
            toolStripSplitButton2.Image = Properties.Resources.roomsicon;
            toolStripSplitButton2.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton2.Name = "toolStripSplitButton2";
            toolStripSplitButton2.Size = new Size(60, 54);
            toolStripSplitButton2.Text = "Rooms";
            toolStripSplitButton2.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // addRoomToolStripMenuItem
            // 
            addRoomToolStripMenuItem.Name = "addRoomToolStripMenuItem";
            addRoomToolStripMenuItem.Size = new Size(131, 22);
            addRoomToolStripMenuItem.Text = "Add Room";
            addRoomToolStripMenuItem.Click += addRoomToolStripMenuItem_Click;
            // 
            // addLabsToolStripMenuItem
            // 
            addLabsToolStripMenuItem.Name = "addLabsToolStripMenuItem";
            addLabsToolStripMenuItem.Size = new Size(131, 22);
            addLabsToolStripMenuItem.Text = "Add Labs";
            addLabsToolStripMenuItem.Click += addLabsToolStripMenuItem_Click;
            // 
            // toolStripButton4
            // 
            toolStripButton4.DropDownItems.AddRange(new ToolStripItem[] { newSemestersToolStripMenuItem, addSemesterSectionsToolStripMenuItem, assignSemesterToProgramToolStripMenuItem, assignSubjectToSemesterToolStripMenuItem });
            toolStripButton4.Image = Properties.Resources.semestericon;
            toolStripButton4.ImageTransparentColor = Color.Magenta;
            toolStripButton4.Name = "toolStripButton4";
            toolStripButton4.Size = new Size(76, 54);
            toolStripButton4.Text = "Semesters";
            toolStripButton4.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // newSemestersToolStripMenuItem
            // 
            newSemestersToolStripMenuItem.Name = "newSemestersToolStripMenuItem";
            newSemestersToolStripMenuItem.Size = new Size(223, 22);
            newSemestersToolStripMenuItem.Text = "New Semesters";
            newSemestersToolStripMenuItem.Click += newSemestersToolStripMenuItem_Click;
            // 
            // addSemesterSectionsToolStripMenuItem
            // 
            addSemesterSectionsToolStripMenuItem.Name = "addSemesterSectionsToolStripMenuItem";
            addSemesterSectionsToolStripMenuItem.Size = new Size(223, 22);
            addSemesterSectionsToolStripMenuItem.Text = "Add Semester Sections";
            addSemesterSectionsToolStripMenuItem.Click += addSemesterSectionsToolStripMenuItem_Click;
            // 
            // assignSemesterToProgramToolStripMenuItem
            // 
            assignSemesterToProgramToolStripMenuItem.Name = "assignSemesterToProgramToolStripMenuItem";
            assignSemesterToProgramToolStripMenuItem.Size = new Size(223, 22);
            assignSemesterToProgramToolStripMenuItem.Text = "Assign Semester to Program";
            assignSemesterToProgramToolStripMenuItem.Click += assignSemesterToProgramToolStripMenuItem_Click;
            // 
            // assignSubjectToSemesterToolStripMenuItem
            // 
            assignSubjectToSemesterToolStripMenuItem.Name = "assignSubjectToSemesterToolStripMenuItem";
            assignSubjectToSemesterToolStripMenuItem.Size = new Size(223, 22);
            assignSubjectToSemesterToolStripMenuItem.Text = " Assign Subject to Semester";
            assignSubjectToSemesterToolStripMenuItem.Click += assignSubjectToSemesterToolStripMenuItem_Click;
            // 
            // toolStripButton5
            // 
            toolStripButton5.DropDownItems.AddRange(new ToolStripItem[] { addDaysToolStripMenuItem, dayTimeSlotToolStripMenuItem });
            toolStripButton5.Image = Properties.Resources.daysicon;
            toolStripButton5.ImageTransparentColor = Color.Magenta;
            toolStripButton5.Name = "toolStripButton5";
            toolStripButton5.Size = new Size(51, 54);
            toolStripButton5.Text = "Days";
            toolStripButton5.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // addDaysToolStripMenuItem
            // 
            addDaysToolStripMenuItem.Name = "addDaysToolStripMenuItem";
            addDaysToolStripMenuItem.Size = new Size(180, 22);
            addDaysToolStripMenuItem.Text = "Add Day's";
            addDaysToolStripMenuItem.Click += addDaysToolStripMenuItem_Click;
            // 
            // dayTimeSlotToolStripMenuItem
            // 
            dayTimeSlotToolStripMenuItem.Name = "dayTimeSlotToolStripMenuItem";
            dayTimeSlotToolStripMenuItem.Size = new Size(180, 22);
            dayTimeSlotToolStripMenuItem.Text = "Day Time Slot";
            dayTimeSlotToolStripMenuItem.Click += dayTimeSlotToolStripMenuItem_Click;
            // 
            // toolStripButton6
            // 
            toolStripButton6.Image = Properties.Resources.timetableicon;
            toolStripButton6.ImageTransparentColor = Color.Magenta;
            toolStripButton6.Name = "toolStripButton6";
            toolStripButton6.Size = new Size(69, 54);
            toolStripButton6.Text = "Time Table";
            toolStripButton6.TextImageRelation = TextImageRelation.ImageAboveText;
            toolStripButton6.Click += toolStripButton6_Click;
            // 
            // toolStripSplitButton3
            // 
            toolStripSplitButton3.DropDownItems.AddRange(new ToolStripItem[] { printAllTimeTablesToolStripMenuItem, printAllTeacherTimeTablesToolStripMenuItem, printAllDaysWiseTimeTablesToolStripMenuItem });
            toolStripSplitButton3.Image = Properties.Resources.printsicon;
            toolStripSplitButton3.ImageTransparentColor = Color.Magenta;
            toolStripSplitButton3.Name = "toolStripSplitButton3";
            toolStripSplitButton3.Size = new Size(51, 54);
            toolStripSplitButton3.Text = "Print";
            toolStripSplitButton3.TextImageRelation = TextImageRelation.ImageAboveText;
            // 
            // printAllTimeTablesToolStripMenuItem
            // 
            printAllTimeTablesToolStripMenuItem.Name = "printAllTimeTablesToolStripMenuItem";
            printAllTimeTablesToolStripMenuItem.Size = new Size(238, 22);
            printAllTimeTablesToolStripMenuItem.Text = "Print All Time Tables";
            // 
            // printAllTeacherTimeTablesToolStripMenuItem
            // 
            printAllTeacherTimeTablesToolStripMenuItem.Name = "printAllTeacherTimeTablesToolStripMenuItem";
            printAllTeacherTimeTablesToolStripMenuItem.Size = new Size(238, 22);
            printAllTeacherTimeTablesToolStripMenuItem.Text = " Print All Teacher Time Tables";
            // 
            // printAllDaysWiseTimeTablesToolStripMenuItem
            // 
            printAllDaysWiseTimeTablesToolStripMenuItem.Name = "printAllDaysWiseTimeTablesToolStripMenuItem";
            printAllDaysWiseTimeTablesToolStripMenuItem.Size = new Size(238, 22);
            printAllDaysWiseTimeTablesToolStripMenuItem.Text = "Print All Days Wise Time Tables";
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, tsslblDateTime });
            statusStrip1.Location = new Point(0, 428);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(800, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(45, 17);
            toolStripStatusLabel1.Text = "Ready..";
            // 
            // tsslblDateTime
            // 
            tsslblDateTime.Name = "tsslblDateTime";
            tsslblDateTime.Size = new Size(740, 17);
            tsslblDateTime.Spring = true;
            tsslblDateTime.Text = "toolStripStatusLabel2";
            tsslblDateTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "HomeForm";
            Text = "HomeForm";
            Load += HomeForm_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private MenuStrip menuStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripSplitButton toolStripSplitButton1;
        private ToolStripMenuItem newLectureToolStripMenuItem;
        private ToolStripMenuItem assignSubjectsToLectureToolStripMenuItem;
        private ToolStripSplitButton toolStripSplitButton2;
        private ToolStripMenuItem addRoomToolStripMenuItem;
        private ToolStripMenuItem addLabsToolStripMenuItem;
        private ToolStripSplitButton toolStripButton4;
        private ToolStripMenuItem newSemestersToolStripMenuItem;
        private ToolStripMenuItem addSemesterSectionsToolStripMenuItem;
        private ToolStripMenuItem assignSemesterToProgramToolStripMenuItem;
        private ToolStripMenuItem assignSubjectToSemesterToolStripMenuItem;
        private ToolStripSplitButton toolStripButton5;
        private ToolStripMenuItem addDaysToolStripMenuItem;
        private ToolStripMenuItem dayTimeSlotToolStripMenuItem;
        private ToolStripButton toolStripButton6;
        private ToolStripSplitButton toolStripSplitButton3;
        private ToolStripMenuItem printAllTimeTablesToolStripMenuItem;
        private ToolStripMenuItem printAllTeacherTimeTablesToolStripMenuItem;
        private ToolStripMenuItem printAllDaysWiseTimeTablesToolStripMenuItem;
        private ToolStripStatusLabel tsslblDateTime;
    }
}