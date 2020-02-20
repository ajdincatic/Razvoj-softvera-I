using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.VM
{
    public class PopravniIspitUrediVM
    {
        public int PopravniIspitId { get; set; }
        public string ClanKomisije1 { get; set; }
        public string ClanKomisije2 { get; set; }
        public string ClanKomisije3 { get; set; }
        public string Datum { get; set; }
        public string Skola { get; set; }
        public string SkolskaGodina { get; set; }
        public string Predmet { get; set; }
        public int PodaciId { get; set; }
    }
}
