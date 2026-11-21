using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nguyenkhacminh241224482_de1.Models;

namespace nguyenkhacminh241224482_de1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly QLTaiSanContext _context;

    public HomeController(ILogger<HomeController> logger, QLTaiSanContext context)
    {
        _logger = logger;
        _context = context;
    }

    // Câu 3: Load dữ liệu từ bảng TaiSan có NguyenGia >= 20 và NguyenGia != null
    public async Task<IActionResult> Index()
    {
        var listTaiSan = await _context.TaiSans
            .Where(t => t.NguyenGia != null && t.NguyenGia >= 20)
            .OrderBy(t => t.MaTs)
            .ToListAsync();

        return View(listTaiSan);
    }

    // Câu 4: AJAX lọc TaiSan theo MaLoai
    // Nếu maLoai == 0 (mục họ tên sinh viên): tải lại danh sách ban đầu (NguyenGia >= 20)
    // Nếu maLoai > 0: tải danh sách tài sản thuộc loại đó
    [HttpGet]
    public async Task<IActionResult> GetTaiSanByLoai(int maLoai)
    {
        List<TaiSan> listTaiSan;
        if (maLoai == 0)
        {
            listTaiSan = await _context.TaiSans
                .Where(t => t.NguyenGia != null && t.NguyenGia >= 20)
                .OrderBy(t => t.MaTs)
                .ToListAsync();
        }
        else
        {
            listTaiSan = await _context.TaiSans
                .Where(t => t.MaLoai == maLoai)
                .OrderBy(t => t.MaTs)
                .ToListAsync();
        }

        return PartialView("nguyenkhacminh_MainContent", listTaiSan);
    }

    [HttpGet]
    public async Task<IActionResult> LocTaiSanTheoLoai(int maLoai)
    {
        return await GetTaiSanByLoai(maLoai);
    }

    // Câu 5: Thêm tài sản mới
    public async Task<IActionResult> Create()
    {
        ViewBag.MaLoai = new SelectList(await _context.LoaiTaiSans.OrderBy(l => l.MaLoai).ToListAsync(), "MaLoai", "TenLoai");
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TaiSan taiSan)
    {
        if (ModelState.IsValid)
        {
            _context.TaiSans.Add(taiSan);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        ViewBag.MaLoai = new SelectList(await _context.LoaiTaiSans.OrderBy(l => l.MaLoai).ToListAsync(), "MaLoai", "TenLoai", taiSan.MaLoai);
        return View(taiSan);
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
}
