//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MyConservation.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Etudiant
    {
        public Etudiant()
        {
            this.Documents = new HashSet<Document>();
        }
    
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string adresse { get; set; }
        public string email { get; set; }
        public string sexe { get; set; }
        public string nationalite { get; set; }
        public string password { get; set; }
    
        public virtual ICollection<Document> Documents { get; set; }
    }
}
