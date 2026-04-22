using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductApi.Data;
using ProductApi.Models;
using ProductApi.Services;

namespace ProductApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly BlobService _blobService;

        public ProductController(AppDbContext context, BlobService blobService)
        {
            _context = context;
            _blobService = blobService;
        }

        // GET: api/product
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        // GET: api/product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound(new { message = $"Product with ID {id} not found" });

            return Ok(product);
        }

        // POST: api/product  (multipart/form-data: name, price, file)
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromForm] string name,
            [FromForm] decimal price,
            IFormFile file)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest(new { message = "Name is required" });
            if (price <= 0)
                return BadRequest(new { message = "Price must be greater than 0" });
            if (file == null || file.Length == 0)
                return BadRequest(new { message = "Image file is required" });

            var imageUrl = await _blobService.UploadFileAsync(file);

            var product = new Product
            {
                Name = name,
                Price = price,
                ImageUrl = imageUrl
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product created successfully", product });
        }

        // PUT: api/product/5  (JSON body: { "name": "...", "price": ... })
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Product updated)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound(new { message = $"Product with ID {id} not found" });

            product.Name = updated.Name;
            product.Price = updated.Price;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Product updated successfully", product });
        }

        // DELETE: api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
                return NotFound(new { message = $"Product with ID {id} not found" });

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Product {id} deleted successfully" });
        }
    }
}