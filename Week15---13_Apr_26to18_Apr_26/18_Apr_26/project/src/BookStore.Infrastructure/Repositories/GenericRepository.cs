using BookStore.Core.Entities;
using BookStore.Core.Interfaces;
using BookStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Infrastructure.Repositories;

public class GenericRepository<T>(BookStoreDbContext context) : IGenericRepository<T>
    where T : class
{
    protected readonly BookStoreDbContext _context = context;
    protected readonly DbSet<T> _dbSet = context.Set<T>();

    public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);

    public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();

    public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);

    public void Update(T entity) => _dbSet.Update(entity);

    public void Delete(T entity) => _dbSet.Remove(entity);

    public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;
}

public class BookRepository(BookStoreDbContext context)
    : GenericRepository<Book>(context),
        IBookRepository
{
    public async Task<IEnumerable<Book>> GetBooksWithDetailsAsync() =>
        await _dbSet
            .Include(b => b.Category)
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .AsNoTracking()
            .ToListAsync();

    public async Task<Book?> GetBookWithDetailsAsync(int bookId) =>
        await _dbSet
            .Include(b => b.Category)
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .Include(b => b.Reviews)
                .ThenInclude(r => r.User)
            .FirstOrDefaultAsync(b => b.BookId == bookId);

    public async Task<IEnumerable<Book>> GetBooksByCategoryAsync(int categoryId) =>
        await _dbSet.Where(b => b.CategoryId == categoryId).Include(b => b.Author).ToListAsync();

    public async Task<IEnumerable<Book>> SearchBooksAsync(string query) =>
        await _dbSet
            .Where(b => b.Title.Contains(query) || b.Author.Name.Contains(query))
            .Include(b => b.Author)
            .ToListAsync();

    public async Task<IEnumerable<Book>> GetLowStockBooksAsync(int threshold = 5) =>
        await _dbSet.Where(b => b.Stock <= threshold).ToListAsync();
}
