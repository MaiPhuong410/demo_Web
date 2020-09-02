using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyCuaHang.Models;
namespace QuanLyCuaHang.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        QuanLyWebCoffeeDataContext db = new QuanLyWebCoffeeDataContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DanhSachDanhMuc() //tạo view cho action danhsachdanhmuc
        {
            return View(db.DanhMucs.ToList());
        }

        public ActionResult DanhSachSanPham(int iddm)
        {
            var dsSP = db.SanPhams.Where(x => x.MaDMId == iddm).ToList();
            return PartialView("DanhSachSanPham", dsSP);
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
            return View("ToanBoSP",dsProduct);

        }

        public ActionResult Details(int id)
        {

            SanPham sp = db.SanPhams.FirstOrDefault(p => p.Id == id);
            return View(sp);
        }

        

        public ActionResult DanhMuc_SanPham()
        {
            return View();
        }

    }

}