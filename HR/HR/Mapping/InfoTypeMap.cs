using FluentNHibernate.Mapping;
using HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.Mapping
{
    public class InfoTypeMap : ClassMap<InfoType>
    {
        public InfoTypeMap()
        {
            Table("InfoType");
            Id(_ => _.Id);
            Map(_ => _.Name);
            Map(_ => _.Mask);
            Map(_ => _.Active);
            Map(_ => _.Group, "[Group]").CustomType<Group>();
            References(_ => _.Image).Column("ImageId");
        }
    }
}