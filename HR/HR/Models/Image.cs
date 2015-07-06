using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.Models
{
    public class Image
    {
        public virtual Guid Id { get; set; }
        public virtual byte[] Content { get; set; }
    }
}