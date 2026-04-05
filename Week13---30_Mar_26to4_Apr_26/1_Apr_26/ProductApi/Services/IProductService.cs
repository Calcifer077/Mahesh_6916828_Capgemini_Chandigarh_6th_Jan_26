using ProductApi.Models;

namespace ProductApi.Services;

public interface IProductService
{
    Task<List<Product>> GetAll();
    Task<Product?> GetProductByIdAsync(int id);
    Task Add(Product product);
}