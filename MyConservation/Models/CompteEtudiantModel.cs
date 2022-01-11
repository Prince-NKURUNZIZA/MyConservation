using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyConservation.Models
{
    public class CompteEtudiantModel 
    {
        public int id { get; set; }
        public string titre { get; set; }
       
        public int domaine { get; set; }
        public int nature { get; set; }
        

        // [DisplayName("upload file")]
        public string fichier { get; set; }

        // [NotMapped]
        // public HttpPostedFileBase docfile { get; set; }

        public bool etatPublication { get; set; }
        public bool autoriseTelecharge { get; set; }
   
  
    
    }
   
}