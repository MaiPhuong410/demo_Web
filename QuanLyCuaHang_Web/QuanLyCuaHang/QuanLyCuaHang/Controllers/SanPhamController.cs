using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using QuanLyCuaHang.Models;
namespace QuanLyCuaHang.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        QuanLyWebCoffeeDataContext db = new QuanLyWebCoffeeDataContext();
       
        

        public ActionResult Index(string searchString)
        {
            var dsProduct = from sp in db.SanPhams select sp; //câu truy vấn
            if (!String.IsNullOrEmpty(searchString))
            {
                dsProduct = dsProduct.Where(s => s.TenSP.Contains(searchString));
            }
            return View(dsProduct);
        }

        public ActionResult Create()
        {
            if (Request.Form.Count > 0)
            {
                
                SanPham sp = new SanPham();
                sp.MaDMId = int.Parse(Request.Form["MaDMId"]);
                sp.MaSP = Request.Form["MaSP"];
                sp.TenSP = Request.Form["TenSP"];
                HttpPostedFileBase file = Request.Files["HinhAnh"];
                sp.MoTa = Request.Form["MoTa"];
                sp.GiaSP = float.Parse(Request.Form["GiaSP"]);

                if (file != null)  //lưu được tên hình xuống DB
                {
                    string serverPath = HttpContext.Server.MapPath("~/HinhAnh");
                    var fileName = Path.GetFileName(file.FileName); 
                    string filePath = serverPath + "/" + fileName;
                    file.SaveAs(filePath);
                    sp.HinhAnh = fileName;
                }
                
                    db.SanPhams.InsertOnSubmit(sp);
                    db.SubmitChanges();
                
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.Id == id);
            if (Request.Form.Count == 0)
            {
                return View(sp);
            }
            sp.MaDMId = int.Parse(Request.Form["MaDMId"]);
            sp.MaSP = Request.Form["MaSP"];
            sp.TenSP = Request.Form["TenSP"];
            HttpPostedFileBase file = Request.Files["HinhAnh"];
            sp.MoTa = Request.Form["Mota"];
            sp.GiaSP = float.Parse(Request.Form["GiaSP"]);

            if (file != null && file.FileName != "")
            {
                string serverPath = HttpContext.Server.MapPath("~/HinhAnh");
                //string filePath = serverPath + "/" + file.FileName;
                var fileName = Path.GetFileName(file.FileName); 
                string filePath = serverPath + "/" + fileName;
                file.SaveAs(filePath);
                sp.HinhAnh = fileName;
            }
            db.SubmitChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.Id == id);
            if (sp != null)
            {
                db.SanPhams.DeleteOnSubmit(sp);
                db.SubmitChanges();
            }
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id) 
        {
            
            SanPham sp = db.SanPhams.FirstOrDefault(p => p.Id == id); 
            return View(sp);
        }

        public ActionResult PartialSanPham (int madm)
        {
            var dsSP = db.SanPhams.Where(x => x.MaDMId == madm).ToList();
            return PartialView("PartialSanPham", dsSP);
        }

        public ActionResult Details_1(int id)
        {

            SanPham sp = db.SanPhams.FirstOrDefault(p => p.Id == id);
            return View(sp);
        }

        
    }
}