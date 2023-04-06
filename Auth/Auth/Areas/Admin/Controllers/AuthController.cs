using Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auth.Areas.Admin.Controllers
{
    public class AuthController : Controller
    {
        WEBCAPHE8Entities db = new WEBCAPHE8Entities();
        // GET: Admin/Auth
        public ActionResult Login()
        {
            ViewBag.StrError = "";
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection filed)
        {
            string StrError = "";
            String user = filed["username"];
            String pass = MyString.ToMD5(filed["password"]);

            var objUser = db.Users.Where(n => n.userName == user && n.access == 1 && n.status == 1).FirstOrDefault();
            if (objUser == null)
            {
                StrError = "Tên đăng nhập không tồn tại!";
            }
            else
            {
                if (objUser.passWord.Equals(pass))
                {
                    Session["UserAdmin"] = objUser.userName;
                
                    return RedirectToAction("Index", "DashBoard");
                }
                else
                {
                    StrError = "Mật khẩu không đúng!";
                }
            }
            ViewBag.StrError = StrError;
            return View();
        }
        public ActionResult Logout()
        {
            Session["UserAdmin"] = "";
           
            return Redirect("~/Admin/login");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User _user)
        {
            _user.status = 1;
            _user.access = 1;
            _user.passWord = MyString.ToMD5(_user.passWord);
            db.Users.Add(_user);
            db.SaveChanges();
            return RedirectToAction("Login", "Auth");
        }
    }
}