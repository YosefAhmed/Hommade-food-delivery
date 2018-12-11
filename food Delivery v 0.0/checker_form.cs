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

namespace food_Delivery_v_0._0
{
    
    public partial class checker_form : Form
    {
        Account user = new Account();
        public checker_form()
        {
            InitializeComponent();
            checker_requests1.Hide();
            notification_lbl.Hide();
          //  notification_lbl.Text="you have " +user.rows_count("Checker")+" requests";
        }
        
        private void customImageButton2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();
        }

        private void customImageButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to Log out ?", "Log out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                WelcomeInterface w = new WelcomeInterface();
                w.Show();
            }
        }
        int i = 0;
        private void customImageButton3_Click(object sender, EventArgs e)
        {
            if(i==0)
            {
                checker_requests1.Show();
                notification_lbl.Show();
                i = 1;
            }
            else if (i == 1)
            {
                checker_requests1.Hide();
                notification_lbl.Show();
                i = 0;
            }
            user.cmd=new SqlCommand("select meal_id from check_request where checker_id='"+SignInControl.checker_username+"'",user.con);
            user.con.Open();
           SqlDataReader dr = user.cmd.ExecuteReader() ;
            
           while (dr.HasRows)
           {
                   Label mealname = new Label();
                   mealname.Text = "" + user.select_meal_requested()+"";
                   checker_requests1.flowLayoutPanel1.Controls.Add(mealname);  
                    
           }
           user.con.Close();
            //Label mealname=new Label();
            // mealname.Text = "MealName";     
            //checker_requests1.flowLayoutPanel1.Controls.Add(mealname);          
        }
    }
}
