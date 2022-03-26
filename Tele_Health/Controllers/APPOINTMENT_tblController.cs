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
    public class APPOINTMENT_tblController : Controller
    {
        private Model1 db = new Model1();

        // GET: APPOINTMENT_tbl
        public ActionResult Index()
        {
            var aPPOINTMENT_tbl = db.APPOINTMENT_tbl.Include(a => a.DOCTOR_SCHEDULE).Include(a => a.PATIENT_tbl);
            return View(aPPOINTMENT_tbl.ToList());
        }

        // GET: APPOINTMENT_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPOINTMENT_tbl aPPOINTMENT_tbl = db.APPOINTMENT_tbl.Find(id);
            if (aPPOINTMENT_tbl == null)
            {
                return HttpNotFound();
            }
            return View(aPPOINTMENT_tbl);
        }

        // GET: APPOINTMENT_tbl/Create
        public ActionResult Create()
        {
            ViewBag.PATIENT_FID = new SelectList(db.DOCTOR_SCHEDULE, "SCHEDULE_ID", "TOTAL_APPOINTMENTS");
            ViewBag.PATIENT_FID = new SelectList(db.PATIENT_tbl, "PATIENT_ID", "PATIENT_NAME");
            return View();
        }

        // POST: APPOINTMENT_tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "APPOINTMENT_ID,APPOINTMENT_NO,APPOINTMENT_DATE,DOCTOR_FID,PATIENT_FID,SCHEDULE_FID")] APPOINTMENT_tbl aPPOINTMENT_tbl)
        {
            if (ModelState.IsValid)
            {
                db.APPOINTMENT_tbl.Add(aPPOINTMENT_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PATIENT_FID = new SelectList(db.DOCTOR_SCHEDULE, "SCHEDULE_ID", "TOTAL_APPOINTMENTS", aPPOINTMENT_tbl.PATIENT_FID);
            ViewBag.PATIENT_FID = new SelectList(db.PATIENT_tbl, "PATIENT_ID", "PATIENT_NAME", aPPOINTMENT_tbl.PATIENT_FID);
            return View(aPPOINTMENT_tbl);
        }

        // GET: APPOINTMENT_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPOINTMENT_tbl aPPOINTMENT_tbl = db.APPOINTMENT_tbl.Find(id);
            if (aPPOINTMENT_tbl == null)
            {
                return HttpNotFound();
            }
            ViewBag.PATIENT_FID = new SelectList(db.DOCTOR_SCHEDULE, "SCHEDULE_ID", "TOTAL_APPOINTMENTS", aPPOINTMENT_tbl.PATIENT_FID);
            ViewBag.PATIENT_FID = new SelectList(db.PATIENT_tbl, "PATIENT_ID", "PATIENT_NAME", aPPOINTMENT_tbl.PATIENT_FID);
            return View(aPPOINTMENT_tbl);
        }

        // POST: APPOINTMENT_tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "APPOINTMENT_ID,APPOINTMENT_NO,APPOINTMENT_DATE,DOCTOR_FID,PATIENT_FID,SCHEDULE_FID")] APPOINTMENT_tbl aPPOINTMENT_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aPPOINTMENT_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PATIENT_FID = new SelectList(db.DOCTOR_SCHEDULE, "SCHEDULE_ID", "TOTAL_APPOINTMENTS", aPPOINTMENT_tbl.PATIENT_FID);
            ViewBag.PATIENT_FID = new SelectList(db.PATIENT_tbl, "PATIENT_ID", "PATIENT_NAME", aPPOINTMENT_tbl.PATIENT_FID);
            return View(aPPOINTMENT_tbl);
        }

        // GET: APPOINTMENT_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            APPOINTMENT_tbl aPPOINTMENT_tbl = db.APPOINTMENT_tbl.Find(id);
            if (aPPOINTMENT_tbl == null)
            {
                return HttpNotFound();
            }
            return View(aPPOINTMENT_tbl);
        }

        // POST: APPOINTMENT_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            APPOINTMENT_tbl aPPOINTMENT_tbl = db.APPOINTMENT_tbl.Find(id);
            db.APPOINTMENT_tbl.Remove(aPPOINTMENT_tbl);
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
