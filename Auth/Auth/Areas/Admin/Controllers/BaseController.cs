using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auth.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            if (System.Web.HttpContext.Current.Session["UserAdmin"].Equals("")) // if == null
            {
                System.Web.HttpContext.Current.Response.Redirect("~/Admin/login");
                //return Redirect("~/Admin/login");
            }
        }
    }
}