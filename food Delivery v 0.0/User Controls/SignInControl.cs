﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace food_Delivery_v_0._0
{
    public partial class SignInControl : UserControl
    {
        public SignInControl()
        {
            InitializeComponent();
        }
        Account user = new Account();

        string sqlTable = null; //to get the string of the table which data will be retrieved from
        public static string checker_username;
        private void SignIn_bt_Click(object sender, EventArgs e)
        {
            if (usernametxt.Text == "" || passwordtxt.Text == "")
                MessageBox.Show("Please enter all information", "Sign in error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (customerRadiobox.Checked == false && driverRadiobox.Checked == false && cookRadiobox.Checked == false && checkerRadiobox.Checked == false && adminRadiobox.Checked == false)
            {
                MessageBox.Show("Please enter all information", "Sign in error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    user.con.Open();
                    if (user.con.State == System.Data.ConnectionState.Open) //to avoid database connection errors 
                    {
                        string query = null;
                        if (sqlTable == "Admin")
                            query = "select top 1 * from " + sqlTable + " where Name = '" + usernametxt.Text + "' and Password = '" + passwordtxt.Text + "'";
                        else
                            query = "select top 1 * from " + sqlTable + " where Username = '" + usernametxt.Text + "' and Password = '" + passwordtxt.Text + "'";
                        SqlCommand cmd = new SqlCommand(query, user.con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            MessageBox.Show("sign in successful", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (sqlTable == "Customer")
                            {
                                //the customer's options goes here
                            }
                            else if (sqlTable == "Driver")
                            {
                                //the driver's options goes here
                            }
                            else if (sqlTable == "Cooks")
                            {
                                //cook's options goes here
                            }
                                
                            else if (sqlTable == "Checker")
                            {
                                //Checker's options goes here
                                checker_username = usernametxt.Text;
                                checker_form ch = new checker_form();
                                ch.Show();
                                this.Hide();
                            }
                            else if (sqlTable == "Admin")
                            {
                                //admin's options goes here
                                Admin_form af = new Admin_form();
                                af.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("please enter username and password again", "username or password incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                        MessageBox.Show("Can not open connection to database", "Database connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.ToString(), "Data connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    user.con.Close();
                }
            }
        }

        //the next 4 events to get the table name
        private void customerRadiobox_CheckedChanged(object sender, EventArgs e)
        {
            if (customerRadiobox.Checked == true)
                sqlTable = "Customer";
        }

        private void driverRadiobox_CheckedChanged(object sender, EventArgs e)
        {
            if (driverRadiobox.Checked == true)
                sqlTable = "Driver";
        }

        private void cookRadiobox_CheckedChanged(object sender, EventArgs e)
        {
            if (cookRadiobox.Checked == true)
                sqlTable = "Cooks";
        }

        private void checkerRadiobox_CheckedChanged(object sender, EventArgs e)
        {
            if (checkerRadiobox.Checked == true)
                sqlTable = "Checker";
        }

        private void adminRadiobox_CheckedChanged(object sender, EventArgs e)
        {
            if (adminRadiobox.Checked == true)
                sqlTable = "Admin";
        }

        private void SignInControl_VisibleChanged(object sender, EventArgs e) //to clear all the fields so when it loads again it will not contain old data
        {
            usernametxt.Text = "";
            passwordtxt.Text = "";
            customerRadiobox.Checked = false;
            driverRadiobox.Checked = false;
            checkerRadiobox.Checked = false;
            adminRadiobox.Checked = false;
            cookRadiobox.Checked = false;
        }
    }
}