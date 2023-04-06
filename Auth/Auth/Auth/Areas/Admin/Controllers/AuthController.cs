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
        WEBCAPHE7Entities db = new WEBCAPHE7Entities();
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
                    Session["UserID"] = objUser.idUser;
                    Session["Name"] = objUser.lastName;
                    Session["Img"] = objUser.img;
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
            Session["UserID"] = "";
            Session["Name"] = "";
            Session["Img"] = "";
            return Redirect("~/Admin/login");
        }
    }
}