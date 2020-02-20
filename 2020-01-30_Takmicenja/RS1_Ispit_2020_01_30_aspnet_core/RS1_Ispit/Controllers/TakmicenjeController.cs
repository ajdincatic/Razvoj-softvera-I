using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.VM;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class TakmicenjeController : Controller
    {
        public TakmicenjeController(MojContext db)
        {
            this.db = db;
        }

        public MojContext db { get; }

        public IActionResult Index()
        {
            TakmicenjeIndexVM model = new TakmicenjeIndexVM
            {
                Skole = db.Skola
                .Select(x => new SelectListItem
                {
                    Text = x.Naziv,
                    Value = x.Id.ToString()
                }).ToList()
            };
            return View(model);
        }

        public IActionResult Prikaz(TakmicenjeIndexVM model)
        {
            IQueryable<Takmicenje> takmicenja = null;
            if (model.Razred == 0)
            {
                takmicenja = db.Takmicenje
                    .Include(x => x.Predmet)
                    .Where(x => x.SkolaDomacinId == model.SkolaDomacinId);
            }
            else
            {
                takmicenja = db.Takmicenje
                    .Include(x => x.Predmet)
                    .Where(x => x.Razred == model.Razred && x.SkolaDomacinId == model.SkolaDomacinId);
            }

            TakmicenjePrikazVM ulazniModel = new TakmicenjePrikazVM
            {
                SkolaDomacinId = model.SkolaDomacinId,
                SkolaDomacin = db.Skola.Where(x => x.Id == model.SkolaDomacinId).SingleOrDefault().Naziv,
                Razred = model.Razred,
                rows = takmicenja
                    .Select(x => new TakmicenjePrikazVM.Row
                    {
                        Datum = x.Datum.ToShortDateString(),
                        Razred = x.Razred,
                        Predmet = x.Predmet.Naziv,
                        TakmicenjeId = x.Id,
                        BrojNisuPristupili = db.TakmicenjeUcesnik.Where(y => y.TakmicenjeId == x.Id).Count(y => y.IsPristupio == false),
                        NajUcenik = db.TakmicenjeUcesnik.Where(y => y.TakmicenjeId == x.Id).OrderByDescending(y => y.BrojBodova)
                            .Select(y => y.OdjeljenjeStavka.Ucenik).FirstOrDefault().ImePrezime,
                    }).ToList()
            };


            foreach (var x in ulazniModel.rows)
            {
                var naj = db.OdjeljenjeStavka
                    .Include(cx => cx.Odjeljenje)
                    .Include(cx => cx.Ucenik)
                    .Include(cx => cx.Odjeljenje.Skola)
                    .Where(c => c.Ucenik.ImePrezime == x.NajUcenik).FirstOrDefault();
                if (x.NajUcenik != null)
                {
                    x.SkolaNajUcenika = naj.Odjeljenje.Skola.Naziv;
                    x.OdjeljenjeNajUcenika = naj.Odjeljenje.Oznaka;
                }
            }

            return View(ulazniModel);
        }

        public IActionResult Dodaj(int SkolaDomacinId)
        {
            TakmicenjeDodajVM model = new TakmicenjeDodajVM
            {
                Predmeti = db.Predmet
                    .GroupBy(x => x.Naziv)
                    .Select(x => x.First())
                    .Select(x => new SelectListItem
                    {
                        Text = x.Naziv,
                        Value = x.Id.ToString()
                    }).ToList(),
                SkolaDomacin = db.Skola.Where(x => x.Id == SkolaDomacinId).SingleOrDefault().Naziv,
                SkolaDomacinId = db.Skola.Where(x => x.Id == SkolaDomacinId).SingleOrDefault().Id,
            };
            return View(model);
        }

        public IActionResult Snimi(TakmicenjeDodajVM model)
        {
            Takmicenje takmicenje = new Takmicenje
            {
                Datum = model.Datum,
                PredmetId = model.PredmetId,
                Razred = model.Razred,
                SkolaDomacinId = model.SkolaDomacinId
            };
            db.Takmicenje.Add(takmicenje);

            var dp = db.DodjeljenPredmet
                .Include(x => x.OdjeljenjeStavka)
                    .ThenInclude(x => x.Ucenik)
                .Include(x => x.Predmet);

            foreach (var ts in dp)
            {
                if ((ts.Predmet.Id == takmicenje.PredmetId && ts.ZakljucnoKrajGodine == 5)
                    || db.DodjeljenPredmet.Where(y => y.Id == ts.Id).Average(y => y.ZakljucnoKrajGodine) > 4.0)
                {
                    TakmicenjeUcesnik tu = new TakmicenjeUcesnik
                    {
                        Takmicenje = takmicenje,
                        IsPristupio = false,
                        BrojBodova = 0,
                        OdjeljenjeStavkaId = ts.OdjeljenjeStavkaId
                    };
                    db.TakmicenjeUcesnik.Add(tu);
                }
            }
            db.SaveChanges();

            return Redirect("Index");
        }

        public IActionResult Rezultati(int TakmicenjeId)
        {
            var takmicenje = db.Takmicenje.Include(x => x.SkolaDomacin).Include(x => x.Predmet).Where(x => x.Id == TakmicenjeId).SingleOrDefault();
            TakmicenjeRezultatiVM model = new TakmicenjeRezultatiVM
            {
                TakmicenjeId = takmicenje.Id,
                Datum = takmicenje.Datum.ToShortDateString(),
                Predmet = takmicenje.Predmet.Naziv,
                Razred = takmicenje.Razred,
                SkolaDomacin = takmicenje.SkolaDomacin.Naziv,
                SkolaDomacinId = takmicenje.SkolaDomacinId,
                Zakljucano = takmicenje.IsZakljucano
            };
            return View(model);
        }

        public IActionResult Zakljucaj(int TakmicenjeId)
        {
            var takmicenje = db.Takmicenje.Where(x => x.Id == TakmicenjeId).SingleOrDefault();
            takmicenje.IsZakljucano = true;
            db.SaveChanges();
            return RedirectToAction("Rezultati" , new { TakmicenjeId });
        }

    }
}