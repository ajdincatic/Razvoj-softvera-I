﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class OdrzaniCas
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public PredajePredmet PredajePredmet { get; set; }
        public int PredajePredmetId { get; set; }
        public string SadrzajaCasa { get; set; }
    }
}
