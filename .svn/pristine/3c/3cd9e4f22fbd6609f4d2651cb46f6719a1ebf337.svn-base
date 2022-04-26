using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Operational.Repository
{
    public class Connection
    {
        public static SqlConnection GetConnection()
        {
            var builder = new ConfigurationBuilder().AddJsonFile($"appsettings.json", true, true);
            var config = builder.Build();
            var connectionString = config["SqlConnectionString"];
            SqlConnection con = new(connectionString);
            con.Open(); return con;
        }
    }
}
