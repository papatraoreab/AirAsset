using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AirAsset.Models
{
    public class File
    {
        [Key]
        public int fileId { get; set; }
        [StringLength(255)]
        public string fileName { get; set; }
        [StringLength(100)]
        public string contentType { get; set; }
        public byte[] content { get; set; }
        public FileType FileType { get; set; }
        public int moyenID { get; set; }
        public virtual Moyen Moyen { get; set; }
    }
}