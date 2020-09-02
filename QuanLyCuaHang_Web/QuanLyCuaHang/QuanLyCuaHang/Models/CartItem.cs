using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyCuaHang.Models;
namespace QuanLyCuaHang.Models
{
    public class CartItem
    {
        
        public SanPham SanPham { set; get; }
        public int Sl { set; get; }
        public float ThanhTien
        {
            get
            {
                
                return (float)(Sl * SanPham.GiaSP);
            }
        }
    }
}