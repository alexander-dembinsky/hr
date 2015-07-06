using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR.Models
{
    public class InfoType
    {
        public virtual Guid Id { get; set; }

        [Remote("ValidateInfoTypeName", "InfoType", "Settings", AdditionalFields = "Id")]
        [Required(ErrorMessage = "Name is required")]
        [Display(Name = "Name")]
        public virtual string Name { get; set; }

        [Display(Name = "Mask")]
        public virtual string Mask { get; set; }

        [Required]
        public virtual Group Group { get; set; }

        public virtual bool Active { get; set; }

        public virtual Image Image { get; set; }
    }
}