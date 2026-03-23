using Microsoft.AspNetCore.Mvc;
using ShoppingCartMvc.Data;
using ShoppingCartMvc.Models;

namespace ShoppingCartMvc.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            if (!ModelState.IsValid) return View(p);

            _context.Products.Add(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_context.Products.Find(id));
        }

        [HttpPost]
        public IActionResult Edit(Product p)
        {
            _context.Products.Update(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var p = _context.Products.Find(id);
            _context.Products.Remove(p);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}