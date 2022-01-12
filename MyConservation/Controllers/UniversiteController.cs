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
    public class UniversiteController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /Universite/

        public ActionResult Index()
        {
            return View(db.Universites.ToList());
        }

        //
        // GET: /Universite/Details/5

        public ActionResult Details(int id = 0)
        {
            Universite universite = db.Universites.Find(id);
            if (universite == null)
            {
                return HttpNotFound();
            }
            return View(universite);
        }

        //
        // GET: /Universite/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Universite/Create

        [HttpPost]
        public ActionResult Create(Universite universite)
        {
            bool IsAdminExist = db.Universites.Any(x => x.nomUniversite == universite.nomUniversite && x.id != universite.id);
            if (IsAdminExist == true)
            {
                TempData["AlertMessage2"] = "L'universite existe deja....!";
                return RedirectToAction("Index");
            }
           
            if (ModelState.IsValid)
            {
                db.Universites.Add(universite);
                db.SaveChanges();
                TempData["AlertMessage"] = "Enregistre avec sucess....!";
                return RedirectToAction("Index");
            }

            return View(universite);
        }

        //
        // GET: /Universite/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Universite universite = db.Universites.Find(id);
            if (universite == null)
            {
                return HttpNotFound();
            }
            return View(universite);
        }

        //
        // POST: /Universite/Edit/5

        [HttpPost]
        public ActionResult Edit(Universite universite)
        {
            if (ModelState.IsValid)
            {
                db.Entry(universite).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Modifié avec sucess....!";
                return RedirectToAction("Index");
            }
            return View(universite);
        }

        //
        // GET: /Universite/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Universite universite = db.Universites.Find(id);
            if (universite == null)
            {
                return HttpNotFound();
            }
            return View(universite);
        }

        //
        // POST: /Universite/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Universite universite = db.Universites.Find(id);
            db.Universites.Remove(universite);
            db.SaveChanges();
            TempData["AlertMessage"] = "Supprimé avec sucess....!";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}