using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace QuanLyCuaHang.Models
{
    public class OrderDetails
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public int orderID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public int proID { get; set; }

        public int ordtsQuantity { get; set; }

        [StringLength(50)]
        public string ordtsThanhTien { get; set; }

        public virtual Order Order { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}