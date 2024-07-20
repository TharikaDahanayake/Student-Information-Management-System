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
    public partial class InsertMarks : Form
    {
        public InsertMarks()
        {
            InitializeComponent();
        }

        private void InsertMarks_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (comboCourseID.Text != "" && txtIndexNo.Text != "" && txtMarks.Text != "" )
            {

                string courseID = comboCourseID.Text;
                string indexNo = txtIndexNo.Text;
                string marks = txtMarks.Text;
                
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into Marks (courseID,indexNo,marks)values('" + courseID + "','" + indexNo + "'," + marks + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboCourseID.Items.RemoveAt(0);
                txtIndexNo.Clear();
                txtMarks.Clear();

            }
            else
            {
                MessageBox.Show("Empty field not allowed !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("This will delete your unsaved data !", "Are you sure? ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            comboCourseID.Items.RemoveAt(0);
            txtIndexNo.Clear();
            txtMarks.Clear();
        }
    }
}
