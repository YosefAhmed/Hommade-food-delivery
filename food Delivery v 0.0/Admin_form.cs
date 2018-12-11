using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace food_Delivery_v_0._0
{
    public partial class Admin_form : Form
    {
        public Admin_form()
        {
            InitializeComponent();
            adminReviews1.BackColor = Color.FromArgb(150, Color.Black);
            adminReviews1.Hide();
            Backbutton.Hide();
            label1.Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            fire f = new fire();
            f.Show();
        }
        
        private void customImageButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void adminReviewButton_Click(object sender, EventArgs e)
        {
            fire_btn.Hide();
            adminReviewButton.Hide();
            Backbutton.Show();
            adminReviews1.Show();
            label1.Show();
        }
        private void Backbutton_Click_1(object sender, EventArgs e)
        {
            fire_btn.Show();
            adminReviewButton.Show();
            Backbutton.Hide();
            adminReviews1.Hide();
            label1.Hide();
        }
        private void customImageButton1_Click_1(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Log out ?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                WelcomeInterface w = new WelcomeInterface();
                w.Show();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
