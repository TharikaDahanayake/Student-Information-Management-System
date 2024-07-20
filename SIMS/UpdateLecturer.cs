using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SIMS
{
    public partial class UpdateLecturer : Form
    {
        public UpdateLecturer()
        {
            InitializeComponent();
        }

        private void UpdateLecturer_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT lecID,lecPassword,lecName,lecEmail,deptName From Lecturer";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        string rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string txtLecID;
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtLecID = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT lecID,lecPassword,lecName,lecEmail,deptName From Lecturer where lecID= '" + txtLecID + "'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                rowid = ds.Tables[0].Rows[0][0].ToString();
                txtLecPassword.Text = ds.Tables[0].Rows[0][1].ToString();
                txtLecName.Text = ds.Tables[0].Rows[0][2].ToString();

                txtLecEmail.Text = ds.Tables[0].Rows[0][3].ToString();
                txtDeptName.Text = ds.Tables[0].Rows[0][4].ToString();

               
            }
        }

        private void txtLecID_TextChanged(object sender, EventArgs e)
        {
            if (txtLecID.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "SELECT lecID,lecPassword,lecName,lecEmail,deptName From Lecturer where lecID LIKE '" + txtLecID.Text + "%'";
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

                cmd.CommandText = "SELECT lecID,lecPassword,lecName,lecEmail,deptName From Lecturer";
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

                string lecPassword = txtLecPassword.Text;
                string lecName = txtLecName.Text;
                string lecEmail = txtLecEmail.Text;

                string deptName = txtDeptName.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "Update Lecturer set lecPassword='"+txtLecPassword.Text+"', lecName='" + txtLecName.Text + "'  ,lecEmail='" + txtLecEmail.Text + "' ,deptName='" + txtDeptName.Text + "' where lecID='" +rowid + "' ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);


                MessageBox.Show("Successfully Updated !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
