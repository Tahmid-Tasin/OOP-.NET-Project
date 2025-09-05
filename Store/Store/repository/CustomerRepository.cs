using System.Data.SqlClient;

namespace Store.Repository
{
    public class CustomerRepository
    {
        private readonly SqlConnectionFactory _factory;

        public CustomerRepository()
        {
            _factory = new SqlConnectionFactory();
        }

        public int Insert(Customer a)
        {
            string sql = @"INSERT INTO dbo.customer 
                           (full_name, mobile,email,address, password)
                           VALUES (@fn, @mb, @em, @ad, @pw);";

            SqlConnection con = _factory.Create();
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@fn", a.FullName ?? "");
            cmd.Parameters.AddWithValue("@mb", a.Mobile ?? "");
            cmd.Parameters.AddWithValue("@em", a.Email ?? "");
            cmd.Parameters.AddWithValue("@ad", a.Address ?? "");
            cmd.Parameters.AddWithValue("@pw", a.Password ?? "");

            con.Open();
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            return rows;
        }

        public Customer Get(string full_name)
        {
            string sql = @"SELECT TOP 1 id, full_name, mobile, email, address, password
                           FROM dbo.customer
                           WHERE full_name = @fn;";

            SqlConnection con = _factory.Create();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@fn", full_name);

            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            Customer customer = null;
            if (rd.Read())
            {
                customer = new Customer();
                customer.Id = (int)rd["id"];
                customer.FullName = rd["full_name"].ToString();
                customer.Mobile = rd["mobile"].ToString();
                customer.Email = rd["email"].ToString();
                customer.Address = rd["address"].ToString();
                customer.Password = rd["password"].ToString();
            }

            con.Close();
            return customer;
        }

        public bool Verify(string fullName, string password)
        {
            string sql = @"SELECT 1 
                           FROM dbo.customer
                           WHERE full_name = @fn AND password = @pw;";

            SqlConnection con = _factory.Create();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@fn", fullName);
            cmd.Parameters.AddWithValue("@pw", password);

            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            bool found = rd.Read();
            con.Close();

            return found;
        }
    }
}

