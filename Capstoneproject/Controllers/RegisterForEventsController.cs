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
    public class RegisterforeventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Registerforevents
        public ViewResult Index(string sortOrder, string searchString)
        {
            var register = from s in db.Registerforevents
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                register = register.Where(s => s.Name.Contains(searchString)
                                       || s.Email.Contains(searchString)
                                       || s.EventName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "Name":
                    register = register.OrderByDescending(s => s.Name);
                    break;
                case "Event":
                    register = register.OrderBy(s => s.EventName);
                    break;
                case "Email":
                    register = register.OrderByDescending(s => s.Email);
                    break;
            }
            return View(register.ToList());
        }

        // GET: Registerforevents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registerforevent registerforevent = db.Registerforevents.Find(id);
            if (registerforevent == null)
            {
                return HttpNotFound();
            }
            return View(registerforevent);
        }

        // GET: Registerforevents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Registerforevents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,EventName,Email")] Registerforevent registerforevent)
        {
            if (ModelState.IsValid)
            {
                db.Registerforevents.Add(registerforevent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registerforevent);
        }

        // GET: Registerforevents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registerforevent registerforevent = db.Registerforevents.Find(id);
            if (registerforevent == null)
            {
                return HttpNotFound();
            }
            return View(registerforevent);
        }

        // POST: Registerforevents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,EventName,Email")] Registerforevent registerforevent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerforevent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registerforevent);
        }

        // GET: Registerforevents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registerforevent registerforevent = db.Registerforevents.Find(id);
            if (registerforevent == null)
            {
                return HttpNotFound();
            }
            return View(registerforevent);
        }

        // POST: Registerforevents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registerforevent registerforevent = db.Registerforevents.Find(id);
            db.Registerforevents.Remove(registerforevent);
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
