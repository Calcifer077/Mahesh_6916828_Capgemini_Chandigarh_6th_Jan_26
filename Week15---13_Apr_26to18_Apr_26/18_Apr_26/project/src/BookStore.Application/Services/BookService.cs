using BookStore.Application.DTOs.Books;
using BookStore.Core.Entities;

namespace BookStore.Application.Services;

public class BookService(IBookRepository repo, IMapper mapper, IEmailService emailService)
    : IBookService
{
    public async Task<IEnumerable<BookDto>> GetAllBooksAsync()
    {
        var books = await repo.GetBooksWithDetailsAsync();
        return mapper.Map<IEnumerable<BookDto>>(books);
    }

    public async Task<BookDto?> GetBookByIdAsync(int id)
    {
        var book =
            await repo.GetBookWithDetailsAsync(id)
            ?? throw new KeyNotFoundException($"Book {id} not found");
        return mapper.Map<BookDto>(book);
    }

    public async Task<BookDto> CreateBookAsync(BookCreateDto dto)
    {
        var book = mapper.Map<Book>(dto);
        await repo.AddAsync(book);
        await repo.SaveChangesAsync();

        if (book.Stock <= 5)
            await emailService.SendLowStockAlertAsync(book.Title, book.Stock);

        return mapper.Map<BookDto>(book);
    }

    public async Task UpdateBookAsync(int id, BookUpdateDto dto)
    {
        var book =
            await repo.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Book {id} not found");
        mapper.Map(dto, book);
        repo.Update(book);
        await repo.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(int id)
    {
        var book =
            await repo.GetByIdAsync(id) ?? throw new KeyNotFoundException($"Book {id} not found");
        repo.Delete(book);
        await repo.SaveChangesAsync();
    }
}
