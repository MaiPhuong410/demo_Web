using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyCuaHang.Models;
namespace QuanLyCuaHang.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo

        QuanLyWebCoffeeDataContext db = new QuanLyWebCoffeeDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ToanBoSP(string searchString)
        {
            //List<SanPham> dsProduct;
            //dsProduct = db.SanPhams.ToList();
            var dsProduct = from sp in db.SanPhams select sp; //câu truy vấn
            if (!String.IsNullOrEmpty(searchString))
            {
                dsProduct = dsProduct.Where(s => s.TenSP.Contains(searchString));
            }
            return View("ToanBoSP", dsProduct);

        }
    }
}