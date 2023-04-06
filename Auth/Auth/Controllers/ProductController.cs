using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Auth.Models;
using System.Web.UI;
using System.Data.Entity.Core.Common.CommandTrees;
using PagedList;

namespace Auth.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        WEBCAPHE8Entities db=new WEBCAPHE8Entities();
        public ActionResult Index(int? page)
        {
            int pagesize = 9;  //số sản phẩm trên một trang
            int pagenumber = (page ?? 1); //số trang
            List<douong> lsProducts = db.douongs.ToList();
            return View(lsProducts.ToPagedList(pagenumber, pagesize));
        }

        public ViewResult DetailsProduct(string Madouong)
        {
            douong product = db.douongs.SingleOrDefault(n => n.Madouong == Madouong);
            if (product == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(product);
        }
        [HttpGet]
        public ActionResult SearchResults(string searchkey, int? page)
        {
            ViewBag.searchkey = searchkey;
            List<douong> lstSearchResults = db.douongs.Where(n => n.Tendouong.Contains(searchkey)).ToList();

            int pagesize = 9;  //so sp tren 1 trang
            int pagenumber = (page ?? 1); //so trang
            if (lstSearchResults.Count == 0)
            {
                ViewBag.ThongBao = "Không có sản phẩm bạn tìm";
                return View(db.douongs.ToList().ToPagedList(pagenumber, pagesize));
            }
            ViewBag.ThongBao = "Đã tìm thấy" + lstSearchResults.Count.ToString() + " sản phẩm";
            return View(lstSearchResults.OrderBy(n => n.Tendouong).ToPagedList(pagenumber, pagesize));
        }
        public PartialViewResult CategoryPartial()
        {
            return PartialView(db.Loaidouongs.ToList());
        }
        public ActionResult ProductsByCategory(int? page, string Maloai)
        {
            List<douong> lstProducts = db.douongs.Where(n => n.Maloai == Maloai).OrderBy(n => n.Maloai).ToList();
            if (lstProducts.Count == 0)
            {
                ViewBag.Products = "Khong co san pham nay";
                ViewBag.lstProducts = db.douongs.ToList();
            }
            int pagesize = 12;  //số sản phẩm trên một trang
            int pagenumber = (page ?? 1); //số trang

            return View(lstProducts.ToPagedList(pagenumber, pagesize));
        }

    }
}