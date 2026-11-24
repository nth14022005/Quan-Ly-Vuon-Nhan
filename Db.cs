using System.Configuration;
using System.Data.SqlClient;

namespace QLVuonNhan
{
    internal static class Db
    {
        public static string ConnStr =>
            ConfigurationManager.ConnectionStrings["QLVuonNhan"].ConnectionString;

        public static SqlConnection CreateConnection()
            => new SqlConnection(ConnStr);
    }
}
