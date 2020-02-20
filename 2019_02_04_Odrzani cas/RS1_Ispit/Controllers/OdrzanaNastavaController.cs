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
            List<OdrzanaNastavaIndexVM> model = db.Nastavnik.
                Select(x => new OdrzanaNastavaIndexVM
                {
                    NastavnikId = x.Id,
                    Nastavnik = x.Ime + " " + x.Prezime,
                    BrojCasova = db.OdrzaniCas
                        .Include(y => y.PredajePredmet)
                        .Include(y => y.PredajePredmet.Odjeljenje)
                        .Include(y => y.PredajePredmet.Odjeljenje.SkolskaGodina)
                        .Where(y => y.PredajePredmet.NastavnikID == x.Id && y.PredajePredmet.Odjeljenje.SkolskaGodina.Aktuelna).Count()
                }).ToList();
            return View(model);
        }
        
        public IActionResult Prikaz(int NastavnikId)
        {
            OdrzanaNastavaPrikazVM model = new OdrzanaNastavaPrikazVM
            {
                NastavnikId = NastavnikId,
                rows = db.OdrzaniCas
                .Include(x => x.PredajePredmet)
                .Include(x=>x.PredajePredmet.Odjeljenje)
                .Include(x=>x.PredajePredmet.Odjeljenje.Skola)
                .Include(x=>x.PredajePredmet.Odjeljenje.SkolskaGodina)
                .Include(x=>x.PredajePredmet.Predmet)
                .Where(x => x.PredajePredmet.NastavnikID == NastavnikId)
                .Select(x => new OdrzanaNastavaPrikazVM.Row
                {
                    OdrzaniCasId = x.Id,
                    Datum = x.Datum.ToShortDateString(),
                    Odjeljenje = x.PredajePredmet.Odjeljenje.Oznaka,
                    Predmet = x.PredajePredmet.Predmet.Naziv,
                    Skola = x.PredajePredmet.Odjeljenje.Skola.Naziv,
                    SkGodina = x.PredajePredmet.Odjeljenje.SkolskaGodina.Naziv
                }).ToList()
            };

            foreach (var x in model.rows)
            {
                var odsutniUcenici = db.OdrzanCasDetalji
                    .Include(y => y.Ucenik)
                    .Where(z => z.OdrzanicasId == x.OdrzaniCasId && !z.IsPrisutan);
                x.Odsutni = new List<string>();
                foreach (var u in odsutniUcenici)
                {
                    x.Odsutni.Add(u.Ucenik.ImePrezime);
                }
            }

            return View(model);
        }

        public IActionResult Obrisi(int OdrzaniCasId)
        {
            var odCas = db.OdrzaniCas.Include(y => y.PredajePredmet).Where(x => x.Id == OdrzaniCasId).SingleOrDefault();
            foreach (var x in db.OdrzanCasDetalji.Where(y => y.OdrzanicasId == odCas.Id))
            {
                db.OdrzanCasDetalji.Remove(x);
            }
            db.OdrzaniCas.Remove(odCas);
            db.SaveChanges();

            return RedirectToAction("Prikaz", new { odCas.PredajePredmet.NastavnikID });
        }

        public IActionResult Dodaj(int NastavnikId)
        {
            var nast = db.Nastavnik.Where(x => x.Id == NastavnikId).SingleOrDefault();
            OdrzanNastavaDodajVM model = new OdrzanNastavaDodajVM
            {
                Nastavnik = nast.Ime + " " + nast.Prezime,
                NastavnikId = nast.Id,
                Skola_Odjeljenje_Predemet = db.PredajePredmet
                .Include(x => x.Odjeljenje)
                .Include(x => x.Odjeljenje.Skola)
                .Include(x => x.Predmet)
                .Where(x => x.NastavnikID == NastavnikId)
                .Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Odjeljenje.Skola.Naziv + " / " + x.Odjeljenje.Oznaka + " / " + x.Predmet.Naziv
                }).ToList()
            };
            return View(model);
        }

        public IActionResult Snimi(OdrzanNastavaDodajVM model)
        {
            OdrzaniCas cas = new OdrzaniCas
            {
                Datum = model.Datum,
                PredajePredmetId = model.PredajePredmetId,
                SadrzajaCasa = model.SadrzajCasa
            };
            db.OdrzaniCas.Add(cas);

            foreach (var x in db.Ucenik)
            {
                OdrzanCasDetalji odDetalji = new OdrzanCasDetalji
                {
                    OdrzaniCas=cas,
                    UcenikId=x.Id,
                    IsPrisutan=true,
                };
                db.OdrzanCasDetalji.Add(odDetalji);
            }
            db.SaveChanges();
            return Redirect("Prikaz?NastavnikId=" + model.NastavnikId);
        }

        public IActionResult Detalji(int OdrzaniCasId)
        {
            var cas = db.OdrzaniCas.Where(x => x.Id == OdrzaniCasId).SingleOrDefault();
            OdrzanaNastavaDetaljiVM model = new OdrzanaNastavaDetaljiVM
            {
                OdrzaniCasId = cas.Id,
                Datum = cas.Datum.ToShortDateString(),
                Skola_Odjeljenje_Predemet = db.PredajePredmet
                .Include(x => x.Odjeljenje)
                .Include(x => x.Odjeljenje.Skola)
                .Where(x => x.Id == cas.PredajePredmetId).SingleOrDefault().
                    Odjeljenje.Skola.Naziv
                    + " / " +
                    db.PredajePredmet
                .Include(x => x.Odjeljenje)
                .Where(x => x.Id == cas.PredajePredmetId).SingleOrDefault().
                    Odjeljenje.Oznaka
                    + " / " +
                    db.PredajePredmet
                .Include(x => x.Predmet)
                .Where(x => x.Id == cas.PredajePredmetId).SingleOrDefault().
                    Predmet.Naziv,
                SadrzajCasa = cas.SadrzajaCasa
            };
            return View(model);
        }

        public IActionResult OdrzaniCasStavke(int OdrzaniCasId)
        {
            var cas = db.OdrzaniCas.Where(x => x.Id == OdrzaniCasId).SingleOrDefault();
            OdrzaniCasStavkeVM model = new OdrzaniCasStavkeVM
            {
                rows = db.OdrzanCasDetalji
                .Where(x => x.OdrzanicasId == OdrzaniCasId)
                .Select(x => new OdrzaniCasStavkeVM.Row
                {
                    StavkaId = x.Id,
                    Ocjena = x.Bodovi,
                    Opravdano = x.OpravdanoOdsutan ?? false,
                    Prisutan = x.IsPrisutan,
                    Ucenik = x.Ucenik.ImePrezime
                }).ToList()
            };
            return PartialView(model);
        }

        public IActionResult UcenikJeOdsutan(int StavkaId)
        {
            var s = db.OdrzanCasDetalji.Where(x => x.Id == StavkaId).SingleOrDefault();
            s.IsPrisutan = false;
            s.Bodovi = null;
            db.SaveChanges();
            return Redirect("Detalji?OdrzaniCasId=" + s.OdrzanicasId);
        }

        public IActionResult UcenikJePrisutan(int StavkaId)
        {
            var s = db.OdrzanCasDetalji.Where(x => x.Id == StavkaId).SingleOrDefault();
            s.IsPrisutan = true;
            db.SaveChanges();
            return Redirect("Detalji?OdrzaniCasId=" + s.OdrzanicasId);
        }

        public IActionResult UrediPrisutan(int StavkaId)
        {
            var s = db.OdrzanCasDetalji.Include(x=>x.Ucenik).Where(x => x.Id == StavkaId).SingleOrDefault();

            UrediPrisutanVM model = new UrediPrisutanVM
            {
                StavkaId = StavkaId,
                Ucenik = s.Ucenik.ImePrezime,
                Ocjena = s.Bodovi ?? 0
            };
            return PartialView(model);
        }

        public IActionResult SnimiPrisutan(UrediPrisutanVM model)
        {
            var s = db.OdrzanCasDetalji.Where(x => x.Id == model.StavkaId).SingleOrDefault();
            s.Bodovi = model.Ocjena;
            db.SaveChanges();
            return Redirect("Detalji?OdrzaniCasId=" + s.OdrzanicasId);
        }

        public IActionResult UrediOdsutan(int StavkaId)
        {
            var s = db.OdrzanCasDetalji.Include(x => x.Ucenik).Where(x => x.Id == StavkaId).SingleOrDefault();

            UrediOdsutanVM model = new UrediOdsutanVM
            {
                StavkaId = StavkaId,
                Ucenik = s.Ucenik.ImePrezime,
            };
            return PartialView(model);
        }

        public IActionResult SnimiOdsutan(UrediOdsutanVM model)
        {
            var s = db.OdrzanCasDetalji.Include(x => x.Ucenik).Where(x => x.Id == model.StavkaId).SingleOrDefault();
            s.Napomena = model.Napomena;
            s.OpravdanoOdsutan = model.Opravdano;
            db.SaveChanges();
            return Redirect("Detalji?OdrzaniCasId=" + s.OdrzanicasId);
        }

        public IActionResult UpdateBodova(int Id,int Ocjena)
        {
            var s = db.OdrzanCasDetalji.Include(x => x.Ucenik).Where(x => x.Id == Id).SingleOrDefault();
            s.Bodovi = Ocjena;
            db.SaveChanges();
            return Redirect("Detalji?OdrzaniCasId=" + s.OdrzanicasId);
        }
    }
}