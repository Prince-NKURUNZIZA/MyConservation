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
    public class EtudiantController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /Etudiant/

        public ActionResult Index()
        {
           
            return View(db.Etudiants.ToList());
        }

        //
        // GET: /Etudiant/Details/5

        public ActionResult Details(int id = 0)
        {
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        //
        // GET: /Etudiant/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Etudiant/Create

        [HttpPost]
        public ActionResult Create(Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.Etudiants.Add(etudiant);
                db.SaveChanges();
                TempData["AlertMessage"] = "Enregistre avec sucess....!";
                return RedirectToAction("Index");
            }

            return View(etudiant);
        }

        //
        // GET: /Etudiant/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        //
        // POST: /Etudiant/Edit/5

        [HttpPost]
        public ActionResult Edit(Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etudiant).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Modifie avec sucess....!";
                return RedirectToAction("Index");
            }
            return View(etudiant);
        }

        //
        // GET: /Etudiant/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Etudiant etudiant = db.Etudiants.Find(id);
            if (etudiant == null)
            {
                return HttpNotFound();
            }
            return View(etudiant);
        }

        //
        // POST: /Etudiant/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Etudiant etudiant = db.Etudiants.Find(id);
            db.Etudiants.Remove(etudiant);
            db.SaveChanges();
            TempData["AlertMessage"] = "Supprime avec sucess....!";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}