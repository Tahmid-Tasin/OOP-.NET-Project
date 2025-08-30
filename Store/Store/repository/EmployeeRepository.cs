using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

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
            int rows = cmd.ExecuteNonQuery();
            con.Close();

            return rows;
        }

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
                emp = new Employee
                {
                    ID = (int)rd["id"],
                    NAME = rd["name"].ToString(),
                    MOBILE = rd["mobile"].ToString(),
                    PASSWORD = rd["password"].ToString(),
                    ADDRESS = rd["address"].ToString()
                };
            }

            con.Close();
            return emp;
        }

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

        public List<Employee> GetAll()
        {
            const string sql = @"SELECT id, name, mobile, address
                                 FROM dbo.employee
                                 ORDER BY id DESC;";

            var list = new List<Employee>();

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Employee
                        {
                            ID = (int)rd["id"],
                            NAME = rd["name"].ToString(),
                            MOBILE = rd["mobile"].ToString(),
                            ADDRESS = rd["address"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        public List<Employee> Search(string namePart, string mobilePart)
        {
            var results = new List<Employee>();
            var sb = new StringBuilder();
            sb.Append(@"SELECT id, name, mobile, address
                        FROM dbo.employee
                        WHERE 1=1 ");

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;

                if (!string.IsNullOrWhiteSpace(namePart))
                {
                    sb.Append(" AND name LIKE @nm ");
                    cmd.Parameters.AddWithValue("@nm", "%" + namePart + "%");
                }

                if (!string.IsNullOrWhiteSpace(mobilePart))
                {
                    sb.Append(" AND mobile LIKE @mo ");
                    cmd.Parameters.AddWithValue("@mo", "%" + mobilePart + "%");
                }

                sb.Append(" ORDER BY id DESC;");
                cmd.CommandText = sb.ToString();

                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        results.Add(new Employee
                        {
                            ID = (int)rd["id"],
                            NAME = rd["name"].ToString(),
                            MOBILE = rd["mobile"].ToString(),
                            ADDRESS = rd["address"].ToString()
                        });
                    }
                }
            }

            return results;
        }
    }
}
