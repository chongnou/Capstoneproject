using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Capstoneproject.Models;

namespace Capstoneproject.Controllers
{
    public class ReserveATablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReserveATables
        public ActionResult Index()
        {
            return View(db.ReserveATable.ToList());
        }

        // GET: ReserveATables/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveATable reserveATable = db.ReserveATable.Find(id);
            if (reserveATable == null)
            {
                return HttpNotFound();
            }
            return View(reserveATable);
        }

        // GET: ReserveATables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReserveATables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PhoneNumber,Email")] ReserveATable reserveATable)
        {
            if (ModelState.IsValid)
            {
                db.ReserveATable.Add(reserveATable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reserveATable);
        }

        // GET: ReserveATables/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveATable reserveATable = db.ReserveATable.Find(id);
            if (reserveATable == null)
            {
                return HttpNotFound();
            }
            return View(reserveATable);
        }

        // POST: ReserveATables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PhoneNumber,Email")] ReserveATable reserveATable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserveATable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserveATable);
        }

        // GET: ReserveATables/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReserveATable reserveATable = db.ReserveATable.Find(id);
            if (reserveATable == null)
            {
                return HttpNotFound();
            }
            return View(reserveATable);
        }

        // POST: ReserveATables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ReserveATable reserveATable = db.ReserveATable.Find(id);
            db.ReserveATable.Remove(reserveATable);
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
