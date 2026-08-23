using btthuchanh.Models;
using Microsoft.AspNetCore.Mvc;

namespace btthuchanh.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            List<Product> products = new List<Product>();

            products.Add(new Product
                {
                Id = 1,
                Name = "Product 1",
                Image = "/images/product1.png"
            });
            products.Add(new Product
            {
                Id = 2,
                Name = "Product 2",
                Image = "/images/product2.png"
            });
            products.Add(new Product
            {
                Id = 3,
                Name = "Product 3",
                Image = "/images/product3.png"
            });
            products.Add(new Product
            {
                Id = 4,
                Name = "Product 4",
                Image = "/images/product4.png"
            });
            return View(products);
        }
    }
}
