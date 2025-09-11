using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Store.Repository
{
    public class InventoryRepository
    {
        private readonly SqlConnectionFactory _factory;
        private readonly CompanyRepository _companyRepo;
        private readonly BranchRepository _branchRepo;
        private readonly ProductRepository _productRepo;

        public InventoryRepository()
        {
            _factory = new SqlConnectionFactory();
            _companyRepo = new CompanyRepository();
            _branchRepo = new BranchRepository();
            _productRepo = new ProductRepository();
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
    INSERT (id, company_id, branch_id, product_id, quantity, updated_at)
    VALUES (@id, @company_id, @branch_id, @product_id, @qty, SYSUTCDATETIME());";

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", inv.Id);
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

        /// <summary>
        /// Eager load Inventory + Company + Branch + Product.
        /// </summary>
        public Inventory Get(int id)
        {
            const string sql = @"SELECT * FROM dbo.inventory WHERE id = @id;";
            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    if (rd.Read())
                        return MapInventory(rd);
                }
            }
            return null;
        }

        public List<Inventory> GetAll()
        {
            const string sql = @"SELECT * FROM dbo.inventory ORDER BY id DESC;";
            var list = new List<Inventory>();

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(MapInventory(rd));
                }
            }
            return list;
        }

        public List<Inventory> Search(int? companyId = null, int? branchId = null,
                                      int? productId = null, decimal? minQty = null, decimal? maxQty = null)
        {
            var results = new List<Inventory>();
            var sql = "SELECT * FROM dbo.inventory WHERE 1=1 ";
            var cmd = new SqlCommand();

            if (companyId.HasValue)
            {
                sql += " AND company_id = @cid ";
                cmd.Parameters.AddWithValue("@cid", companyId.Value);
            }
            if (branchId.HasValue)
            {
                sql += " AND branch_id = @bid ";
                cmd.Parameters.AddWithValue("@bid", branchId.Value);
            }
            if (productId.HasValue)
            {
                sql += " AND product_id = @pid ";
                cmd.Parameters.AddWithValue("@pid", productId.Value);
            }
            if (minQty.HasValue)
            {
                sql += " AND quantity >= @min ";
                cmd.Parameters.AddWithValue("@min", minQty.Value);
            }
            if (maxQty.HasValue)
            {
                sql += " AND quantity <= @max ";
                cmd.Parameters.AddWithValue("@max", maxQty.Value);
            }

            sql += " ORDER BY id DESC;";
            cmd.CommandText = sql;

            using (SqlConnection con = _factory.Create())
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        results.Add(MapInventory(rd));
                }
            }
            return results;
        }

        /// <summary>
        /// Map Inventory and eager-load related objects via repositories.
        /// </summary>
        private Inventory MapInventory(SqlDataReader rd)
        {
            var inv = new Inventory
            {
                Id = (int)rd["id"],
                CompanyId = (int)rd["company_id"],
                BranchId = (int)rd["branch_id"],
                ProductId = (int)rd["product_id"],
                Quantity = (decimal)rd["quantity"],
                UpdatedAt = (DateTime)rd["updated_at"]
            };

            // Fetch related entities via their repositories
            inv.Company = _companyRepo.Get(inv.CompanyId);
            inv.Branch = _branchRepo.Get(inv.BranchId);
            inv.Product = _productRepo.Get(inv.ProductId);

            return inv;
        }
    }
}
