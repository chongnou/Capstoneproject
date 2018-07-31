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
    public class ReserveatablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reserveatables
        public ViewResult Index(string sortOrder, string searchString)
        {
            var register = from s in db.Reserveatables
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                register = register.Where(s => s.Name.Contains(searchString)
                                       || s.RestaurantName.Contains(searchString)
                                       || s.PhoneNumber.Contains(searchString)
                                       || s.Email.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Name":
                    register = register.OrderByDescending(s => s.Name);
                    break;
                case "Restaurant Name":
                    register = register.OrderBy(s => s.RestaurantName);
                    break;
                case "Phone Number":
                    register = register.OrderByDescending(s => s.PhoneNumber);
                    break;
                case "Email":
                    register = register.OrderByDescending(s => s.Email);
                    break;
            }
            return View(register.ToList());
        }

        // GET: Reserveatables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserveatable reserveatable = db.Reserveatables.Find(id);
            if (reserveatable == null)
            {
                return HttpNotFound();
            }
            return View(reserveatable);
        }

        // GET: Reserveatables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reserveatables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,RestaurantName,PhoneNumber,Email")] Reserveatable reserveatable)
        {
            if (ModelState.IsValid)
            {
                db.Reserveatables.Add(reserveatable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reserveatable);
        }

        // GET: Reserveatables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserveatable reserveatable = db.Reserveatables.Find(id);
            if (reserveatable == null)
            {
                return HttpNotFound();
            }
            return View(reserveatable);
        }

        // POST: Reserveatables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,RestaurantName,PhoneNumber,Email")] Reserveatable reserveatable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserveatable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserveatable);
        }

        // GET: Reserveatables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserveatable reserveatable = db.Reserveatables.Find(id);
            if (reserveatable == null)
            {
                return HttpNotFound();
            }
            return View(reserveatable);
        }

        // POST: Reserveatables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserveatable reserveatable = db.Reserveatables.Find(id);
            db.Reserveatables.Remove(reserveatable);
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
