using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.VM
{
    public class OznaceniDogadjajDetaljiVM
    {
        public DateTime DatumDogadjaja { get; set; }
        public DateTime DatumDodavanja { get; set; }
        public string Opis { get; set; }
        public string Nastavnik { get; set; }
        public int DogadjajId { get; set; }
        public int OznacenDogadjajId { get; set; }
    }
}
