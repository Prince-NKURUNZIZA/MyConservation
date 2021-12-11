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
    public class NatureDocumentController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /NatureDocument/

        public ActionResult Index()
        {
            return View(db.NatureDocuments.ToList());
        }

        //
        // GET: /NatureDocument/Details/5

        public ActionResult Details(int id = 0)
        {
            NatureDocument naturedocument = db.NatureDocuments.Find(id);
            if (naturedocument == null)
            {
                return HttpNotFound();
            }
            return View(naturedocument);
        }

        //
        // GET: /NatureDocument/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NatureDocument/Create

        [HttpPost]
        public ActionResult Create(NatureDocument naturedocument)
        {
            if (ModelState.IsValid)
            {
                db.NatureDocuments.Add(naturedocument);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(naturedocument);
        }

        //
        // GET: /NatureDocument/Edit/5

        public ActionResult Edit(int id = 0)
        {
            NatureDocument naturedocument = db.NatureDocuments.Find(id);
            if (naturedocument == null)
            {
                return HttpNotFound();
            }
            return View(naturedocument);
        }

        //
        // POST: /NatureDocument/Edit/5

        [HttpPost]
        public ActionResult Edit(NatureDocument naturedocument)
        {
            if (ModelState.IsValid)
            {
                db.Entry(naturedocument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(naturedocument);
        }

        //
        // GET: /NatureDocument/Delete/5

        public ActionResult Delete(int id = 0)
        {
            NatureDocument naturedocument = db.NatureDocuments.Find(id);
            if (naturedocument == null)
            {
                return HttpNotFound();
            }
            return View(naturedocument);
        }

        //
        // POST: /NatureDocument/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            NatureDocument naturedocument = db.NatureDocuments.Find(id);
            db.NatureDocuments.Remove(naturedocument);
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