using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace food_Delivery_v_0._0
{

    class Account
    {
        public SqlConnection con = new SqlConnection(@"Data Source=desktop-sd63um7\sqlexpress;Initial Catalog=is_project;Integrated Security=True");
        public  SqlCommand cmd;
        public SqlDataReader sdr;
        //Users data
        public String FullName;
        public String UserName;
        public String Password;
        public String Address;
        public String Gender;
        public int PhoneNumber;
        public String Acc_Type;
        public String Driver_CivilId;
        public String Cook_WorkingHours;

        //Function for pushing data into database tables
        public String Insert_Reg_Data()
        {
            if (Acc_Type == "Cook")
            {
                cmd = new SqlCommand("insert into Cooks(FullName,Username,Password,Gender,phone,Address,isworking) values('" +FullName+ "','" + UserName + "','" + Password + "','" + Gender + "','" + PhoneNumber + "','" + Address + "','" + Cook_WorkingHours + "')",con);
                con.Open(); //opens connection
                cmd.ExecuteNonQuery(); //excutes the command
                con.Close(); //closes connection  
            }
            else if (Acc_Type == "Customer")
            {
                cmd = new SqlCommand("insert into Customer(Username,FullName,Password,Phone,Address,Gender) values('" + UserName + "', '" + FullName + "' ,'" + Password + "','" + PhoneNumber + "','" + Address + "','" + Gender + "')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (Acc_Type == "Driver")
            {
                cmd = new SqlCommand("insert into Driver(Username,FullName,Password,Civil_ID,Phone,Address,Gender) values('" + UserName + "', '" + FullName + "' ,'" + Password + "', '"+ Driver_CivilId +"' ,'" + PhoneNumber + "','" + Address + "','"+Gender+"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            else if (Acc_Type == "Checker")
            {
                cmd = new SqlCommand("insert into Checker(Username,FullName,Password,Phone,Address,Gender) values('" + UserName + "', '" + FullName + "' ,'" + Password + "','" + PhoneNumber + "','" + Address + "','"+ Gender +"')", con);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            return "You have been registered successfully! Now you can sign in.";
        }

        //Function for checking if the current entered username is already existed
        public bool Is_data_Existed()
        {
            SqlDataAdapter Cooks_sda = new SqlDataAdapter("SELECT * FROM Cooks WHERE Username='"+UserName+"' ",con);  //SqlDataAdapter is responsible of filling a new data table
            SqlDataAdapter Customer_sda = new SqlDataAdapter("SELECT * FROM Customer WHERE Username='" + UserName + "' ", con);
            SqlDataAdapter Driver_sda = new SqlDataAdapter("SELECT * FROM Driver WHERE Username='" + UserName + "' ", con);
            SqlDataAdapter Checker_sda = new SqlDataAdapter("SELECT * FROM Checker WHERE Username='" + UserName + "' ", con);
            DataTable dt = new DataTable(); //A new data table to put the username's data in (if existed)
            Cooks_sda.Fill(dt); //Filling the data table with the username's data (if existed)
            Customer_sda.Fill(dt);
            Driver_sda.Fill(dt);
            Checker_sda.Fill(dt);

            if (dt.Rows.Count == 1) //If no. of rows = 1 , it means that there is a username in the database similar to the one that was entered
                return true;
            else
                return false;            
        }

        //Function for checking if a meal is already existed
        public bool check_meal(int Meal_id)
        {
            con.Open();
            cmd = new SqlCommand("select * from Menu  where meal_ID='" + Meal_id + "'", con);
            SqlDataReader RD = cmd.ExecuteReader();

            if (!RD.Read())
            {
                MessageBox.Show("Meal Does Not Exist !", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                con.Close();
                return false;
            }

            else
            {
                con.Close();
                return true;
            }
        }

        //returns number of rows in a tabel
        public string rows_count(string table_Name)
        {
            cmd=new SqlCommand("select count(*) from"+table_Name+"",con);
            con.Open();
            string counter;
                SqlDataReader rd= cmd.ExecuteReader();

            counter=rd[""].ToString();
            con.Close();
            return counter;
        }

        public void done_request(string meal_id)
        {
            cmd = new SqlCommand("delete from check_request where meal_id='" +Convert.ToInt32(meal_id) + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}