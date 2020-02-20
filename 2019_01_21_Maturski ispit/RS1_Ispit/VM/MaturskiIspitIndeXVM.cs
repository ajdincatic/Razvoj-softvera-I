using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.VM
{
    public class MaturskiIspitIndexVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public string Škola { get; set; }
            public string Nastavnik { get; set; }
            public int NastavnikId { get; set; }
        }
    }
}
