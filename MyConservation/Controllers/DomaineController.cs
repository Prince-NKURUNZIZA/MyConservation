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
    public class DomaineController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /Domaine/

        public ActionResult Index()
        {
            return View(db.DomaineFormations.ToList());
        }

        //
        // GET: /Domaine/Details/5

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
        // GET: /Domaine/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Domaine/Create

        [HttpPost]
        public ActionResult Create(DomaineFormation domaineformation)
        {
            if (ModelState.IsValid)
            {
                db.DomaineFormations.Add(domaineformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(domaineformation);
        }

        //
        // GET: /Domaine/Edit/5

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
        // POST: /Domaine/Edit/5

        [HttpPost]
        public ActionResult Edit(DomaineFormation domaineformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(domaineformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(domaineformation);
        }

        //
        // GET: /Domaine/Delete/5

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
        // POST: /Domaine/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            DomaineFormation domaineformation = db.DomaineFormations.Find(id);
            db.DomaineFormations.Remove(domaineformation);
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