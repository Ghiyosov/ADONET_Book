using Infrastructure.Models;
namespace Infrastructure.Interface;

public interface IBookService
{
    List<Book> getBooks();
    Book getBookById(int id);
    void addBook(Book book);
    void updateBook(Book book);
    void deleteBook(int id);
}