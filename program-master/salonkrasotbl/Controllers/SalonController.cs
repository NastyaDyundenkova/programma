using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace salonkrasotbl.Controllers
{
    public class SalonController : HomeController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}