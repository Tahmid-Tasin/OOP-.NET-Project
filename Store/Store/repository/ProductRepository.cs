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
            string sql = @"SELECT p.*, pb.Buying_Price
                           FROM dbo.product p
                           LEFT JOIN dbo.ProductBuyingPrice pb
                           ON p.id = pb.Product_ID
                           ORDER BY p.id DESC;";

            var list = new List<Product>();

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    list.Add(MapWithBuyingPrice(rd));
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

        private Product MapWithBuyingPrice(SqlDataReader rd)
        {
            var product = Map(rd);
            if (rd["Buying_Price"] != DBNull.Value)
                product.Buying_Price = (decimal)rd["Buying_Price"];
            return product;
        }

        public List<Product> Search(string name, string brand, string barcode,
            decimal? minPrice, decimal? maxPrice, int? categoryId)
        {
            var results = new List<Product>();
            var sb = new System.Text.StringBuilder("SELECT p.*, pb.Buying_Price FROM dbo.product p LEFT JOIN dbo.ProductBuyingPrice pb ON p.id = pb.Product_ID WHERE 1=1 ");
            var cmd = new SqlCommand();

            if (!string.IsNullOrWhiteSpace(name))
            {
                sb.Append(" AND p.name LIKE @nm ");
                cmd.Parameters.AddWithValue("@nm", "%" + name + "%");
            }

            if (!string.IsNullOrWhiteSpace(brand))
            {
                sb.Append(" AND p.brand LIKE @br ");
                cmd.Parameters.AddWithValue("@br", "%" + brand + "%");
            }

            if (!string.IsNullOrWhiteSpace(barcode))
            {
                sb.Append(" AND p.barcode = @bc ");
                cmd.Parameters.AddWithValue("@bc", barcode);
            }

            if (minPrice.HasValue)
            {
                sb.Append(" AND p.price >= @min ");
                cmd.Parameters.AddWithValue("@min", minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                sb.Append(" AND p.price <= @max ");
                cmd.Parameters.AddWithValue("@max", maxPrice.Value);
            }

            if (categoryId.HasValue)
            {
                sb.Append(" AND p.category_id = @cat ");
                cmd.Parameters.AddWithValue("@cat", categoryId.Value);
            }

            sb.Append(" ORDER BY p.id DESC;");
            cmd.CommandText = sb.ToString();

            using (SqlConnection con = _factory.Create())
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        results.Add(MapWithBuyingPrice(rd));
                    }
                }
            }

            return results;
        }

        // --------------------- NEW METHOD ---------------------
        // Save (insert or update) Buying Price
        public int SaveBuyingPrice(int productId, decimal buyingPrice)
        {
            string sql = @"
                IF EXISTS (SELECT 1 FROM ProductBuyingPrice WHERE Product_ID = @pid)
                    UPDATE ProductBuyingPrice
                    SET Buying_Price = @price
                    WHERE Product_ID = @pid;
                ELSE
                    INSERT INTO ProductBuyingPrice (Product_ID, Buying_Price)
                    VALUES (@pid, @price);
            ";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@pid", productId);
                cmd.Parameters.AddWithValue("@price", buyingPrice);

                con.Open();
                return cmd.ExecuteNonQuery(); // returns number of rows affected
            }
        }
    }
}
