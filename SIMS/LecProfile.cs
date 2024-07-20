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
    public partial class LecProfile : Form
    {
        private string LecturerEmail;
        public LecProfile(string loggedInLecturerEmail)
        {
            InitializeComponent();
            LecturerEmail = loggedInLecturerEmail;
        }

        private void LecProfile_Load(object sender, EventArgs e)
        {
            label1.Text = LecturerEmail;
        }
    }
}
