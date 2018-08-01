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
    public class RestaurantcommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Restaurantcomments
        public ActionResult Index()
        {
            return View(db.Restaurantcomments.ToList());
        }

        // GET: Restaurantcomments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurantcomments restaurantcomments = db.Restaurantcomments.Find(id);
            if (restaurantcomments == null)
            {
                return HttpNotFound();
            }
            return View(restaurantcomments);
        }

        // GET: Restaurantcomments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurantcomments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,RestaurantName,Comment,PostDate")] Restaurantcomments restaurantcomments)
        {
            if (ModelState.IsValid)
            {
                restaurantcomments.PostDate = DateTime.Today;
                db.Restaurantcomments.Add(restaurantcomments);
                db.SaveChanges();
                return RedirectToAction("Index", "Restaurants");
            }

            return View(restaurantcomments);
        }

        // GET: Restaurantcomments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurantcomments restaurantcomments = db.Restaurantcomments.Find(id);
            if (restaurantcomments == null)
            {
                return HttpNotFound();
            }
            return View(restaurantcomments);
        }

        // POST: Restaurantcomments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,RestaurantName,Comment,PostDate")] Restaurantcomments restaurantcomments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantcomments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Restaurants");
            }
            return View(restaurantcomments);
        }

        // GET: Restaurantcomments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurantcomments restaurantcomments = db.Restaurantcomments.Find(id);
            if (restaurantcomments == null)
            {
                return HttpNotFound();
            }
            return View(restaurantcomments);
        }

        // POST: Restaurantcomments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurantcomments restaurantcomments = db.Restaurantcomments.Find(id);
            db.Restaurantcomments.Remove(restaurantcomments);
            db.SaveChanges();
            return RedirectToAction("Index", "Restaurants");
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
