using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.VM
{
    public class AjaxPrikazUcenikaVM
    {
        public int PopravniIspitId { get; set; }
        public List<Row> rows { get; set; }
        public class Row
        {
            public string Ucenik { get; set; }
            public string Odjeljenje { get; set; }
            public int BrojUDnevniku { get; set; }
            public bool PristupioIspitu { get; set; }
            public bool MozePristupiti { get; set; }
            public float? BrojBodova { get; set; }
            public int PopravniStavkaId { get; set; }
        }
    }
}
