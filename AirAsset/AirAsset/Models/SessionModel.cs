using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static AirAsset.Models.ApplicationModel;
namespace AirAsset.Models
{
    public class SessionModel
    {
        //collection a afficher dans le formulaire
        public Item[] SecteurListe { get; set; }
        public Item[] ProgrammeListe { get; set; }
        public Item[] PoinEcoulementListe { get; set; }
        public Item[] EntrepotListe { get; set; }
        public Item[] TypeListe { get; set; }
        public Item[] SuiviListe { get; set; }
        public Item[] LocalisationListe { get; set; }
        //public Item[] FournisseursListe { get; set; }
        public Item[] StatutListe { get; set; }
    }
}