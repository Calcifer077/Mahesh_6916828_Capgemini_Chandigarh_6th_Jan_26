using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();

        Book GetBookById(int id);
    }
}