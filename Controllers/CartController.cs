using Microsoft.AspNetCore.Mvc;
using ECommerceMVC.Data;
using ECommerceMVC.Models;

namespace ECommerceMVC.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var cart = _context.CartItems.ToList();
            return View(cart);
        }

        public IActionResult AddToCart(int productId)
        {
            var item = _context.CartItems
                .FirstOrDefault(x => x.ProductId == productId);

            if (item == null)
            {
                item = new CartItem
                {
                    ProductId = productId,
                    Quantity = 1
                };

                _context.CartItems.Add(item);
            }
            else
            {
                item.Quantity++;
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            var item = _context.CartItems.Find(id);

            if (item != null)
            {
                _context.CartItems.Remove(item);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}