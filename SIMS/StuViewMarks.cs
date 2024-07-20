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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SIMS
{
    public partial class StuViewMarks : Form
    {

        // Define a field to store the logged-in student's email
        private string studentEmail;

        public StuViewMarks(string loggedInStudentEmail)
        {
            InitializeComponent();

            // Assign the logged-in student's email to the field
            studentEmail = loggedInStudentEmail;
        }
        
        private void StuViewMarks_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "SELECT Marks.courseID, Student.indexNo,Marks.marks FROM Marks INNER JOIN Student ON Marks.indexNo=Student.indexNo WHERE Student.email = @Email";

           
            
            cmd.Parameters.AddWithValue("@Email", studentEmail);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        
        
    }
}
