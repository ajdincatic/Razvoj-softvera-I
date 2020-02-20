using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.VM
{
    public class AjaxMaturskiIspitStavkeVM
    {
        public int MaturskiIspitId { get; set; }
        public List<Row> rows { get; set; }
        public class Row
        {
            public int StavkaId { get; set; }
            public string Ucenik { get; set; }
            public string Prosjek { get; set; }
            public bool Pristupio { get; set; }
            public int Bodovi { get; set; }
        }
    }
}
