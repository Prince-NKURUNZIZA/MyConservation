using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyConservation.Models;

namespace MyConservation.Controllers
{
    public class DashboardController : Controller
    {
        private ConservationEntities db = new ConservationEntities();
        //
        // GET: /Dashboard/

        public ActionResult Admin()
        {
            return View();
        }



        [HttpGet]

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Index(Administrateur administrateur)
        {
            var obj = db.Administrateurs.Where(x => x.email.Equals(administrateur.email) && x.password.Equals(administrateur.password)).FirstOrDefault();

            Session["username"] = obj.prenom;
            if (obj != null)
            {

                return RedirectToAction("Admin", "Dashboard");
            }

            else
            {
                TempData["AlertMessage"] = "Impossible de se connecter...!";
                return RedirectToAction("Index", "Dashboard");

            }
        }
    }
}
