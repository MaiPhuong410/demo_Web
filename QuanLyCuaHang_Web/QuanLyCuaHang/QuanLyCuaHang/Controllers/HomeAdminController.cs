using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCuaHang.Controllers
{
    public class HomeAdminController : Controller
    {
        // GET: HomeAdmin
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}