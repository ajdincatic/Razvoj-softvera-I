using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.VM
{
    public class OdjeljenjeIndexVM
    {
        public int OdId { get; set; }
        public string SkolskaGodina { get; set; }
        public int Razred { get; set; }
        public string Oznaka { get; set; }
        public string Razrednik { get; set; }
        public bool IsPrebacen { get; set; }
        public string Prosjek { get; set; }
        public string NajUcenik { get; set; }

    }
}
