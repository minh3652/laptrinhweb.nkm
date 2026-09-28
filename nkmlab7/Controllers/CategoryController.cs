
using Microsoft.AspNetCore.Mvc;
using nkmlab7.Models;

namespace nkmlab7.Controllers
{
    public class CategoryController : Controller
    {
        private List<Category> categories => StoreData.Categories;

        public IActionResult Index()
        {
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            category.Id = StoreData.NextCategoryId++;
            categories.Add(category);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
                return View(category);

            var existing = categories.FirstOrDefault(x => x.Id == category.Id);

            if (existing == null)
                return NotFound();

            existing.Name = category.Name;

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var category = categories.FirstOrDefault(x => x.Id == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = categories.FirstOrDefault(x => x.Id == id);

            if (category != null)
            {
                categories.Remove(category);
            }

            return RedirectToAction("Index");
        }
    }
}