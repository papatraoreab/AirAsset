using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AirAsset.Models
{
    public class Secteur
    {
        [Key]
        public int secteurId { get; set; }

        [Required(ErrorMessage = "Le secteur est obligatoire")]
        [Display(Name = "Produit")]
        [Index(IsUnique = true)]// correct bug Column ‘{column_name}’ in table ‘{table_name}’ is of a type that is invalid to use as key column in an index.
        [Column(TypeName = "VARCHAR")]//
        [StringLength(150)]
        public string secteur { get; set; }
    }
}