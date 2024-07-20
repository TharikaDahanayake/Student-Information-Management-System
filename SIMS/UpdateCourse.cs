using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SIMS
{
    public partial class UpdateCourse : Form
    {
        public UpdateCourse()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void UpdateCourse_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT courseID, courseName,creditValue,lecID,deptName From Course";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        string rowid;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (CourseID.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT courseID, courseName,creditValue,lecID,deptName From Course where courseID LIKE '" + CourseID.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT courseID, courseName,creditValue,lecID,deptName From Course";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will be updated. Confirm?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {


                string courseName = txtCourseName.Text;

                int creditValue = Convert.ToInt32(txtCredit.Text);
                string  lecID= txtLecID.Text;

                string deptName = txtDeptName.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Update Course set courseName='" + txtCourseName.Text + "'  ,creditValue='" + txtCredit.Text + "' ,lecID='" + txtLecID.Text + "', deptName='" + txtDeptName.Text + "' where CourseID='" + rowid + "' ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                MessageBox.Show("Successfully Updated !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string courseID;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                courseID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT courseID, courseName,creditValue,lecID,deptName From Course where courseID= '" + courseID + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                rowid = ds.Tables[0].Rows[0][0].ToString();

                txtCourseName.Text = ds.Tables[0].Rows[0][1].ToString();

                txtCredit.Text = ds.Tables[0].Rows[0][2].ToString();
                txtLecID.Text = ds.Tables[0].Rows[0][3].ToString();

                txtDeptName.Text = ds.Tables[0].Rows[0][4].ToString();


            }
        }
    }
}
