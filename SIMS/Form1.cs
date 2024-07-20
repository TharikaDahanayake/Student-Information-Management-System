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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SIMS
{
    public partial class Form1 : Form
    {

        public string LoggedInEmail { get; }
        public string LoggedInPaasword { get; }
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string usernamefromtextbox, string passwordfromtextbox)
        {
            LoggedInEmail = usernamefromtextbox;

            LoggedInPaasword = passwordfromtextbox;
        }
        

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=THARIKA\\SQLEXPRESS;database=SIMS;integrated security=True";

            SqlCommand admincmd = new SqlCommand();
            admincmd.CommandText = "select * from Admin WHERE adminID ='"+ txtUsername.Text + "' and adminPassword='"+txtPassword.Text+"'";
            admincmd.Connection = con;

            SqlCommand studentcmd = new SqlCommand();
            studentcmd.CommandText = "select * from Student WHERE email ='"+ txtUsername.Text + "'";
            studentcmd.Connection = con;

            SqlCommand lecturercmd = new SqlCommand();
            lecturercmd.CommandText = "select * from Lecturer WHERE lecEmail ='"+ txtUsername.Text + "'";
            lecturercmd.Connection = con;

            string usernamefromtextbox = txtUsername.Text.Trim();
            string passwordfromtextbox = txtPassword.Text.Trim();

            SqlDataAdapter dad = new SqlDataAdapter(admincmd);
            DataSet de = new DataSet();
            dad.Fill(de);

            SqlDataAdapter da = new SqlDataAdapter(studentcmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            SqlDataAdapter dt = new SqlDataAdapter(lecturercmd);
            DataSet dl = new DataSet();
            dt.Fill(dl);

            string loggedInEmail = usernamefromtextbox;
            string loggedInPassword = passwordfromtextbox;

            

            if (ds.Tables[0].Rows.Count != 0 && usernamefromtextbox.StartsWith("stu") && loggedInPassword == Convert.ToString(ds.Tables[0].Rows[0]["stuPassword"]))
            {
       
                this.Hide();
                DashboardStudent dsa = new DashboardStudent(loggedInEmail);
                dsa.Show();

                MessageBox.Show("Login Successfull !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            

            }
            
            else if (dl.Tables[0].Rows.Count != 0 && usernamefromtextbox.StartsWith("lec") && loggedInPassword == Convert.ToString(dl.Tables[0].Rows[0]["lecPassword"]))
            {
              
                this.Hide();
                DashboardLecturer dsalec = new DashboardLecturer(loggedInEmail);
                dsalec.Show();

                MessageBox.Show("Login Successfull !", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(de.Tables[0].Rows.Count != 0 && usernamefromtextbox.StartsWith("admin") && loggedInPassword == Convert.ToString(de.Tables[0].Rows[0]["adminPassword"]))
            {
                this.Hide();
                Dashboard dn = new Dashboard(loggedInEmail);
                dn.Show();
                MessageBox.Show("Login Successfull !","Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid Username or Password!!!", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
            

            private void txtUsername_MouseClick(object sender, MouseEventArgs e)
            {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Clear();
            }
            }

            private void txtPassword_TextChanged(object sender, EventArgs e)
            {

            }

            private void txtPassword_MouseClick(object sender, MouseEventArgs e)
            {
                if (txtPassword.Text == "Password")
                {
                    txtPassword.Clear();
                    txtPassword.PasswordChar = '*';
                }
            }

            private void pictureBox1_Click(object sender, EventArgs e)
            {

            }

            private void Form1_Load(object sender, EventArgs e)
            {

            }


        
    }
}
