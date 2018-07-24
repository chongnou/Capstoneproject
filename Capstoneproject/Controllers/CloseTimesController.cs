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
    public class CloseTimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CloseTimes
        public ActionResult Index()
        {
            return View(db.CloseTime.ToList());
        }

        // GET: CloseTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CloseTime closeTime = db.CloseTime.Find(id);
            if (closeTime == null)
            {
                return HttpNotFound();
            }
            return View(closeTime);
        }

        // GET: CloseTimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CloseTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Start")] CloseTime closeTime)
        {
            if (ModelState.IsValid)
            {
                db.CloseTime.Add(closeTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(closeTime);
        }

        // GET: CloseTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CloseTime closeTime = db.CloseTime.Find(id);
            if (closeTime == null)
            {
                return HttpNotFound();
            }
            return View(closeTime);
        }

        // POST: CloseTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Start")] CloseTime closeTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(closeTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(closeTime);
        }

        // GET: CloseTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CloseTime closeTime = db.CloseTime.Find(id);
            if (closeTime == null)
            {
                return HttpNotFound();
            }
            return View(closeTime);
        }

        // POST: CloseTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CloseTime closeTime = db.CloseTime.Find(id);
            db.CloseTime.Remove(closeTime);
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
