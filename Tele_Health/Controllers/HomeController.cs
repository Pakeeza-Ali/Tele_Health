using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Tele_Health.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult IndexPatient()
        {
            return View();
        }
        public ActionResult IndexDoctor()
        {
            return View();
        } 
        public ActionResult IndexAdmin()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}