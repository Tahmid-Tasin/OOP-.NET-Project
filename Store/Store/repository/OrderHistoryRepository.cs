// File: Repository/OrderHistoryRepository.cs
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Store.Repository
{
    public class OrderHistoryRepository
    {
        private readonly SqlConnectionFactory _factory;

        public OrderHistoryRepository()
        {
            _factory = new SqlConnectionFactory();
        }

        public int Insert(OrderHistory o)
        {
            const string sql = @"
        INSERT INTO dbo.order_history
        (company_id, branch_id, product_id, product_name, quantity, unit_price, customer_id)
        VALUES (@companyId, @branchId, @productId, @productName, @qty, @price, @custId);";

            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@companyId", o.CompanyId);
                cmd.Parameters.AddWithValue("@branchId", o.BranchId);
                cmd.Parameters.AddWithValue("@productId", (object)o.ProductId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@productName", o.ProductName ?? "");
                cmd.Parameters.AddWithValue("@qty", o.Quantity);
                cmd.Parameters.AddWithValue("@price", o.UnitPrice);
                cmd.Parameters.AddWithValue("@custId", (object)o.CustomerId ?? DBNull.Value);

                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }


        public void InsertBulk(List<OrderHistory> rows)
        {
            if (rows == null || rows.Count == 0) return;

            const string sql = @"
        INSERT INTO dbo.order_history
        (company_id, branch_id, product_id, product_name, quantity, unit_price, customer_id)
        VALUES (@companyId, @branchId, @productId, @productName, @qty, @price, @custId);";

            using (var con = _factory.Create())
            {
                con.Open();

                using (var tx = con.BeginTransaction())
                using (var cmd = new SqlCommand(sql, con, tx))
                {
                    var pCompany = cmd.Parameters.Add("@companyId", SqlDbType.Int);
                    var pBranch  = cmd.Parameters.Add("@branchId", SqlDbType.Int);
                    var pProdId  = cmd.Parameters.Add("@productId", SqlDbType.Int);
                    var pName    = cmd.Parameters.Add("@productName", SqlDbType.NVarChar, 200);
                    var pQty     = cmd.Parameters.Add("@qty", SqlDbType.Decimal);
                    var pPrice   = cmd.Parameters.Add("@price", SqlDbType.Decimal);
                    var pCustId  = cmd.Parameters.Add("@custId", SqlDbType.Int);

                    pQty.Precision = 18; pQty.Scale = 3;
                    pPrice.Precision = 18; pPrice.Scale = 2;

                    try
                    {
                        foreach (var r in rows)
                        {
                            pCompany.Value = r.CompanyId;
                            pBranch.Value  = r.BranchId;
                            pProdId.Value  = (object)r.ProductId ?? DBNull.Value;
                            pName.Value    = r.ProductName ?? "";
                            pQty.Value     = r.Quantity;
                            pPrice.Value   = r.UnitPrice;
                            pCustId.Value  = (object)r.CustomerId ?? DBNull.Value;

                            cmd.ExecuteNonQuery();
                        }
                        tx.Commit();
                    }
                    catch
                    {
                        tx.Rollback();
                        throw;
                    }
                }
            }
        }



        public OrderHistory Get(int id)
        {
            const string sql = @"
                SELECT id, company_id, branch_id, product_id, product_name,
                       quantity, unit_price, created_at
                FROM dbo.order_history
                WHERE id = @id;";

            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    return rd.Read() ? Map(rd) : null;
                }
            }
        }

        public List<OrderHistory> GetAll()
        {
            const string sql = @"
                SELECT id, company_id, branch_id, product_id, product_name,
                       quantity, unit_price, created_at
                FROM dbo.order_history
                ORDER BY id DESC;";

            var list = new List<OrderHistory>();
            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read()) list.Add(Map(rd));
                }
            }
            return list;
        }
        
        private OrderHistory Map(SqlDataReader rd)
        {
            return new OrderHistory
            {
                Id          = Convert.ToInt32(rd["id"]),
                CompanyId   = Convert.ToInt32(rd["company_id"]),
                BranchId    = Convert.ToInt32(rd["branch_id"]),
                ProductId   = rd["product_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(rd["product_id"]),
                ProductName = rd["product_name"].ToString(),
                Quantity    = Convert.ToDecimal(rd["quantity"]),
                UnitPrice   = Convert.ToDecimal(rd["unit_price"]),
                CreatedAt   = Convert.ToDateTime(rd["created_at"]),
                CustomerId  = rd["customer_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(rd["customer_id"])
            };
        }

        
        // File: Repository/OrderHistoryRepository.cs
        public List<OrderHistory> GetByCustomer(int customerId)
        {
            const string sql = @"
        SELECT oh.id,
               oh.company_id,
               c.name AS CompanyName,
               oh.branch_id,
               b.name AS BranchName,
               oh.product_id,
               oh.product_name,
               oh.quantity,
               oh.unit_price,
               (oh.quantity * oh.unit_price) AS Total,   -- ✅ computed
               oh.created_at
        FROM dbo.order_history oh
        LEFT JOIN dbo.company c ON oh.company_id = c.id
        LEFT JOIN dbo.branch b ON oh.branch_id = b.id
        WHERE oh.customer_id = @cid
        ORDER BY oh.created_at DESC;";

            var list = new List<OrderHistory>();
            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@cid", customerId);
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new OrderHistory
                        {
                            Id          = Convert.ToInt32(rd["id"]),
                            CompanyId   = Convert.ToInt32(rd["company_id"]),
                            BranchId    = Convert.ToInt32(rd["branch_id"]),
                            ProductId   = rd["product_id"] == DBNull.Value ? (int?)null : Convert.ToInt32(rd["product_id"]),
                            ProductName = rd["product_name"].ToString(),
                            Quantity    = Convert.ToDecimal(rd["quantity"]),
                            UnitPrice   = Convert.ToDecimal(rd["unit_price"]),
                            CreatedAt   = Convert.ToDateTime(rd["created_at"]),
                            CustomerId  = customerId,

                            // ✅ extra fields
                            CompanyName = rd["CompanyName"].ToString(),
                            BranchName  = rd["BranchName"].ToString(),
                            Total       = Convert.ToDecimal(rd["Total"])
                        });
                    }
                }
            }
            return list;
        }

    }
    


}
