using System.Data.SqlClient;

namespace ObuvApp
{
    public static class DBHelper
    {
        // Change "DESKTOP-83LP0DS\NOLA" to your server name from SSMS
        private static readonly string ConnectionString =
            @"Server=DESKTOP-83LP0DS\NOLA;Database=Obuv;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
