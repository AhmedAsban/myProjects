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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackColor = Color.LightGray;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.BackColor = Color.White;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackColor = Color.LightGray;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackColor = Color.White;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //changeIcon();
            this.WindowState = FormWindowState.Maximized;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateDelete update = new UpdateDelete();
            update.Show();
            //this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Payments payment = new Payments();
            payment.Show();
            //this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            //Application.Exit();

            DialogResult result = MessageBox.Show("Are you sure", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            trainer tr = new trainer();
            tr.Show();
            //this.Hide();
        }

        private void button4_MouseEnter_1(object sender, EventArgs e)
        {
            button4.BackColor = Color.LightGray;
        }

        private void button4_MouseLeave_1(object sender, EventArgs e)
        {
            button4.BackColor = Color.White;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ViewMember vm = new ViewMember();
            vm.Show();
            //this.Hide();
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.BackColor = Color.LightGray;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.BackColor = Color.White;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
          
                //// Get the working area of the current screen
                //Screen screen = Screen.PrimaryScreen;
                //Rectangle workingArea = screen.WorkingArea;

                //// Calculate the position to minimize the form to the middle
                //int xPosition = workingArea.Width / 2 - this.Width / 2;
                //int yPosition = workingArea.Height / 2 - this.Height / 2;

                //// Set the form's location and window state
                //this.Location = new Point(xPosition, yPosition);
                this.WindowState = FormWindowState.Minimized;
            
        }


        private void changeIcon()
        {
            // Load the icon file
            Icon icon = new Icon(@"C:\icons\icons8-gym-100.png");

            // Set the form's icon
            this.Icon = icon;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            signUp sup = new signUp();
            sup.Show();
            
        }

        private void button1_MouseEnter_1(object sender, EventArgs e)
        {
            button1.BackColor = Color.LightGray;
        }

        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            button1.BackColor = Color.White;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
