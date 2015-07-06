using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR.Models
{
    public class InfoType
    {
        public virtual Guid Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Mask { get; set; }
        public virtual Group Group { get; set; }
        public virtual bool Active { get; set; }
        public virtual Image Image { get; set; }
    }
}