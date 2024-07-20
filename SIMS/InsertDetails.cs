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

namespace SIMS
{
    public partial class InsertDetails : Form
    {
        public InsertDetails()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtIndex.Text != "" && txtName.Text != ""  && txtDob.Text != "" && txtEmail.Text != ""  && txtDept.Text !="")
            {
                string index = txtIndex.Text;
                string stuPassword =txtStuPassword.Text;
                string name = txtName.Text;
                string dob = txtDob.Text;
                string email = txtEmail.Text;              
                string department = txtDept.Text;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into Student (indexNo,stuPassword,name,dob,email,deptName)values('" + index + "','"+stuPassword+"','" + name + "','" + dob + "','" + email + "','" + department+"')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIndex.Clear();
                txtStuPassword.Clear();
                txtName.Clear();               
                txtDob.Clear();
                txtEmail.Clear();                
                txtDept.Clear();

            }
            else
            {
                MessageBox.Show("Empty field not allowed !","warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtIndex.Clear();
            txtStuPassword.Clear();
            txtName.Clear();
            txtDob.Clear();
            txtEmail.Clear();          
            txtDept.Clear();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("This will delete your unsaved data !", "Are you sure? ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)==DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void InsertDetails_Load(object sender, EventArgs e)
        {

        }
    }
}
