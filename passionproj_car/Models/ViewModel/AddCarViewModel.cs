using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace passionproject_2.Models.ViewModel
{
    public class AddCarViewModel
    {
        public Cars Cars { get; set; }
        public List<Brands> Brands { get; set; }
        public List<Bodytypes> Bodytypes { get; set; }
    }
}


