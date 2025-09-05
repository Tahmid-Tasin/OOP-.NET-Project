using System.Data.SqlClient;

namespace Store.Repository
{
    public class SqlConnectionFactory
    {
        private readonly string _cs;
        public SqlConnectionFactory()
        {
            _cs =
                "Server=192.168.0.113,1433;" +
                "Database=Keno;" +
                "User Id=sa;" +
                "Password=BS@Dhaka;" +
                "TrustServerCertificate=True;";
        }

        public SqlConnection Create()
        {
            return new SqlConnection(_cs);
        }
    }
}
