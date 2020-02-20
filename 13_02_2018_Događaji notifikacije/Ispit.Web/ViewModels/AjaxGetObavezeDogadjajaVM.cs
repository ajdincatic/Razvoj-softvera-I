using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.ViewModels
{
    public class AjaxGetObavezeDogadjajaVM
    {
        public int OznaecenDogadjajId { get; set; }
        public List<Row> rows { get; set; }
        public class Row
        {
            public int StanjeObavezeId { get; set; }
            public string Naziv { get; set; }
            public string ProcenatRealizacije { get; set; }
            public int VrijemeZaNotifikaciju { get; set; }
            public bool SaljiRekurzivno { get; set; }
        }
        
    }
}
