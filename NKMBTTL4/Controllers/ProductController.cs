using Microsoft.AspNetCore.Mvc;
using NKMBTTL4.Data;

namespace NKMBTTL4.Controllers
{
    public class ProductController : Controller
    {
        // ==================================================
        // DANH SÁCH SẢN PHẨM
        // ==================================================

        public IActionResult Index()
        {
            var products = ProductData.Products
                .OrderByDescending(p => p.CreatedAt)
                .ToList();

            return View(products);
        }


        // ==================================================
        // CHI TIẾT SẢN PHẨM
        // ==================================================

        public IActionResult Details(int id)
        {
            var product = ProductData.Products
                .FirstOrDefault(p => p.Id == id);


            if (product == null)
            {
                return NotFound();
            }


            return View(product);
        }
    }
}