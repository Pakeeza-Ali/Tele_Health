using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tele_Health.Models;

namespace Tele_Health.Controllers
{
    public class ADMIN_tblController : Controller
    {
        private Model1 db = new Model1();

        // GET: ADMIN_tbl
        public ActionResult Index()
        {
            return View(db.ADMIN_tbl.ToList());
        }

        // GET: ADMIN_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMIN_tbl aDMIN_tbl = db.ADMIN_tbl.Find(id);
            if (aDMIN_tbl == null)
            {
                return HttpNotFound();
            }
            return View(aDMIN_tbl);
        }

        // GET: ADMIN_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ADMIN_tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ADMIN_ID,ADMIN_NAME,ADMIN_CNIC,ADMIN_EMAIL,ADMIN_PASSWORD,ADMIN_CONTACT,ADMIN_ADDRESS")] ADMIN_tbl aDMIN_tbl)
        {
            if (ModelState.IsValid)
            {
                db.ADMIN_tbl.Add(aDMIN_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(aDMIN_tbl);
        }

        // GET: ADMIN_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMIN_tbl aDMIN_tbl = db.ADMIN_tbl.Find(id);
            if (aDMIN_tbl == null)
            {
                return HttpNotFound();
            }
            return View(aDMIN_tbl);
        }

        // POST: ADMIN_tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ADMIN_ID,ADMIN_NAME,ADMIN_CNIC,ADMIN_EMAIL,ADMIN_PASSWORD,ADMIN_CONTACT,ADMIN_ADDRESS")] ADMIN_tbl aDMIN_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aDMIN_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(aDMIN_tbl);
        }

        // GET: ADMIN_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ADMIN_tbl aDMIN_tbl = db.ADMIN_tbl.Find(id);
            if (aDMIN_tbl == null)
            {
                return HttpNotFound();
            }
            return View(aDMIN_tbl);
        }

        // POST: ADMIN_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ADMIN_tbl aDMIN_tbl = db.ADMIN_tbl.Find(id);
            db.ADMIN_tbl.Remove(aDMIN_tbl);
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
