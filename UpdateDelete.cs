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

namespace Gym_system_management
{
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source= DESKTOP-RLEGLOP; Initial Catalog= Gym_DB; Integrated Security= True");



        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0 || nameTb.Text == "" || phoneTb.Text == "" || ageTb.Text == "" || genderCb.Text == "" || amountTb.Text == "" || timingCb.Text == "")
            {
                MessageBox.Show("Missing information");
            }
            else
            {
                try
                {

                    con.Open();
                    string sql = "Update member_info Set M_name=@name, M_phone=@phone, M_gender=@gender, M_age=@age, M_amount=@amount, M_timing=@timing Where M_ID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(sql, con);

                    cmd.Parameters.AddWithValue("@name", nameTb.Text);
                    cmd.Parameters.AddWithValue("@phone", Convert.ToInt64(phoneTb.Text));
                    cmd.Parameters.AddWithValue("@gender", genderCb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@age", Convert.ToInt32(ageTb.Text));
                    cmd.Parameters.AddWithValue("@amount", Convert.ToInt32(amountTb.Text));
                    cmd.Parameters.AddWithValue("@timing", timingCb.SelectedItem.ToString());

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member updated successfully");
                    

                    nameTb.Text = "";
                    phoneTb.Text = "";
                    ageTb.Text = "";
                    genderCb.Text = "";
                    amountTb.Text = "";
                    timingCb.Text = "";

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    view_member();
                }
            }
        }


        


        private void view_member()
        {
            con.Open();

            string sql = "select * from member_info";

            SqlDataAdapter sda = new SqlDataAdapter(sql, con);

            SqlCommand cmd = new SqlCommand();

            DataSet ds = new DataSet();
            try
            {
                sda.Fill(ds);
                membersDGV.DataSource = ds.Tables[0];

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
        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            view_member();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void membersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            membersDGV.EnableHeadersVisualStyles = false;
            membersDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            membersDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;





        }

        private void membersDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.RowIndex >= 0)
            //    {
            //        nameTb.Text = membersDGV.SelectedRows[0].Cells[1].Value.ToString();
            //        phoneTb.Text = membersDGV.SelectedRows[0].Cells[2].Value.ToString();
            //        genderCb.Text = membersDGV.SelectedRows[0].Cells[3].Value.ToString();
            //        ageTb.Text = membersDGV.SelectedRows[0].Cells[4].Value.ToString();
            //        amountTb.Text = membersDGV.SelectedRows[0].Cells[5].Value.ToString();
            //        timingTb.Text = membersDGV.SelectedRows[0].Cells[6].Value.ToString();
            //    }
            //}
            //catch(Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{

            //}
        }

        int key = 0;

        private void membersDGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (membersDGV.SelectedRows.Count >= 0)
                {
                    key = Convert.ToInt32(membersDGV.SelectedRows[0].Cells[0].Value.ToString());
                    nameTb.Text = membersDGV.SelectedRows[0].Cells[1].Value.ToString();
                    phoneTb.Text = membersDGV.SelectedRows[0].Cells[2].Value.ToString();
                    genderCb.Text = membersDGV.SelectedRows[0].Cells[3].Value.ToString();
                    ageTb.Text = membersDGV.SelectedRows[0].Cells[4].Value.ToString();
                    amountTb.Text = membersDGV.SelectedRows[0].Cells[5].Value.ToString();
                    timingCb.Text = membersDGV.SelectedRows[0].Cells[6].Value.ToString();
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

        private void button2_Click(object sender, EventArgs e)
        {
            nameTb.Text = "";
            phoneTb.Text = "";
            ageTb.Text = "";
            genderCb.Text = "";
            amountTb.Text = "";
            timingCb.Text = "";
            nameTb.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mf = new MainForm();
            mf.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(key == 0)
            {
                MessageBox.Show("Select the member to be deleted by a double click");
            }
            else
            {
                try
                {

                    con.Open();
                    string sql = "Delete from member_info Where M_ID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(sql, con);  
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member deleted successfully");
                    

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
                    view_member();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (nameTb.Text == "" || phoneTb.Text == "" || ageTb.Text == "" || genderCb.Text == "" || amountTb.Text == "" || timingCb.Text == "")
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
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    view_member();
                   
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void searchTb_TextChanged(object sender, EventArgs e)
        {
            con.Open();

            String sql = "select * from member_info WHERE M_name LIKE '%" + searchTb.Text + "%' ";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            try
            {

                

                sda.Fill(dt);

                membersDGV.DataSource = dt;
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

        private void membersDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.Crimson;
                e.CellStyle.ForeColor = Color.White;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //MainForm mf = new MainForm();
            //mf.Show();
            //this.Hide();
            this.Close();
        }

        private void phoneTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
