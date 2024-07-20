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
    public partial class InsertLecturer : Form
    {
        public InsertLecturer()
        {
            InitializeComponent();
        }

        private void InsertLecturer_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtLecID.Text != "" && txtLecPassword.Text!= "" && txtLecName.Text != "" && txtLecEmail.Text != "" && txtDeptName.Text != "" )
            {
                string lecID = txtLecID.Text;
                string lecPassword = txtLecPassword.Text;
                string lecName = txtLecName.Text;
                string lecEmail = txtLecEmail.Text;
                string deptName = txtDeptName.Text;



                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into Lecturer (lecID,lecPassword,lecName,lecEmail,deptName)values('" + lecID + "','"+ lecPassword + "','" + lecName + "','" + lecEmail + "','" + deptName + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLecID.Clear();
                txtLecPassword.Clear();
                txtLecName.Clear();
                txtLecEmail.Clear();
                txtDeptName.Clear();


            }
            else
            {
                MessageBox.Show("Empty field not allowed !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtLecID.Clear();
            txtLecPassword.Clear();
            txtLecName.Clear();

            txtLecEmail.Clear();
            txtDeptName.Clear();
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
