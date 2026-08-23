using btthuchanh.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace btthuchanh.Controllers
{
    public class qlsanphamController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Products = new List<Product> 
            {
                new Product { Id = 1, Name = "Product 1", Price = 500000,CreatedAt ="25-12-2020",Image = "/images/product1.png" },

                new Product { Id = 2, Name = "Product 2", Price = 700000,CreatedAt ="25-12-2020", Image = "/images/product1.png" },

                new Product { Id = 3, Name = "Product 3", Price = 550000,CreatedAt ="25-12-2020", Image = "/images/product1.png" },

                new Product { Id = 4, Name = "Product 4", Price = 550000,CreatedAt ="25-12-2020", Image = "/images/product1.png" }

            };
                return View();
        }
    }

}
