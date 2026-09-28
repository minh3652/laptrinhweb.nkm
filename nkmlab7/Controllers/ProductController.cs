
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using nkmlab7.Models;

namespace nkmlab7.Controllers
{
    public class ProductController : Controller
    {
        private List<Product> products => StoreData.Products;
        private List<Category> categories => StoreData.Categories;

        private readonly IWebHostEnvironment _environment;

        public ProductController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        // Danh sách sản phẩm
        public IActionResult Index()
        {
            foreach (var product in products)
            {
                product.Category = categories.FirstOrDefault(
                    c => c.Id == product.CategoryId);
            }

            return View(products);
        }

        // Chi tiết sản phẩm
        public IActionResult Details(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            product.Category = categories.FirstOrDefault(
                c => c.Id == product.CategoryId);

            return View(product);
        }

        // Thêm sản phẩm
        public IActionResult Create()
        {
            LoadCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            Product product, IFormFile? ImageFile)
        {
            if (!categories.Any(c => c.Id == product.CategoryId))
            {
                ModelState.AddModelError(
                    "CategoryId", "Vui lòng chọn danh mục hợp lệ.");
            }

            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(product);
            }

            if (ImageFile != null && ImageFile.Length > 0)
            {
                product.Image = await UploadImage(ImageFile);
            }

            product.Id = StoreData.NextProductId++;
            products.Add(product);

            return RedirectToAction("Index");
        }

        // Sửa sản phẩm
        public IActionResult Edit(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            LoadCategories();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            Product product, IFormFile? ImageFile)
        {
            var existing = products.FirstOrDefault(
                p => p.Id == product.Id);

            if (existing == null)
                return NotFound();

            if (!categories.Any(c => c.Id == product.CategoryId))
            {
                ModelState.AddModelError(
                    "CategoryId", "Vui lòng chọn danh mục hợp lệ.");
            }

            if (!ModelState.IsValid)
            {
                LoadCategories();
                return View(product);
            }

            existing.Name = product.Name;
            existing.Price = product.Price;
            existing.SalePrice = product.SalePrice;
            existing.Description = product.Description;
            existing.CategoryId = product.CategoryId;

            if (ImageFile != null && ImageFile.Length > 0)
            {
                existing.Image = await UploadImage(ImageFile);
            }

            return RedirectToAction("Index");
        }

        // Xóa sản phẩm
        public IActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                products.Remove(product);
            }

            return RedirectToAction("Index");
        }

        // Nạp danh mục vào ComboBox
        private void LoadCategories()
        {
            ViewBag.Categories = new SelectList(
                categories, "Id", "Name");
        }

        // Upload ảnh vào wwwroot/products
        private async Task<string> UploadImage(IFormFile file)
        {
            string folder = Path.Combine(
                _environment.WebRootPath, "products");

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string extension = Path.GetExtension(file.FileName);
            string fileName = Guid.NewGuid().ToString() + extension;

            string filePath = Path.Combine(folder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return "/products/" + fileName;
        }
    }
}