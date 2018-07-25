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
    public class RestaurantListsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RestaurantLists
        public ActionResult Index()
        {
            return View(db.RestaurantLists.ToList());
        }

        // GET: RestaurantLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantList restaurantList = db.RestaurantLists.Find(id);
            if (restaurantList == null)
            {
                return HttpNotFound();
            }
            return View(restaurantList);
        }

        // GET: RestaurantLists/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,No,Name,Website")] RestaurantList restaurantList)
        {
            if (ModelState.IsValid)
            {
                db.RestaurantLists.Add(restaurantList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurantList);
        }

        // GET: RestaurantLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantList restaurantList = db.RestaurantLists.Find(id);
            if (restaurantList == null)
            {
                return HttpNotFound();
            }
            return View(restaurantList);
        }

        // POST: RestaurantLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,No,Name,Website")] RestaurantList restaurantList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurantList);
        }

        // GET: RestaurantLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RestaurantList restaurantList = db.RestaurantLists.Find(id);
            if (restaurantList == null)
            {
                return HttpNotFound();
            }
            return View(restaurantList);
        }

        // POST: RestaurantLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RestaurantList restaurantList = db.RestaurantLists.Find(id);
            db.RestaurantLists.Remove(restaurantList);
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
