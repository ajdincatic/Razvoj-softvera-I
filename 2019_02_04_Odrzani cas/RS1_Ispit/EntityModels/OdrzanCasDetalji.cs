using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class OdrzanCasDetalji
    {
        public int Id { get; set; }
        public OdrzaniCas OdrzaniCas { get; set; }
        public int OdrzanicasId { get; set; }
        public Ucenik Ucenik { get; set; }
        public int UcenikId { get; set; }
        public bool IsPrisutan { get; set; }
        public int? Bodovi { get; set; }
        public bool? OpravdanoOdsutan { get; set; }
        public string Napomena { get; set; }
    }
}
