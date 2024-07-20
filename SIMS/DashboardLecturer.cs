using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMS
{
    public partial class DashboardLecturer : Form
    {
        private string loggedInLecturerEmail;
        public DashboardLecturer(string loggedInEmail)
        {
            InitializeComponent();
            loggedInLecturerEmail = loggedInEmail;
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertMarks insertMarks = new InsertMarks();
            insertMarks.Show();
        }

        private void deleteStudentMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteMarks deleteMarks = new DeleteMarks();
            deleteMarks.Show();
        }

        private void updateStudentMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateMarks updateMarks = new UpdateMarks();
            updateMarks.Show();
        }

        private void viewStudentMarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewMarks viewMarks = new ViewMarks();
            viewMarks.Show();
        }

        private void viewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LecViewStudent viewDetails = new LecViewStudent();
            viewDetails.Show();
        }

        private void DashboardLecturer_Load(object sender, EventArgs e)
        {

        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LecProfile profile = new LecProfile(loggedInLecturerEmail);
            profile.Show();
        }
    }
}
