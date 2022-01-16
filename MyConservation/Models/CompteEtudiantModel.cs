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
        public int nomAuteur { get; set; }
        public int universite { get; set; }
        public int diplome { get; set; }
        public int domaine { get; set; }
        public int nature { get; set; }
        public int annee { get; set; }


        public string fichier { get; set; }

        // [NotMapped]
        
       

        public bool etatPublication { get; set; }
        public bool autoriseTelecharge { get; set; }

       
   
  
    
    }
   
}