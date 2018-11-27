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
    public class Programme
    {
        [Key]
        public int programID { get; set; }

        [Required(ErrorMessage = "Le programme est obligatoire")]
        [Display(Name = "Programme")]
        [DataType(DataType.Text)]
        [Index(IsUnique = true)]// correct bug Column ‘{column_name}’ in table ‘{table_name}’ is of a type that is invalid to use as key column in an index.
        [Column(TypeName = "VARCHAR")]//
        [StringLength(50)]//
        public string program { get; set; }
    }
}