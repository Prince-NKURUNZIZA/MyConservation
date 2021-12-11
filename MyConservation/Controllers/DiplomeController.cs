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
    public class DiplomeController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /Diplome/

        public ActionResult Index()
        {
            return View(db.Diplomes.ToList());
        }

        //
        // GET: /Diplome/Details/5

        public ActionResult Details(int id = 0)
        {
            Diplome diplome = db.Diplomes.Find(id);
            if (diplome == null)
            {
                return HttpNotFound();
            }
            return View(diplome);
        }

        //
        // GET: /Diplome/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Diplome/Create

        [HttpPost]
        public ActionResult Create(Diplome diplome)
        {
            if (ModelState.IsValid)
            {
                db.Diplomes.Add(diplome);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(diplome);
        }

        //
        // GET: /Diplome/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Diplome diplome = db.Diplomes.Find(id);
            if (diplome == null)
            {
                return HttpNotFound();
            }
            return View(diplome);
        }

        //
        // POST: /Diplome/Edit/5

        [HttpPost]
        public ActionResult Edit(Diplome diplome)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diplome).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(diplome);
        }

        //
        // GET: /Diplome/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Diplome diplome = db.Diplomes.Find(id);
            if (diplome == null)
            {
                return HttpNotFound();
            }
            return View(diplome);
        }

        //
        // POST: /Diplome/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Diplome diplome = db.Diplomes.Find(id);
            db.Diplomes.Remove(diplome);
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