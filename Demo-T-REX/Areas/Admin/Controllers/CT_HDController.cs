using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo_T_REX.Models;

namespace Demo_T_REX.Areas.Admin.Controllers
{
    public class CT_HDController : Controller
    {
        private T_RexContext db = new T_RexContext();

        // GET: Admin/CT_HD
        public ActionResult Index()
        {
            var cT_HD = db.CT_HD.Include(c => c.Hoa_Don).Include(c => c.San_Pham);
            return View(cT_HD.ToList());
        }

        // GET: Admin/CT_HD/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HD cT_HD = db.CT_HD.Find(id);
            if (cT_HD == null)
            {
                return HttpNotFound();
            }
            return View(cT_HD);
        }

        // GET: Admin/CT_HD/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.Hoa_Don, "MaHD", "SDT");
            ViewBag.MaSP = new SelectList(db.San_Pham, "MaSP", "TenSP");
            return View();
        }

        // POST: Admin/CT_HD/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,MaSP,Don_Gia_Ban,SL_Mua")] CT_HD cT_HD)
        {
            if (ModelState.IsValid)
            {
                db.CT_HD.Add(cT_HD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.Hoa_Don, "MaHD", "SDT", cT_HD.MaHD);
            ViewBag.MaSP = new SelectList(db.San_Pham, "MaSP", "TenSP", cT_HD.MaSP);
            return View(cT_HD);
        }

        // GET: Admin/CT_HD/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HD cT_HD = db.CT_HD.Find(id);
            if (cT_HD == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.Hoa_Don, "MaHD", "SDT", cT_HD.MaHD);
            ViewBag.MaSP = new SelectList(db.San_Pham, "MaSP", "TenSP", cT_HD.MaSP);
            return View(cT_HD);
        }

        // POST: Admin/CT_HD/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,MaSP,Don_Gia_Ban,SL_Mua")] CT_HD cT_HD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cT_HD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.Hoa_Don, "MaHD", "SDT", cT_HD.MaHD);
            ViewBag.MaSP = new SelectList(db.San_Pham, "MaSP", "TenSP", cT_HD.MaSP);
            return View(cT_HD);
        }

        // GET: Admin/CT_HD/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CT_HD cT_HD = db.CT_HD.Find(id);
            if (cT_HD == null)
            {
                return HttpNotFound();
            }
            return View(cT_HD);
        }

        // POST: Admin/CT_HD/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CT_HD cT_HD = db.CT_HD.Find(id);
            db.CT_HD.Remove(cT_HD);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
