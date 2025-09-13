// File: Repository/EmployeeRepository.cs
using System;
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
            const string sql = @"INSERT INTO dbo.employee (name, mobile, email, password, address, company_id)
                           VALUES (@nm, @mo, @em, @pw, @ad, @companyId);";

            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@nm", e.NAME ?? "");
                cmd.Parameters.AddWithValue("@mo", e.MOBILE ?? "");
                cmd.Parameters.AddWithValue("@em", e.EMAIL ?? "");
                cmd.Parameters.AddWithValue("@pw", e.PASSWORD ?? "");
                cmd.Parameters.AddWithValue("@ad", e.ADDRESS ?? "");
                cmd.Parameters.AddWithValue("@companyId", (object)e.CompanyId ?? DBNull.Value);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public Employee Get(int id)
        {
            const string sql = @"
                SELECT e.id, e.name, e.mobile, e.email, e.password, e.address, e.company_id,
                       c.id AS CompanyId, c.name AS CompanyName, c.address_line1, c.city
                FROM dbo.employee e
                LEFT JOIN dbo.company c ON e.company_id = c.id
                WHERE e.id = @id;";

            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    return rd.Read() ? Map(rd) : null;
                }
            }
        }

        public Employee GetByEmail(string email)
        {
            const string sql = @"
                SELECT e.id, e.name, e.mobile, e.email, e.password, e.address, e.company_id,
                       c.id AS CompanyId, c.name AS CompanyName, c.address_line1, c.city
                FROM dbo.employee e
                LEFT JOIN dbo.company c ON e.company_id = c.id
                WHERE LTRIM(RTRIM(e.email)) = LTRIM(RTRIM(@em));";

            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@em", email ?? "");
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    return rd.Read() ? Map(rd) : null;
                }
            }
        }

        public Employee GetByName(string name)
        {
            const string sql = @"
                SELECT e.id, e.name, e.mobile, e.email, e.password, e.address, e.company_id,
                       c.id AS CompanyId, c.name AS CompanyName, c.address_line1, c.city
                FROM dbo.employee e
                LEFT JOIN dbo.company c ON e.company_id = c.id
                WHERE LTRIM(RTRIM(e.name)) = LTRIM(RTRIM(@nm));";

            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@nm", name ?? "");
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    return rd.Read() ? Map(rd) : null;
                }
            }
        }

        public Employee GetByLoginKey(string userOrEmail)
        {
            if (!string.IsNullOrWhiteSpace(userOrEmail) && userOrEmail.Contains("@"))
                return GetByEmail(userOrEmail);
            var e = GetByName(userOrEmail);
            return e ?? GetByEmail(userOrEmail);
        }

        public bool VerifyByEmail(string email, string password)
        {
            const string sql = @"SELECT TOP 1 1
                           FROM dbo.employee
                           WHERE LTRIM(RTRIM(email)) = LTRIM(RTRIM(@em)) AND password = @pw;";

            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@em", email ?? "");
                cmd.Parameters.AddWithValue("@pw", password ?? "");
                con.Open();
                using (var rd = cmd.ExecuteReader()) return rd.Read();
            }
        }

        public bool VerifyByName(string name, string password)
        {
            const string sql = @"SELECT TOP 1 1
                           FROM dbo.employee
                           WHERE LTRIM(RTRIM(name)) = LTRIM(RTRIM(@nm)) AND password = @pw;";

            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@nm", name ?? "");
                cmd.Parameters.AddWithValue("@pw", password ?? "");
                con.Open();
                using (var rd = cmd.ExecuteReader()) return rd.Read();
            }
        }

        public bool VerifyFlexible(string userOrEmail, string password)
        {
            if (string.IsNullOrWhiteSpace(userOrEmail)) return false;
            if (userOrEmail.Contains("@") && VerifyByEmail(userOrEmail, password)) return true;
            if (VerifyByName(userOrEmail, password)) return true;
            return VerifyByEmail(userOrEmail, password);
        }

        public List<Employee> GetAll()
        {
            const string sql = @"
                SELECT e.id, e.name, e.mobile, e.email, e.address, e.company_id,
                       c.id AS CompanyId, c.name AS CompanyName, c.address_line1, c.city
                FROM dbo.employee e
                LEFT JOIN dbo.company c ON e.company_id = c.id
                ORDER BY e.id DESC;";

            var list = new List<Employee>();
            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read()) list.Add(Map(rd));
                }
            }
            return list;
        }

        public List<Employee> Search(string namePart, string mobilePart, int? companyId = null)
        {
            var results = new List<Employee>();
            var sb = new StringBuilder();
            sb.Append(@"
                SELECT e.id, e.name, e.mobile, e.email, e.address, e.company_id,
                       c.id AS CompanyId, c.name AS CompanyName, c.address_line1, c.city
                FROM dbo.employee e
                LEFT JOIN dbo.company c ON e.company_id = c.id
                WHERE 1=1 ");

            using (var con = _factory.Create())
            using (var cmd = new SqlCommand())
            {
                cmd.Connection = con;

                if (!string.IsNullOrWhiteSpace(namePart))
                {
                    sb.Append(" AND e.name LIKE @nm ");
                    cmd.Parameters.AddWithValue("@nm", "%" + namePart + "%");
                }

                if (!string.IsNullOrWhiteSpace(mobilePart))
                {
                    sb.Append(" AND e.mobile LIKE @mo ");
                    cmd.Parameters.AddWithValue("@mo", "%" + mobilePart + "%");
                }

                if (companyId.HasValue)
                {
                    sb.Append(" AND e.company_id = @companyId ");
                    cmd.Parameters.AddWithValue("@companyId", companyId.Value);
                }

                sb.Append(" ORDER BY e.id DESC;");
                cmd.CommandText = sb.ToString();

                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read()) results.Add(Map(rd));
                }
            }
            return results;
        }

        public int UpdateNoPassword(Employee e)
        {
            const string sql = @"
                UPDATE dbo.employee
                SET name = @nm, mobile = @mo, email = @em, address = @ad, company_id = @companyId
                WHERE id = @id;";

            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@nm", e.NAME ?? "");
                cmd.Parameters.AddWithValue("@mo", e.MOBILE ?? "");
                cmd.Parameters.AddWithValue("@em", e.EMAIL ?? "");
                cmd.Parameters.AddWithValue("@ad", e.ADDRESS ?? "");
                cmd.Parameters.AddWithValue("@companyId", (object)e.CompanyId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", e.ID);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int id)
        {
            const string sql = @"DELETE FROM dbo.employee WHERE id = @id;";
            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        private Employee Map(SqlDataReader rd)
        {
            var emp = new Employee
            {
                ID = Convert.ToInt32(rd["id"]),
                NAME = rd["name"].ToString(),
                MOBILE = rd["mobile"].ToString(),
                EMAIL = rd["email"].ToString(),
                ADDRESS = rd["address"].ToString(),
                // Correct DBNull-safe cast:
                CompanyId = rd["company_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(rd["company_id"]),
            };

            if (rd["CompanyId"] != DBNull.Value)
            {
                emp.Company = new Company
                {
                    Id = Convert.ToInt32(rd["CompanyId"]),
                    Name = rd["CompanyName"].ToString(),
                    AddressLine1 = rd["address_line1"].ToString(),
                    City = rd["city"].ToString()
                };
            }

            return emp;
        }
    }
}
