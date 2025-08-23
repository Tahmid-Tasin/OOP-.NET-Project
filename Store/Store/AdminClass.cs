using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store
{
    public class AdminClass
    {
        private string Firstname;
        private string Lastname;
        private string userName;
        private string Mobile;
        private string password;

        public AdminClass() { }

        public AdminClass(string a,string b, string c, string d,string e)
        {
            Firstname = a;
            Lastname = b;
            userName = c;
            Mobile = d;
            password = e;
        }

        public string FirstName
        {
            get { return Firstname; }
            set { Firstname = value; }
        }

        public string LastName
        {
            get { return Lastname; }
            set { Lastname = value; }
        }

        public string UserName
        { 
            get { return userName; } 
            set { userName = value; } 
        }

        public string MOBILE
        {
            get { return Mobile; }
            set { Mobile = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public void ConnectionDB()
        {
            string ConnectionString = "Data Source=LAPTOP-HDHIKD8J\\SQLEXPRESS;Initial Catalog=KENO;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string Query = "Insert into Admins_Table (FirstName,LastName,UserName,Mobile,Passwords) VALUES('"+FirstName+"','"+LastName+"','"+UserName+"','"+MOBILE+"','"+Password+"')";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Saved");
        }

        public void verify(string a, string b)
        {
            string user_name, pw;
            string ConnectionString = "Data Source=LAPTOP-HDHIKD8J\\SQLEXPRESS;Initial Catalog=KENO;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string Query = "SELECT * FROM Admins_Table WHERE UserName = '" + a + "' AND Passwords = '" + b + "'";
            SqlDataAdapter sqlog = new SqlDataAdapter(Query,con);
            DataTable dt = new DataTable();
            sqlog.Fill(dt);

            if(dt.Rows.Count > 0 )
            {
                user_name = a;
                pw = b;

                MessageBox.Show("Login Successfull");
                AdminView op = new AdminView();
            }
            else
            {
                MessageBox.Show("Error in Username or Password");
            }

            con.Close();



        }

    }
}
