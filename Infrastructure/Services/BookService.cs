using Npgsql;
using Infrastructure.Interface;
using Infrastructure.Models;

namespace Infrastructure.Services;

public class BookService: IBookService
{
    List<Book> books = new List<Book>();
     string connectionString = @"Server=127.0.0.1;Port=5432;Database=books_db;User Id=postgres;Password=832111;";
    

    public List<Book> getBooks()
    {
        List<Book> lib = new List<Book>();

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
           connection.Open();
           NpgsqlCommand command = connection.CreateCommand();
           command.CommandText = "SELECT * FROM books";
           using (NpgsqlDataReader reader = command.ExecuteReader())
           {
               if (reader.HasRows)
               {
                   while (reader.Read())
                   {
                       Book book = new Book()
                       {
                           Id = reader.GetInt32(0),
                           Title = reader.GetString(1),
                           Author = reader.GetString(2),
                           Description = reader.GetString(3),
                           Price = reader.GetDecimal(4)
                       };
                       lib.Add(book);
                   }
               }
           }
        }
        return lib;
    }

    public Book getBookById(int id)
    {
        List<Book> lib = new List<Book>();

        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM books;";
            using (NpgsqlDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Book book = new Book()
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Author = reader.GetString(2),
                            Description = reader.GetString(3),
                            Price = reader.GetDecimal(4)
                        };
                        lib.Add(book);
                    }
                }
            }
        }
        return lib.FirstOrDefault(x => x.Id == id);
    }

    public void addBook(Book book)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = $@"insert into books(title,author,discription,price)
                                        values ('{book.Title}','{book.Author}','{book.Description}',{book.Price});";
            command.ExecuteNonQuery();
        }
    }

    public void updateBook(Book book)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = $@"update books 
                                    set title='{book.Title}',author='{book.Author}',discription='{book.Description}',price={book.Price}
                                    where id={book.Id};";
            command.ExecuteNonQuery();
        }
        
    }

    public void deleteBook(int idd)
    {
        using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
        {
            connection.Open();
            NpgsqlCommand command = connection.CreateCommand();
            command.CommandText = $"delete from books where id = {idd};";
            command.ExecuteNonQuery();
        }
    }
}