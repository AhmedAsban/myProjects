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
    public partial class ViewMember : Form
    {
        public ViewMember()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source= DESKTOP-RLEGLOP; Initial Catalog= Gym_DB; Integrated Security= True");


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
                //membersDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  

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

        

        private void ViewMember_Load(object sender, EventArgs e)
        {
            
            view_member();
            count_members();
        }

        private void count_members()
        {
            String sql = "SELECT COUNT(*) FROM member_info";

            SqlCommand cmd = new SqlCommand(sql, con);

            con.Open();

            int count = Convert.ToInt32(cmd.ExecuteScalar());

            noOfMembers.Text = count.ToString();

            

            con.Close();

            view_member();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Login log = new Login();
            //log.Show();
            //this.Hide();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            //MainForm mf = new MainForm();
            //mf.Show();
            //this.Hide();

            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void membersDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            membersDGV.EnableHeadersVisualStyles = false;
            membersDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            membersDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void membersDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.Crimson;
                e.CellStyle.ForeColor = Color.White;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void noOfMembers_Click(object sender, EventArgs e)
        {

        }
    }
}
