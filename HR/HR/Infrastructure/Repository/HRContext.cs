using HR.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HR.Infrastructure.Repository
{
    public class HRContext : DbContext
    {
        public DbSet<InfoType> InfoType { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}