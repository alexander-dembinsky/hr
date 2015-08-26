using HR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR.Infrastructure.Repository
{
    public class HRRepository : IHRRepository
    {
        HRContext context = new HRContext();

        public IEnumerable<InfoType> GetAllInfoType
        {
            get { return context.InfoType; }
        }

        public IEnumerable<Image> GetAllImage
        {
            get { return context.Images; }
        }

        public void SaveInfoType(InfoType infoType)
        {
            context.InfoType.Add(infoType);
            context.SaveChanges();
        }
    }
}