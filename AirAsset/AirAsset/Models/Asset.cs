using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static AirAsset.Models.Moyen;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PagedList.Mvc;
using PagedList;
namespace AirAsset.Models
{
    public class Asset
    {

        public int assetID { get; set; }

        [Required(ErrorMessage = "La réference est obligatoire")]
        [Display(Name = "Reference Moyen")]
        [DataType(DataType.Text)]
        public string reference { get; set; }

        [Required(ErrorMessage = "Le code de l'exemplaire est obligatoire")]
        [Display(Name = "Code Exemplaire")]
        [DataType(DataType.Text)]
        //[Index(IsUnique = true)]// correct bug Column ‘{column_name}’ in table ‘{table_name}’ is of a type that is invalid to use as key column in an index.
        //[Column(TypeName = "VARCHAR")]//
        [StringLength(150)]//
        public string exemplaireCODE { get; set; }
       


        [Display(Name = "Désignation")]
        [DataType(DataType.Text)]
        [StringLength(150)]
        public string designation { get {return location+"-"+assetID; } }


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


        public Moyen moyen { get; set; }
      
    }
}