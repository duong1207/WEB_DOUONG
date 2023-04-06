using Auth.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auth.Areas.Admin.Controllers
{
    public class DashBoardController : Controller
    {
        WEBCAPHE7Entities db = new WEBCAPHE7Entities();
        public ActionResult Index()
        {
            if (Session["UserAdmin"].Equals("")) // if == null
            {
                return Redirect("~/Admin/login");
               //return RedirectToAction("Auth");
            }
            List<douong> lstProduct = db.douongs.ToList();
            return View(lstProduct);
        }
        // Quản lý nhân viên
        public ActionResult TTNhanVien()
        {
            if (Session["UserAdmin"].Equals("")) // if == null
            {
                return Redirect("~/Admin/login");
                //return RedirectToAction("Auth");
            }
            List<Nhanvien> lstProduct = db.Nhanviens.ToList();
            return View(lstProduct);
        }
        //Thêm sản phẩm
        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Create(douong objProduct)
        {
            db.douongs.Add(objProduct);
            db.SaveChanges();
            return RedirectToAction("Index", "DashBoard");
        }


        // Xóa sản phẩm 

        [HttpGet]
        public ActionResult XoaSanPham(string Madouong)
        {
            douong sanpham = db.douongs.SingleOrDefault(n => n.Madouong == Madouong);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }
        [HttpPost, ActionName("XoaSanPham")]
        public ActionResult XacNhanXoa(String Madouong)
        {
            douong sanpham = db.douongs.SingleOrDefault(n => n.Madouong == Madouong);
            
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            
            db.douongs.Remove(sanpham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        //sửa sản phẩm

        [HttpGet]
        public ActionResult SuaSanPham(string Madouong)
        {
            douong sanpham = db.douongs.Find(Madouong);

            

            return View(sanpham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaSanPham(douong douong1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(douong1).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //Thêm nhân viên
        [HttpGet]
        public ActionResult CreateNV()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateNV(Nhanvien objProduct)
        {
            db.Nhanviens.Add(objProduct);
            db.SaveChanges();
            return RedirectToAction("TTNhanVien", "DashBoard");
        }
        //Xóa nhân viên
        [HttpGet]
        public ActionResult XoaNV(string MaNV)
        {
            Nhanvien nhanvien = db.Nhanviens.SingleOrDefault(n => n.MaNV == MaNV);
            if (nhanvien == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(nhanvien);
        }
        [HttpPost, ActionName("XoaNV")]
        public ActionResult XacNhanXoaNV(String MaNV)
        {
            Nhanvien nhanvien = db.Nhanviens.SingleOrDefault(n => n.MaNV == MaNV);

            if (nhanvien== null)
            {
                Response.StatusCode = 404;
                return null;
            }

            db.Nhanviens.Remove(nhanvien);
            db.SaveChanges();
            return RedirectToAction("TTNhanVien");
        }


        //Sửa nhân viên
        [HttpGet]
        public ActionResult SuaNV(string MaNV)
        {
            Nhanvien nhanvien = db.Nhanviens.Find(MaNV);



            return View(nhanvien);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaNV(Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhanvien).State = EntityState.Modified;
                db.SaveChanges();
            }
            return RedirectToAction("TTNhanVien");
        }
    }
}