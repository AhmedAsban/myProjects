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
    public partial class trainer : Form
    {
        public trainer()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source= DESKTOP-RLEGLOP; Initial Catalog= Gym_DB; Integrated Security= True");


        private void view_trainer()
        {
            con.Open();

            string sql = "select * from Trainer_info";

            SqlDataAdapter sda = new SqlDataAdapter(sql, con);

            SqlCommand cmd = new SqlCommand();

            DataSet ds = new DataSet();
            try
            {
                sda.Fill(ds);
                trainerDGV.DataSource = ds.Tables[0];

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




        private void button5_Click(object sender, EventArgs e)
        {
            if (nameTb.Text == "" || phoneTb.Text == "" || ageTb.Text == "" || genderCb.Text == "")
            {
                MessageBox.Show("missing informaion!");
            }
            else
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO Trainer_info (T_name, T_age, T_gender, T_phone) Values (@name, @age, @gender, @phone) ";

                    SqlCommand cmd = new SqlCommand(sql, con);

                    //cmd.Parameters.AddWithValue("@id", Convert.ToInt32(idTb.Text));
                    cmd.Parameters.AddWithValue("@name", nameTb.Text);
                    cmd.Parameters.AddWithValue("@age", Convert.ToInt64(ageTb.Text));
                    cmd.Parameters.AddWithValue("@gender", genderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@phone", Convert.ToInt64(phoneTb.Text));

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Trainer Successfully Added");

                    nameTb.Text = "";
                    phoneTb.Text = "";
                    ageTb.Text = "";
                    genderCb.Text = "";



                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    view_trainer();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //MainForm mf = new MainForm();
            //mf.Show();
            //this.Hide();

            this.Close();
        }

        private void trainerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            trainerDGV.EnableHeadersVisualStyles = false;
            trainerDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            trainerDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void trainerDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.Crimson;
                e.CellStyle.ForeColor = Color.White;
            }
        }

        int key = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0 || nameTb.Text == "" || phoneTb.Text == "" || ageTb.Text == "" || genderCb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {

                    con.Open();
                    string sql = "Update Trainer_info Set T_name=@name, T_age=@age, T_gender=@gender, T_phone=@phone Where T_ID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@name", nameTb.Text);
                    cmd.Parameters.AddWithValue("@age", Convert.ToInt64(ageTb.Text));
                    cmd.Parameters.AddWithValue("@gender", genderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@phone", Convert.ToInt64(phoneTb.Text));

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Trainer updated successfully");
                   

                    nameTb.Text = "";
                    phoneTb.Text = "";
                    ageTb.Text = "";
                    genderCb.Text = "";


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    view_trainer();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            nameTb.Text = "";
            phoneTb.Text = "";
            ageTb.Text = "";
            genderCb.Text = "";
            nameTb.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select the member to be deleted by a double click");
            }
            else
            {
                try
                {

                    con.Open();
                    string sql = "Delete from Trainer_info Where T_ID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member deleted successfully");
                   

                    nameTb.Text = "";
                    phoneTb.Text = "";
                    ageTb.Text = "";
                    genderCb.Text = "";


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    view_trainer();
                }
            }
        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            String sql = "select * from Trainer_info WHERE T_name LIKE '%" + searchTb.Text + "%' ";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            try
            {



                sda.Fill(dt);

                trainerDGV.DataSource = dt;
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
        private void trainerDGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (trainerDGV.SelectedRows.Count >= 0)
                {
                    key = Convert.ToInt32(trainerDGV.SelectedRows[0].Cells[0].Value.ToString());
                    nameTb.Text = trainerDGV.SelectedRows[0].Cells[1].Value.ToString();
                    ageTb.Text = trainerDGV.SelectedRows[0].Cells[2].Value.ToString();
                    genderCb.Text = trainerDGV.SelectedRows[0].Cells[3].Value.ToString();
                    phoneTb.Text = trainerDGV.SelectedRows[0].Cells[4].Value.ToString();
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("invalid selection, please select a row by a double a click");
            }
            finally
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();

            string sql = "select * from Trainer_info";

            SqlDataAdapter sda = new SqlDataAdapter(sql, con);

            SqlCommand cmd = new SqlCommand();

            DataSet ds = new DataSet();
            try
            {
                sda.Fill(ds);
                trainerDGV.DataSource = ds.Tables[0];

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

        private void trainer_Load(object sender, EventArgs e)
        {
            view_trainer();
        }
    }
}
