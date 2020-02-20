using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.VM
{
    public class OdrzanaNastavaPrikazVM
    {
        public int NastavnikId { get; set; }
        public List<Row> rows { get; set; }
        public class Row
        {
            public int OdrzaniCasId { get; set; }
            public string Datum { get; set; }
            public string Skola { get; set; }
            public string Odjeljenje { get; set; }
            public string SkGodina { get; set; }
            public string Predmet { get; set; }
            public List<string> Odsutni { get; set; }
        }
    }
}
