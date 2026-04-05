using ProductApi.Models;
using ProductApi.Repositories;

namespace ProductApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repo;

    public ProductService(IProductRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Product>> GetAll() =>
        await _repo.GetAll();

    public async Task<Product?> GetProductByIdAsync(int id) =>
        await _repo.GetById(id);

    public async Task Add(Product product) =>
        await _repo.Add(product);
}