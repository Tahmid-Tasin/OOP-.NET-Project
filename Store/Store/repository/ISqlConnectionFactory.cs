using System.Data.SqlClient;

namespace Store.Repository
{
    public class SqlConnectionFactory
    {
        private readonly string _cs;
        public SqlConnectionFactory()
        {
            _cs =
                "Server=103.174.51.134,1433;" +
                "Database=Keno;" +
                "User Id=sa;" +
                "Password=123456@Aa;" +
                "TrustServerCertificate=True;";
        }

        public SqlConnection Create()
        {
            return new SqlConnection(_cs);
        }
    }
}
