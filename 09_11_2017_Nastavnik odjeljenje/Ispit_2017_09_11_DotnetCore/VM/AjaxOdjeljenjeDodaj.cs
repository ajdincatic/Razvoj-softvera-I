using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.VM
{
    public class AjaxOdjeljenjeDodaj
    {
        public int BrojUDnevniku { get; set; }
        public List<SelectListItem> ucenici { get; set; }
        public int UcenikId { get; set; }
        public int OdjeljenjeID { get; set; }
        public int OdjeljenjeStavkaId { get; set; }
    }
}
