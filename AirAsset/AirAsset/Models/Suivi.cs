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
    public class Suivi
    {
        [Key]
        public int suiviID { get; set; }

        [Required(ErrorMessage = "Le suivi est obligatoire")]
        [Display(Name ="Suivi")]
        [Index(IsUnique = true)]// correct bug Column ‘{column_name}’ in table ‘{table_name}’ is of a type that is invalid to use as key column in an index.
        [Column(TypeName = "VARCHAR")]//
        [StringLength(50)]
        public string suivi { get; set; }
    }
}