using Microsoft.AspNetCore.Mvc;
using NguyenKhacMinh_241224482_de2023.Models;
using System.Diagnostics;
using System.Linq;
namespace NguyenKhacMinh_241224482_de2023.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLHangHoaContext _context;
        public HomeController(QLHangHoaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.LoaiHangs = _context.LoaiHangs.ToList();

            var hangHoas = _context.HangHoas
                .Where(x => x.Gia >= 100)
                .ToList();

            return View(hangHoas);
        }

        public IActionResult LocHangHoa (int maLoai)
        {
            var hangHoas = _context.HangHoas
                .Where(x => x.Gia >= 100 && x.MaLoai == maLoai)
                .ToList();
            return View("Index", hangHoas);
        }
    }
}
