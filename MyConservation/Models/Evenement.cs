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
    
    public partial class Evenement
    {
        public Evenement()
        {
            this.Galeries = new HashSet<Galery>();
        }
    
        public int id { get; set; }
        public string titreEvenement { get; set; }
        public string commentaire { get; set; }
    
        public virtual ICollection<Galery> Galeries { get; set; }
    }
}
