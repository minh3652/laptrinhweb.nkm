using Microsoft.AspNetCore.Mvc;
using nkmTH3lab5.Data;
using nkmTH3lab5.Models;

namespace nkmTH3lab5.ViewComponents
{
    public class MajorViewComponent : ViewComponent
    {
        private readonly SchoolContext db;
        private readonly List<Major> majors;

        public MajorViewComponent(SchoolContext _context)
        {
            db = _context;
            majors = db.Majors.ToList();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("RenderMajor", majors);
        }
    }
}

