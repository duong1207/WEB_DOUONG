using Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;

namespace Auth.Controllers
{
    public class LoginController : Controller
    {
        WEBCAPHE7Entities db = new WEBCAPHE7Entities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Verify(Account acc)
        {
            foreach (var item in db.User_khach)
            {
                if (acc.Name == item.taikhoan && acc.Password == item.matkhau)
                {
                    return RedirectToAction("Index", "Product");
                }

            }
            return View("Index");
        }
        public ActionResult DangNhap(User_khach user)
        {
            var user2 = db.User_khach.Where(n => n.taikhoan.Equals(user.taikhoan) && n.matkhau.Equals(user.matkhau)).SingleOrDefault();
            if (user2 == null)
            {
                ViewBag.message = "Sai ten nguoi dung hoac mat khau";
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Session["userName"] = user2.taikhoan;
                return RedirectToAction("Index", "product");
            }
        }

        [HttpGet]
        public ActionResult DangKi()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKi(User_khach taikhoan1)
        {

            if (ModelState.IsValid)
            {
                db.User_khach.Add(taikhoan1);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(taikhoan1);
        }
    }
}