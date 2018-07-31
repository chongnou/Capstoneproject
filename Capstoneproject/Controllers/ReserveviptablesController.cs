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
    public class ReserveviptablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reserveviptables
        public ViewResult Index(string sortOrder, string searchString)
        {
            var register = from s in db.Reserveviptables
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                register = register.Where(s => s.Name.Contains(searchString)
                                       || s.BarName.Contains(searchString)
                                       || s.PhoneNumber.Contains(searchString)
                                       || s.PartySize.Contains(searchString)
                                       || s.Email.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Name":
                    register = register.OrderByDescending(s => s.Name);
                    break;
                case "Restaurant Name":
                    register = register.OrderBy(s => s.BarName);
                    break;
                case "Phone Number":
                    register = register.OrderByDescending(s => s.PhoneNumber);
                    break;
                case "Party Size":
                    register = register.OrderByDescending(s => s.PartySize);
                    break;
                case "Email":
                    register = register.OrderByDescending(s => s.Email);
                    break;
            }
            return View(register.ToList());
        }

        // GET: Reserveviptables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserveviptable reserveviptable = db.Reserveviptables.Find(id);
            if (reserveviptable == null)
            {
                return HttpNotFound();
            }
            return View(reserveviptable);
        }

        // GET: Reserveviptables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Reserveviptables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,BarName,PhoneNumber,PartySize,Email")] Reserveviptable reserveviptable)
        {
            if (ModelState.IsValid)
            {
                db.Reserveviptables.Add(reserveviptable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reserveviptable);
        }

        // GET: Reserveviptables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserveviptable reserveviptable = db.Reserveviptables.Find(id);
            if (reserveviptable == null)
            {
                return HttpNotFound();
            }
            return View(reserveviptable);
        }

        // POST: Reserveviptables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,BarName,PhoneNumber,PartySize,Email")] Reserveviptable reserveviptable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserveviptable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserveviptable);
        }

        // GET: Reserveviptables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reserveviptable reserveviptable = db.Reserveviptables.Find(id);
            if (reserveviptable == null)
            {
                return HttpNotFound();
            }
            return View(reserveviptable);
        }

        // POST: Reserveviptables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reserveviptable reserveviptable = db.Reserveviptables.Find(id);
            db.Reserveviptables.Remove(reserveviptable);
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
