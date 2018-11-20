using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PagedList.Mvc;
using PagedList;

namespace AirAsset.Models
{
    public class Moyen
    {
        //[ScaffoldColumn(false)]// masque les champs de formulaire de l'éditeur
        public int moyenID { get; set; }

        [Required(ErrorMessage = "Le code du moyen est obligatoire")]
        [Display(Name = "Code Moyen")]
        [DataType(DataType.Text)]
        [Index(IsUnique = true)]
        [Column(TypeName = "VARCHAR")]
        [StringLength(150)]
        public string moyenCODE { get; set; }

        [Required(ErrorMessage = "La désignation du moyen est obligatoire")]
        [Display(Name = "Désignation ")]
        [DataType(DataType.Text)]
        [StringLength(150)]
        public string designation { get; set; }

        [Display(Name = "Secteur")]
        public string secteur { get; set; }

        [Display(Name = "Programme")]
        public string program { get; set; }

        [Display(Name = "Entrepot|Ligne")]
        public string entrepot { get; set; }

        [Display(Name = "Type")]
        public string type { get; set; }

        [Required(ErrorMessage = "La description du moyen est obligatoire")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        [StringLength(250)]
        public string description { get; set; }

        [Required(ErrorMessage = "Le poids du moyen est obligatoire")]
        [Display(Name = "Poids (Kg)")]
        [DataType(DataType.Text)]
        public double poids { get; set; }

        [Required(ErrorMessage = "Le CMU du moyen est obligatoire")]
        [Display(Name = "CMU (Kg)")]
        [DataType(DataType.Text)]
        public double cmu { get; set; }

        [Required(ErrorMessage = "La Hauteur du moyen est obligatoire")]
        [Display(Name = "Hauteur (mm)")]
        [DataType(DataType.Text)]
        public double hauteur { get; set; }

        [Required(ErrorMessage = "La Longueur du moyen est obligatoire")]
        [Display(Name = "Longueur (mm)")]
        [DataType(DataType.Text)]
        public double longueur { get; set; }

        [Required(ErrorMessage = "La Largeur du moyen est obligatoire")]
        [Display(Name = "Largeur (mm)")]
        [DataType(DataType.Text)]
        public double largeur { get; set; }

        [Required(ErrorMessage = "La vitesse du vent est obligatoire")]
        [Display(Name = "Vitesse Vent")]
        [DataType(DataType.Text)]
        public double vVent { get; set; }

        [Required(ErrorMessage = "Le RUS Number est obligatoire")]
        [Display(Name = "RUS Number")]
        [DataType(DataType.Text)]
        public string r_number { get; set; }

        [Required(ErrorMessage = "Le Tool Number est obligatoire")]
        [Display(Name = "Tool Number")]
        [DataType(DataType.Text)]
        public string t_number { get; set; }

        //collection de Files
        public virtual ICollection<File> Files { get; set; }


        //collection a afficher dans le formulaire

        //Liste des Secteurs
        public ApplicationModel.Item[] SecteurListe { get; set; }

        //Liste des Programmes
        public ApplicationModel.Item[] ProgrammeListe { get; set; }

        //Liste des Entrepots|Lignes
        public ApplicationModel.Item[] EntrepotListe { get; set; }

        //Liste des Types
        public ApplicationModel.Item[] TypeListe { get; set; }

        //constructeur par defaut
        public Moyen()
        {

        }

        //constructeur avec paramètres
        public Moyen(ApplicationModel app)
        {
            //Init collections
            //Init collections
            SecteurListe = app.SecteurListe;
            ProgrammeListe = app.ProgrammeListe;
            EntrepotListe = app.EntrepotListe;
            TypeListe = app.TypeListe;

            //Init des champs du formulaires
            moyenCODE = "XX0000";
            designation = "designation du moyen";
            secteur = "1";
            program = "1";
            entrepot = "1";
            type = "1";
            description = "descriptions du moyen ici, ...";
            poids = 0;
            cmu = 0;
            hauteur = 0;
            longueur = 0;
            largeur = 0;
            vVent = 0;
            r_number = "pas renseigne";
            t_number = "pas renseigne";
        }
    }
}