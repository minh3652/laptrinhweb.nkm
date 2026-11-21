using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using nguyenkhacminh_241224482_de2.Models;

namespace nguyenkhacminh_241224482_de2.ViewComponents;

public class LoaiTaiSanMenuViewComponent : ViewComponent
{
    private readonly QLTaiSanContext _context;

    public LoaiTaiSanMenuViewComponent(QLTaiSanContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var loaiTaiSans = await _context.LoaiTaiSans.OrderBy(l => l.MaLoai).ToListAsync();
        return View(loaiTaiSans);
    }
}
