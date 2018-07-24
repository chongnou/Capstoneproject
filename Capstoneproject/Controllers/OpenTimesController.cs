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
    public class OpenTimesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OpenTimes
        public ActionResult Index()
        {
            return View(db.OpenTime.ToList());
        }

        // GET: OpenTimes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenTime openTime = db.OpenTime.Find(id);
            if (openTime == null)
            {
                return HttpNotFound();
            }
            return View(openTime);
        }

        // GET: OpenTimes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OpenTimes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Start")] OpenTime openTime)
        {
            if (ModelState.IsValid)
            {
                db.OpenTime.Add(openTime);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(openTime);
        }

        // GET: OpenTimes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenTime openTime = db.OpenTime.Find(id);
            if (openTime == null)
            {
                return HttpNotFound();
            }
            return View(openTime);
        }

        // POST: OpenTimes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Start")] OpenTime openTime)
        {
            if (ModelState.IsValid)
            {
                db.Entry(openTime).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(openTime);
        }

        // GET: OpenTimes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OpenTime openTime = db.OpenTime.Find(id);
            if (openTime == null)
            {
                return HttpNotFound();
            }
            return View(openTime);
        }

        // POST: OpenTimes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OpenTime openTime = db.OpenTime.Find(id);
            db.OpenTime.Remove(openTime);
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
