using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxUrediModVM
    {
        
        public string Pretraga { get; set; }
        public List<SelectListItem> Vrijednosti { get; set; }
        public int VrijednostId { get; set; }
        public int RezultatiPretrageId { get; set; }
        public int UplatnicaId { get; set; }

    }
}
