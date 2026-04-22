using BookStore.Core.Entities;

namespace BookStore.Core.Interfaces;

public interface IGenericRepository<T>
    where T : class
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<bool> SaveChangesAsync();
}

public interface IBookRepository : IGenericRepository<Book>
{
    Task<IEnumerable<Book>> GetBooksWithDetailsAsync();
    Task<Book?> GetBookWithDetailsAsync(int bookId);
    Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId);
    Task<IEnumerable<Book>> SearchBooksAsync(string query);
    Task<IEnumerable<Book>> GetLowStockBooksAsync(int threshold = 5);
}
