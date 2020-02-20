using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxUrediNumVM
    {
        public string Pretraga { get; set; }
        public string MjernaJedinica { get; set; }
        public int IzmjerenaVrijednost { get; set; }
        public int RezultatiPretrageId { get; set; }
        public int UplatnicaId { get; set; }

    }
}
