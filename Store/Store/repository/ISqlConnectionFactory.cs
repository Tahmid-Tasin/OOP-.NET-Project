using System.Data.SqlClient;

namespace Store.Repository
{
    public class SqlConnectionFactory
    {
        private readonly string _cs;
        public SqlConnectionFactory()
        {
            _cs =
                "Server=localhost,1433;" +
                "Database=Keno;" +
                "User Id=sa;" +
                "Password=Root@123;" +
                "TrustServerCertificate=True;";
        }

        public SqlConnection Create()
        {
            return new SqlConnection(_cs);
        }
    }
}
