using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.VM
{
    public class OznaceniDogadjajiIndexVM
    {
        public List<NeoznaceniRow> neoznaceni { get; set; }
        public List<OznaceniRow> oznaceni { get; set; }
        public class NeoznaceniRow
        {
            public DateTime Datum { get; set; }
            public int DogadjajId { get; set; }
            public string Nastavnik { get; set; }
            public string Opis { get; set; }
            public int BrojObaveza { get; set; }
        }
        public class OznaceniRow
        {
            public int DogadjajId { get; set; }
            public int OznaceniDogadjajId { get; set; }
            public DateTime Datum { get; set; }
            public string Nastavnik { get; set; }
            public string Opis { get; set; }
            public string RealizovanoObavezaProcenat { get; set; }
        }
    }
}
