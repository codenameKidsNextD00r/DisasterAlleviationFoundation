using Microsoft.EntityFrameworkCore;

namespace DisasterAlleviationFoundationWebApp.Database
{
    public class DBconnection
    {
        public string Connection()
        {

            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            string connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            return connectionString;
        }

    }
}
