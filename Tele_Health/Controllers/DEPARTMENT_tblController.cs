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
    public class DEPARTMENT_tblController : Controller
    {
        private Model1 db = new Model1();

        // GET: DEPARTMENT_tbl
        public ActionResult Index()
        {
            var dEPARTMENT_tbl = db.DEPARTMENT_tbl.Include(d => d.HOSPITAL_tbl);
            return View(dEPARTMENT_tbl.ToList());
        }

        // GET: DEPARTMENT_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT_tbl dEPARTMENT_tbl = db.DEPARTMENT_tbl.Find(id);
            if (dEPARTMENT_tbl == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT_tbl);
        }

        // GET: DEPARTMENT_tbl/Create
        public ActionResult Create()
        {
            ViewBag.HOSPITAL_FID = new SelectList(db.HOSPITAL_tbl, "HOSPITAL_ID", "HOSPITAL_NAME");
            return View();
        }

        // POST: DEPARTMENT_tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DEPARTMENT_ID,DEPARTMENT_NAME,HOSPITAL_FID")] DEPARTMENT_tbl dEPARTMENT_tbl)
        {
            if (ModelState.IsValid)
            {
                db.DEPARTMENT_tbl.Add(dEPARTMENT_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HOSPITAL_FID = new SelectList(db.HOSPITAL_tbl, "HOSPITAL_ID", "HOSPITAL_NAME", dEPARTMENT_tbl.HOSPITAL_FID);
            return View(dEPARTMENT_tbl);
        }

        // GET: DEPARTMENT_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT_tbl dEPARTMENT_tbl = db.DEPARTMENT_tbl.Find(id);
            if (dEPARTMENT_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.HOSPITAL_FID = new SelectList(db.HOSPITAL_tbl, "HOSPITAL_ID", "HOSPITAL_NAME", dEPARTMENT_tbl.HOSPITAL_FID);
            return View(dEPARTMENT_tbl);
        }

        // POST: DEPARTMENT_tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DEPARTMENT_ID,DEPARTMENT_NAME,HOSPITAL_FID")] DEPARTMENT_tbl dEPARTMENT_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dEPARTMENT_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HOSPITAL_FID = new SelectList(db.HOSPITAL_tbl, "HOSPITAL_ID", "HOSPITAL_NAME", dEPARTMENT_tbl.HOSPITAL_FID);
            return View(dEPARTMENT_tbl);
        }

        // GET: DEPARTMENT_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DEPARTMENT_tbl dEPARTMENT_tbl = db.DEPARTMENT_tbl.Find(id);
            if (dEPARTMENT_tbl == null)
            {
                return HttpNotFound();
            }
            return View(dEPARTMENT_tbl);
        }

        // POST: DEPARTMENT_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DEPARTMENT_tbl dEPARTMENT_tbl = db.DEPARTMENT_tbl.Find(id);
            db.DEPARTMENT_tbl.Remove(dEPARTMENT_tbl);
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
