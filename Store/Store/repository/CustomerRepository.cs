// File: Repository/CustomerRepository.cs
using System;
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
            const string sql = @"INSERT INTO dbo.customer 
                           (full_name, mobile, email, address, password)
                           VALUES (@fn, @mb, @em, @ad, @pw);";

            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@fn", a.FullName ?? "");
                cmd.Parameters.AddWithValue("@mb", a.Mobile ?? "");
                cmd.Parameters.AddWithValue("@em", a.Email ?? "");
                cmd.Parameters.AddWithValue("@ad", a.Address ?? "");
                cmd.Parameters.AddWithValue("@pw", a.Password ?? "");
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public Customer GetByFullName(string fullName)
        {
            const string sql = @"SELECT TOP 1 id, full_name, mobile, email, address, password
                           FROM dbo.customer
                           WHERE LTRIM(RTRIM(full_name)) = LTRIM(RTRIM(@fn));";
            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@fn", fullName ?? "");
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    return rd.Read() ? Map(rd) : null;
                }
            }
        }

        public Customer GetByEmail(string email)
        {
            const string sql = @"SELECT TOP 1 id, full_name, mobile, email, address, password
                           FROM dbo.customer
                           WHERE LTRIM(RTRIM(email)) = LTRIM(RTRIM(@em));";
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

        public Customer GetByLoginKey(string userOrEmail)
        {
            // Prefer email if looks like email; else try full_name, then email fallback.
            if (!string.IsNullOrWhiteSpace(userOrEmail) && userOrEmail.Contains("@"))
                return GetByEmail(userOrEmail);

            var c = GetByFullName(userOrEmail);
            if (c != null) return c;

            return GetByEmail(userOrEmail);
        }

        public bool VerifyByEmail(string email, string password)
        {
            const string sql = @"SELECT TOP 1 1 
                           FROM dbo.customer
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

        public bool VerifyByFullName(string fullName, string password)
        {
            const string sql = @"SELECT TOP 1 1 
                           FROM dbo.customer
                           WHERE LTRIM(RTRIM(full_name)) = LTRIM(RTRIM(@fn)) AND password = @pw;";
            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@fn", fullName ?? "");
                cmd.Parameters.AddWithValue("@pw", password ?? "");
                con.Open();
                using (var rd = cmd.ExecuteReader()) return rd.Read();
            }
        }

        public bool VerifyFlexible(string userOrEmail, string password)
        {
            if (string.IsNullOrWhiteSpace(userOrEmail)) return false;
            // Try email first if it looks like one
            if (userOrEmail.Contains("@") && VerifyByEmail(userOrEmail, password)) return true;
            // Try full name
            if (VerifyByFullName(userOrEmail, password)) return true;
            // Fallback: opposite attempt
            return VerifyByEmail(userOrEmail, password);
        }

        private Customer Map(SqlDataReader rd)
        {
            return new Customer
            {
                Id = Convert.ToInt32(rd["id"]),
                FullName = rd["full_name"].ToString(),
                Mobile = rd["mobile"].ToString(),
                Email = rd["email"].ToString(),
                Address = rd["address"].ToString(),
                Password = rd["password"].ToString()
            };
        }
    }
}
