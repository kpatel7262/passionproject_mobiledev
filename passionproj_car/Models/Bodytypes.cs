using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace passionproject_2.Models
{
    public class Bodytypes
    {
        [Key]
        public int BodytypeID { get; set; }
        public string BodytypeName { get; set; }

    }
}
