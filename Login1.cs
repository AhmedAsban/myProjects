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
    public partial class Login1 : Form
    {
        public Login1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source= DESKTOP-RLEGLOP; Initial Catalog= Gym_DB; Integrated Security= True");

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from login_info WHERE R_username= '" + usernameTb.Text + "' AND R_password= '" + passwordTb.Text + "' ";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            try
            {



                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (dt.Rows.Count > 0)
                {
                    this.Hide();
                    signUp mf = new signUp();
                    mf.Show();

                }
                else
                {
                    MessageBox.Show("Invalid username or password", "Error");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            usernameTb.Text = "";
            passwordTb.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
