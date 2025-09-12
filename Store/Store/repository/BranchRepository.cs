using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Store.Repository
{
    public class BranchRepository
    {
        private readonly SqlConnectionFactory _factory;

        public BranchRepository()
        {
            _factory = new SqlConnectionFactory();
        }

        // Insert new branch
        public int Insert(Branch b)
        {
            string sql = @"
                INSERT INTO dbo.branch 
                (company_id, name, address_line1, address_line2, city, state, postal_code, country,
                 phone, email)
                VALUES (@cid, @nm, @ad1, @ad2, @ct, @st, @pc, @cntry, @ph, @em);";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@cid", b.CompanyId);
                cmd.Parameters.AddWithValue("@nm", b.Name ?? "");
                cmd.Parameters.AddWithValue("@ad1", b.AddressLine1 ?? "");
                cmd.Parameters.AddWithValue("@ad2", (object)b.AddressLine2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ct", b.City ?? "");
                cmd.Parameters.AddWithValue("@st", (object)b.State ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pc", (object)b.PostalCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cntry", (object)b.Country ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ph", (object)b.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@em", (object)b.Email ?? DBNull.Value);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Get branch by ID
        public Branch Get(int id)
        {
            const string sql = @"
                SELECT id, company_id, name, address_line1, address_line2, city, state, postal_code, 
                       country, phone, email, created_at, updated_at
                FROM dbo.branch WHERE id = @id;";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                        return MapBranch(rd);
                }
            }
            return null;
        }

        // Get all branches
        public List<Branch> GetAll()
        {
            const string sql = @"
                SELECT id, company_id, name, address_line1, address_line2, city, state, postal_code, 
                       country, phone, email, created_at, updated_at
                FROM dbo.branch ORDER BY id DESC;";

            var list = new List<Branch>();
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(MapBranch(rd));
                }
            }
            return list;
        }

        // Get branches by company
        public List<Branch> GetByCompany(int companyId)
        {
            const string sql = @"
                SELECT id, company_id, name, address_line1, address_line2, city, state, postal_code, 
                       country, phone, email, created_at, updated_at
                FROM dbo.branch WHERE company_id = @cid ORDER BY id DESC;";

            var list = new List<Branch>();
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@cid", companyId);
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(MapBranch(rd));
                }
            }
            return list;
        }

        // Search with multiple optional filters
        public List<Branch> Search(string name, string city, string phone, string postalCode, int? companyId = null)
        {
            var results = new List<Branch>();
            var sb = new StringBuilder(@"
                SELECT id, company_id, name, address_line1, address_line2, city, state, postal_code, 
                       country, phone, email, created_at, updated_at
                FROM dbo.branch
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

                if (!string.IsNullOrWhiteSpace(city))
                {
                    sb.Append(" AND city LIKE @ct ");
                    cmd.Parameters.AddWithValue("@ct", "%" + city + "%");
                }

                if (!string.IsNullOrWhiteSpace(phone))
                {
                    sb.Append(" AND phone LIKE @ph ");
                    cmd.Parameters.AddWithValue("@ph", "%" + phone + "%");
                }

                if (!string.IsNullOrWhiteSpace(postalCode))
                {
                    sb.Append(" AND postal_code LIKE @pc ");
                    cmd.Parameters.AddWithValue("@pc", "%" + postalCode + "%");
                }

                if (companyId.HasValue)
                {
                    sb.Append(" AND company_id = @cid ");
                    cmd.Parameters.AddWithValue("@cid", companyId.Value);
                }

                sb.Append(" ORDER BY id DESC;");
                cmd.CommandText = sb.ToString();

                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        results.Add(MapBranch(rd));
                }
            }

            return results;
        }

        // Update
        public int Update(Branch b)
        {
            const string sql = @"
                UPDATE dbo.branch
                SET company_id = @cid,
                    name = @nm,
                    address_line1 = @ad1,
                    address_line2 = @ad2,
                    city = @ct,
                    state = @st,
                    postal_code = @pc,
                    country = @cntry,
                    phone = @ph,
                    email = @em
                WHERE id = @id;";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@cid", b.CompanyId);
                cmd.Parameters.AddWithValue("@nm", b.Name ?? "");
                cmd.Parameters.AddWithValue("@ad1", b.AddressLine1 ?? "");
                cmd.Parameters.AddWithValue("@ad2", (object)b.AddressLine2 ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ct", b.City ?? "");
                cmd.Parameters.AddWithValue("@st", (object)b.State ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pc", (object)b.PostalCode ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@cntry", (object)b.Country ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@ph", (object)b.Phone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@em", (object)b.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", b.Id);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Delete
        public int Delete(int id)
        {
            const string sql = @"DELETE FROM dbo.branch WHERE id = @id;";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        // Helper mapper
        private Branch MapBranch(SqlDataReader rd)
        {
            return new Branch
            {
                Id = (int)rd["id"],
                CompanyId = (int)rd["company_id"],
                Name = rd["name"].ToString(),
                AddressLine1 = rd["address_line1"].ToString(),
                AddressLine2 = rd["address_line2"] == DBNull.Value ? null : rd["address_line2"].ToString(),
                City = rd["city"].ToString(),
                State = rd["state"] == DBNull.Value ? null : rd["state"].ToString(),
                PostalCode = rd["postal_code"] == DBNull.Value ? null : rd["postal_code"].ToString(),
                Country = rd["country"] == DBNull.Value ? null : rd["country"].ToString(),
                Phone = rd["phone"] == DBNull.Value ? null : rd["phone"].ToString(),
                Email = rd["email"] == DBNull.Value ? null : rd["email"].ToString(),
                CreatedAt = (DateTime)rd["created_at"],
                UpdatedAt = (DateTime)rd["updated_at"]
            };
        }
    }
}
