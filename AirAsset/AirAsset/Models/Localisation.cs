using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace AirAsset.Models
{
    public class Localisation
    {
        [Key]
        public int localisationId { get; set; }

        [Required(ErrorMessage = "La localisation est obligatoire")]
        [Display(Name = "Localisation")]
        [Index(IsUnique = true)]// correct bug Column ‘{column_name}’ in table ‘{table_name}’ is of a type that is invalid to use as key column in an index.
        [Column(TypeName = "VARCHAR")]//
        [StringLength(50)]
        public string localisation { get; set; }
    }
}