using Microsoft.AspNetCore.Mvc;
using NKMBTTL4.Data;

namespace NKMBTTL4.ViewComponents
{
    public class HotProductViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            // ==================================================
            // LẤY SẢN PHẨM BÁN CHẠY
            // ==================================================

            var products = ProductData.Products
                .OrderByDescending(p => p.CreatedAt)
                .Skip(3)
                .Take(3)
                .ToList();


            // ==================================================
            // TRẢ VỀ VIEW COMPONENT
            // ==================================================

            return View(products);
        }
    }
}