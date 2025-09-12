using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Store.Repository
{
    public class InventoryRepository
    {
        private readonly SqlConnectionFactory _factory;

        public InventoryRepository()
        {
            _factory = new SqlConnectionFactory();
        }

        public int Upsert(Inventory inv)
        {
            string sql = @"
MERGE dbo.inventory AS target
USING (SELECT @company_id AS company_id,
              @branch_id  AS branch_id,
              @product_id AS product_id) AS src
    ON (target.company_id = src.company_id 
        AND target.branch_id = src.branch_id 
        AND target.product_id = src.product_id)
WHEN MATCHED THEN
    UPDATE SET quantity = @qty,
               updated_at = SYSUTCDATETIME()
WHEN NOT MATCHED THEN
    INSERT (company_id, branch_id, product_id, quantity, updated_at)
    VALUES (@company_id, @branch_id, @product_id, @qty, SYSUTCDATETIME());";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@company_id", inv.CompanyId);
                cmd.Parameters.AddWithValue("@branch_id", inv.BranchId);
                cmd.Parameters.AddWithValue("@product_id", inv.ProductId);
                cmd.Parameters.AddWithValue("@qty", inv.Quantity);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public int Delete(int id)
        {
            string sql = @"DELETE FROM dbo.inventory WHERE id = @id;";
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public Inventory Get(int id)
        {
            string sql = @"
SELECT i.id, i.company_id, i.branch_id, i.product_id, i.quantity, i.updated_at,
       c.id AS comp_id, c.name AS comp_name,
       b.id AS branch_id, b.name AS branch_name,
       p.id AS prod_id, p.name AS prod_name, p.brand, p.description, p.price, p.image_path
FROM dbo.inventory i
JOIN dbo.company c ON i.company_id = c.id
JOIN dbo.branch b  ON i.branch_id = b.id
JOIN dbo.product p ON i.product_id = p.id
WHERE i.id = @id;";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                        return MapJoined(rd);
                }
            }
            return null;
        }

        public List<Inventory> GetAll()
        {
            string sql = @"
SELECT i.id, i.company_id, i.branch_id, i.product_id, i.quantity, i.updated_at,
       c.id AS comp_id, c.name AS comp_name,
       b.id AS branch_id, b.name AS branch_name,
       p.id AS prod_id, p.name AS prod_name, p.brand, p.description, p.price, p.image_path
FROM dbo.inventory i
JOIN dbo.company c ON i.company_id = c.id
JOIN dbo.branch b  ON i.branch_id = b.id
JOIN dbo.product p ON i.product_id = p.id
ORDER BY i.id DESC;";

            var list = new List<Inventory>();
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(MapJoined(rd));
                }
            }
            return list;
        }

        public List<Inventory> Search(int? companyId = null, int? branchId = null,
                                      int? productId = null, decimal? minQty = null, decimal? maxQty = null)
        {
            var results = new List<Inventory>();
            string sql = @"
SELECT i.id, i.company_id, i.branch_id, i.product_id, i.quantity, i.updated_at,
       c.id AS comp_id, c.name AS comp_name,
       b.id AS branch_id, b.name AS branch_name,
       p.id AS prod_id, p.name AS prod_name, p.brand, p.description, p.price, p.image_path
FROM dbo.inventory i
JOIN dbo.company c ON i.company_id = c.id
JOIN dbo.branch b  ON i.branch_id = b.id
JOIN dbo.product p ON i.product_id = p.id
WHERE 1=1";

            var cmd = new SqlCommand();

            if (companyId.HasValue)
            {
                sql += " AND i.company_id = @cid ";
                cmd.Parameters.AddWithValue("@cid", companyId.Value);
            }
            if (branchId.HasValue)
            {
                sql += " AND i.branch_id = @bid ";
                cmd.Parameters.AddWithValue("@bid", branchId.Value);
            }
            if (productId.HasValue)
            {
                sql += " AND i.product_id = @pid ";
                cmd.Parameters.AddWithValue("@pid", productId.Value);
            }
            if (minQty.HasValue)
            {
                sql += " AND i.quantity >= @min ";
                cmd.Parameters.AddWithValue("@min", minQty.Value);
            }
            if (maxQty.HasValue)
            {
                sql += " AND i.quantity <= @max ";
                cmd.Parameters.AddWithValue("@max", maxQty.Value);
            }

            sql += " ORDER BY i.id DESC;";
            cmd.CommandText = sql;

            using (SqlConnection con = _factory.Create())
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        results.Add(MapJoined(rd));
                }
            }
            return results;
        }

        private Inventory MapJoined(SqlDataReader rd)
        {
            return new Inventory
            {
                Id = (int)rd["id"],
                CompanyId = (int)rd["company_id"],
                BranchId = (int)rd["branch_id"],
                ProductId = (int)rd["product_id"],
                Quantity = (decimal)rd["quantity"],
                UpdatedAt = (DateTime)rd["updated_at"],

                Company = new Company
                {
                    Id = (int)rd["comp_id"],
                    Name = rd["comp_name"].ToString()
                },
                Branch = new Branch
                {
                    Id = (int)rd["branch_id"],
                    Name = rd["branch_name"].ToString()
                },
                Product = new Product
                {
                    ID = (int)rd["prod_id"],
                    NAME = rd["prod_name"].ToString(),
                    BRAND = rd["brand"].ToString(),
                    DESCRIPTION = rd["description"].ToString(),
                    PRICE = (decimal)rd["price"],
                    IMAGE_PATH = rd["image_path"].ToString()
                }
            };
        }
    }
}
