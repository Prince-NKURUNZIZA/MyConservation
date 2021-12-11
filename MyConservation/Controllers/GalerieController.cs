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
    public class GalerieController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /Galerie/

        public ActionResult Index()
        {
            var galeries = db.Galeries.Include(g => g.Evenement1);
            return View(galeries.ToList());
        }

        //
        // GET: /Galerie/Details/5

        public ActionResult Details(int id = 0)
        {
            Galery galery = db.Galeries.Find(id);
            if (galery == null)
            {
                return HttpNotFound();
            }
            return View(galery);
        }

        //
        // GET: /Galerie/Create

        public ActionResult Create()
        {
            ViewBag.evenement = new SelectList(db.Evenements, "id", "titreEvenement");
            return View();
        }

        //
        // POST: /Galerie/Create

        [HttpPost]
        public ActionResult Create(Galery galery)
        {
            if (ModelState.IsValid)
            {
                db.Galeries.Add(galery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.evenement = new SelectList(db.Evenements, "id", "titreEvenement", galery.evenement);
            return View(galery);
        }

        //
        // GET: /Galerie/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Galery galery = db.Galeries.Find(id);
            if (galery == null)
            {
                return HttpNotFound();
            }
            ViewBag.evenement = new SelectList(db.Evenements, "id", "titreEvenement", galery.evenement);
            return View(galery);
        }

        //
        // POST: /Galerie/Edit/5

        [HttpPost]
        public ActionResult Edit(Galery galery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(galery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.evenement = new SelectList(db.Evenements, "id", "titreEvenement", galery.evenement);
            return View(galery);
        }

        //
        // GET: /Galerie/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Galery galery = db.Galeries.Find(id);
            if (galery == null)
            {
                return HttpNotFound();
            }
            return View(galery);
        }

        //
        // POST: /Galerie/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Galery galery = db.Galeries.Find(id);
            db.Galeries.Remove(galery);
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