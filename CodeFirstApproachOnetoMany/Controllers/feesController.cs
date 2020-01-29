using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeFirstApproachOnetoMany.Models;

namespace CodeFirstApproachOnetoMany.Controllers
{
    public class feesController : Controller
    {
        private cs db = new cs();

        // GET: fees
        public ActionResult Index()
        {
            var fees = db.fees.Include(f => f.student);
            return View(fees.ToList());
        }

        // GET: fees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fee fee = db.fees.Find(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            return View(fee);
        }

        // GET: fees/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "Std_name");
            return View();
        }

        // POST: fees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "feeid,feeamount,date,StudentId")] fee fee)
        {
            if (ModelState.IsValid)
            {
                db.fees.Add(fee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.students, "StudentId", "Std_name", fee.StudentId);
            return View(fee);
        }

        // GET: fees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fee fee = db.fees.Find(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "Std_name", fee.StudentId);
            return View(fee);
        }

        // POST: fees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "feeid,feeamount,date,StudentId")] fee fee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.students, "StudentId", "Std_name", fee.StudentId);
            return View(fee);
        }

        // GET: fees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            fee fee = db.fees.Find(id);
            if (fee == null)
            {
                return HttpNotFound();
            }
            return View(fee);
        }

        // POST: fees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            fee fee = db.fees.Find(id);
            db.fees.Remove(fee);
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
