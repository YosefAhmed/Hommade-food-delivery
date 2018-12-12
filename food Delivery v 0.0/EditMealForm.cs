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
    public partial class EditMealForm : Form
    {
        Account user = new Account();
        public EditMealForm()
        {
            InitializeComponent();
            groupBox3.BackColor = Color.FromArgb(150, Color.Black);
            groupBox3.Hide();
            Edit_bt.Hide();
            Cancel_bt.Hide();
        }

        private void EditMealForm_Load(object sender, EventArgs e)
        {
            
        }

        private void Search_bt_Click(object sender, EventArgs e)
        {
            //user.con.Open();
            //SqlDataAdapter sda = new SqlDataAdapter("select MealName from Menu where meal_ID='" + IdSearch_txt.Text + "'", user.con);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //MealName_txt.Text = dt.ToString();
            //user.con.Close();
            //groupBox4.Hide();
            //groupBox3.Show();
        }
    }
}
