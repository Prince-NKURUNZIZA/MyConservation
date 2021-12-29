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
    public class DomaineFormationController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /DomaineFormation/

        public ActionResult Index()
        {
            return View(db.DomaineFormations.ToList());
        }

        //
        // GET: /DomaineFormation/Details/5

        public ActionResult Details(int id = 0)
        {
            DomaineFormation domaineformation = db.DomaineFormations.Find(id);
            if (domaineformation == null)
            {
                return HttpNotFound();
            }
            return View(domaineformation);
        }

        //
        // GET: /DomaineFormation/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /DomaineFormation/Create

        [HttpPost]
        public ActionResult Create(DomaineFormation domaineformation)
        {
            if (ModelState.IsValid)
            {
                db.DomaineFormations.Add(domaineformation);
                db.SaveChanges();
                TempData["AlertMessage"] = "Enregistre avec sucess....!";
                return RedirectToAction("Index");
            }

            return View(domaineformation);
        }

        //
        // GET: /DomaineFormation/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DomaineFormation domaineformation = db.DomaineFormations.Find(id);
            if (domaineformation == null)
            {
                return HttpNotFound();
            }
            return View(domaineformation);
        }

        //
        // POST: /DomaineFormation/Edit/5

        [HttpPost]
        public ActionResult Edit(DomaineFormation domaineformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(domaineformation).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Modifié avec sucess....!";
                return RedirectToAction("Index");
            }
            return View(domaineformation);
        }

        //
        // GET: /DomaineFormation/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DomaineFormation domaineformation = db.DomaineFormations.Find(id);
            if (domaineformation == null)
            {
                return HttpNotFound();
            }
            return View(domaineformation);
        }

        //
        // POST: /DomaineFormation/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            DomaineFormation domaineformation = db.DomaineFormations.Find(id);
            db.DomaineFormations.Remove(domaineformation);
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