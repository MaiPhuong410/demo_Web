using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyCuaHang.Models;
namespace QuanLyCuaHang.Controllers
{
    public class DanhMucController : Controller
    {
        // GET: DanhMuc
        QuanLyWebCoffeeDataContext db = new QuanLyWebCoffeeDataContext();
        public ActionResult Index()
        {
            List<DanhMuc> dsDanhMuc = db.DanhMucs.ToList();
            return View(dsDanhMuc);
        }

        // Tạo mới danh mục 
        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                string maDM = Request.Form["MaDM"];
                string tenDM = Request.Form["TenDM"];


                DanhMuc dm = new DanhMuc();
                dm.MaDM= maDM;
                dm.TenDM = tenDM;
                db.DanhMucs.InsertOnSubmit(dm);
                db.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // Chỉnh sửa thông tin danh mục
        public ActionResult Edit(int Id)
        {
            DanhMuc dm = db.DanhMucs.FirstOrDefault(p => p.Id == Id);
            if (Request.Form.Count == 0)
            {
                return View(dm);
            }
            string maDM = Request.Form["MaDM"];
            string tenDM = Request.Form["TenDM"];

            dm.MaDM = maDM;
            dm.TenDM = tenDM;
          
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        // Xóa danh mục
        public ActionResult Delete (int Id)
        {
            DanhMuc dm = db.DanhMucs.FirstOrDefault(p => p.Id == Id);
            if(dm != null)
            {
               
                try
                {
                    db.DanhMucs.DeleteOnSubmit(dm);
                    db.SubmitChanges();
                }
                catch
                {
                    return Content("Danh mục đang chứa sản phẩm. Bạn không thể xóa danh mục này!");
                }
               
            }    
            return RedirectToAction("Index");
        }

        public ActionResult PartialDanhMuc()
        {
            var dsDM = db.DanhMucs.ToList();
            return PartialView("PartialDanhMuc", dsDM);
        }


    }
}