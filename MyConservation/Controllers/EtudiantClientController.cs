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
    public class EtudiantClientController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /EtudiantClient/

        public ActionResult Index()
        {
            return View(db.Etudiants.ToList());
        }

        //
        // GET: /EtudiantClient/Details/5

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
        // GET: /EtudiantClient/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /EtudiantClient/Create

        [HttpPost]
        public ActionResult Create(Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.Etudiants.Add(etudiant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etudiant);
        }

        //
        // GET: /EtudiantClient/Edit/5

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
        // POST: /EtudiantClient/Edit/5

        [HttpPost]
        public ActionResult Edit(Etudiant etudiant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etudiant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etudiant);
        }

        //
        // GET: /EtudiantClient/Delete/5

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
        // POST: /EtudiantClient/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Etudiant etudiant = db.Etudiants.Find(id);
            db.Etudiants.Remove(etudiant);
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