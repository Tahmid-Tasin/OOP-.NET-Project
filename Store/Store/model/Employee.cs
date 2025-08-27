using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Store
{
    public class Employee
    {
        private string Name;
        private int Id;
        private string Mobile;
        private string Password;
        private string Address;
        public Employee() { }

        public Employee(string a, int b, string c, string d, string e)
        {

            Name = a;
            Id = b;
            Mobile = c;
            Password = d;
            Address = e;
        }

        public string NAME
        {
            get { return Name; }
            set { Name = value; }
        }

        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public string MOBILE
        { get { return Mobile; } 
           set { Mobile = value; } 
        }

        public string PASSWORD
        {
            get { return Password; }
            set { Password = value; }
        }

        public string ADDRESS
        { 
            get { return Address; }
            set { Address = value; }
        
        }
        public void ConnectDB()
        {

            string ConnectionString = "Data Source=LAPTOP-HDHIKD8J\\SQLEXPRESS;Initial Catalog=KENO;Integrated Security=True;TrustServerCertificate=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string Query = "Insert into  Employee(ID,EmpName,Mobile,Passwords,EmpAddress) VALUES('" + ID + "','" + NAME + "','" + MOBILE + "','" + PASSWORD + "','" + ADDRESS + "')";
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Data Saved");
        }
    }
}
