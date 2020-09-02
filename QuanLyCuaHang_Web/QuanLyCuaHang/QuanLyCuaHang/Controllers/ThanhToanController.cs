using QuanLyCuaHang.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCuaHang.Controllers
{
    public class ThanhToanController : Controller
    {
        // GET: ThanhToan
        QuanLyWebCoffeeDataContext db = new QuanLyWebCoffeeDataContext();
        private const string CartSession = "CartSession";
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;

            }
            return View(list);
        }


        [HttpPost]
        public ActionResult StepEnd()
        {
            //Nhận reqest từ trang index
            string phone = Request.Form["phone"];
            string fullname = Request.Form["fullname"];
            string email = Request.Form["email"];
            string address = Request.Form["address"];
            string note = Request.Form["note"];
            //kiểm tra xem có customer chưa và cập nhật lại
            KhachHang newCus = new KhachHang();
            var cus = db.KhachHangs.FirstOrDefault(p => p.SDT.Equals(phone));
            if (cus != null)
            {
                //nếu có số điện thoại trong db rồi
                //cập nhật thông tin và lưu
                cus.HoTenKH = fullname;
                
                cus.DiaChi = address;
                
                db.SubmitChanges();
            }
            else
            {
                //nếu chưa có sđt trong db
                //thêm thông tin và lưu
                newCus.SDT = phone;
                newCus.HoTenKH = fullname;
                //newCus.cusEmail = email;
                newCus.DiaChi= address;
                db.KhachHangs.InsertOnSubmit(newCus);
                db.SubmitChanges();
            }
            //Thêm thông tin vào order và orderdetail

            List<CartItem> giohang = Session[CartSession] as List<CartItem>;
            
            //thêm order mới
            HoaDon newOrder = new HoaDon();
           
            newOrder.NgayLap = DateTime.Now;
            
            db.HoaDons.InsertOnSubmit(newOrder);
            db.SubmitChanges();
            //thêm chi tiết
            for (int i = 0; i < giohang.Count; i++)
            {
                CTHD newOrdts = new CTHD();
                
                newOrdts.IdHD = newOrder.IdHD;
                newOrdts.MaSPId = giohang.ElementAtOrDefault(i).SanPham.Id;
                newOrdts.SoLuongBan = giohang.ElementAtOrDefault(i).Sl;
                newOrdts.ThanhTien = giohang.ElementAtOrDefault(i).ThanhTien;
                db.CTHDs.InsertOnSubmit(newOrdts);
                db.SubmitChanges();
            }
            Session["MHD"] = "HD" + newOrder.IdHD;
            Session["Phone"] = phone;
            //xoá sạch giỏ hàng
            giohang.Clear();
            return RedirectToAction("HoaDon", "ThanhToan");
        }
        
        public ActionResult HoaDon ()
        {
            
            return View();
        }
    }
}