using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.VM
{
    public class OdrzaniCasStavkeVM
    {
        public List<Row> rows { get; set; }
        public class Row
        {
            public int StavkaId { get; set; }
            public string Ucenik { get; set; }
            public int? Ocjena { get; set; }
            public bool Prisutan { get; set; }
            public bool Opravdano { get; set; }
        }
       
    }
}
