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
    public partial class Dashboard : Form
    {
        private string loggedInAdminEmail;
        public Dashboard(string loggedInEmail)
        {
            InitializeComponent();
            loggedInAdminEmail = loggedInEmail;
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void insertStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertDetails insertDetails = new InsertDetails();
            insertDetails.Show();
        }

        private void deleteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteDetails deleteDetails = new DeleteDetails();
            deleteDetails.Show();
        }

        private void updateStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateDetails updateDetails = new UpdateDetails();
            updateDetails.Show();
        }

        private void viewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDetails viewDetails = new ViewDetails();
            viewDetails.Show();
        }

        private void insertCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCourse addCourse = new AddCourse();
            addCourse.Show();
        }

        private void deleteCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCourse deleteCourse = new DeleteCourse();
            deleteCourse.Show();
        }

        private void updateCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCourse updateCourse = new UpdateCourse();
            updateCourse.Show();
        }

        private void viewCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCourse viewCourse = new ViewCourse();
            viewCourse.Show();
        }

        private void insertLecturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InsertLecturer insertLecturer = new InsertLecturer();
            insertLecturer.Show();
        }

        private void deleteLectuerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteLecturer deleteLecturer = new DeleteLecturer();
            deleteLecturer.Show();
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateLecturer updateLecturer = new UpdateLecturer();
            updateLecturer.Show();
        }

        private void viewLectuersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewLecturer viewLecturer = new ViewLecturer();
            viewLecturer.Show();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdminProfile adminProfile = new AdminProfile(loggedInAdminEmail);
            adminProfile.Show();
        }
    }
}