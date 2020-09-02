using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using QuanLyCuaHang.Models;
namespace QuanLyCuaHang.Models
{
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        public HashSet<OrderDetails> OrderDetails { get; }

        [StringLength(20)]
        public int orderID { get; set; }

        [StringLength(20)]
        public string HoTenKH { get; set; }

        public string SDT { get; set; }

        [StringLength(50)]
        public string orderDateTime { get; set; }

        [StringLength(50)]
        public string DiaChi { get; set; }
        
        public KhachHang khach { get; set; }
    }
}