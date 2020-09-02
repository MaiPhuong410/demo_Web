using QuanLyCuaHang.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCuaHang.Controllers
{
    public class GioHangController : Controller
    {
        // GET: GioHang
        QuanLyWebCoffeeDataContext db = new QuanLyWebCoffeeDataContext();
        private const string CartSession = "CartSession";
        public ActionResult Index()
        {
            //List<CartItem> giohang = Session["giohang"] as List<CartItem>;
            //return View(giohang);
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;

            }
            return View(list);
        }

        public ActionResult ThemVaoGio(int id)
        {
            
            QuanLyWebCoffeeDataContext db = new QuanLyWebCoffeeDataContext();
            SanPham sp = db.SanPhams.FirstOrDefault(x => x.Id == id);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.SanPham.Id == id))
                {
                    foreach (var item in list)
                    {
                        if (item.SanPham.Id == id)
                        {
                            item.Sl ++;
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart item
                    var item = new CartItem();
                    item.SanPham = sp;
                    item.Sl = 1;
                    list.Add(item);
                }
                //gắn vào session
                Session[CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart item
                var item = new CartItem();
                item.SanPham = sp;
                item.Sl = 1;
                var list = new List<CartItem>();
                list.Add(item);
                //gắn vào session
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

        //Sửa số lượng
        public ActionResult SuaSoLuong(int SanPhamID, int soluongmoi)
        {
            // tìm carditem muon sua
            var giohang = (List<CartItem>)Session[CartSession];
            CartItem itemSua = giohang.FirstOrDefault(m => m.SanPham.Id ==(SanPhamID));
            if (itemSua != null)
            {
                if (soluongmoi < 1 || soluongmoi > 100)
                {

                }
                else
                {
                    @ViewBag.GioError = "";
                    itemSua.Sl = soluongmoi;
                }
            }
            Session[CartSession] = giohang;
            return RedirectToAction("Index");

        }

        public ActionResult XoaKhoiGio(int SanPhamID)
        {
            var giohang = (List<CartItem>)Session[CartSession];
            giohang.RemoveAll(x => x.SanPham.Id == SanPhamID);
            return RedirectToAction("Index");

            
        }
    }
    }