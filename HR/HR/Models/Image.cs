using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HR.Models
{
    [Table("Images")]
    public class Image
    {
        [Column(TypeName = "uniqueidentifier")]
        [Required]
        public Guid Id { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] Content { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string ContentType { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string FileName { get; set; }

        [Column(TypeName = "bigint")]
        [Required]
        public long ContentLength { get; set; }
    }
}