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
    public class Nhan_HieuController : Controller
    {
        private T_RexContext db = new T_RexContext();

        // GET: Admin/Nhan_Hieu
        public ActionResult Index()
        {
            return View(db.Nhan_Hieu.ToList());
        }

        // GET: Admin/Nhan_Hieu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhan_Hieu nhan_Hieu = db.Nhan_Hieu.Find(id);
            if (nhan_Hieu == null)
            {
                return HttpNotFound();
            }
            return View(nhan_Hieu);
        }

        // GET: Admin/Nhan_Hieu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Nhan_Hieu/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLoai,TenLoaiSP")] Nhan_Hieu nhan_Hieu)
        {
            if (ModelState.IsValid)
            {
                db.Nhan_Hieu.Add(nhan_Hieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nhan_Hieu);
        }

        // GET: Admin/Nhan_Hieu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhan_Hieu nhan_Hieu = db.Nhan_Hieu.Find(id);
            if (nhan_Hieu == null)
            {
                return HttpNotFound();
            }
            return View(nhan_Hieu);
        }

        // POST: Admin/Nhan_Hieu/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLoai,TenLoaiSP")] Nhan_Hieu nhan_Hieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhan_Hieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nhan_Hieu);
        }

        // GET: Admin/Nhan_Hieu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nhan_Hieu nhan_Hieu = db.Nhan_Hieu.Find(id);
            if (nhan_Hieu == null)
            {
                return HttpNotFound();
            }
            return View(nhan_Hieu);
        }

        // POST: Admin/Nhan_Hieu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nhan_Hieu nhan_Hieu = db.Nhan_Hieu.Find(id);
            db.Nhan_Hieu.Remove(nhan_Hieu);
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
