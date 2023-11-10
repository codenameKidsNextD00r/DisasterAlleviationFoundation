
using DisasterAlleviationFoundationWebApp.Database;
using DisasterAlleviationFoundationWebApp.Entity;
using Microsoft.Data.SqlClient;

namespace DisasterAlleviationFoundationWebApp.Services
{

    public class CategoryServices
    {    
        DBconnection dBconnection = new DBconnection();
        public void Insert(Category category)
        {
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();

            string connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO category (name) VALUES (@Name)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", category.Name);

                command.ExecuteNonQuery();
            }
        }
        public List<Category> Read()
        {

            var configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .Build();

            string connectionString = configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");
            List<Category> categories = new List<Category>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT * FROM category";

                SqlCommand command = new SqlCommand(selectQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Category category = new Category
                    {
                        Name = reader["Name"].ToString(),
                       
                    };
                    categories.Add(category);
                }

                reader.Close();
            }
            return categories;
        }
    }
}
