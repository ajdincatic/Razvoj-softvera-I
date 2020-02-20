using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class UputnicaDodajVM
    {
        public List<SelectListItem> Ljekari { get; set; }
        public int LjekarId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime DatumUputnice { get; set; }
        public List<SelectListItem> Pacijenti { get; set; }
        public int PacijentId { get; set; }
        public List<SelectListItem> VrstePretrage { get; set; }
        public int VrstaPretrageId { get; set; }
    }
}
