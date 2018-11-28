using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using static AirAsset.Models.Moyen;
using System.ComponentModel.DataAnnotations.Schema;
using PagedList.Mvc;
using PagedList;

namespace AirAsset.Models
{
    public class Exemplaire
    {
        //[ScaffoldColumn(false)]// masque les champs de formulaire de l'éditeur
        public int exemplaireID { get; set; }

        /*
        public virtual int moyenID { get; set; }
        public Moyen Moyen { get; set; }
        */


        [Required(ErrorMessage = "La réference est obligatoire")]
        [Display(Name = "Reference Moyen")]
        [DataType(DataType.Text)]
        public string reference { get; set; }

        //[Required(ErrorMessage = "Le code de l'exemplaire est obligatoire")]
        [Display(Name = "Code Exemplaire")]
        [DataType(DataType.Text)]
        //[Index(IsUnique = true)]// correct bug Column ‘{column_name}’ in table ‘{table_name}’ is of a type that is invalid to use as key column in an index.
        //[Column(TypeName = "VARCHAR")]//
        [StringLength(150)]//
        public string exemplaireCODE {
            get { return reference + "-" + exemplaireID; }
        }

        [Display(Name = "Désignation")]
        [DataType(DataType.Text)]
        [StringLength(150)]
        public string designation { get; set; }

        

        [Required(ErrorMessage = "Le prix de l'exemplaire est obligatoire")]
        [Display(Name = "Prix")]
        [DataType(DataType.Text)]
        public double prix { get; set; }

        [Display(Name = "Suivi")]
        public string suivi { get; set; }

        [Display(Name = "Localisation")]
        public string location { get; set; }

        [Display(Name = "Type de Localisation")]
        public string typelocation { get; set; }


        [Required(ErrorMessage = "Le fournisseur de l'exemplaire est obligatoire")]
        [Display(Name = "Fournisseur")]
        [DataType(DataType.Text)]
        [StringLength(150)]
        public string fournisseur { get; set; }

        [Display(Name = "Statut")]
        public string statut { get; set; }

        [Required(ErrorMessage = "La date d'Entrée en Service est obligatoire")]
        [Display(Name = "Date d'Entrée en Service")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date_ES { get; set; }

        [Required(ErrorMessage = "La date de Fin de Service est obligatoire")]
        [Display(Name = "Date de Fin de Service")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date_FS { get; set; }

        public Moyen Moyen { get; set; }


        [NotMapped]
        public IEnumerable<Moyen> MoyensCollection { get; set; }

        [NotMapped]
        public IEnumerable<Exemplaire> ExemplairesCollection { get; set; }


        //collection à afficher dans le formulaire

        //Liste des Suivis
        public ApplicationModel.Item[] SuiviListe { get; set; }

        //Liste des Localisations
        public ApplicationModel.Item[] LocalisationListe { get; set; }

        //Liste des Localisations
        public ApplicationModel.Item[] TypeLocalisationListe { get; set; }

        //Liste des Fournisseurs
        //public ApplicationModel.Item[] FournisseurListe { get; set; }

        //Liste des Statuts
        public ApplicationModel.Item[] StatutListe { get; set; }

        //constructeur par defaut
        public Exemplaire()
        {

        }

        //constructeur avec paramètres
        public Exemplaire(ApplicationModel app)
        {
            //Init collections
            SuiviListe = app.SuiviListe;
            LocalisationListe = app.LocalisationListe;
            TypeLocalisationListe = app.TypeLocalisationListe;
            //FournisseurListe = app.FournisseurListe;
            StatutListe = app.StatutListe;

            //Init des champs du formulaires
            //exemplaireCODE = "XX0000-000";
            designation = "designation du moyen";
            prix = 0;
            suivi = "1";
            location = "1";
            typelocation = "1";
            fournisseur = "nom du fournisseur";
            statut = "1";
        }

        
    }
}