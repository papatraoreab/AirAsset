using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace AirAsset.Models
{
    public class TypeLocalisation
    {
        [Key]
        public int typelocalisationId { get; set; }

        [Required(ErrorMessage = "Le type de localisation est obligatoire")]
        [Display(Name = "Type de localisation")]
        [Index(IsUnique = true)]// correct bug Column ‘{column_name}’ in table ‘{table_name}’ is of a type that is invalid to use as key column in an index.
        [Column(TypeName = "VARCHAR")]//
        [StringLength(150)]
        public string typelocalisation { get; set; }
    }
}