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

        // ✅ Insert new employee
        public int Insert(Employee e)
        {
            string sql = @"INSERT INTO dbo.employee (name, mobile, email, password, address, outlet_id)
                           VALUES (@nm, @mo, @em, @pw, @ad, @outletId);";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@nm", e.NAME ?? "");
                cmd.Parameters.AddWithValue("@mo", e.MOBILE ?? "");
                cmd.Parameters.AddWithValue("@em", e.EMAIL ?? "");
                cmd.Parameters.AddWithValue("@pw", e.PASSWORD ?? "");
                cmd.Parameters.AddWithValue("@ad", e.ADDRESS ?? "");
                cmd.Parameters.AddWithValue("@outletId", (object)e.OutletId ?? DBNull.Value);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // ✅ Get single employee by ID
        public Employee Get(int id)
        {
            string sql = @"
                SELECT e.id, e.name, e.mobile, e.email, e.password, e.address, e.outlet_id,
                       o.id AS OutletId, o.name AS OutletName, o.address_line1, o.city
                FROM dbo.employee e
                LEFT JOIN dbo.outlet o ON e.outlet_id = o.id
                WHERE e.id = @id;";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();

                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                    {
                        return new Employee
                        {
                            ID = (int)rd["id"],
                            NAME = rd["name"].ToString(),
                            MOBILE = rd["mobile"].ToString(),
                            EMAIL = rd["email"].ToString(),
                            PASSWORD = rd["password"].ToString(),
                            ADDRESS = rd["address"].ToString(),
                            OutletId = rd["outlet_id"] as int?,
                            Outlet = rd["OutletId"] != DBNull.Value ? new Outlet
                            {
                                Id = (int)rd["OutletId"],
                                Name = rd["OutletName"].ToString(),
                                AddressLine1 = rd["address_line1"].ToString(),
                                City = rd["city"].ToString()
                            } : null
                        };
                    }
                }
            }

            return null;
        }

        // ✅ Verify login (email + password)
        public bool Verify(string email, string password)
        {
            string sql = @"SELECT 1
                           FROM dbo.employee
                           WHERE email = @em AND password = @pw;";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@em", email);
                cmd.Parameters.AddWithValue("@pw", password);

                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    return rd.Read();
                }
            }
        }

        // ✅ Get all employees
        public List<Employee> GetAll()
        {
            const string sql = @"
                SELECT e.id, e.name, e.mobile, e.email, e.address, e.outlet_id,
                       o.id AS OutletId, o.name AS OutletName, o.address_line1, o.city
                FROM dbo.employee e
                LEFT JOIN dbo.outlet o ON e.outlet_id = o.id
                ORDER BY e.id DESC;";

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
                            EMAIL = rd["email"].ToString(),
                            ADDRESS = rd["address"].ToString(),
                            OutletId = rd["outlet_id"] as int?,
                            Outlet = rd["OutletId"] != DBNull.Value ? new Outlet
                            {
                                Id = (int)rd["OutletId"],
                                Name = rd["OutletName"].ToString(),
                                AddressLine1 = rd["address_line1"].ToString(),
                                City = rd["city"].ToString()
                            } : null
                        });
                    }
                }
            }

            return list;
        }

        // ✅ Search employees by name, mobile, or outlet
        public List<Employee> Search(string namePart, string mobilePart, int? outletId = null)
        {
            var results = new List<Employee>();
            var sb = new StringBuilder();
            sb.Append(@"
                SELECT e.id, e.name, e.mobile, e.email, e.address, e.outlet_id,
                       o.id AS OutletId, o.name AS OutletName, o.address_line1, o.city
                FROM dbo.employee e
                LEFT JOIN dbo.outlet o ON e.outlet_id = o.id
                WHERE 1=1 ");

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand())
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

                if (outletId.HasValue)
                {
                    sb.Append(" AND e.outlet_id = @outletId ");
                    cmd.Parameters.AddWithValue("@outletId", outletId.Value);
                }

                sb.Append(" ORDER BY e.id DESC;");
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
                            EMAIL = rd["email"].ToString(),
                            ADDRESS = rd["address"].ToString(),
                            OutletId = rd["outlet_id"] as int?,
                            Outlet = rd["OutletId"] != DBNull.Value ? new Outlet
                            {
                                Id = (int)rd["OutletId"],
                                Name = rd["OutletName"].ToString(),
                                AddressLine1 = rd["address_line1"].ToString(),
                                City = rd["city"].ToString()
                            } : null
                        });
                    }
                }
            }

            return results;
        }

        // ✅ Update employee (without changing password)
        public int UpdateNoPassword(Employee e)
        {
            const string sql = @"
                UPDATE dbo.employee
                SET name = @nm, mobile = @mo, email = @em, address = @ad, outlet_id = @outletId
                WHERE id = @id;";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@nm", e.NAME ?? "");
                cmd.Parameters.AddWithValue("@mo", e.MOBILE ?? "");
                cmd.Parameters.AddWithValue("@em", e.EMAIL ?? "");
                cmd.Parameters.AddWithValue("@ad", e.ADDRESS ?? "");
                cmd.Parameters.AddWithValue("@outletId", (object)e.OutletId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", e.ID);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // ✅ Delete employee
        public int Delete(int id)
        {
            const string sql = @"DELETE FROM dbo.employee WHERE id = @id;";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
