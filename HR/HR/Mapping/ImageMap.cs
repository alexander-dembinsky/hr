using FluentNHibernate.Mapping;
using HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.Mapping
{
    public class ImageMap : ClassMap<Image>
    {
        public ImageMap()
        {
            Table("Images");
            Id(_ => _.Id);
            Map(_ => _.Content);
            Map(_ => _.ContentLength);
            Map(_ => _.ContentType);
            Map(_ => _.FileName);
        }
    }
}