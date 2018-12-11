using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace food_Delivery_v_0._0
{
    public partial class checker_requests : UserControl
    {
        public checker_requests()
        {
            InitializeComponent();
        }

        private void mealname_lbl_Click(object sender, EventArgs e)
        {
            
        }
        public void addlbl()
        {
            Label lbl = new Label();
            lbl.Text = "meal Name";
            flowLayoutPanel1.Controls.Add(lbl);
        }
    }
}
