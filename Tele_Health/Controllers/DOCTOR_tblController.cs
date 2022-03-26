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
    public class DOCTOR_tblController : Controller
    {
        private Model1 db = new Model1();

        // GET: DOCTOR_tbl
        public ActionResult Index()
        {
            var dOCTOR_tbl = db.DOCTOR_tbl.Include(d => d.DEPARTMENT_tbl).Include(d => d.HOSPITAL_tbl);
            return View(dOCTOR_tbl.ToList());
        }

        // GET: DOCTOR_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR_tbl dOCTOR_tbl = db.DOCTOR_tbl.Find(id);
            if (dOCTOR_tbl == null)
            {
                return HttpNotFound();
            }
            return View(dOCTOR_tbl);
        }

        // GET: DOCTOR_tbl/Create
        public ActionResult Create()
        {
            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_tbl, "DEPARTMENT_ID", "DEPARTMENT_NAME");
            ViewBag.HOSPITAL_FID = new SelectList(db.HOSPITAL_tbl, "HOSPITAL_ID", "HOSPITAL_NAME");
            return View();
        }

        // POST: DOCTOR_tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DOCTOR_ID,DOCTOR_NAME,DOCTOR_CNIC,DOCTOR_EMAIL,DOCTOR_PASSWORD,DOCTOR_ADDRESS,DOCTOR_SPECIFICATION,DEPARTMENT_FID,HOSPITAL_FID")] DOCTOR_tbl dOCTOR_tbl)
        {
            if (ModelState.IsValid)
            {
                db.DOCTOR_tbl.Add(dOCTOR_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_tbl, "DEPARTMENT_ID", "DEPARTMENT_NAME", dOCTOR_tbl.DEPARTMENT_FID);
            ViewBag.HOSPITAL_FID = new SelectList(db.HOSPITAL_tbl, "HOSPITAL_ID", "HOSPITAL_NAME", dOCTOR_tbl.HOSPITAL_FID);
            return View(dOCTOR_tbl);
        }

        // GET: DOCTOR_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR_tbl dOCTOR_tbl = db.DOCTOR_tbl.Find(id);
            if (dOCTOR_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_tbl, "DEPARTMENT_ID", "DEPARTMENT_NAME", dOCTOR_tbl.DEPARTMENT_FID);
            ViewBag.HOSPITAL_FID = new SelectList(db.HOSPITAL_tbl, "HOSPITAL_ID", "HOSPITAL_NAME", dOCTOR_tbl.HOSPITAL_FID);
            return View(dOCTOR_tbl);
        }

        // POST: DOCTOR_tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DOCTOR_ID,DOCTOR_NAME,DOCTOR_CNIC,DOCTOR_EMAIL,DOCTOR_PASSWORD,DOCTOR_ADDRESS,DOCTOR_SPECIFICATION,DEPARTMENT_FID,HOSPITAL_FID")] DOCTOR_tbl dOCTOR_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCTOR_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DEPARTMENT_FID = new SelectList(db.DEPARTMENT_tbl, "DEPARTMENT_ID", "DEPARTMENT_NAME", dOCTOR_tbl.DEPARTMENT_FID);
            ViewBag.HOSPITAL_FID = new SelectList(db.HOSPITAL_tbl, "HOSPITAL_ID", "HOSPITAL_NAME", dOCTOR_tbl.HOSPITAL_FID);
            return View(dOCTOR_tbl);
        }

        // GET: DOCTOR_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR_tbl dOCTOR_tbl = db.DOCTOR_tbl.Find(id);
            if (dOCTOR_tbl == null)
            {
                return HttpNotFound();
            }
            return View(dOCTOR_tbl);
        }

        // POST: DOCTOR_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOCTOR_tbl dOCTOR_tbl = db.DOCTOR_tbl.Find(id);
            db.DOCTOR_tbl.Remove(dOCTOR_tbl);
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
