using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using salonkrasotbl.Models;
using System.Data.Entity;

namespace salonkrasotbl.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        public ActionResult Index()
        {
            return View(db.Servicess);
        }
        [HttpPost]
        public ActionResult EditServices(Services services)
        {
            db.Entry(services).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        [HttpGet]
        public ActionResult CreateServices()
        {
            SelectList services = new SelectList(db.Servicess,"nomer","nazvanije","stoimist");
            ViewBag.Services = services;
            return View();
        }
        [HttpPost]
        public ActionResult CreateServices(Services services)
        {
            db.Servicess.Add(services);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult BuyServices(int nomer)
        {
            ViewBag.Servicesnomer = nomer;
            return View();
        }
        [HttpPost]
        public string BuyServices(Orders orders)
        {
            orders.vremja = DateTime.Now;
            db.Orderss.Add(orders);
            db.SaveChanges();
            return " Spasibo za pokypky";
        }
        private DateTime getToday()
        {
            return DateTime.Now;
        }
    }

}