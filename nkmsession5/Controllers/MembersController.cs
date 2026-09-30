using Microsoft.AspNetCore.Mvc;
using nkmsession5.Models.DataModels;
using nkmsession5.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace nkmsession5.Controllers
{
    public class MembersController : Controller
    {
        public static readonly List<Member> members = new List<Member>();

        public IActionResult Index()
        {
            return View(members);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                Member m = new Member
                {
                    MemberId = Guid.NewGuid().ToString(),
                    UserName = register.UserName,
                    FullName = register.FullName,
                    Password = register.Password,
                    Email = register.Email,
                    Phone = register.Phone,
                    Birthday = register.Birthday
                };

                members.Add(m);

                return RedirectToAction("Index");
            }
            else
            {
                return View(register);
            }
        }
    }
}