using Demo_T_REX.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Demo_T_REX.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        T_RexContext context = new T_RexContext();

        public ActionResult SanPham(int? page)
        {
            var context = new T_RexContext();
            int pageSize = 3;
            int pageIndex = page.HasValue ? page.Value : 1;
            var listProduct = context.San_Pham.ToList();
            var result = listProduct.ToPagedList(pageIndex, pageSize);
            return View(result);
        }


        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }


        [HttpGet]
        public ActionResult Create()
        {
            San_Pham sanPham = new San_Pham();
            sanPham.ListNhanHieu = context.Nhan_Hieu.ToList();
            return View(sanPham);
        }

        [HttpPost]
        public ActionResult Create(San_Pham sanPham)
        {
            if (!ModelState.IsValid)
            {
                sanPham.ListNhanHieu = context.Nhan_Hieu.ToList();
            }
            context.San_Pham.Add(sanPham);
            context.SaveChanges();
            return RedirectToAction("SanPham", "Home");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            //San_Pham sanPham = context.San_Pham.FirstOrDefault(p => p.MaSP == id);

            San_Pham sanPham = context.San_Pham.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            return View(sanPham);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            San_Pham sanPham = context.San_Pham.Find(id);
            context.San_Pham.Remove(sanPham);
            context.SaveChanges();
            return RedirectToAction("SanPham", "Home");
        }

        public ActionResult DeleteAll()
        {
            return View();
        }

        [HttpPost, ActionName("DeleteAll")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAllConfirm()
        {
            var SanPhamList = context.San_Pham.ToList();
            if (SanPhamList != null)
            {
                foreach (var i in context.San_Pham)
                {
                    context.San_Pham.Remove(i);                   
                }
            }
            context.SaveChanges();
            return RedirectToAction("SanPham");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            San_Pham sanPham = context.San_Pham.FirstOrDefault(p => p.MaSP == id);
            sanPham.ListNhanHieu = context.Nhan_Hieu.ToList();
            if (sanPham == null)
            {
                return HttpNotFound("Không Tìm Thấy Giày");
            }

            return View(sanPham);
        }

        [HttpPost]
        public ActionResult Edit(San_Pham edit)
        {
            San_Pham sanPham = context.San_Pham.FirstOrDefault(p => p.MaSP == edit.MaSP);
            if (sanPham == null)
            {
                return HttpNotFound("Không Tìm Thấy Giày");
            }
            sanPham.TenSP = edit.TenSP;
            sanPham.Size = edit.Size;
            sanPham.MauSac = edit.MauSac;
            sanPham.Don_Gia_Ban = edit.Don_Gia_Ban;
            sanPham.Mo_ta_SP = edit.Mo_ta_SP;
            sanPham.SL_TonKho = edit.SL_TonKho;
            sanPham.GiamGia= edit.GiamGia;
            sanPham.MaLoai = edit.MaLoai;
            sanPham.Img = edit.Img;
            context.SaveChanges();
            return RedirectToAction("SanPham", sanPham);
        }

        public ActionResult Search(string searchString)
        {

            var results = (from m in context.San_Pham where m.TenSP.Contains(searchString) || m.MauSac.Contains(searchString) || m.Nhan_Hieu.TenLoaiSP.Contains(searchString) select m);
           
            return View("SanPham", results.ToList().ToPagedList(1, 3));
            
        }

        public ActionResult Details(int id)
        {
            var context = new T_RexContext();
            var firstShoes = context.San_Pham.FirstOrDefault(p => p.MaSP == id);
            if (firstShoes== null)
                return HttpNotFound("Không tìm thấy giày này!");
            return View(firstShoes);
        }

    }
}