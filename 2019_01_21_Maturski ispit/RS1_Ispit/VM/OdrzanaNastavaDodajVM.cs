﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.VM
{
    public class OdrzanaNastavaDodajVM
    {
        public int SkolaId { get; set; }
        public List<SelectListItem> Skole { get; set; }
        public string Nastavnik { get; set; }
        public string SkolskaGodina { get; set; }
        [DataType(DataType.Date)]
        public DateTime Datum { get; set; }
        public int PredmetId { get; set; }
        public List<SelectListItem> Predemeti { get; set; }
        public int NastanikId { get; set; }

    }
}
