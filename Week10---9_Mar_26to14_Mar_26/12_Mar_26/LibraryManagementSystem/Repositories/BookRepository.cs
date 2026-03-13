using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly List<Book> _books;

        public BookRepository()
        {
            _books = new List<Book>
            {
                new Book { Id = 1, Title = "Clean Code", Author = "Robert Martin" },
                new Book { Id = 2, Title = "Design Patterns", Author = "GoF" },
                new Book { Id = 3, Title = "Refactoring", Author = "Martin Fowler" }
            };
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }
    }
}