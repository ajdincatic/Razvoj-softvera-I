using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxGetRezultatiPretrageVM
    {
        public string Pretraga { get; set; }
        public string IzmjerenaVrijednost { get; set; }
        public string Modalitet { get; set; }
        public string JMJ { get; set; }
        public int RezultatiPretrageId { get; set; }
        public int UputnicaId { get; set; }
        public bool IsZakljucano { get; internal set; }
    }
}
