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
    public class OdrzanaNastavaController : Controller
    {
        public OdrzanaNastavaController(MojContext db)
        {
            this.db = db;
        }

        public MojContext db { get; }

        public IActionResult Index()
        {
            MaturskiIspitIndexVM model = new MaturskiIspitIndexVM
            {
                rows = db.Nastavnik
                .Select(x => new MaturskiIspitIndexVM.Row
                {
                    NastavnikId = x.Id,
                    Nastavnik = x.Ime + " " + x.Prezime,
                    Škola = db.Skola
                    .Where(y => y.Id == x.SkolaId).SingleOrDefault().Naziv
                }).ToList()
            };
            return View(model);
        }

        public IActionResult Prikaz(int NastavnikId)
        {
            var nastavnik = db.Nastavnik.Where(x => x.Id == NastavnikId).SingleOrDefault();
            if (nastavnik == null)
                return Content("Error");
            OdrzanaNastavanPrikaziVM model = new OdrzanaNastavanPrikaziVM
            {
                NastavnikId = NastavnikId,
                rows = db.MaturskiIspit
                    .Where(x => x.NastavnikId == nastavnik.Id)
                    .Select(x => new OdrzanaNastavanPrikaziVM.Row
                    {
                        Datum = x.Datum.ToShortDateString(),
                        MaturskiIspitId = x.Id,
                        Predmet = x.Predmet.Naziv,
                        Skola = x.Skola.Naziv,
                    }).ToList(),
            };

            foreach (var r in model.rows)
            {
                var nisuPristupili = db.MaturskiIspitStavka
                    .Include(x => x.OdjeljenjeStavka)
                    .Include(x => x.OdjeljenjeStavka.Ucenik)
                    .Where(x => x.MaturskiIspitId == r.MaturskiIspitId && !x.IsPristupio)
                    .ToList();
                r.NisuPristupili = new List<string>();
                foreach (var c in nisuPristupili)
                {
                    r.NisuPristupili.Add(c.OdjeljenjeStavka.Ucenik.ImePrezime);
                }
            }

            return View(model);
        }

        public IActionResult Dodaj(int NastavnikId)
        {
            var nastavnik = db.Nastavnik.Where(x => x.Id == NastavnikId).SingleOrDefault();
            if (nastavnik == null)
                return Content("Error");

            OdrzanaNastavaDodajVM model = new OdrzanaNastavaDodajVM
            {
                Skole = db.Skola
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Naziv
                }).ToList(),
                Predemeti = db.Predmet
                .Select(x => new SelectListItem
                {
                    Text = x.Naziv,
                    Value = x.Id.ToString()
                }).ToList(),
                NastanikId = NastavnikId,
                Nastavnik = nastavnik.Ime + " " + nastavnik.Prezime,
                SkolskaGodina = "2019/20"
            };
            return View(model);
        }

        public IActionResult Snimi(OdrzanaNastavaDodajVM ulazniModel)
        {
            var nastavnik = db.Nastavnik.Where(x => x.Id == ulazniModel.NastanikId).SingleOrDefault();
            if (nastavnik == null)
                return Content("Error");
            MaturskiIspit maturskiIspit = new MaturskiIspit
            {
                NastavnikId = ulazniModel.NastanikId,
                Datum = ulazniModel.Datum,
                PredmetId = ulazniModel.PredmetId,
                SkolaId = ulazniModel.SkolaId,
            };
            db.MaturskiIspit.Add(maturskiIspit);

            var odjeljenjeStavka = db.OdjeljenjeStavka
                .Include(x => x.Odjeljenje)
                    .ThenInclude(x => x.Skola)
                .Where(x => x.Odjeljenje.Skola.Id == ulazniModel.SkolaId && x.Odjeljenje.Razred == 4);

            foreach (var os in odjeljenjeStavka)
            {
                if (!db.DodjeljenPredmet.Where(x => x.OdjeljenjeStavkaId == os.Id).Any(x => x.ZakljucnoKrajGodine == 1)
                    ||
                    (db.MaturskiIspitStavka.Where(x => x.OdjeljenjeStavkaId == os.Id).SingleOrDefault() != null &&
                        db.MaturskiIspitStavka.Where(x => x.OdjeljenjeStavkaId == os.Id).SingleOrDefault().BrojBodova <= 55))
                {
                    MaturskiIspitStavka miS = new MaturskiIspitStavka
                    {
                        IsPristupio = false,
                        BrojBodova = 0,
                        MaturskiIspit = maturskiIspit,
                        OdjeljenjeStavkaId = os.Id
                    };
                    db.MaturskiIspitStavka.Add(miS);
                }
            }
            db.SaveChanges();

            return Redirect("Prikaz?NastavnikId=" + ulazniModel.NastanikId);
        }

        public IActionResult Uredi(int MaturskiIspitId)
        {
            var maturskiIspit = db.MaturskiIspit.Where(x => x.Id == MaturskiIspitId)
                .Include(x => x.Predmet)
                .SingleOrDefault();
            if (maturskiIspit == null)
                return Content("Error");
            OdrzanaNastavaUrediVM model = new OdrzanaNastavaUrediVM
            {
                Datum = maturskiIspit.Datum.ToShortDateString(),
                MaturskiIspitId = maturskiIspit.Id,
                Predmet = maturskiIspit.Predmet.Naziv,
                Napomena = maturskiIspit.Napomena
            };
            return View(model);
        }

        public IActionResult SnimiUredjeno(OdrzanaNastavaUrediVM model)
        {
            var maturskiIspit = db.MaturskiIspit.Where(x => x.Id == model.MaturskiIspitId)
                .SingleOrDefault();
            if (maturskiIspit == null)
                return Content("Error");
            maturskiIspit.Napomena = model.Napomena;
            db.SaveChanges();
            return Redirect("Uredi?MaturskiIspitId=" + model.MaturskiIspitId);
        }

    }
}