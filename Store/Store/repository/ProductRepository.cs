using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Store.Repository
{
    public class ProductRepository
    {
        private readonly SqlConnectionFactory _factory;

        public ProductRepository()
        {
            _factory = new SqlConnectionFactory();
        }

        public int Insert(Product p)
        {
            string sql = @"INSERT INTO dbo.product 
                          (category_id, name, brand, description, price, barcode, image_path, is_active)
                          VALUES (@cat, @nm, @br, @ds, @pr, @bc, @img, @active);";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@cat", p.CATEGORY_ID);
                cmd.Parameters.AddWithValue("@nm", p.NAME ?? "");
                cmd.Parameters.AddWithValue("@br", p.BRAND ?? "");
                cmd.Parameters.AddWithValue("@ds", p.DESCRIPTION ?? "");
                cmd.Parameters.AddWithValue("@pr", p.PRICE);
                cmd.Parameters.AddWithValue("@bc", (object)p.BARCODE ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@img", (object)p.IMAGE_PATH ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@active", p.IS_ACTIVE);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Update(Product p)
        {
            string sql = @"UPDATE dbo.product
                           SET category_id = @cat,
                               name = @nm,
                               brand = @br,
                               description = @ds,
                               price = @pr,
                               barcode = @bc,
                               image_path = @img,
                               is_active = @active,
                               updated_at = SYSUTCDATETIME()
                           WHERE id = @id;";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", p.ID);
                cmd.Parameters.AddWithValue("@cat", p.CATEGORY_ID);
                cmd.Parameters.AddWithValue("@nm", p.NAME ?? "");
                cmd.Parameters.AddWithValue("@br", p.BRAND ?? "");
                cmd.Parameters.AddWithValue("@ds", p.DESCRIPTION ?? "");
                cmd.Parameters.AddWithValue("@pr", p.PRICE);
                cmd.Parameters.AddWithValue("@bc", (object)p.BARCODE ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@img", (object)p.IMAGE_PATH ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@active", p.IS_ACTIVE);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int id)
        {
            string sql = @"DELETE FROM dbo.product WHERE id = @id;";
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public Product Get(int id)
        {
            string sql = @"SELECT * FROM dbo.product WHERE id = @id;";
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    return Map(rd);
                }
            }
            return null;
        }

        public List<Product> GetAll()
        {
            string sql = @"SELECT * FROM dbo.product ORDER BY id DESC;";
            var list = new List<Product>();

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(Map(rd));
                }
            }
            return list;
        }

        private Product Map(SqlDataReader rd)
        {
            return new Product
            {
                ID = (int)rd["id"],
                CATEGORY_ID = (int)rd["category_id"],
                NAME = rd["name"].ToString(),
                BRAND = rd["brand"].ToString(),
                DESCRIPTION = rd["description"].ToString(),
                PRICE = (decimal)rd["price"],
                BARCODE = rd["barcode"]?.ToString(),
                IMAGE_PATH = rd["image_path"]?.ToString(),
                IS_ACTIVE = (bool)rd["is_active"]
            };
        }
    }
}

