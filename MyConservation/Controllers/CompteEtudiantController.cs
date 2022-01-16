using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using MyConservation.Models;

namespace MyConservation.Controllers
{
    public class CompteEtudiantController : Controller
    {
        private ConservationEntities db = new ConservationEntities();

        //
        // GET: /CompteEtudiant/

        public ActionResult Index()
        {
        
                   
            var documents = db.Documents.Include(d => d.Diplome1).Include(d => d.DomaineFormation).Include(d => d.NatureDocument).Include(d => d.Etudiant).Include(d => d.Universite1);


            return View(documents.ToList());
        }
        public ActionResult Acceuil()
        {
            return View();
        }

        //
        // GET: /CompteEtudiant/Details/5

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
        // GET: /CompteEtudiant/Create

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
        // POST: /CompteEtudiant/Create
        public bool Infile(HttpPostedFileBase imgfile)
        {
            return (imgfile != null && imgfile.ContentLength > 0) ? true : false;
        }  

        [HttpPost]
        public ActionResult Create(Document document, HttpPostedFileBase fichier)
        {

           

           /* string fileName = Path.GetFileNameWithoutExtension(document.docfile.FileName);
            string extension = Path.GetExtension(document.docfile.FileName);
            fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;

           
            fileName = Path.Combine(Server.MapPath("~/Assets/files"), fileName);
            

           document.docfile.SaveAs(fileName);*/


           /* foreach (string upload in Request.Files)
            {
                if (Request.Files[upload].FileName != "")
                {
                    string path = AppDomain.CurrentDomain.BaseDirectory + "/App_Data/uploads/";
                    string filename = Path.GetFileName(Request.Files[upload].FileName);
                    Request.Files[upload].SaveAs(Path.Combine(path, filename));
                }
            }   */

           

   if (ModelState.IsValid)
            {
                if (fichier != null)
                {
                    var fileName = Path.GetFileName(fichier.FileName); 
                    string name = Path.GetFileNameWithoutExtension(fileName);
                    string path = Path.Combine(Server.MapPath("~/Fichiers"), Path.GetFileName(fichier.FileName));
                    fichier.SaveAs(path);

                }
               
                db.Documents.Add(document);
                
                db.SaveChanges();
                TempData["AlertMessage"] = "Enregistre avec sucess....!";
                return RedirectToAction("Index");
            }

            ViewBag.diplome = new SelectList(db.Diplomes, "id", "niveau", document.diplome);
            ViewBag.domaine = new SelectList(db.DomaineFormations, "id", "nomDomaine", document.domaine);
            ViewBag.nature = new SelectList(db.NatureDocuments, "id", "nature", document.nature);
            ViewBag.nomAuteur = new SelectList(db.Etudiants, "id", "nom", document.nomAuteur);
            ViewBag.universite = new SelectList(db.Universites, "id", "nomUniversite", document.universite);
            return View(document);
        }
        //////////////////////////////////////////////////////////
      


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
        // GET: /CompteEtudiant/Edit/5

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
        // POST: /CompteEtudiant/Edit/5

        [HttpPost]
        public ActionResult Edit(Document document)
        {
            if (ModelState.IsValid)
            {
                db.Entry(document).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Modifié avec sucess....!";
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
        // GET: /CompteEtudiant/Delete/5

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
        // POST: /CompteEtudiant/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Document document = db.Documents.Find(id);
            db.Documents.Remove(document);
            db.SaveChanges();
            TempData["AlertMessage"] = "Supprimé avec sucess....!";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}