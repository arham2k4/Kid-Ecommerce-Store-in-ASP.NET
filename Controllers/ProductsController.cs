using Microsoft.AspNetCore.Mvc;
using ECommerceMVC.Data;

namespace ECommerceMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products.ToList());
        }

        public IActionResult Details(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }
    }
}