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
            int idEtudiant = 0;
            if (Session["idEtudiant"] != null)
            {
                idEtudiant = Convert.ToInt32(Session["idEtudiant"].ToString());
            }
            var Etu = (db.Etudiants).Where(d => d.id == idEtudiant);
            var nombreEtu = (from num in db.Etudiants                 
                          select num).Count();
            Session["NombreEt"] = nombreEtu;
            return View(Etu.ToList());
            
            
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
            bool IsAdminExist = db.Etudiants.Any(x => x.email == etudiant.email && x.id != etudiant.id);
            if (IsAdminExist == true)
            {
                TempData["AlertMessage2"] = "Votre email est déjà utilisé....!";
                return RedirectToAction("Login");
            }
            if (ModelState.IsValid)
            {
                db.Etudiants.Add(etudiant);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            
            return View(etudiant);
        }

        [HttpGet]

        public ActionResult Login()
        {
            
            return View();
        }

    [HttpPost]

        public ActionResult Login(Etudiant etudiant)
        {
           
        var obj = db.Etudiants.Where(x => x.email.Equals(etudiant.email) && x.password.Equals(etudiant.password)).FirstOrDefault();
                 
        if(obj != null){

            Session["nomEtudiant"] = obj.prenom;
            Session["idEtudiant"] = obj.id;
            Session["nomAuteur"] = obj.nom;
            return RedirectToAction("Acceuil","CompteEtudiant");

        }
       
        else {

            TempData["AlertMessage"] = "Mot de passe incorrect ou pas de compte....!";
            return RedirectToAction("Login", "EtudiantClient");       
        } 
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
 