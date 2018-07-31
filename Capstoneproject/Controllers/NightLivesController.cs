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
    [Authorize]
    public class NightLivesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: NightLives
        public ActionResult Index()
        {
            ViewBag.Key = clientkey.SecretKey;
            return View(db.NightLives.ToList());
        }

        // GET: NightLives/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NightLife nightLife = db.NightLives.Find(id);
            if (nightLife == null)
            {
                return HttpNotFound();
            }
            return View(nightLife);
        }

        // GET: NightLives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NightLives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,No,Name")] NightLife nightLife)
        {
            if (ModelState.IsValid)
            {
                db.NightLives.Add(nightLife);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nightLife);
        }

        // GET: NightLives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NightLife nightLife = db.NightLives.Find(id);
            if (nightLife == null)
            {
                return HttpNotFound();
            }
            return View(nightLife);
        }

        // POST: NightLives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,No,Name")] NightLife nightLife)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nightLife).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nightLife);
        }

        // GET: NightLives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NightLife nightLife = db.NightLives.Find(id);
            if (nightLife == null)
            {
                return HttpNotFound();
            }
            return View(nightLife);
        }

        // POST: NightLives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NightLife nightLife = db.NightLives.Find(id);
            db.NightLives.Remove(nightLife);
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
