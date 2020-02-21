using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using passionproject_2;
using passionproject_2.Models;

namespace passionproject_2.Data
{
    public class CarContext : DbContext
    {
        public CarContext() : base("name=CarContext")
        {
        }


        public System.Data.Entity.DbSet<Brands> Brands { get; set; }
        
        public System.Data.Entity.DbSet<Bodytypes> Bodytypes { get; set; }

        public System.Data.Entity.DbSet<Cars> Cars { get; set; }


    }
}