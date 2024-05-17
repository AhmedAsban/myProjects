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
    public partial class signUp : Form
    {
        public signUp()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source= DESKTOP-RLEGLOP; Initial Catalog= Gym_DB; Integrated Security= True");


        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //MainForm mf = new MainForm();
            //mf.Show();
            this.Close();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            //string sql = "select count(*) from login_info where R_username = @1 and R_password = @2 ";
            //SqlCommand cmd = new SqlCommand(sql, con);
            //cmd.Parameters.AddWithValue("@1", usernameTb.Text);
            //cmd.Parameters.AddWithValue("@2", passwordTb.Text);

            //try
            //{
            //    con.Open();
            //    int count = Convert.ToInt32(cmd.ExecuteScalar());
            //    if (count > 0)
            //    {
            //        MessageBox.Show("choose another username or password.... this is taken");

            //    }
            //    else
            //    {
            //        string sql2 = "update login_info set R_username=@3, R_password=@4 where R_id=" + key + ";";
            //        SqlCommand cmd2 = new SqlCommand(sql2, con);
            //        cmd2.Parameters.AddWithValue("@3", usernameTb.Text);
            //        cmd2.Parameters.AddWithValue("@4", passwordTb.Text);

            //        cmd2.ExecuteNonQuery();

            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    con.Close();
            //}
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            usernameTb.Text = "";
            passwordTb.Text = "";
            usernameTb.Focus();
        }

        private void signUpDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ////signUpDGV.Rows[0].Visible = false;
            //signUpDGV.EnableHeadersVisualStyles = false;
            //signUpDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            //signUpDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void signUp_Load(object sender, EventArgs e)
        {
            //con.Open();

            //string sql = "select * from login_info";

            //SqlDataAdapter sda = new SqlDataAdapter(sql, con);

            //SqlCommand cmd = new SqlCommand();

            //DataSet ds = new DataSet();
            //try
            //{
            //    sda.Fill(ds);
            //    signUpDGV.DataSource = ds.Tables[0];

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    con.Close();
            //}
        }

        private void button5_Click(object sender, EventArgs e)
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
                    MessageBox.Show("choose another username or password.... this is taken");

                }
                else
                {
                    string sql2 = "insert into login_info(R_username,R_password) values(@3,@4)";
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.Parameters.AddWithValue("@3", usernameTb.Text);
                    cmd2.Parameters.AddWithValue("@4", passwordTb.Text);

                    cmd2.ExecuteNonQuery();

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

        //int key = 0;

        private void signUpDGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //try
            //{
            //    if (signUpDGV.SelectedRows.Count >= 0)
            //    {
            //        key = Convert.ToInt32(signUpDGV.SelectedRows[0].Cells[0].Value.ToString());
            //        usernameTb.Text = signUpDGV.SelectedRows[0].Cells[1].Value.ToString();
            //        passwordTb.Text = signUpDGV.SelectedRows[0].Cells[2].Value.ToString();
                   
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("invalid selection, please select a row by a double a click");
            //}
            //finally
            //{

            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //if (key == 0)
            //{
            //    MessageBox.Show("Select the user to be deleted by a double click");
            //}
            //else
            //{
            //    try
            //    {
            //        string sql1 = "Delete from login_info Where R_id=" + key + ";";
            //        SqlCommand cmd = new SqlCommand(sql1, con);
            //        con.Open();

            //        cmd.ExecuteNonQuery();
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //    finally
            //    {
            //        con.Close();
            //    }
            //}
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //con.Open();

            //string sql = "select * from login_info";

            //SqlDataAdapter sda = new SqlDataAdapter(sql, con);

            //SqlCommand cmd = new SqlCommand();

            //DataSet ds = new DataSet();
            //try
            //{
            //    sda.Fill(ds);
            //    signUpDGV.DataSource = ds.Tables[0];

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    con.Close();
            //}
        }

        private void signUpDGV_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            //if (e.RowIndex == 0)
            //{
            //    e.Handled = true;
            //}
        }
    }
}
