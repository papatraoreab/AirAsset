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
    public class EntrepotLigne
    {
        [Key]
        public int entrepotID { get; set; }

        [Required(ErrorMessage = "L'entrepot ou la ligne est obligatoire")]
        [Display(Name = "Entrepot ou Ligne")]
        [DataType(DataType.Text)]
        [Index(IsUnique = true)]// correct bug Column ‘{column_name}’ in table ‘{table_name}’ is of a type that is invalid to use as key column in an index.
        [Column(TypeName = "VARCHAR")]//
        [StringLength(150)]//
        public string entrepot { get; set; }
    }
}