using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SIMS
{
    public partial class AddCourse : Form
    {
        public AddCourse()
        {
            InitializeComponent();
        }

        private void AddCourse_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCourseID.Text != "" && txtCourseName.Text != "" && txtCredit.Text != "" && txtDeptName.Text != "" && txtLecID.Text != "")
            {
                string courseID = txtCourseID.Text;
                string courseName = txtCourseName.Text;
                int creditValue = Convert.ToInt32(txtCredit.Text);
                string lecID = txtLecID.Text;
                string deptName = txtDeptName.Text;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into Course (courseID,courseName,creditValue,lecID,deptName)values('" + courseID + "','" + courseName + "'," + creditValue + ",'" + lecID + "','" + deptName + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCourseID.Clear();
                txtCourseName.Clear();

                txtCredit.Clear();
                txtDeptName.Clear();

                txtLecID.Clear();
            }
            else
            {
                MessageBox.Show("Empty field not allowed !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtCourseID.Clear();
            txtCourseName.Clear();
            txtCredit.Clear();
            txtDeptName.Clear();
            txtLecID.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete your unsaved data !", "Are you sure? ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }

        }
    }
}
