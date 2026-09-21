using Microsoft.AspNetCore.Mvc;
using NKmlap6_.Models;

namespace NKmlap6_.Controllers
{
    public class NkmMemberController : Controller
    {
        private static readonly List<NkmMember> _nkmMembers = new List<NkmMember>()
        {
            new NkmMember
            {
                NkmMemberId = "1",
                NkmMemberUserName = "Nguyen Khac Minh",
                NkmMemberPassword = "123456",
                NkmMemberEmail = "nguyenvana@gmail.com",
                NkmMemberPhone = "0901234567"
            },

            new NkmMember
            {
                NkmMemberId = "2",
                NkmMemberUserName = "Nguyen Van B",
                NkmMemberPassword = "123456",
                NkmMemberEmail = "nguyenvanb@gmail.com",
                NkmMemberPhone = "0901234568"
            },

            new NkmMember
            {
                NkmMemberId = "3",
                NkmMemberUserName = "Nguyen Van C",
                NkmMemberPassword = "123456",
                NkmMemberEmail = "nguyenvanc@gmail.com",
                NkmMemberPhone = "0901234569"
            }
        };

        public IActionResult Index()
        {
            return View(_nkmMembers);
        }


        [HttpGet]
        public IActionResult NkmCreate()
        {
            return View("NkmCreate");
        }

        [HttpPost]
        public IActionResult NkmCreate(NkmMember nkmMember)
        {
            nkmMember.NkmMemberId = Guid.NewGuid().ToString();
            _nkmMembers.Add(nkmMember);

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult NkmEdit(string id)
        {
            var nkmMember = _nkmMembers.FirstOrDefault(x => x.NkmMemberId == id);

            if (nkmMember == null)
            {
                return NotFound();
            }

            return View(nkmMember);
        }

        [HttpPost]
        public IActionResult NkmEdit(NkmMember nkmMember)
        {
            var member = _nkmMembers.FirstOrDefault(x => x.NkmMemberId == nkmMember.NkmMemberId);

            if (member == null)
            {
                return NotFound();
            }

            member.NkmMemberUserName = nkmMember.NkmMemberUserName;
            member.NkmMemberPassword = nkmMember.NkmMemberPassword;
            member.NkmMemberEmail = nkmMember.NkmMemberEmail;
            member.NkmMemberPhone = nkmMember.NkmMemberPhone;

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult NkmDelete(string id)
        {
            var nkmMember = _nkmMembers.FirstOrDefault(x => x.NkmMemberId == id);

            if (nkmMember == null)
            {
                return NotFound();
            }

            return View(nkmMember);
        }

        [HttpPost]
        public IActionResult NkmDeleteConfirmed(string id)
        {
            var nkmMember = _nkmMembers.FirstOrDefault(x => x.NkmMemberId == id);

            if (nkmMember == null)
            {
                return NotFound();
            }

            _nkmMembers.Remove(nkmMember);

            return RedirectToAction("Index");
        }

        public IActionResult NkmGetDetails()
        {
            var nkmMember = new NkmMember
            {
                NkmMemberId = "1",
                NkmMemberUserName = "JohnDoe",
                NkmMemberPassword = "password123",
                NkmMemberEmail = "johndoe@example.com",
                NkmMemberPhone = "123-456-7890"
            };

            return View(nkmMember);
        }
    }
}