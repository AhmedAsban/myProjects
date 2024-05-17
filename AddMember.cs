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
    public partial class AddMember : Form
    {
        public AddMember()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source= DESKTOP-RLEGLOP; Initial Catalog= Gym_DB; Integrated Security= True");

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AddMember_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(nameTb.Text == "" || phoneTb.Text == "" || ageTb.Text == "" || genderCb.Text == "" || amountTb.Text == "" || timingCb.Text == "")
            {
                MessageBox.Show("missing informaion!");
            }
            else
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO member_info (M_name, M_phone, M_gender, M_age, M_amount, M_timing) Values (@name, @phone, @gender, @age, @amount, @timing) ";

                    SqlCommand cmd = new SqlCommand(sql, con);

                    //cmd.Parameters.AddWithValue("@id", Convert.ToInt32(idTb.Text));
                    cmd.Parameters.AddWithValue("@name", nameTb.Text);
                    cmd.Parameters.AddWithValue("@phone", Convert.ToInt64(phoneTb.Text));
                    cmd.Parameters.AddWithValue("@gender", genderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@age", Convert.ToInt32(ageTb.Text));
                    cmd.Parameters.AddWithValue("@amount", Convert.ToInt32(amountTb.Text));
                    cmd.Parameters.AddWithValue("@timing", timingCb.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Member Successfully Added");

                    nameTb.Text = "";
                    phoneTb.Text = "";
                    ageTb.Text = "";
                    genderCb.Text = "";
                    amountTb.Text = "";
                    timingCb.Text = "";


                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nameTb.Text = "";
            phoneTb.Text = "";
            ageTb.Text = "";
            genderCb.Text = "";
            amountTb.Text = "";
            timingCb.Text = "";
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //MainForm mf = new MainForm();
            //mf.Show();
            //this.Hide();
        }
    }
}
