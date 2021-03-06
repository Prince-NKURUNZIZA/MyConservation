using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyConservation.Models;
using System.IO;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyConservation.Controllers
{
    public class TraveauPublierController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /TraveauPublier/

        public ActionResult Index()
        {
            var documents = db.Documents.Include(d => d.Diplome1).Include(d => d.DomaineFormation).Include(d => d.NatureDocument).Include(d => d.Etudiant).Include(d => d.Universite1).OrderByDescending(d => d.id);
            return View(documents.ToList());
        }

        //
        // GET: /TraveauPublier/Details/5

        public ActionResult Details(int id = 0)
        {
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        //
        // GET: /TraveauPublier/Create

        public ActionResult Create()
        {
            ViewBag.diplome = new SelectList(db.Diplomes, "id", "niveau");
            ViewBag.domaine = new SelectList(db.DomaineFormations, "id", "nomDomaine");
            ViewBag.nature = new SelectList(db.NatureDocuments, "id", "nature");
            ViewBag.nomAuteur = new SelectList(db.Etudiants, "id", "nom");
            ViewBag.universite = new SelectList(db.Universites, "id", "nomUniversite");
            return View();
        }

        //
        // POST: /TraveauPublier/Create

        [HttpPost]
        public ActionResult Create(Document document)
        {
            if (ModelState.IsValid)
            {
                db.Documents.Add(document);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.diplome = new SelectList(db.Diplomes, "id", "niveau", document.diplome);
            ViewBag.domaine = new SelectList(db.DomaineFormations, "id", "nomDomaine", document.domaine);
            ViewBag.nature = new SelectList(db.NatureDocuments, "id", "nature", document.nature);
            ViewBag.nomAuteur = new SelectList(db.Etudiants, "id", "nom", document.nomAuteur);
            ViewBag.universite = new SelectList(db.Universites, "id", "nomUniversite", document.universite);
            return View(document);
        }


        public ActionResult Downloads()
        {
            var dir = new System.IO.DirectoryInfo(Server.MapPath("~/Fichiers/"));
            System.IO.FileInfo[] fileNames = dir.GetFiles("*.*"); List<string> items = new List<string>();
            foreach (var file in fileNames)
            {
                items.Add(file.Name);
            }
            return View(items);
        }

        public FileResult Download(string ImageName)
        {
            var FileVirtualPath = "~/Fichiers/" + ImageName;
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }

        //
        // GET: /TraveauPublier/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            ViewBag.diplome = new SelectList(db.Diplomes, "id", "niveau", document.diplome);
            ViewBag.domaine = new SelectList(db.DomaineFormations, "id", "nomDomaine", document.domaine);
            ViewBag.nature = new SelectList(db.NatureDocuments, "id", "nature", document.nature);
            ViewBag.nomAuteur = new SelectList(db.Etudiants, "id", "nom", document.nomAuteur);
            ViewBag.universite = new SelectList(db.Universites, "id", "nomUniversite", document.universite);
            return View(document);
        }

        //
        // POST: /TraveauPublier/Edit/5

        [HttpPost]
        public ActionResult Edit(Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.diplome = new SelectList(db.Diplomes, "id", "niveau", document.diplome);
            ViewBag.domaine = new SelectList(db.DomaineFormations, "id", "nomDomaine", document.domaine);
            ViewBag.nature = new SelectList(db.NatureDocuments, "id", "nature", document.nature);
            ViewBag.nomAuteur = new SelectList(db.Etudiants, "id", "nom", document.nomAuteur);
            ViewBag.universite = new SelectList(db.Universites, "id", "nomUniversite", document.universite);
            return View(document);
        }

        //
        // GET: /TraveauPublier/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Document document = db.Documents.Find(id);
            if (document == null)
            {
                return HttpNotFound();
            }
            return View(document);
        }

        //
        // POST: /TraveauPublier/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
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