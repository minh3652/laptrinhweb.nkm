using Microsoft.AspNetCore.Mvc;
using NKMBTTL4.Data;
using NKMBTTL4.Models;

namespace NKMBTTL4.Controllers
{
    public class HomeController : Controller
    {
        // ==================================================
        // TRANG CHỦ
        // ==================================================

        public IActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();


            // ----------------------------------------------
            // LẤY DANH MỤC
            // ----------------------------------------------

            model.Categories = ProductData.Categories;


            // ----------------------------------------------
            // LẤY 3 SẢN PHẨM MỚI NHẤT
            // ----------------------------------------------

            model.LatestProducts = ProductData.Products
                .OrderByDescending(p => p.CreatedAt)
                .Take(3)
                .ToList();


            // ----------------------------------------------
            // TRẢ MODEL SANG VIEW
            // ----------------------------------------------

            return View(model);
        }
    }
}