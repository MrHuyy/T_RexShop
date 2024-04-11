using Demo_T_REX.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Demo_T_REX.Controllers
{
    public class ShoppingCartController : Controller
    {
        public static int id;
        private T_RexContext db = new T_RexContext();
        public List<CartItem> GetShoppingCartFromSession()
        {
            var listShoppingCart = Session["ShoppingCart"] as List<CartItem>;
            if (listShoppingCart == null)
            {
                listShoppingCart = new List<CartItem>();
                Session["ShoppingCart"] = listShoppingCart;
            }
            return listShoppingCart;
        }
        // GET: ShoppingCart
        public ActionResult Index()
        {
            List<CartItem> ShoppingCart = GetShoppingCartFromSession();
            if (ShoppingCart.Count() == 0)
                return RedirectToAction("Index", "Home", new { area = "" });
            ViewBag.tongsoluong = ShoppingCart.Sum(p => p.Quanlity);
            ViewBag.tongtien = ShoppingCart.Sum(p => p.Money);
            return View(ShoppingCart);
        }
        [Authorize]
        public RedirectToRouteResult AddToCart(int id)
        {
            List<CartItem> ShoppingCart = GetShoppingCartFromSession();
            CartItem findCartItem = ShoppingCart.FirstOrDefault(p => p.MaSP == id);
            if (findCartItem == null)
            {
                var Findbook = db.San_Pham.FirstOrDefault(p => p.MaSP == id);
                CartItem cartItem = new CartItem()
                {
                    MaSP = Findbook.MaSP,
                    TenSP = Findbook.TenSP,
                    Quanlity = 1,
                    Img = Findbook.Img,
                    Size = (float)Findbook.Size,
                    MauSac = Findbook.MauSac,
                    Don_Gia_Ban = (long)Findbook.don_gia_giam
                };
                ShoppingCart.Add(cartItem);
            }
            else
            {
                findCartItem.Quanlity++;
            }
            return RedirectToAction("Index", "ShoppingCart");
        }

        public RedirectToRouteResult UpdateCart(int id, int txtQuantity)
        {
            var itemFind = GetShoppingCartFromSession().FirstOrDefault(p => p.MaSP == id);
            if (itemFind != null)
            {
                itemFind.Quanlity = txtQuantity;
            }
            return RedirectToAction("Index", "ShoppingCart");
        }

        public RedirectToRouteResult RemoveCartItem(int id)
        {
            List<CartItem> ShoppingCart = GetShoppingCartFromSession();
            CartItem itemFind = ShoppingCart.First(p => p.MaSP == id);
            if (itemFind != null)
            {
                ShoppingCart.Remove(itemFind);

            }
            return RedirectToAction("Index", "ShoppingCart");
        }

        public ActionResult CartSummary()
        {
            ViewBag.CartCount = GetShoppingCartFromSession().Count();
            return PartialView("CartSummary");
        }

        public RedirectToRouteResult Delete()
        {
            List<CartItem> ShoppingCart = GetShoppingCartFromSession();
            if (ShoppingCart != null)
            {
                GetShoppingCartFromSession().Clear();
            }

            return RedirectToAction("Index", "ShoppingCart");
        }
       
        public ActionResult Order1()
        {
            string currentUserId = User.Identity.GetUserId();
           
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    Hoa_Don objOrder = new Hoa_Don()
                    {
                        MaKH = currentUserId,
                        NgayLapHD = DateTime.Now,
                        DeliverDate = null,
                        isConplete = false,
                        isPaid = false
                    };
                    objOrder = db.Hoa_Don.Add(objOrder);
                    db.SaveChanges();
                    id = objOrder.MaHD;
                    List<CartItem> ListCartItems = GetShoppingCartFromSession();
                    foreach (var item in ListCartItems)
                    {
                        CT_HD cthd = new CT_HD()
                        {
                            MaHD = objOrder.MaHD,
                            MaSP = item.MaSP,
                            SL_Mua = item.Quanlity,
                            Don_Gia_Ban = (long)item.Don_Gia_Ban
                        };
                        db.CT_HD.Add(cthd);
                        db.SaveChanges();
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Content("Gặp lỗi khi đặt hàng:" + ex.Message);
                }
            }
            
            Session["ShoppingCart"] = null;
            return RedirectToAction("Order", "ShoppingCart");
        }

        [HttpGet]
        public ActionResult Order()
        {
            Hoa_Don ojbOrder1 = db.Hoa_Don.FirstOrDefault(p => p.MaHD == id);
            return View(ojbOrder1);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(Hoa_Don ojbOrder1)
        {
           
            Hoa_Don hoaDon = db.Hoa_Don.FirstOrDefault(p=>p.MaHD == id);
            using (DbContextTransaction transaction = db.Database.BeginTransaction())
            {
                try
                {
                    
                    hoaDon.SDT = ojbOrder1.SDT;
                    hoaDon.DiaChiNhan = ojbOrder1.DiaChiNhan;
                    hoaDon.TenNguoNhan = ojbOrder1.TenNguoNhan;
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return Content("Gặp lỗi khi đặt hàng:" + ex.Message);
                }
            }
            return RedirectToAction("Payment", "Momo", new { area = "", id });
        }
        //public RedirectResult IfoUserReceiver(int id)
        //{
        //    return RedirectToAction(/*"Payment", "Home", new { id = id }*/);
        //}
    }
}