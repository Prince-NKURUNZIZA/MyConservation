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
    public class EvenementController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /Evenement/

        public ActionResult Index()
        {
            return View(db.Evenements.ToList());
        }

        //
        // GET: /Evenement/Details/5

        public ActionResult Details(int id = 0)
        {
            Evenement evenement = db.Evenements.Find(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }
            return View(evenement);
        }

        //
        // GET: /Evenement/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Evenement/Create

        [HttpPost]
        public ActionResult Create(Evenement evenement)
        {
            if (ModelState.IsValid)
            {
                db.Evenements.Add(evenement);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(evenement);
        }

        //
        // GET: /Evenement/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Evenement evenement = db.Evenements.Find(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }
            return View(evenement);
        }

        //
        // POST: /Evenement/Edit/5

        [HttpPost]
        public ActionResult Edit(Evenement evenement)
        {
            if (ModelState.IsValid)
            {
                db.Entry(evenement).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evenement);
        }

        //
        // GET: /Evenement/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Evenement evenement = db.Evenements.Find(id);
            if (evenement == null)
            {
                return HttpNotFound();
            }
            return View(evenement);
        }

        //
        // POST: /Evenement/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Evenement evenement = db.Evenements.Find(id);
            db.Evenements.Remove(evenement);
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