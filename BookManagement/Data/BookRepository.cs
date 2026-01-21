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

            var query = "SELECT * FROM Books ORDER BY Id ASC";

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

        public Book? GetById(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "SELECT * FROM Books WHERE Id = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", id);
            connection.Open();
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Book()
                {
                    Id = reader.GetInt32(0),
                    Title = reader.GetString(1),
                    Author = reader.GetString(2),
                    Genre = reader.GetString(3),
                    Year = reader.GetInt32(4)
                };
            }
            return null;
        }

        public int Add(Book book)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "INSERT INTO Books (Title, Author, Genre, [Year]) " +
                        "VALUES (@Title, @Author, @Genre, @Year); " +
                        "SELECT SCOPE_IDENTITY();";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@Genre", book.Genre);
            command.Parameters.AddWithValue("@Year", book.Year);
            connection.Open();
            var id = Convert.ToInt32(command.ExecuteScalar());
            return id;
        }

        public bool Update(Book book)
        {
            using var connection = new SqlConnection(_connectionString);
            var query = "UPDATE Books SET Title = @Title, Author = @Author, Genre = @Genre, [Year] = @Year " +
                        "WHERE Id = @Id";
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Id", book.Id);
            command.Parameters.AddWithValue("@Title", book.Title);
            command.Parameters.AddWithValue("@Author", book.Author);
            command.Parameters.AddWithValue("@Genre", book.Genre);
            command.Parameters.AddWithValue("@Year", book.Year);
            connection.Open();
            var rowsAffected = command.ExecuteNonQuery();
            return rowsAffected > 0;
        }
    }
}
