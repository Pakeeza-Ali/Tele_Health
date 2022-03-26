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
    public class DOCTOR_SCHEDULEController : Controller
    {
        private Model1 db = new Model1();

        // GET: DOCTOR_SCHEDULE
        public ActionResult Index()
        {
            var dOCTOR_SCHEDULE = db.DOCTOR_SCHEDULE.Include(d => d.DOCTOR_tbl);
            return View(dOCTOR_SCHEDULE.ToList());
        }

        // GET: DOCTOR_SCHEDULE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR_SCHEDULE dOCTOR_SCHEDULE = db.DOCTOR_SCHEDULE.Find(id);
            if (dOCTOR_SCHEDULE == null)
            {
                return HttpNotFound();
            }
            return View(dOCTOR_SCHEDULE);
        }

        // GET: DOCTOR_SCHEDULE/Create
        public ActionResult Create()
        {
            ViewBag.DOCTOR_FID = new SelectList(db.DOCTOR_tbl, "DOCTOR_ID", "DOCTOR_NAME");
            return View();
        }

        // POST: DOCTOR_SCHEDULE/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SCHEDULE_ID,DOCTOR_FID,TOTAL_APPOINTMENTS,TIME,DATE,DAY")] DOCTOR_SCHEDULE dOCTOR_SCHEDULE)
        {
            if (ModelState.IsValid)
            {
                db.DOCTOR_SCHEDULE.Add(dOCTOR_SCHEDULE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DOCTOR_FID = new SelectList(db.DOCTOR_tbl, "DOCTOR_ID", "DOCTOR_NAME", dOCTOR_SCHEDULE.DOCTOR_FID);
            return View(dOCTOR_SCHEDULE);
        }

        // GET: DOCTOR_SCHEDULE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR_SCHEDULE dOCTOR_SCHEDULE = db.DOCTOR_SCHEDULE.Find(id);
            if (dOCTOR_SCHEDULE == null)
            {
                return HttpNotFound();
            }
            ViewBag.DOCTOR_FID = new SelectList(db.DOCTOR_tbl, "DOCTOR_ID", "DOCTOR_NAME", dOCTOR_SCHEDULE.DOCTOR_FID);
            return View(dOCTOR_SCHEDULE);
        }

        // POST: DOCTOR_SCHEDULE/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SCHEDULE_ID,DOCTOR_FID,TOTAL_APPOINTMENTS,TIME,DATE,DAY")] DOCTOR_SCHEDULE dOCTOR_SCHEDULE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCTOR_SCHEDULE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DOCTOR_FID = new SelectList(db.DOCTOR_tbl, "DOCTOR_ID", "DOCTOR_NAME", dOCTOR_SCHEDULE.DOCTOR_FID);
            return View(dOCTOR_SCHEDULE);
        }

        // GET: DOCTOR_SCHEDULE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCTOR_SCHEDULE dOCTOR_SCHEDULE = db.DOCTOR_SCHEDULE.Find(id);
            if (dOCTOR_SCHEDULE == null)
            {
                return HttpNotFound();
            }
            return View(dOCTOR_SCHEDULE);
        }

        // POST: DOCTOR_SCHEDULE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DOCTOR_SCHEDULE dOCTOR_SCHEDULE = db.DOCTOR_SCHEDULE.Find(id);
            db.DOCTOR_SCHEDULE.Remove(dOCTOR_SCHEDULE);
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
