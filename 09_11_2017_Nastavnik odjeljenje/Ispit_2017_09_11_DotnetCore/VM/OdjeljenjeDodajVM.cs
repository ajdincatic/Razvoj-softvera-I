using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.VM
{
    public class OdjeljenjeDodajVM
    {
        public string SkolskaGodina { get; set; }
        public int Razred { get; set; }
        public string Oznaka { get; set; }
        public List<SelectListItem> Razrednici { get; set; }
        public int RazrednikId { get; set; }
        public List<SelectListItem> NizaOdjeljenja { get; set; }
        public int OdjeljenjeId { get; set; }
    }
}
