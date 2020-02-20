using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ispit.Web.ViewModels
{
    public class AjaxUrediVM
    {
        public int StanjeObavezeID { get; set; }
        public int ObavezaID { get; set; }
        public string Naziv { get; set; }
        public int IzvrsenoProcentualno { get; set; }
        public int OznaceniDogadjajID { get; set; }
    }
}
