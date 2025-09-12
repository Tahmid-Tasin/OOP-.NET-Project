using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Store.Repository
{
    public class CompanyRepository
    {
        private readonly SqlConnectionFactory _factory;

        public CompanyRepository()
        {
            _factory = new SqlConnectionFactory();
        }

        // Insert new company
        public int Insert(Company c)
        {
            string sql = @"
                INSERT INTO dbo.company 
                (name, address_line1, address_line2, city, state, postal_code, country,
                 phone, contact_name, contact_email, is_active)
                VALUES (@nm, @ad1, @ad2, @ct, @st, @pc, @cntry, 
                        @ph, @cname, @cemail, @active);";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@nm", c.Name ?? "");
                cmd.Parameters.AddWithValue("@ad1", c.AddressLine1 ?? "");
                cmd.Parameters.AddWithValue("@ad2", (object)c.AddressLine2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ct", c.City ?? "");
                cmd.Parameters.AddWithValue("@st", (object)c.State ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pc", (object)c.PostalCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cntry", (object)c.Country ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ph", (object)c.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cname", (object)c.ContactName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cemail", (object)c.ContactEmail ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@active", c.IsActive);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Get by ID
        public Company Get(int id)
        {
            const string sql = @"
                SELECT id, name, address_line1, address_line2, city, state, postal_code, country,
                       phone, contact_name, contact_email, is_active, created_at, updated_at
                FROM dbo.company WHERE id = @id;";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                        return MapCompany(rd);
                }
            }
            return null;
        }

        // Get all companies
        public List<Company> GetAll()
        {
            const string sql = @"
                SELECT id, name, address_line1, address_line2, city, state, postal_code, country,
                       phone, contact_name, contact_email, is_active, created_at, updated_at
                FROM dbo.company ORDER BY id DESC;";

            var list = new List<Company>();
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(MapCompany(rd));
                }
            }
            return list;
        }

        // Search with multiple optional filters
        public List<Company> Search(string name, string phone, string address, string city, string postalCode, string contactName)
        {
            var results = new List<Company>();
            var sb = new StringBuilder(@"
                SELECT id, name, address_line1, address_line2, city, state, postal_code, country,
                       phone, contact_name, contact_email, is_active, created_at, updated_at
                FROM dbo.company
                WHERE 1=1 ");

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;

                if (!string.IsNullOrWhiteSpace(name))
                {
                    sb.Append(" AND name LIKE @nm ");
                    cmd.Parameters.AddWithValue("@nm", "%" + name + "%");
                }

                if (!string.IsNullOrWhiteSpace(phone))
                {
                    sb.Append(" AND phone LIKE @ph ");
                    cmd.Parameters.AddWithValue("@ph", "%" + phone + "%");
                }

                if (!string.IsNullOrWhiteSpace(address))
                {
                    sb.Append(" AND (address_line1 LIKE @ad OR address_line2 LIKE @ad) ");
                    cmd.Parameters.AddWithValue("@ad", "%" + address + "%");
                }

                if (!string.IsNullOrWhiteSpace(city))
                {
                    sb.Append(" AND city LIKE @ct ");
                    cmd.Parameters.AddWithValue("@ct", "%" + city + "%");
                }

                if (!string.IsNullOrWhiteSpace(postalCode))
                {
                    sb.Append(" AND postal_code LIKE @pc ");
                    cmd.Parameters.AddWithValue("@pc", "%" + postalCode + "%");
                }

                if (!string.IsNullOrWhiteSpace(contactName))
                {
                    sb.Append(" AND contact_name LIKE @cname ");
                    cmd.Parameters.AddWithValue("@cname", "%" + contactName + "%");
                }

                sb.Append(" ORDER BY id DESC;");
                cmd.CommandText = sb.ToString();

                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        results.Add(MapCompany(rd));
                }
            }

            return results;
        }

        // Update
        public int Update(Company c)
        {
            const string sql = @"
                UPDATE dbo.company
                SET name = @nm,
                    address_line1 = @ad1,
                    address_line2 = @ad2,
                    city = @ct,
                    state = @st,
                    postal_code = @pc,
                    country = @cntry,
                    phone = @ph,
                    contact_name = @cname,
                    contact_email = @cemail,
                    is_active = @active
                WHERE id = @id;";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@nm", c.Name ?? "");
                cmd.Parameters.AddWithValue("@ad1", c.AddressLine1 ?? "");
                cmd.Parameters.AddWithValue("@ad2", (object)c.AddressLine2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ct", c.City ?? "");
                cmd.Parameters.AddWithValue("@st", (object)c.State ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pc", (object)c.PostalCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cntry", (object)c.Country ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ph", (object)c.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cname", (object)c.ContactName ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cemail", (object)c.ContactEmail ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@active", c.IsActive);
                cmd.Parameters.AddWithValue("@id", c.Id);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Delete
        public int Delete(int id)
        {
            const string sql = @"DELETE FROM dbo.company WHERE id = @id;";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Helper mapper
        private Company MapCompany(SqlDataReader rd)
        {
            return new Company
            {
                Id = (int)rd["id"],
                Name = rd["name"].ToString(),
                AddressLine1 = rd["address_line1"].ToString(),
                AddressLine2 = rd["address_line2"] == DBNull.Value ? null : rd["address_line2"].ToString(),
                City = rd["city"].ToString(),
                State = rd["state"] == DBNull.Value ? null : rd["state"].ToString(),
                PostalCode = rd["postal_code"] == DBNull.Value ? null : rd["postal_code"].ToString(),
                Country = rd["country"] == DBNull.Value ? null : rd["country"].ToString(),
                Phone = rd["phone"] == DBNull.Value ? null : rd["phone"].ToString(),
                ContactName = rd["contact_name"] == DBNull.Value ? null : rd["contact_name"].ToString(),
                ContactEmail = rd["contact_email"] == DBNull.Value ? null : rd["contact_email"].ToString(),
                IsActive = (bool)rd["is_active"],
                CreatedAt = (DateTime)rd["created_at"],
                UpdatedAt = (DateTime)rd["updated_at"]
            };
        }
    }
}
