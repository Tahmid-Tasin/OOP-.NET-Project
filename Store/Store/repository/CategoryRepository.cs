using System.Collections.Generic;
using System.Data.SqlClient;

namespace Store.Repository
{
    public class CategoryRepository
    {
        private readonly SqlConnectionFactory _factory;

        public CategoryRepository()
        {
            _factory = new SqlConnectionFactory();
        }

        public List<Category> GetAll()
        {
            const string sql = @"SELECT id, name FROM dbo.category ORDER BY name ASC;";
            var list = new List<Category>();

            using (SqlConnection con = _factory.Create())
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                con.Open();
                using (SqlDataReader rd = cmd.ExecuteReader())
                {
                    while (rd.Read())
                    {
                        list.Add(new Category
                        {
                            ID = (int)rd["id"],
                            NAME = rd["name"].ToString()
                        });
                    }
                }
            }

            return list;
        }
    }

    public class Category
    {
        public int ID { get; set; }
        public string NAME { get; set; }
    }
}

