using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirAsset.Models
{
    public class Statut
    {
        public int statutID { get; set; }
        [Required(ErrorMessage = "Le statut est obligatoire")]
        [Display(Name = "Statut")]
        [DataType(DataType.Text)]
        [Index(IsUnique = true)]// correct bug Column ‘{column_name}’ in table ‘{table_name}’ is of a type that is invalid to use as key column in an index.
        [Column(TypeName = "VARCHAR")]//
        [StringLength(50)]//
        public string statut { get; set; }


    }
}