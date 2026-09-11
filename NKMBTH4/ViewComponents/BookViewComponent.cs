using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using NKMBTH4.Models;

namespace NKMBTH4.ViewComponents
{
    public class BookViewComponent : ViewComponent
    {
        protected Book book = new Book();

        public ViewViewComponentResult Invoke()
        {
            var books = book.GetBookList();
            return View(books);
        }
    }
}