using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Demo_T_REX.Models
{
    public class CartItem
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }

        public double Size { get; set; }
        public string MauSac { get; set; }

        public long Don_Gia_Ban { get; set; }
        public int GiamGia { get; set; }
        public string Img { get; set; }

        public float Don_Gia_Ban_giam
        {
            get
            {
                float y = (float)GiamGia / 100;
                float x = (float)(y * Don_Gia_Ban);
                return (float)Don_Gia_Ban - x;
            }
            
        }
        public int MaLoai { get; set; }
        public int Quanlity { get; set; }
        public float Money
        {
            get
            {
                return Quanlity * Don_Gia_Ban_giam;
            }
        }
    }
}