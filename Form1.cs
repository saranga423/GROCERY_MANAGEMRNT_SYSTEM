using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace final_project_1
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-73R3HS1\SQLEXPRESS;Initial Catalog=students;Integrated Security=True"); // need to Update Connection String
        //SqlConnection com;

        private void button2_Click(object sender, EventArgs e)
        {


            try
            {
                string username = txtUsername.Text;
                string password = txtPassword.Text;

                if (username.Length == 0 || password.Length == 0)
                {
                    MessageBox.Show("User Name or Password is empty", "Invalid Login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            
                if(username == "Admin" && password == "Skills@123")
                {
                    this.Hide();
                    //Register obj = new Register();
                    //obj.Show();
                    Register formR = new Register();
                    formR.Show();
                }

                con.Open();
                string query_search = "SELECT * FROM Login WHERE username='" + username + "'AND password='" + password + "'";
                SqlCommand cmnd = new SqlCommand(query_search, con);

                SqlDataReader r = cmnd.ExecuteReader();
                if (r.HasRows)
                {
                    r.Read();
                    this.Hide();
                    Form3 form3= new Form3();
                    form3.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Login Credentials, Please check Username & Password and try again!", "Invalid Login Details", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error while saving!" + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure,Do you really want to exit...?", "Exit", MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);
            if (result ==
                DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
