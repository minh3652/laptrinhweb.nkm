using Microsoft.AspNetCore.Mvc;
using nguyenkhacminh__241224482_de2026.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace nguyenkhacminh__241224482_de2026.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLNhaSachContext _context;
        public HomeController(QLNhaSachContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.TheLoais = _context.TheLoais.ToList();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult SachGiaTu100()
        {
            ViewBag.TheLoais = _context.TheLoais.ToList();

            var dsSach = _context.Saches.Where(s => s.Gia >= 100000).ToList();
            return View(dsSach);
        }
        public IActionResult LocSachTheoTheLoai(int maTl)
        {
            var theLoai = _context.TheLoais.FirstOrDefault(tl => tl.MaTl == maTl);
            
            var dsSach = _context.Saches.Where(s => s.MaTl == maTl).ToList();

            ViewBag.TenTheLoai = theLoai?.TenTl;
            return PartialView("Nguyenkhacminh_SachTheoTheLoai", dsSach);
        }
        public IActionResult Create()
        {
            ViewBag.MaTl = new SelectList(_context.TheLoais, "MaTl", "TenTl");
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sach sach)
      
        {
            if(ModelState.IsValid)
            {
                _context.Saches.Add(sach);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaTl = new SelectList(_context.TheLoais.ToList(), "MaTl", "TenTl", sach.MaTl);
            return View(sach);
        }
    }
}
