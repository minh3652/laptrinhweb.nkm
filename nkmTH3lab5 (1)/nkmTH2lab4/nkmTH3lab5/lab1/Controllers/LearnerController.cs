using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using nkmTH3lab5.Data;
using nkmTH3lab5.Models;

namespace nkmTH3lab5.Controllers
{
    public class LearnerController : Controller
    {
        private readonly SchoolContext db;

        public LearnerController(SchoolContext context)
        {
            db = context;
        }

        // GET: Learner (Index) - Hỗ trợ lọc đồng bộ theo mid (Bài thực hành 5 - Phần 1)
        public IActionResult Index(int? mid)
        {
            if (mid == null || mid == 0)
            {
                var learners = db.Learners.Include(m => m.Major).ToList();
                return View(learners);
            }
            else
            {
                var learners = db.Learners
                    .Where(l => l.MajorID == mid)
                    .Include(m => m.Major)
                    .ToList();
                return View(learners);
            }
        }

        // AJAX: Lọc không đồng bộ Learner theo MajorID (Bài thực hành 5 - Phần 2)
        public IActionResult LearnerByMajorID(int mid)
        {
            var learners = (mid == 0)
                ? db.Learners.Include(m => m.Major).ToList()
                : db.Learners.Where(l => l.MajorID == mid).Include(m => m.Major).ToList();

            return PartialView("LearnerTable", learners);
        }

        // GET: Learner/Create
        public IActionResult Create()
        {
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View();
        }

        // POST: Learner/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstMidName, LastName, MajorID, EnrollmentDate")] Learner learner)
        {
            if (ModelState.IsValid)
            {
                db.Learners.Add(learner);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName");
            return View(learner);
        }

        // GET: Learner/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }
            var learner = db.Learners.Find(id);
            if (learner == null)
            {
                return NotFound();
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        // POST: Learner/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("LearnerID, FirstMidName, LastName, MajorID, EnrollmentDate")] Learner learner)
        {
            if (id != learner.LearnerID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(learner);
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LearnerExists(learner.LearnerID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.MajorID = new SelectList(db.Majors, "MajorID", "MajorName", learner.MajorID);
            return View(learner);
        }

        // GET: Learner/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null || db.Learners == null)
            {
                return NotFound();
            }
            var learner = db.Learners
                .Include(l => l.Major)
                .Include(e => e.Enrollments)
                .FirstOrDefault(m => m.LearnerID == id);

            if (learner == null)
            {
                return NotFound();
            }

            if (learner.Enrollments.Count > 0)
            {
                return Content("This learner has some enrollments, can't delete!");
            }

            return View(learner);
        }

        // POST: Learner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (db.Learners == null)
            {
                return Problem("Entity set 'Learners' is null.");
            }

            int targetId = id;
            if (targetId == 0 && Request.Form.ContainsKey("LearnerID") && int.TryParse(Request.Form["LearnerID"], out int parsedId))
            {
                targetId = parsedId;
            }

            var learner = db.Learners.Find(targetId);
            if (learner != null)
            {
                db.Learners.Remove(learner);
                db.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool LearnerExists(int id)
        {
            return (db.Learners?.Any(e => e.LearnerID == id)).GetValueOrDefault();
        }
    }
}
