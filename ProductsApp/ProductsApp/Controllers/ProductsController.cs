using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApp.Data;

namespace ProductsApp.Controllers
{
    public class ProductsController : Controller
    {
        ProductsDbContext context;
        public ProductsController(ProductsDbContext _context)
        {
            context = _context;
        }

        public IActionResult Index()
        {
            return View(context.Products.ToList());
        }

        public IActionResult Details(int id)
        {
            var product =  context.Products
            .Include(p => p.Comments)
            .FirstOrDefault(m => m.Id == id);
            return View(product);
        }
    }
}
