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
    public class LoginAdminController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /LoginAdmin/

        public ActionResult Index()
        {
            return View(db.Administrateurs.ToList());
        }

        //
        // GET: /LoginAdmin/Details/5

        public ActionResult Details(int id = 0)
        {
            Administrateur administrateur = db.Administrateurs.Find(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        //
        // GET: /LoginAdmin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LoginAdmin/Create

        [HttpPost]
        public ActionResult Create(Administrateur administrateur)
        {
            if (ModelState.IsValid)
            {
                db.Administrateurs.Add(administrateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrateur);
        }

        [HttpGet]

        public ActionResult LoginAdm()
        {
            return View();
        }

        [HttpPost]

        public ActionResult LoginAdm(Administrateur administrateur)
        {
            var obj = db.Administrateurs.Where(x => x.email.Equals(administrateur.email) && x.password.Equals(administrateur.password)).FirstOrDefault();


            if (obj != null)
            {

                return RedirectToAction("Acceuil", "CompteEtudiant");
            }

            else
            {
                return RedirectToAction("Login", "EtudiantClient");

            }
        }


        //
        // GET: /LoginAdmin/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Administrateur administrateur = db.Administrateurs.Find(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        //
        // POST: /LoginAdmin/Edit/5

        [HttpPost]
        public ActionResult Edit(Administrateur administrateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrateur);
        }

        //
        // GET: /LoginAdmin/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Administrateur administrateur = db.Administrateurs.Find(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        //
        // POST: /LoginAdmin/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrateur administrateur = db.Administrateurs.Find(id);
            db.Administrateurs.Remove(administrateur);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}