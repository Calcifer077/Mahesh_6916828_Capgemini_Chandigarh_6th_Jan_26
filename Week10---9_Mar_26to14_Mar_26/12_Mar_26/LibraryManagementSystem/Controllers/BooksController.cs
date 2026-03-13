using Microsoft.AspNetCore.Mvc;
using LibraryManagementSystem.Repositories;

namespace LibraryManagementSystem.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _bookRepository;

        // Dependency Injection through constructor
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult Index()
        {
            var books = _bookRepository.GetAllBooks();
            return View(books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookRepository.GetBookById(id);

            if (book == null)
                return NotFound();

            return View(book);
        }
    }
}