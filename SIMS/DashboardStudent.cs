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
    public partial class DashboardStudent : Form
    {
        private string loggedInStudentEmail;
        public DashboardStudent(string loggedInEmail)
        {
            InitializeComponent();
            loggedInStudentEmail=loggedInEmail;
        }

        

        private void myProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void marksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StuViewMarks stuViewMarksForm = new StuViewMarks(loggedInStudentEmail);
            stuViewMarksForm.Show();
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StuProfile stuProfile = new StuProfile(loggedInStudentEmail);
            stuProfile.Show();
        }
    }
}
