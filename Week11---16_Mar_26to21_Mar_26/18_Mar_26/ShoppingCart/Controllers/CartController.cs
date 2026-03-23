using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShoppingCartMvc.Models;
using ShoppingCartMvc.Data;

namespace ShoppingCartMvc.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;

        public CartController(AppDbContext context)
        {
            _context = context;
        }

        private List<CartItem> GetCart()
        {
            var data = HttpContext.Session.GetString("Cart");
            return data == null ? new List<CartItem>() : JsonConvert.DeserializeObject<List<CartItem>>(data);
        }

        private void SaveCart(List<CartItem> cart)
        {
            HttpContext.Session.SetString("Cart", JsonConvert.SerializeObject(cart));
        }

        public IActionResult Index()
        {
            return View(GetCart());
        }

        public IActionResult Add(int id)
        {
            var product = _context.Products.Find(id);
            var cart = GetCart();

            var item = cart.FirstOrDefault(x => x.ProductId == id);

            if (item == null)
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Quantity = 1
                });
            }
            else item.Quantity++;

            SaveCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult Increase(int id)
        {
            var cart = GetCart();
            cart.First(x => x.ProductId == id).Quantity++;
            SaveCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult Decrease(int id)
        {
            var cart = GetCart();
            var item = cart.First(x => x.ProductId == id);
            item.Quantity--;

            if (item.Quantity <= 0)
                cart.Remove(item);

            SaveCart(cart);
            return RedirectToAction("Index");
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (!ModelState.IsValid) return View(order);

            _context.Orders.Add(order);
            _context.SaveChanges();

            HttpContext.Session.Remove("Cart");

            return RedirectToAction("Confirmation");
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}