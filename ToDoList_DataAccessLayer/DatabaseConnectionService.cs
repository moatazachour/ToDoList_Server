using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ToDoList_DataAccessLayer
{
    public class DatabaseConnectionService
    {
        private readonly string _connectionString;

        public DatabaseConnectionService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("TodolistDBConnection") 
                ?? throw new ArgumentNullException(nameof(configuration), "Connection string is missing."); ;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
