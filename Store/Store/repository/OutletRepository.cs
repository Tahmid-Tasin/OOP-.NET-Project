using System.Collections.Generic;
using System.Data.SqlClient;

namespace Store.Repository
{
    public class OutletRepository
    {
        private readonly SqlConnectionFactory _factory;

        public OutletRepository()
        {
            _factory = new SqlConnectionFactory();
        }

        public int Insert(Outlet outlet)
        {
            string sql = @"INSERT INTO dbo.outlet (name) VALUES (@nm);";
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@nm", outlet.Name ?? "");
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Outlet outlet)
        {
            string sql = @"UPDATE dbo.outlet SET name=@nm WHERE id=@id;";
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", outlet.ID);
                cmd.Parameters.AddWithValue("@nm", outlet.Name ?? "");
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int id)
        {
            string sql = @"DELETE FROM dbo.outlet WHERE id=@id;";
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public Outlet Get(int id)
        {
            string sql = @"SELECT * FROM dbo.outlet WHERE id=@id;";
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    return new Outlet
                    {
                        ID = (int)rd["id"],
                        Name = rd["name"].ToString()
                    };
                }
            }
            return null;
        }

        public List<Outlet> GetAll()
        {
            string sql = @"SELECT * FROM dbo.outlet ORDER BY id DESC;";
            var list = new List<Outlet>();
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(new Outlet
                    {
                        ID = (int)rd["id"],
                        Name = rd["name"].ToString()
                    });
                }
            }
            return list;
        }
    }
}
