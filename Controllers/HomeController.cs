using Microsoft.AspNetCore.Mvc;
using ECommerceMVC.Data;
using System.Linq;

namespace ECommerceMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var featuredProducts = _context.Products.Take(4).ToList();
            return View(featuredProducts);
        }
    }
}