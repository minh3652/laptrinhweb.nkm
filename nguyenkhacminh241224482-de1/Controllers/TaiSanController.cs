using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nguyenkhacminh241224482_de1.Models;

namespace nguyenkhacminh241224482_de1.Controllers;

public class TaiSanController : Controller
{
    private readonly QLTaiSanContext _context;

    public TaiSanController(QLTaiSanContext context)
    {
        _context = context;
    }

    // GET: /TaiSan/Create (Câu 5.1 & 5.2)
    public async Task<IActionResult> Create()
    {
        ViewBag.MaLoai = new SelectList(await _context.LoaiTaiSans.OrderBy(l => l.MaLoai).ToListAsync(), "MaLoai", "TenLoai");
        return View();
    }

    // POST: /TaiSan/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TaiSan taiSan)
    {
        if (ModelState.IsValid)
        {
            _context.TaiSans.Add(taiSan);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        ViewBag.MaLoai = new SelectList(await _context.LoaiTaiSans.OrderBy(l => l.MaLoai).ToListAsync(), "MaLoai", "TenLoai", taiSan.MaLoai);
        return View(taiSan);
    }
}
