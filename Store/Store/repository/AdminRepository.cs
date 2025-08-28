using System;
using System.Data;
using System.Data.SqlClient;

namespace Store.Repository
{
    public class AdminRepository
    {
        private readonly SqlConnectionFactory _factory;

        public AdminRepository()
        {
            _factory = new SqlConnectionFactory(); 
        }
        
        public int Insert(Admin a)
        {
            string sql = @"INSERT INTO dbo.admin_table 
                           (firstName, lastName, userName, mobile, password)
                           VALUES (@fn, @ln, @un, @mo, @pw);";

            SqlConnection con = _factory.Create();
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@fn", a.FirstName ?? "");
            cmd.Parameters.AddWithValue("@ln", a.LastName ?? "");
            cmd.Parameters.AddWithValue("@un", a.UserName ?? "");
            cmd.Parameters.AddWithValue("@mo", a.Mobile ?? "");
            cmd.Parameters.AddWithValue("@pw", a.Password ?? "");

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            return rows;
        }

        public Admin Get(string userName)
        {
            string sql = @"SELECT TOP 1 id, firstName, lastName, userName, mobile, password
                           FROM dbo.admin_table
                           WHERE userName = @un;";

            SqlConnection con = _factory.Create();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@un", userName);

            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            Admin admin = null;
            if (rd.Read())
            {
                admin = new Admin();
                admin.Id        = (int)rd["id"];
                admin.FirstName = rd["firstName"].ToString();
                admin.LastName  = rd["lastName"].ToString();
                admin.UserName  = rd["userName"].ToString();
                admin.Mobile    = rd["mobile"].ToString();
                admin.Password  = rd["password"].ToString();
            }

            con.Close();
            return admin;
        }
        
        public bool Verify(string userName, string password)
        {
            string sql = @"SELECT 1 
                           FROM dbo.admin_table
                           WHERE userName = @un AND password = @pw;";

            SqlConnection con = _factory.Create();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@un", userName);
            cmd.Parameters.AddWithValue("@pw", password);

            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            bool found = rd.Read();
            con.Close();

            return found;
        }
    }
}
