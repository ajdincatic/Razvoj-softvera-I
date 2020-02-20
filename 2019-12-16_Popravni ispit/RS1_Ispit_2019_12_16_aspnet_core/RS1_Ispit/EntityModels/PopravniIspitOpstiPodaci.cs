﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class PopravniIspitOpstiPodaci
    {
        public int Id { get; set; }
        [ForeignKey(nameof(SkolaId))]
        public Skola Skola { get; set; }
        public int SkolaId { get; set; }
        [ForeignKey(nameof(SkolskaGodinaId))]
        public SkolskaGodina SkolskaGodina { get; set; }
        public int SkolskaGodinaId { get; set; }
        [ForeignKey(nameof(PredmetId))]
        public Predmet Predmet { get; set; }
        public int PredmetId { get; set; }
    }
}