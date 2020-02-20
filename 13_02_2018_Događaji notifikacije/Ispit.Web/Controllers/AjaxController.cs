using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ispit.Web.ViewModels;
using Ispit.Data;
using Microsoft.EntityFrameworkCore;
using Ispit.Data.EntityModels;
using eUniverzitet.Web.Helper;

namespace Ispit.Web.Controllers
{
    public class AjaxController : Controller
    {
        public AjaxController(MyContext db)
        {
            this.db = db;
        }

        public MyContext db { get; }

        public IActionResult GetObavezeDogadjaja(int OznacenDogadjajId)
        {
            var obaveze = db.OznacenDogadjaj.Where(x => x.ID == OznacenDogadjajId).SingleOrDefault();
            if (obaveze == null)
                return Content("Obaveza ne postoji");
            AjaxGetObavezeDogadjajaVM model = new AjaxGetObavezeDogadjajaVM
            {
                OznaecenDogadjajId = OznacenDogadjajId,
                rows = db.StanjeObaveze
                    .Where(x => x.OznacenDogadjajID == obaveze.ID)
                    .Select(x => new AjaxGetObavezeDogadjajaVM.Row
                    {
                        Naziv = x.Obaveza.Naziv,
                        ProcenatRealizacije = x.IzvrsenoProcentualno.ToString(),
                        SaljiRekurzivno = x.NotifikacijeRekurizivno,
                        VrijemeZaNotifikaciju = x.NotifikacijaDanaPrije,
                        StanjeObavezeId = x.Id
                    }).ToList(),
            };
            return PartialView(model);
        }

        public IActionResult Uredi(int StanjeObavezeId)
        {
            var stanjeObaveze = db.StanjeObaveze.Where(x => x.Id == StanjeObavezeId).Include(x => x.Obaveza).SingleOrDefault();
            if (stanjeObaveze == null)
                return Content("Obaveza ne postoji");
            AjaxUrediVM model = new AjaxUrediVM
            {
                OznaceniDogadjajID = stanjeObaveze.OznacenDogadjajID,
                Naziv = stanjeObaveze.Obaveza.Naziv,
                StanjeObavezeID = stanjeObaveze.Id,
                ObavezaID = stanjeObaveze.Obaveza.ID
            };
            return PartialView(model);
        }

        public IActionResult Snimi(AjaxUrediVM model)
        {
            var stanjeObaveze = db.StanjeObaveze.
                Where(x => x.Id == model.StanjeObavezeID && x.ObavezaID == model.ObavezaID && x.OznacenDogadjajID == model.OznaceniDogadjajID)
                .SingleOrDefault();
            if (stanjeObaveze == null)
                return Content("Obaveza ne postoji");
            stanjeObaveze.IzvrsenoProcentualno = model.IzvrsenoProcentualno;
            db.SaveChanges();
            return Redirect("/OznaceniDogadaji/Detalji?DogadjajId=" + 
                db.OznacenDogadjaj.Where(x => x.ID == model.OznaceniDogadjajID).SingleOrDefault().DogadjajID);
        }

        public IActionResult Notifikacije()
        {
            //doraditi
            var logirani = db.Student.Where(x => x.KorisnickiNalogId == HttpContext.GetLogiraniKorisnik().Id).SingleOrDefault();
            var dogadjajiZaKorisnika = db.OznacenDogadjaj.Where(x => x.StudentID == logirani.ID);

            List<AjaxNotifikacijeVM> model = dogadjajiZaKorisnika
                    .Include(x => x.Dogadjaj)
                    .Include(x => x.Student)
                    .Select(x => new AjaxNotifikacijeVM
                    {
                        Dogadjaj = x.Dogadjaj.Opis,
                        DatumDogadjaja = x.Dogadjaj.DatumOdrzavanja.ToShortDateString(),
                        Aktivnost = db.Obaveza.Where(y => y.DogadjajID == x.DogadjajID).FirstOrDefault().Naziv,
                    }).ToList();
            return PartialView(model);
        }
    }
}