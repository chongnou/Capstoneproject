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
    public class EventCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventComments
        public ActionResult Index()
        {
            return View(db.Eventcomments.ToList());
        }

        // GET: EventComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventComments eventComments = db.Eventcomments.Find(id);
            if (eventComments == null)
            {
                return HttpNotFound();
            }
            return View(eventComments);
        }

        // GET: EventComments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EventName,Comment,PostDate")] EventComments eventComments)
        {
            if (ModelState.IsValid)
            {
                eventComments.PostDate = DateTime.Today;
                db.Eventcomments.Add(eventComments);
                db.SaveChanges();
                return RedirectToAction("Index", "Activities");
            }

            return View(eventComments);
        }

        // GET: EventComments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventComments eventComments = db.Eventcomments.Find(id);
            if (eventComments == null)
            {
                return HttpNotFound();
            }
            return View(eventComments);
        }

        // POST: EventComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EventName,Comment,PostDate")] EventComments eventComments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventComments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventComments);
        }

        // GET: EventComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventComments eventComments = db.Eventcomments.Find(id);
            if (eventComments == null)
            {
                return HttpNotFound();
            }
            return View(eventComments);
        }

        // POST: EventComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventComments eventComments = db.Eventcomments.Find(id);
            db.Eventcomments.Remove(eventComments);
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
