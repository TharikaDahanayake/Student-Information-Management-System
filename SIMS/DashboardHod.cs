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
    public partial class DashboardHod : Form
    {
        public DashboardHod()
        {
            InitializeComponent();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HodProfile hodProfile = new HodProfile();
            hodProfile.Show();
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewDetails viewDetails = new ViewDetails();
            viewDetails.Show();
        }

        private void courseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewCourse viewCourse = new ViewCourse();  
            viewCourse.Show();
        }

        private void lecturerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewLecturer viewLecturer = new ViewLecturer();
            viewLecturer.Show();
        }

        private void marksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewMarks viewMarks = new ViewMarks();
            viewMarks.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
