using Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace Auth.Controllers
{
    public class AuthKhachController : Controller
    {
        WEBCAPHE8Entities db = new WEBCAPHE8Entities();
        // GET: AuthUser

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Verify(Account acc)
        {
            foreach (var item in db.User_khach)
            {
                if (acc.Name == item.taikhoan && acc.Password == item.matkhau)
                {
                    return RedirectToAction("Index", "Product");
                }
               
            }
            return View("Login");
        }

        public ActionResult RegisterKhach()
        {
            return View();
        }
        [HttpPost]
        public ActionResult RegisterKhach(User_khach uk)
        {
            uk.matkhau = MyString.ToMD5(uk.matkhau);
            db.User_khach.Add(uk);
            db.SaveChanges();
            return RedirectToAction("Login", "Auth");
        }
    }
}