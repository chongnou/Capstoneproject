using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Capstoneproject.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Capstoneproject.Controllers
{
    public class RegisterForEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegisterForEvents
        public ActionResult Index()
        {
            return View(db.RegisterForEvents.ToList());
        }

        public ActionResult Register()
        {
            ApplicationDbContext db = new ApplicationDbContext();
            
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterForEvent account)
        {
            if (ModelState.IsValid)
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.RegisterForEvents.Add(account);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = account.Name + "" + account.PhoneNumber + "" + account.Email + "Successfully Registered!";
            }
            return View();

        }
    }
}
