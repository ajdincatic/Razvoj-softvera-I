using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit_2017_09_11_DotnetCore.VM
{
    public class AjaxOdjeljenjaStavkeVM
    {
        public int OdjeljenjeId { get; set; }
        public List<Row> rows { get; set; }

        public class Row
        {
            public int BrojUDnevniku { get; set; }
            public string Ucenik { get; set; }
            public int BrojZakljucniOcjena { get; set; }
            public int OdjeljenjeStavkeId { get; set; }
        }
    }
}
