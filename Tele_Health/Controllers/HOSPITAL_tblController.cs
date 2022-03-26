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
    public class HOSPITAL_tblController : Controller
    {
        private Model1 db = new Model1();

        // GET: HOSPITAL_tbl
        public ActionResult Index()
        {
            return View(db.HOSPITAL_tbl.ToList());
        }

        // GET: HOSPITAL_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOSPITAL_tbl hOSPITAL_tbl = db.HOSPITAL_tbl.Find(id);
            if (hOSPITAL_tbl == null)
            {
                return HttpNotFound();
            }
            return View(hOSPITAL_tbl);
        }

        // GET: HOSPITAL_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HOSPITAL_tbl/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HOSPITAL_ID,HOSPITAL_NAME,HOSPITAL_ADDRESS")] HOSPITAL_tbl hOSPITAL_tbl)
        {
            if (ModelState.IsValid)
            {
                db.HOSPITAL_tbl.Add(hOSPITAL_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hOSPITAL_tbl);
        }

        // GET: HOSPITAL_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOSPITAL_tbl hOSPITAL_tbl = db.HOSPITAL_tbl.Find(id);
            if (hOSPITAL_tbl == null)
            {
                return HttpNotFound();
            }
            return View(hOSPITAL_tbl);
        }

        // POST: HOSPITAL_tbl/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HOSPITAL_ID,HOSPITAL_NAME,HOSPITAL_ADDRESS")] HOSPITAL_tbl hOSPITAL_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOSPITAL_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hOSPITAL_tbl);
        }

        // GET: HOSPITAL_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOSPITAL_tbl hOSPITAL_tbl = db.HOSPITAL_tbl.Find(id);
            if (hOSPITAL_tbl == null)
            {
                return HttpNotFound();
            }
            return View(hOSPITAL_tbl);
        }

        // POST: HOSPITAL_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOSPITAL_tbl hOSPITAL_tbl = db.HOSPITAL_tbl.Find(id);
            db.HOSPITAL_tbl.Remove(hOSPITAL_tbl);
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
