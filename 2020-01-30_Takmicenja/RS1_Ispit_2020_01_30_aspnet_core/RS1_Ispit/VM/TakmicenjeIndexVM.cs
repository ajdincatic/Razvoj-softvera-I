﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.VM
{
    public class TakmicenjeIndexVM
    {
        public int SkolaDomacinId { get; set; }
        public List<SelectListItem> Skole { get; set; }
        public int Razred { get; set; }
    }
}
