using System.Data.SqlClient;

namespace Store.Repository
{
    public class SqlConnectionFactory
    {
        private readonly string _cs;
        public SqlConnectionFactory()
        {
            _cs =
                "Server=localhost\\SQLEXPRESS;" +
                "Database=Keno;" +
                "Integrated Security=True;" +
                "TrustServerCertificate=True;";
        }

        public SqlConnection Create()
        {
            return new SqlConnection(_cs);
        }
    }
}
