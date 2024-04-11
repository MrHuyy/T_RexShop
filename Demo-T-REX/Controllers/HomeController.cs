using Demo_T_REX.Models;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using PagedList;

namespace Demo_T_REX.Controllers
{
    public class HomeController : Controller
    {
        T_RexContext context = new T_RexContext();
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult ViewSearch()
        {

            var context = new T_RexContext();
            //int pageSize = 4;
            //int pageIndex = page.HasValue ? page.Value : 1;
            var listProduct = context.San_Pham.ToList();
            //var result = listProduct.ToPagedList(pageIndex, pageSize);
            return View(listProduct);
        }


        public ActionResult Search(string searchString)
        {

            var results = (from m in context.San_Pham where m.TenSP.Contains(searchString) || m.MauSac.Contains(searchString) || m.Nhan_Hieu.TenLoaiSP.Contains(searchString) select m);

            return View("ViewSearch", results/*.ToList()/*.ToPagedList(1, 3)*/);
            
        }
        public ActionResult GetBookByCategory(int id)
        {

            return View("ViewSearch", context.San_Pham.Where(p => p.MaLoai == id).ToList()/*.ToPagedList(1, 2)*/);
        }
        public ActionResult Nhan_hieu()
        {
            var listCategory = context.Nhan_Hieu.ToList();
            return PartialView(listCategory);
        }

       
        public ActionResult TrenDing()
        {
            List<San_Pham> results = new List<San_Pham>();
            foreach (var i in context.CT_HD)
            {

                if (results.FirstOrDefault(p => p.MaSP == i.MaSP) == null)
                {
                    var findbook = context.San_Pham.FirstOrDefault(p => p.MaSP == i.MaSP);
                    if (results.Count() < 8)
                    {

                        results.Add(findbook);
                    }
                    else
                    {
                        var tam1 = context.CT_HD.Where(p => p.MaSP == i.MaSP).ToList();
                        foreach (var y in results)
                        {
                            var tam2 = context.CT_HD.Where(p => p.MaSP == y.MaSP).ToList();
                            if (tam1.Count() > tam2.Count())
                            {
                                int t = 0;
                                foreach(var e in results)
                                {
                                    if(t == 0)
                                    {
                                        t = e.MaSP;
                                    }
                                    else
                                    {
                                        var t1 = context.CT_HD.Where(p => p.MaSP == e.MaSP).ToList();
                                        var t2 = context.CT_HD.Where(p => p.MaSP == t).ToList();
                                        if (t1.Count() < t2.Count())
                                        {
                                            t = e.MaSP;
                                        }
                                    }
                                
                                }
                                var delete = results.FirstOrDefault(p => p.MaSP == t);
                                results.Remove(delete);
                                results.Add(findbook);
                                break;
                            }
                        }
                    }
                }
            }
            return PartialView(results);
        }

        public ActionResult Detail(int id)
        {
            var Detail = context.San_Pham.FirstOrDefault(p => p.MaSP == id);
            ViewBag.dongia = Detail.don_gia_giam;
            if (Detail == null)
            {
                return HttpNotFound("Không tìm thấy sản phẩm này");
            }
            return View(Detail);
        }

        public ActionResult DealAndOffer()
        {
            List<San_Pham> results = new List<San_Pham>();
            foreach (var i in context.San_Pham)
            {

                if (results.FirstOrDefault(p => p.MaSP == i.MaSP) == null)
                {
                    var findbook = context.San_Pham.FirstOrDefault(p => p.MaSP == i.MaSP);
                    int Xet = Convert.ToInt32(findbook.GiamGia);
                    if (results.Count() < 6 )
                    {
                        if(Xet != 0)
                        {
                            results.Add(findbook);
                        }
                        
                    }
                    else
                    {
                        int tam1 = Convert.ToInt32(context.San_Pham.FirstOrDefault(p => p.MaSP == i.MaSP).GiamGia);
                        foreach (var y in results)
                        {
                            int tam2 = Convert.ToInt32(context.San_Pham.FirstOrDefault(p => p.MaSP == y.MaSP).GiamGia);
                            if (tam1 > tam2)
                            {
                                int t = 0;
                                foreach (var e in results)
                                {
                                    if (t == 0)
                                    {
                                        t = e.MaSP;
                                    }
                                    else
                                    {
                                        int t1 = Convert.ToInt32(context.San_Pham.FirstOrDefault(p => p.MaSP == e.MaSP).GiamGia);
                                        int t2 = Convert.ToInt32(context.San_Pham.FirstOrDefault(p => p.MaSP == t).GiamGia);
                                        if (t1 < t2)
                                        {
                                            t = e.MaSP;
                                        }
                                    }

                                }
                                var delete = results.FirstOrDefault(p => p.MaSP == t);
                                results.Remove(delete);
                                results.Add(findbook);
                                break;
                            }
                        }
                    }
                }
            }
            return PartialView(results);
        }

        public ActionResult newProducts()
        {
            List<San_Pham> results = new List<San_Pham>();
            foreach (var i in context.San_Pham)
            {

                if (results.FirstOrDefault(p => p.MaSP == i.MaSP) == null)
                {
                    var findbook = context.San_Pham.FirstOrDefault(p => p.MaSP == i.MaSP);
                   
                    if (results.Count() < 12)
                    {
                       
                        results.Add(findbook);
                       

                    }
                    else
                    {
                        int tam1 = Convert.ToInt32(context.San_Pham.FirstOrDefault(p => p.MaSP == i.MaSP).MaSP);
                        foreach (var y in results)
                        {
                            int tam2 = Convert.ToInt32(context.San_Pham.FirstOrDefault(p => p.MaSP == y.MaSP).MaSP);
                            if (tam1 > tam2)
                            {
                                int t = 0;
                                foreach (var e in results)
                                {
                                    if (t == 0)
                                    {
                                        t = e.MaSP;
                                    }
                                    else
                                    {
                                        int t1 = Convert.ToInt32(context.San_Pham.FirstOrDefault(p => p.MaSP == e.MaSP).MaSP);
                                        int t2 = Convert.ToInt32(context.San_Pham.FirstOrDefault(p => p.MaSP == t).MaSP);
                                        if (t1 < t2)
                                        {
                                            t = e.MaSP;
                                        }
                                    }

                                }
                                var delete = results.FirstOrDefault(p => p.MaSP == t);
                                results.Remove(delete);
                                results.Add(findbook);
                                break;
                            }
                        }
                    }
                }
            }
            return PartialView(results);
        }


        public ActionResult searchPrice(int min, int max)
        {
            List<San_Pham> results = new List<San_Pham>();
            foreach(var i in context.San_Pham)
            {
                if(i.don_gia_giam >= min && i.don_gia_giam <= max)
                {
                    results.Add(i);
                }
            }
            return View("ViewSearch", results);
        }

        public ActionResult sizeSSS()
        {
            List<sizes> results = new List<sizes>();
            foreach(var i in context.San_Pham)
            {
                int tam = Convert.ToInt32(i.Size);
                if (results.Count() == 0)
                {
                    sizes sizeT = new sizes();
                    sizeT.ID = tam;
                    results.Add(sizeT);
                }
                else
                {
                   int t = -1;
                   foreach(var y in results)
                   {
                        if(tam == y.ID)
                        {
                            t = 1;
                        }
                   }
                   if(t == -1)
                   {
                        sizes sizeT = new sizes();
                        sizeT.ID = tam;
                        results.Add(sizeT);
                   }
                }
            }
            return PartialView(results);
        }
        public ActionResult GetBookBySize(int id)
        {

            return View("ViewSearch", context.San_Pham.Where(p => p.Size == id).ToList()/*.ToPagedList(1, 2)*/);
        }

        public ActionResult colorss()
        {
            List<Colors> results = new List<Colors>();
            foreach (var i in context.San_Pham)
            {
                //int tam = Convert.ToInt32(i.Size);
                if (results.Count() == 0)
                {
                    Colors colorT = new Colors();
                    colorT.Name = i.MauSac;
                    results.Add(colorT);
                }
                else
                {
                    int t = -1;
                    foreach (var y in results)
                    {
                        if (i.MauSac == y.Name)
                        {
                            t = 1;
                        }
                    }
                    if (t == -1)
                    {
                        Colors colorT = new Colors();
                        colorT.Name = i.MauSac;
                        results.Add(colorT);
                    }
                }
            }
            return PartialView(results);
        }
        public ActionResult GetBookBycolors(string Color)
        {

            return View("ViewSearch", context.San_Pham.Where(p => p.MauSac == Color).ToList());
        }
    }
}