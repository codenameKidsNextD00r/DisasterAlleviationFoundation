using DisasterAlleviationFoundationWebApp.Entity;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DisasterAlleviationFoundationWebApp.Services
{
    public class DisasterServices
    {


        public void Insert(Disaster disaster)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Disaster (StartDate, EndDate, Location, Description, AidType) " +
                               "VALUES (@StartDate, @EndDate, @Location, @Description, @AidType)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@StartDate", disaster.StartDate);
                command.Parameters.AddWithValue("@EndDate", disaster.EndDate);
                command.Parameters.AddWithValue("@Location", disaster.Location);
                command.Parameters.AddWithValue("@Description", disaster.Description);
                command.Parameters.AddWithValue("@AidType", disaster.AidType);

                command.ExecuteNonQuery();
            }
        }

        public List<Disaster> Read()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            List<Disaster> disasters = new List<Disaster>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM Disaster";

                SqlCommand command = new SqlCommand(selectQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Disaster disaster = new Disaster
                    {
                        id = int.Parse(reader["id"].ToString()),
                        StartDate = Convert.ToDateTime(reader["StartDate"]),
                        EndDate = Convert.ToDateTime(reader["EndDate"]),
                        Location = reader["Location"].ToString(),
                        Description = reader["Description"].ToString(),
                        AidType = reader["AidType"].ToString()
                    };
                    disasters.Add(disaster);
                }

                reader.Close();
            }
            return disasters;
        }
        public Disaster View(int id)
        {
            var configuration = new ConfigurationBuilder()
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .Build();

            string connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");

            Disaster disaster = new Disaster();
            // Open a connection to the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Disaster WHERE id=@id ";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader != null)
                        {
                            disaster.id = int.Parse(reader["id"].ToString());
                            disaster.StartDate = Convert.ToDateTime(reader["StartDate"]);
                            disaster.EndDate = Convert.ToDateTime(reader["EndDate"]);
                            disaster.Location = reader["Location"].ToString();
                            disaster.Description = reader["Description"].ToString();
                            disaster.AidType = reader["AidType"].ToString();


                        }
                    }
                    return disaster;
                }


            }
        }
        public void AllocateFunds(Disaster disaster)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Disaster SET Amount = @Amount WHERE Id = @Id";
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.Parameters.AddWithValue("@Amount", disaster.Amount);
                command.Parameters.AddWithValue("@Id", disaster.id);
                int rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine("Rows affected: " + rowsAffected);
            }

            }
     
    public void AllocateGoods(Disaster disaster)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

        string connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();
            string updateQuery = "UPDATE Disaster SET NumItems = @NumItems AND GoodsDescription = @GoodsDescription WHERE Id = @Id";
            SqlCommand command = new SqlCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@NumItems", disaster.NumItems);
            command.Parameters.AddWithValue("@GoodsDescription", disaster.GoodsDescription);
            command.Parameters.AddWithValue("@Id", disaster.id);
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine("Rows affected: " + rowsAffected);
        }

        }
    }
}

    
