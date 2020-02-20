using RS1_Ispit_asp.net_core.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.VM
{
    public class OdrzanaNastavanPrikaziVM
    {
        public int NastavnikId { get; set; }
        public List<Row> rows { get; set; }
        public class Row
        {
            public int MaturskiIspitId { get; set; }
            public string Datum { get; set; }
            public string Skola { get; set; }
            public string Predmet { get; set; }
            public List<string> NisuPristupili { get; set; }
        }
    }
}
