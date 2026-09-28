using Microsoft.AspNetCore.Mvc;
using nkmlab7.Models;
using System.Text.RegularExpressions;

namespace nkmlab7.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            List<ModelAccount> accounts = new List<ModelAccount>();

            return View(accounts);
        }

        public ActionResult Create()
        {
            ModelAccount model = new ModelAccount();
            return View(model);
        }
        [AcceptVerbs("Get", "Post")]
        public IActionResult VerifyPhone(string phone)
        {
            Regex _isPhone = new Regex(@"^\d{10}$");

            if (!_isPhone.IsMatch(phone))
            {
                return Json($"Số điện thoại {phone} không hợp lệ");
            }

            return Json(true);
        }
    }
}