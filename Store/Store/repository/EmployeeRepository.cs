using System.Data.SqlClient;

namespace Store.Repository
{
    public class EmployeeRepository
    {
        private readonly SqlConnectionFactory _factory;

        public EmployeeRepository()
        {
            _factory = new SqlConnectionFactory();
        }
        
        public int Insert(Employee e)
        {
            string sql = @"INSERT INTO dbo.employee (name, mobile, password, address)
                           VALUES (@nm, @mo, @pw, @ad);";

            SqlConnection con = _factory.Create();
            SqlCommand cmd = new SqlCommand(sql, con);

            cmd.Parameters.AddWithValue("@nm", e.NAME ?? "");
            cmd.Parameters.AddWithValue("@mo", e.MOBILE ?? "");
            cmd.Parameters.AddWithValue("@pw", e.PASSWORD ?? "");
            cmd.Parameters.AddWithValue("@ad", e.ADDRESS ?? "");

            con.Open();
            int rows = cmd.ExecuteNonQuery(); // should be 1
            con.Close();

            return rows;
        }

        // Get employee by id
        public Employee Get(int id)
        {
            string sql = @"SELECT TOP 1 id, name, mobile, password, address
                           FROM dbo.employee
                           WHERE id = @id;";

            SqlConnection con = _factory.Create();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            Employee emp = null;
            if (rd.Read())
            {
                emp = new Employee();
                emp.ID       = (int)rd["id"];
                emp.NAME     = rd["name"].ToString();
                emp.MOBILE   = rd["mobile"].ToString();
                emp.PASSWORD = rd["password"].ToString();
                emp.ADDRESS  = rd["address"].ToString();
            }

            con.Close();
            return emp;
        }

        // Verify login by mobile + password
        public bool Verify(string mobile, string password)
        {
            string sql = @"SELECT 1
                           FROM dbo.employee
                           WHERE mobile = @mo AND password = @pw;";

            SqlConnection con = _factory.Create();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@mo", mobile);
            cmd.Parameters.AddWithValue("@pw", password);

            con.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            bool ok = rd.Read();
            con.Close();

            return ok;
        }
    }
}
