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
    public class DocumentPublierController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /DocumentPublier/

        public ActionResult Index()
        {
            var documentpubliers = db.DocumentPubliers.Include(d => d.Document);
            return View(documentpubliers.ToList());
        }

        //
        // GET: /DocumentPublier/Details/5

        public ActionResult Details(int id = 0)
        {
            DocumentPublier documentpublier = db.DocumentPubliers.Find(id);
            if (documentpublier == null)
            {
                return HttpNotFound();
            }
            return View(documentpublier);
        }

        //
        // GET: /DocumentPublier/Create

        public ActionResult Create()
        {
            ViewBag.titre = new SelectList(db.Documents, "id", "titre");
            return View();
        }

        //
        // POST: /DocumentPublier/Create

        [HttpPost]
        public ActionResult Create(DocumentPublier documentpublier)
        {
            if (ModelState.IsValid)
            {
                db.DocumentPubliers.Add(documentpublier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.titre = new SelectList(db.Documents, "id", "titre", documentpublier.titre);
            return View(documentpublier);
        }

        //
        // GET: /DocumentPublier/Edit/5

        public ActionResult Edit(int id = 0)
        {
            DocumentPublier documentpublier = db.DocumentPubliers.Find(id);
            if (documentpublier == null)
            {
                return HttpNotFound();
            }
            ViewBag.titre = new SelectList(db.Documents, "id", "titre", documentpublier.titre);
            return View(documentpublier);
        }

        //
        // POST: /DocumentPublier/Edit/5

        [HttpPost]
        public ActionResult Edit(DocumentPublier documentpublier)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documentpublier).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.titre = new SelectList(db.Documents, "id", "titre", documentpublier.titre);
            return View(documentpublier);
        }

        //
        // GET: /DocumentPublier/Delete/5

        public ActionResult Delete(int id = 0)
        {
            DocumentPublier documentpublier = db.DocumentPubliers.Find(id);
            if (documentpublier == null)
            {
                return HttpNotFound();
            }
            return View(documentpublier);
        }

        //
        // POST: /DocumentPublier/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            DocumentPublier documentpublier = db.DocumentPubliers.Find(id);
            db.DocumentPubliers.Remove(documentpublier);
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