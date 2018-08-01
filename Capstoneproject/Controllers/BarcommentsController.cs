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
    public class BarcommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Barcomments
        public ActionResult Index()
        {
            return View(db.Barcomments.ToList());
        }

        // GET: Barcomments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barcomments barcomments = db.Barcomments.Find(id);
            if (barcomments == null)
            {
                return HttpNotFound();
            }
            return View(barcomments);
        }

        // GET: Barcomments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Barcomments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BarName,Comment,PostDate")] Barcomments barcomments)
        {
            if (ModelState.IsValid)
            {
                barcomments.PostDate = DateTime.Today;
                db.Barcomments.Add(barcomments);
                db.SaveChanges();
                return RedirectToAction("Index", "NightLives");
            }

            return View(barcomments);
        }

        // GET: Barcomments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barcomments barcomments = db.Barcomments.Find(id);
            if (barcomments == null)
            {
                return HttpNotFound();
            }
            return View(barcomments);
        }

        // POST: Barcomments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BarName,Comment,PostDate")] Barcomments barcomments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(barcomments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "NightLives");
            }
            return View(barcomments);
        }

        // GET: Barcomments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Barcomments barcomments = db.Barcomments.Find(id);
            if (barcomments == null)
            {
                return HttpNotFound();
            }
            return View(barcomments);
        }

        // POST: Barcomments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Barcomments barcomments = db.Barcomments.Find(id);
            db.Barcomments.Remove(barcomments);
            db.SaveChanges();
            return RedirectToAction("Index", "NightLives");
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
