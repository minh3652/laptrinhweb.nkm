using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nguyenkhacminh_241224482_de2.Models;

namespace nguyenkhacminh_241224482_de2.Controllers;

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
    // Tiêu đề của khu vực nội dung được thay thế bằng họ tên sinh viên: NGUYỄN KHẮC MINH
    public async Task<IActionResult> Index(int? maLoai)
    {
        List<TaiSan> listTaiSan;
        string title = "NGUYỄN KHẮC MINH";
        int currentMaLoai = maLoai ?? 0;

        if (currentMaLoai > 0)
        {
            listTaiSan = await _context.TaiSans
                .Where(t => t.MaLoai == currentMaLoai)
                .OrderBy(t => t.MaTs)
                .ToListAsync();

            var loai = await _context.LoaiTaiSans.FindAsync(currentMaLoai);
            if (loai != null)
            {
                title = loai.TenLoai.ToUpper();
            }
        }
        else
        {
            listTaiSan = await _context.TaiSans
                .Where(t => t.NguyenGia != null && t.NguyenGia >= 20)
                .OrderBy(t => t.MaTs)
                .ToListAsync();
        }

        ViewBag.CurrentMaLoai = currentMaLoai;
        ViewBag.SectionTitle = title;
        return View(listTaiSan);
    }

    // Câu 4: Lọc danh sách TaiSan theo MaLoai bằng AJAX (không tải lại toàn bộ trang)
    // maLoai == 0: bấm vào menu họ tên SV -> trả về các tài sản có NguyenGia >= 20
    // maLoai > 0: trả về các tài sản thuộc MaLoai đó
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

    // Câu 5: Chức năng Sửa thông tin tài sản
    // GET: Home/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var taiSan = await _context.TaiSans.FindAsync(id);
        if (taiSan == null)
        {
            return NotFound();
        }

        ViewBag.MaLoai = new SelectList(await _context.LoaiTaiSans.OrderBy(l => l.MaLoai).ToListAsync(), "MaLoai", "TenLoai", taiSan.MaLoai);
        return View(taiSan);
    }

    // POST: Home/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, TaiSan taiSan)
    {
        if (id != taiSan.MaTs)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(taiSan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TaiSans.Any(e => e.MaTs == taiSan.MaTs))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
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
