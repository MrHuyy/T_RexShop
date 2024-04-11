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
    public class Hoa_DonController : Controller
    {
        private T_RexContext db = new T_RexContext();

        // GET: Admin/Hoa_Don
        public ActionResult Index()
        {
            return View(db.Hoa_Don.ToList());
        }

        // GET: Admin/Hoa_Don/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoa_Don hoa_Don = db.Hoa_Don.Find(id);
            if (hoa_Don == null)
            {
                return HttpNotFound();
            }
            return View(hoa_Don);
        }

        // GET: Admin/Hoa_Don/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Hoa_Don/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHD,NgayLapHD,DeliverDate,isConplete,isPaid,SDT,TenNguoNhan,DiaChiNhan,MaKH")] Hoa_Don hoa_Don)
        {
            if (ModelState.IsValid)
            {
                db.Hoa_Don.Add(hoa_Don);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hoa_Don);
        }

        // GET: Admin/Hoa_Don/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoa_Don hoa_Don = db.Hoa_Don.Find(id);
            if (hoa_Don == null)
            {
                return HttpNotFound();
            }
            return View(hoa_Don);
        }

        // POST: Admin/Hoa_Don/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHD,NgayLapHD,DeliverDate,isConplete,isPaid,SDT,TenNguoNhan,DiaChiNhan,MaKH")] Hoa_Don hoa_Don)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hoa_Don).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hoa_Don);
        }

        // GET: Admin/Hoa_Don/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hoa_Don hoa_Don = db.Hoa_Don.Find(id);
            if (hoa_Don == null)
            {
                return HttpNotFound();
            }
            return View(hoa_Don);
        }

        // POST: Admin/Hoa_Don/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hoa_Don hoa_Don = db.Hoa_Don.Find(id);
            db.Hoa_Don.Remove(hoa_Don);
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
