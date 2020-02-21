using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace passionproject_2.Models
{
    public class Cars
    {
        [Key]
        public int CarID { get; set; }

        public string CarName { get; set; }

        /*foreign keys*/
        public int BrandID { get; set; }
        [ForeignKey("BrandID")]
        public virtual Brands Brands { get; set; }

        public int BodytypeID { get; set; }
        [ForeignKey("BodytypeID")]
        public virtual Bodytypes Bodytypes { get; set; }


    }
}

        