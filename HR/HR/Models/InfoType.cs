using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Models
{
    [Table("InfoType")]
    public class InfoType
    {
        [Column(TypeName = "uniqueidentifier")]
        [Required]
        public Guid Id { get; set; }

        [Remote("ValidateInfoTypeName", "InfoType", "Settings", AdditionalFields = "Id")]
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        [Column(TypeName = "text")]
        public string Name { get; set; }

        [Display(Name = "Mask")]
        [Column(TypeName = "text")]
        public string Mask { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public Group Group { get; set; }

        public bool Active { get; set; }

        public virtual Image Image { get; set; }

        public Guid? ImageId { get; set; }
    }
}