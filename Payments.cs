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
    public partial class Payments : Form
    {
        public Payments()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source= DESKTOP-RLEGLOP; Initial Catalog= Gym_DB; Integrated Security= True");

        private void FillName()
        {
            con.Open();

            string sql = ("select M_name From member_info ");

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();  

            DataTable dt = new DataTable();

            try
            {

                dt.Columns.Add("M_name", typeof(string));
                dt.Load(sdr);
                nameCb.ValueMember = "M_name";
                //this.paymentDGV.Sort(this.paymentDGV.Columns["M_name"], ListSortDirection.Ascending);
                nameCb.DataSource = dt;
                

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



        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void filterByName()
        {
            con.Open();

            String sql = "select * from Payment_info WHERE P_member LIKE '%" + searchName.Text + "%' ";

            SqlCommand cmd = new SqlCommand(sql, con);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            try
            {



                sda.Fill(dt);

                paymentDGV.DataSource = dt;
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

        private void view_payment()
        {
            con.Open();

            string sql = "select * from Payment_info";

            SqlDataAdapter sda = new SqlDataAdapter(sql, con);

            SqlCommand cmd = new SqlCommand();

            DataSet ds = new DataSet();
            try
            {
                sda.Fill(ds);
                paymentDGV.DataSource = ds.Tables[0];
                //membersDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;  

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
            dateAmount.Value = DateTime.Today;
            nameCb.Text = "";
            amountTb.Text = "";

        }

        private void Payments_Load(object sender, EventArgs e)
        {
            FillName();
            view_payment();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if(nameCb.Text == "" || amountTb.Text == "")
            {
                MessageBox.Show("Missing informatiom");
            }
            else
            {
                try
                {
                    string payAmountDate = dateAmount.Value.Day.ToString() + "/" + dateAmount.Value.Month.ToString() + "/" + dateAmount.Value.Year.ToString();
                con.Open();
                string sql = "select count(*) from Payment_info where P_member='"+nameCb.SelectedValue.ToString()+"' and P_month='"+payAmountDate+"' ";
                SqlDataAdapter sda = new SqlDataAdapter(sql, con);


                DataTable dt = new DataTable();
                sda.Fill(dt);

                
                    //if (dt.Rows[0][0].ToString() == "1")
                    //{
                    //    MessageBox.Show("Already paid for this month");
                    //}
                    //else
                    //{
                       
                        string query = "Insert into Payment_info values('" + payAmountDate + "','" + nameCb.SelectedValue.ToString() + "'," + amountTb.Text + " )";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Amount paid successfully");
                    //}
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    con.Close();
                    view_payment();
                   
                }

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button5_Click(object sender, EventArgs e)
        {
            view_payment();
        }

        private void searchName_TextChanged(object sender, EventArgs e)
        {
            filterByName();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //MainForm mf = new MainForm();
            //mf.Show();
            //this.Hide();

            this.Close();
        }

        private void paymentDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            paymentDGV.EnableHeadersVisualStyles = false;
            paymentDGV.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            paymentDGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void paymentDGV_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.Crimson;
                e.CellStyle.ForeColor = Color.White;
            }
        }

        int key = 0;

        private void button3_Click_1(object sender, EventArgs e)
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
                    string sql = "Delete from Payment_info Where P_ID=" + key + ";";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member deleted successfully");
                    

                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    con.Close();
                    view_payment();
                }
            }
        }

        private void paymentDGV_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            try
            {
                if (paymentDGV.SelectedRows.Count >= 0)
                {
                    key = Convert.ToInt32(paymentDGV.SelectedRows[0].Cells[0].Value.ToString());
                   dateAmount.Text = paymentDGV.SelectedRows[0].Cells[1].Value.ToString();
                    nameCb.Text = paymentDGV.SelectedRows[0].Cells[2].Value.ToString();
                    amountTb.Text = paymentDGV.SelectedRows[0].Cells[3].Value.ToString();
         
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {

            }
        }

        private void nameCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.paymentDGV.Sort(this.paymentDGV.Columns["P_member"], ListSortDirection.Ascending);
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
            
        }
    }
}
