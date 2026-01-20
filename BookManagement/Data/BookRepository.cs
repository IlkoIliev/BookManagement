using BookManagement.Models;
using Microsoft.Data.SqlClient;

namespace BookManagement.Data
{
    public class BookRepository
    {
        private readonly string _connectionString;

        public BookRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Book> GetAll()
        {
            var result = new List<Book>();

            var connection = new SqlConnection(_connectionString);

            var query = "SELECT * FROM Books ORDER BY Id DESC";

            using var command = new SqlCommand(query, connection);

            connection.Open();

            using var reader = command.ExecuteReader();

            while (reader.Read()) 
            {
                result.Add(new Book() 
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Author = reader.GetString(2),
                    Genre = reader.GetString(3),
                    Year = reader.GetInt32(4)
                });
            }

            return result;
        }
    }
}
