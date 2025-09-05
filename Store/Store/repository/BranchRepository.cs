using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Store.Repository
{
    public class BranchRepository
    {
        private readonly SqlConnectionFactory _factory;

        public BranchRepository()
        {
            _factory = new SqlConnectionFactory();
        }

        public int Insert(Branch branch)
        {
            string sql = @"INSERT INTO dbo.branch (outlet_id, name, location)
                           VALUES (@outlet, @nm, @loc);";
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@outlet", branch.OutletID);
                cmd.Parameters.AddWithValue("@nm", branch.Name ?? "");
                cmd.Parameters.AddWithValue("@loc", (object)branch.Location ?? DBNull.Value);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Branch branch)
        {
            string sql = @"UPDATE dbo.branch SET name=@nm, location=@loc WHERE id=@id;";
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", branch.ID);
                cmd.Parameters.AddWithValue("@nm", branch.Name ?? "");
                cmd.Parameters.AddWithValue("@loc", (object)branch.Location ?? DBNull.Value);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int id)
        {
            string sql = @"DELETE FROM dbo.branch WHERE id=@id;";
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Branch> GetByOutlet(int outletId)
        {
            string sql = @"SELECT * FROM dbo.branch WHERE outlet_id=@outlet;";
            var list = new List<Branch>();
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@outlet", outletId);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new Branch
                    {
                        ID = (int)rd["id"],
                        OutletID = (int)rd["outlet_id"],
                        Name = rd["name"].ToString(),
                        Location = rd["location"]?.ToString()
                    });
                }
            }
            return list;
        }
    }
}
