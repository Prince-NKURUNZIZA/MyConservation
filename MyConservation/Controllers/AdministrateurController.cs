﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyConservation.Models;

namespace MyConservation.Controllers
{
    public class AdministrateurController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /Administrateur/

        public ActionResult Index()
        {
            return View(db.Administrateurs.ToList());
        }

        //
        // GET: /Administrateur/Details/5

        public ActionResult Details(int id = 0)
        {
            Administrateur administrateur = db.Administrateurs.Find(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        //
        // GET: /Administrateur/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administrateur/Create

        [HttpPost]
        public ActionResult Create(Administrateur administrateur)
        {
            if (ModelState.IsValid)
            {
                db.Administrateurs.Add(administrateur);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(administrateur);
        }

        //
        // GET: /Administrateur/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Administrateur administrateur = db.Administrateurs.Find(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        //
        // POST: /Administrateur/Edit/5

        [HttpPost]
        public ActionResult Edit(Administrateur administrateur)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrateur).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(administrateur);
        }

        //
        // GET: /Administrateur/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Administrateur administrateur = db.Administrateurs.Find(id);
            if (administrateur == null)
            {
                return HttpNotFound();
            }
            return View(administrateur);
        }

        //
        // POST: /Administrateur/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Administrateur administrateur = db.Administrateurs.Find(id);
            db.Administrateurs.Remove(administrateur);
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