using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

using Store.model;
using Store.Repository;

namespace Store.repository
{
    internal class ReviewRepository
    {
        private readonly SqlConnectionFactory _factory;


        public ReviewRepository()
        {
            _factory = new SqlConnectionFactory();
        }

        public int Insert(Review r)
        {
            const string sql = @"INSERT INTO Review (customer_id, comment)
                   OUTPUT INSERTED.review_id VALUES (@customer_id, @comment)";

            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                cmd.Parameters.AddWithValue("@customer_id", r.customer_id);
                cmd.Parameters.AddWithValue("@comment", r.comment ?? "");
                con.Open();
                return cmd.ExecuteNonQuery();
            }
        }

        public List<Review> GetAll()
        {
            const string sql = @"
        SELECT r.review_id, r.comment, r.customer_id,
               c.id AS CustomerId, c.name AS CustomerName, c.email AS CustomerEmail
        FROM dbo.Review r
        LEFT JOIN dbo.Customer c ON r.customer_id = c.id
        ORDER BY r.review_id DESC;";

            var list = new List<Review>();
            using (var con = _factory.Create())
            using (var cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (var rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                        list.Add(Map(rd));
                }
            }
            return list;
        }





        private Review Map(SqlDataReader rd)
        {
            var review = new Review
            {
                review_id = Convert.ToInt32(rd["review_id"]),
                comment = rd["comment"].ToString(),
                // DBNull-safe cast for customer_id
                customer_id = rd["customer_id"] == DBNull.Value ? 0 : Convert.ToInt32(rd["customer_id"])
            };


            return review;
        }


    }
}
