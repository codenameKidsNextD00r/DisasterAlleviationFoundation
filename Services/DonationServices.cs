using DisasterAlleviationFoundationWebApp.Entity;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundationWebApp.Services
{
    public class DonationServices
    {

        public void Insert(FundDonation fundDonation)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO FundDonation (FDate, Amount, FDonorName) " +
                               "VALUES (@FDate, @Amount, @FDonorName)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FDate", fundDonation.FDate);
                command.Parameters.AddWithValue("@Amount", fundDonation.Amount);
                command.Parameters.AddWithValue("@FDonorName", fundDonation.FDonorName);

                command.ExecuteNonQuery();
            }
        }
        public void Insert(GoodsDonation goodsDonation)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO GoodsDonation (GDate, NumItems, Description, GDonorName) " +
                               "VALUES (@GDate, @NumItems, @Description, @GDonorName)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@GDate", goodsDonation.GDate);
                command.Parameters.AddWithValue("@NumItems", goodsDonation.NumItems);
                //command.Parameters.AddWithValue("@Category", goodsDonation.category);
                command.Parameters.AddWithValue("@Description", goodsDonation.Description);
                command.Parameters.AddWithValue("@GDonorName", goodsDonation.GDonorName);

                command.ExecuteNonQuery();
            }
        }
        public List<GoodsDonation> ReadGood()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            List<GoodsDonation> goodsDonations = new List<GoodsDonation>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM GoodsDonation";

                SqlCommand command = new SqlCommand(selectQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    GoodsDonation goodsDonation = new GoodsDonation
                    {
                        GDate = Convert.ToDateTime(reader["GDate"]),
                        NumItems = Convert.ToInt32(reader["NumItems"]),
                       
                        Description = reader["Description"].ToString(),
                        GDonorName = reader["GDonorName"].ToString()
                    };
                    goodsDonations.Add(goodsDonation);
                }

                reader.Close();
            }
            return goodsDonations;
        }
        public List<FundDonation> ReadFund()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            List<FundDonation> fundDonations = new List<FundDonation>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM FundDonation";

                SqlCommand command = new SqlCommand(selectQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    FundDonation fundDonation = new FundDonation
                    {
                        FDate = Convert.ToDateTime(reader["FDate"]),
                        Amount = Convert.ToDouble(reader["Amount"]),
                        FDonorName = reader["FDonorName"].ToString()
                    };
                    fundDonations.Add(fundDonation);
                }

                reader.Close();
            }
            return fundDonations;
        }

    }
}
