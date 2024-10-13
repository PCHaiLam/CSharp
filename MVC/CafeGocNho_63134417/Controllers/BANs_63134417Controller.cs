using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CafeGocNho_63134417.Models;

namespace CafeGocNho_63134417.Controllers
{
    public class BANs_63134417Controller : Controller
    {
        private CafeGocNho_63134417Entities db = new CafeGocNho_63134417Entities();

        // GET: BANs_63134417
        public ActionResult Index()
        {
            return View(db.BAN.ToList());
        }

        // GET: BANs_63134417/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAN bAN = db.BAN.Find(id);
            if (bAN == null)
            {
                return HttpNotFound();
            }
            return View(bAN);
        }

        // GET: BANs_63134417/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BANs_63134417/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MABAN,TINHTRANG")] BAN bAN)
        {
            if (ModelState.IsValid)
            {
                db.BAN.Add(bAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bAN);
        }

        // GET: BANs_63134417/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAN bAN = db.BAN.Find(id);
            if (bAN == null)
            {
                return HttpNotFound();
            }
            return View(bAN);
        }

        // POST: BANs_63134417/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MABAN,TINHTRANG")] BAN bAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bAN);
        }

        // GET: BANs_63134417/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAN bAN = db.BAN.Find(id);
            if (bAN == null)
            {
                return HttpNotFound();
            }
            return View(bAN);
        }

        // POST: BANs_63134417/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BAN bAN = db.BAN.Find(id);
            db.BAN.Remove(bAN);
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
