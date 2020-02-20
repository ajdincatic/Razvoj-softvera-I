using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.VM
{
    public class PopravniIspitPrikazVM
    {
        public int OpstiPodaciPPId { get; set; }
        public string Predmet { get; set; }
        public string Skola { get; set; }
        public string SkolskaGodina { get; set; }
        public List<Row> rows { get; set; }
        public class Row
        {
            public int PopravniIspitId { get; set; }
            public string Datum { get; set; }
            public string ClanKomisije { get; set; }
            public int BrojUcenika { get; set; }
            public int BrojPolozenih { get; set; }
        }
    }
}
