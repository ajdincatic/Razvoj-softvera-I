using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eUniverzitet.Web.Helper;
using Ispit.Web.Helper;
using Ispit.Web.VM;
using Microsoft.AspNetCore.Mvc;
using Ispit.Data;
using Ispit.Data.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Ispit.Web.Controllers
{
    [Autorizacija]
    public class OznaceniDogadajiController : Controller
    {
        public OznaceniDogadajiController(MyContext db)
        {
            this.db = db;
        }

        public MyContext db { get; }

        public IActionResult Index()
        {
            var logirani = db.Student.Where(x => x.KorisnickiNalogId == HttpContext.GetLogiraniKorisnik().Id).SingleOrDefault();
            var dogadjajiZaKorisnika = db.OznacenDogadjaj.Where(x => x.StudentID == logirani.ID);

            OznaceniDogadjajiIndexVM model = new OznaceniDogadjajiIndexVM();
            if (dogadjajiZaKorisnika != null)
            {
                model.oznaceni = dogadjajiZaKorisnika
                    .Include(x => x.Dogadjaj)
                    .Include(x => x.Student)
                    .Select(x => new OznaceniDogadjajiIndexVM.OznaceniRow
                    {
                        Datum = x.DatumDodavanja,
                        Opis = x.Dogadjaj.Opis,
                        Nastavnik = db.Nastavnik.Where(y => y.ID == x.Dogadjaj.NastavnikID).SingleOrDefault().ImePrezime,
                        OznaceniDogadjajId = x.ID,
                        DogadjajId = x.DogadjajID,
                        RealizovanoObavezaProcenat = db.StanjeObaveze.Where(y => y.OznacenDogadjajID == x.ID).Average(y => (int?)y.IzvrsenoProcentualno).ToString() ?? "?"
                    }).ToList();
            }
            else
            {
                model.oznaceni = null;
            }

            var oznaceni = new List<Dogadjaj>();
            foreach (var a in model.oznaceni)
            {
                foreach (var b in db.Dogadjaj)
                {
                    if (a.DogadjajId == b.ID)
                    {
                        oznaceni.Add(b);// svi oznaceni dogadjaji pretvaraju se u objekat tipa Dogadjaj
                    }
                }
            }
            //lista dogadjaja koji nisu u listi oznaceni
            IEnumerable<Dogadjaj> neoznaceni = null;
            if (oznaceni != null)
                neoznaceni = db.Dogadjaj.Include(x => x.Nastavnik).Except(oznaceni);
            else
                neoznaceni = db.Dogadjaj.Include(x => x.Nastavnik);

            model.neoznaceni = neoznaceni
                .Select(x => new OznaceniDogadjajiIndexVM.NeoznaceniRow
                {
                    Datum = x.DatumOdrzavanja,
                    DogadjajId = x.ID,
                    Nastavnik = x.Nastavnik.ImePrezime,
                    Opis = x.Opis,
                    BrojObaveza = db.Obaveza.Where(y => y.DogadjajID == x.ID).Count()
                }).ToList();

            return View(model);
        }

        public IActionResult Dodaj(int DogadjajId)
        {
            var dogadjaj = db.Dogadjaj.Where(x => x.ID == DogadjajId).SingleOrDefault();
            var logirani = db.Student.Where(x => x.KorisnickiNalogId == HttpContext.GetLogiraniKorisnik().Id).SingleOrDefault();
            if (logirani == null)
                return Content("Niste logirani");
            if (dogadjaj == null)
                return Content("Dogadjaj ne postoji");
            OznacenDogadjaj oznacenDogadjaj = new OznacenDogadjaj
            {
                DatumDodavanja = DateTime.Now,
                DogadjajID = DogadjajId,
                StudentID = logirani.ID
            };
            db.OznacenDogadjaj.Add(oznacenDogadjaj);
            var sveObaveze = db.Obaveza.Where(x => x.DogadjajID == DogadjajId);
            foreach (var o in sveObaveze)
            {
                StanjeObaveze novoStanje = new StanjeObaveze
                {
                    DatumIzvrsenja = DateTime.MinValue,
                    IsZavrseno = false,
                    NotifikacijeRekurizivno = o.NotifikacijeRekurizivnoDefault,
                    IzvrsenoProcentualno = 0,
                    NotifikacijaDanaPrije = o.NotifikacijaDanaPrijeDefault,
                    OznacenDogadjaj = oznacenDogadjaj,
                    ObavezaID = o.ID
                };
                db.StanjeObaveze.Add(novoStanje);
            }
            db.SaveChanges();
            return Redirect(nameof(Index));
        }

        public IActionResult Detalji(int DogadjajId)
        {
            var dogadjaj = db.Dogadjaj.Where(x => x.ID == DogadjajId).Include(x => x.Nastavnik).SingleOrDefault();
            if (dogadjaj == null)
                return Content("Nema dogadjaja");
            OznaceniDogadjajDetaljiVM model = new OznaceniDogadjajDetaljiVM
            {
                DatumDodavanja = db.OznacenDogadjaj.Where(x => x.DogadjajID == DogadjajId).SingleOrDefault().DatumDodavanja,
                DatumDogadjaja = dogadjaj.DatumOdrzavanja,
                Nastavnik = dogadjaj.Nastavnik.ImePrezime,
                Opis = dogadjaj.Opis,
                OznacenDogadjajId = db.OznacenDogadjaj.Where(x => x.DogadjajID == DogadjajId).SingleOrDefault().ID,
                DogadjajId = DogadjajId,
            };
            return View(model);
        }

    }
}