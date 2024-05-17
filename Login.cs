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


namespace Gym_system_management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source= DESKTOP-RLEGLOP; Initial Catalog= Gym_DB; Integrated Security= True");


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

            //if (usernameTb.Text=="" || passwordTb.Text=="")
            //{
            //    usernameTb.Text = "username"; // Replace with your actual message
            //    usernameTb.ForeColor = Color.LightGray;
            //    passwordTb.Text = "password"; // Replace with your actual message
            //    passwordTb.ForeColor = Color.LightGray;
            //}
            //else
            //{
            //    //usernameTb.Text = ""; // Clear the placeholder text
            //    usernameTb.ForeColor = Color.Black; // Set back to normal text color (adjust as needed)
            //    passwordTb.Text = ""; // Clear the placeholder text
            //    //passwordTb.ForeColor = Color.Black; // Set back to normal text color (adjust as needed)
            //}
            //MainForm mf = new MainForm();
            //mf.MdiParent = Login.ActiveForm;
            //mf.Show();


            //passwordTb.PasswordChar ='*';

        }

        private void passwordTb_TextChanged(object sender, EventArgs e)
        {
            //if(passwordTb.Text!="" && passwordTb.Focus())
            //{
            //    passwordTb.Text = "";
            //    passwordTb.ForeColor = Color.Black;
            //    passwordTb_TextChanged(sender, e);
            //}
            //else
            //{
            //    passwordTb.ForeColor = Color.LightGray;
            //}
            //passwordTb.Text = placeholderText2;
            //passwordTb.ForeColor = Color.Gray;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select count(*) from login_info where R_username = @1 and R_password = @2 ";
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@1", usernameTb.Text);
            cmd.Parameters.AddWithValue("@2", passwordTb.Text);

            try
            {
                con.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                if (count > 0)
                {
                    this.Hide();
                    MainForm mf = new MainForm();
                    mf.Show();
                    //Login log = new Login();
                    //log.Close();

                }
                else
                {
                    MessageBox.Show("username or password is invalid... try again");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
                

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usernameTb.Text = "";
            passwordTb.Text = "";
            usernameTb.Focus();
        }

        //private string placeholderText1 = "username";
        //private string placeholderText2 = "password";

        private void usernameTb_TextChanged(object sender, EventArgs e)
        {
            //if(usernameTb.Text != "")
            //{
            //    usernameTb.ForeColor = Color.Black;
            //}
            //else
            //{
            //    usernameTb.ForeColor = Color.LightGray;
            //}
            
        }

        private void usernameTb_Leave(object sender, EventArgs e)
        {
            //if (usernameTb.Text == "")
            //{
            //    usernameTb.Text = placeholderText1;
            //}
        }

        private void usernameTb_Enter(object sender, EventArgs e)
        {
            //if (usernameTb.Text == placeholderText1)
            //{
            //    usernameTb.Text = "";
            //}
        }

        private void passwordTb_Enter(object sender, EventArgs e)
        {
            //if (passwordTb.Text == placeholderText2)
            //{
            //    passwordTb.Text = "";
            //}
        }

        private void passwordTb_Leave(object sender, EventArgs e)
        {
            //if (passwordTb.Text == "")
            //{
            //    passwordTb.Text = placeholderText2;
            //}
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
