using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.VM
{
    public class PopravniIspitDodajVM
    {
        public int ClanKomisije1Id { get; set; }
        public int ClanKomisije2Id { get; set; }
        public int ClanKomisije3Id { get; set; }
        public List<SelectListItem> Nastavnici { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public string Predmet { get; set; }
        public int PredmetId { get; set; }
        public string Skola { get; set; }
        public string SkolskaGodina { get; set; }
        public int OpstiPodaciId { get; set; }
    }
}
