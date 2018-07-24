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
    public class EventListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EventLists
        public ActionResult Index()
        {
            return View(db.EventList.ToList());
        }

        // GET: EventLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventList eventList = db.EventList.Find(id);
            if (eventList == null)
            {
                return HttpNotFound();
            }
            return View(eventList);
        }

        // GET: EventLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EventLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Hours,Cost,Website,Address")] EventList eventList)
        {
            if (ModelState.IsValid)
            {
                db.EventList.Add(eventList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eventList);
        }

        // GET: EventLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventList eventList = db.EventList.Find(id);
            if (eventList == null)
            {
                return HttpNotFound();
            }
            return View(eventList);
        }

        // POST: EventLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Hours,Cost,Website,Address")] EventList eventList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eventList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eventList);
        }

        // GET: EventLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EventList eventList = db.EventList.Find(id);
            if (eventList == null)
            {
                return HttpNotFound();
            }
            return View(eventList);
        }

        // POST: EventLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EventList eventList = db.EventList.Find(id);
            db.EventList.Remove(eventList);
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
