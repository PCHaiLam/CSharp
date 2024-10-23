using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using CafeGocNho_63134417.Models;

namespace CafeGocNho_63134417.Controllers
{
    public class ADMINs_63134417Controller : Controller
    {
        private readonly CafeGocNho_63134417Entities db = new CafeGocNho_63134417Entities();
        public bool CheckUser(string username, string password, out bool isAdmin)
        {
            var kq = db.ADMIN.Where(x => x.Email == username && x.Password == password).FirstOrDefault();
            if (kq != null)
            {
                Session["Ten"] = kq.Ten;
                isAdmin = kq.Admin1; // Giả sử Admin1 là thuộc tính boolean trong cơ sở dữ liệu
                Session["Role"] = isAdmin ? "True" : "False"; // Lưu vai trò vào Session
                return true;
            }
            else
            {
                Session["Ten"] = null;
                isAdmin = false;
                Session["Role"] = "False"; // Nếu không đăng nhập thành công, vai trò là nhân viên
                return false;
            }
        }

        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(ADMIN qt)
        {
            if (ModelState.IsValid)
            {
                if (CheckUser(qt.Email, qt.Password, out bool isAdmin))
                {
                    FormsAuthentication.SetAuthCookie(qt.Email, true);

                    if (isAdmin)
                    {
                        return RedirectToAction("Index", "ADMINs_63134417"); // Trang dành cho admin
                    }
                    else
                    {
                        return RedirectToAction("Index", "BANs_63134417"); // Trang dành cho nhân viên
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View(qt);
        }


        // GET: ADMINs_63134417
        public ActionResult Index()
        {
            return View(db.ADMIN.ToList());
        }

        // GET: ADMINs_63134417/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMIN aDMIN = db.ADMIN.Find(id);
            if (aDMIN == null)
            {
                return HttpNotFound();
            }
            return View(aDMIN);
        }

        // GET: ADMINs_63134417/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMINs_63134417/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Email,Admin1,Ten,Password")] ADMIN aDMIN)
        {
            if (ModelState.IsValid)
            {
                db.ADMIN.Add(aDMIN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aDMIN);
        }

        // GET: ADMINs_63134417/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMIN aDMIN = db.ADMIN.Find(id);
            if (aDMIN == null)
            {
                return HttpNotFound();
            }
            return View(aDMIN);
        }

        // POST: ADMINs_63134417/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Email,Admin1,Ten,Password")] ADMIN aDMIN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDMIN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aDMIN);
        }

        // GET: ADMINs_63134417/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMIN aDMIN = db.ADMIN.Find(id);
            if (aDMIN == null)
            {
                return HttpNotFound();
            }
            return View(aDMIN);
        }

        // POST: ADMINs_63134417/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ADMIN aDMIN = db.ADMIN.Find(id);
            db.ADMIN.Remove(aDMIN);
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
