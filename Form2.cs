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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace final_project_1
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-73R3HS1\SQLEXPRESS;Initial Catalog=students;Integrated Security=True"); // need to Update Connection String
        SqlConnection com;
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            con.Open();
            string query_search = "SELECT regNo FROM Registration";
            SqlCommand cmnd = new SqlCommand(query_search, con);
            SqlDataReader dr = cmnd.ExecuteReader();
            while (dr.Read())
            {
                cmbRegNo.Items.Add(dr[0].ToString());
            }
            dr.Close();

        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                int regNo = int.Parse(cmbRegNo.Text);
                string firstName = txtFname.Text;
                string lastName = txtLname.Text;
                dtpDob.Format = DateTimePickerFormat.Custom;
                dtpDob.CustomFormat = "yyyy/MM/dd";
                string gender;
                if (rbMale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }

                string address = txtAddress.Text;
                string email = txtEmail.Text;
                int mobilePhone = int.Parse(txtMphone.Text);
                int homePhone = int.Parse(txtHphone.Text);
                string parentName = txtParName.Text;
                string nic = txtNIC.Text;
                int contactNo = int.Parse(txtConNum.Text);

                string query_insert = "INSERT INTO Registration VALUES (" + regNo + ",'" + firstName + "','" + lastName + "','" + dtpDob.Text + "','" + gender + "','" + address + "','" + email + "'," + mobilePhone + "," + homePhone + ",'" + parentName + "','" + nic + "'," + contactNo + ")";

                SqlCommand cmd = new SqlCommand(query_insert, con);
                con.Open();
                cmd.ExecuteNonQuery();
                var res = MessageBox.Show("Record added successfully! Please Login again to continue with the proceeding.", "Register Student", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    this.Hide();
                    frmLogin obj = new frmLogin();
                    obj.Show();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbRegNo.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            dtpDob.Format = DateTimePickerFormat.Custom;
            dtpDob.CustomFormat = "yyyy/MM/dd";
            DateTime thisDay = DateTime.Today;
            dtpDob.Text = thisDay.ToString();
            rbMale.Checked = false;
            rbFmale.Checked = false;
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtMphone.Text = "";
            txtHphone.Text = "";
            txtParName.Text = "";
            txtNIC.Text = "";
            txtConNum.Text = "";
            txtFname.Focus();
        }

        private void lnllbExi_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure, Do you really want to exit...?", "Exit", MessageBoxButtons.YesNo,
            MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int no = int.Parse(cmbRegNo.Text);
                string firstName = txtFname.Text;
                string lastName = txtLname.Text;
                dtpDob.Format = DateTimePickerFormat.Custom;
                dtpDob.CustomFormat = "yyyy/MM/dd";
                string gender;
                if (rbMale.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string address = txtAddress.Text;
                string email = txtEmail.Text;
                int mobilePhone = int.Parse(txtMphone.Text);
                int homePhone = int.Parse(txtHphone.Text);
                string parentName = txtParName.Text;
                string nic = txtNIC.Text;
                int contactNo = int.Parse(txtConNum.Text);

                string query_update = "UPDATE Registration SET firstName='" + firstName + "',lastName='" + lastName + "',dateOfBirth='" + dtpDob.Text + "',gender='" + gender + "',address='" + address + "',email='" + email + "',mobilePhone=" + mobilePhone + ",homePhone=" + homePhone + ",parentName='" + parentName + "',nic='" + nic + "',contactNo=" + contactNo + "WHERE regNo=" + no + "";
                con.Open();
                SqlCommand cmnd = new SqlCommand(query_update, con);
                cmnd.ExecuteNonQuery();
                con.Close();
                var res = MessageBox.Show("Record UpdatedSuccessfully!", "Record Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    cmbRegNo.Text = "";
                    txtFname.Text = "";
                    txtLname.Text = "";
                    dtpDob.Format = DateTimePickerFormat.Custom;
                    dtpDob.CustomFormat = "yyyy/MM/dd";
                    DateTime thisDay = DateTime.Today;
                    dtpDob.Text = thisDay.ToString();
                    rbMale.Checked = false;
                    rbFmale.Checked = false;
                    txtAddress.Text = "";
                    txtEmail.Text = "";
                    txtMphone.Text = "";
                    txtHphone.Text = "";
                    txtParName.Text = "";
                    txtNIC.Text = "";
                    txtConNum.Text = "";
                    cmbRegNo.Focus();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("error while saving!" + ex);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to Delete this Record?", "Delete Record", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                string no = cmbRegNo.Text;
                string query_delete = "DELETE FROM Registration WHERE regNo=" + no + "";

                con.Open();
                SqlCommand cmnd = new SqlCommand(query_delete, con);
                cmnd.ExecuteNonQuery();
                con.Close();
                var res = MessageBox.Show("Record Deleted Successfully! Please Login again to continue with the proceeding.", "Deleted Student", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (res == DialogResult.OK)
                {
                    this.Hide();
                    frmLogin obj = new frmLogin();
                    obj.Show();
                }

            }
        }

        private void lnklblLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure, You really want to Logout?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                frmLogin obj = new frmLogin();
                obj.Show();
            }  
        }

        private void gbContactDet_Enter(object sender, EventArgs e)
        {

        }

        private void cmbRegNo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        }
    }

