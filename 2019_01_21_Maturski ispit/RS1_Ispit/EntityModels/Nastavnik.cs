using System.ComponentModel.DataAnnotations.Schema;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class Nastavnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        [ForeignKey(nameof(SkolaId))]
        public Skola Skola { get; set; }
        public int SkolaId { get; set; }

    }
}
