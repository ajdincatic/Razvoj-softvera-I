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
    public class PopravniIspitController : Controller
    {
        public PopravniIspitController(MojContext db)
        {
            this.db = db;
        }

        public MojContext db { get; }

        public IActionResult Index()
        {
            PopravniIspitIndexVM model = new PopravniIspitIndexVM
            {
                SkolskeGodine = db.SkolskaGodina
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Naziv
                    }).ToList(),
                Skole = db.Skola
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Naziv
                    }).ToList(),
                Predmeti = db.Predmet
                    .Select(x => new SelectListItem
                    {
                        Value = x.Id.ToString(),
                        Text = x.Naziv
                    }).ToList(),
            };
            return View(model);
        }

        public IActionResult Prikaz(PopravniIspitIndexVM ulazniModel)
        {
            var opstiPodaci = db.PopravniIspitOpstiPodaci
                .Where(x => x.PredmetId == ulazniModel.PredmetId
                    && x.SkolaId == ulazniModel.SkolaId
                    && x.SkolskaGodinaId == ulazniModel.SkolskaGodinaId)
                .Include(x => x.Skola)
                .Include(x => x.Predmet)
                .Include(x => x.SkolskaGodina)
                .SingleOrDefault();

            PopravniIspitPrikazVM model = new PopravniIspitPrikazVM
            {
                OpstiPodaciPPId = opstiPodaci.Id,
                SkolskaGodina = opstiPodaci.SkolskaGodina.Naziv,
                Predmet = opstiPodaci.Predmet.Naziv,
                Skola = opstiPodaci.Skola.Naziv,
                rows = db.PopravniIspit
                    .Include(x => x.PopravniIspitOpstiPodaci)
                    .Where(x => x.PopravniIspitOpstiPodaci.PredmetId == opstiPodaci.Predmet.Id)
                    .Select(x => new PopravniIspitPrikazVM.Row
                    {
                        PopravniIspitId = x.Id,
                        ClanKomisije = x.ClanKomisije1.Ime + " " + x.ClanKomisije1.Prezime,
                        Datum = x.Datum.ToShortDateString(),
                        BrojUcenika = db.PopravniIspitStavka.Where(y => x.Id == y.PopravniIspitId).Count(y => y.IsPrisutan == true),
                        BrojPolozenih = db.PopravniIspitStavka.Where(y => x.Id == y.PopravniIspitId).Count(y => y.BrojBodova > 50),
                    }).ToList()
            };
            return View(model);
        }

        public IActionResult Dodaj(int PodaciId)
        {
            PopravniIspitOpstiPodaci popravniIspitOpstiPodaci = db.PopravniIspitOpstiPodaci
                .Include(x => x.Skola)
                .Include(x => x.Predmet)
                .Include(x => x.SkolskaGodina)
                .Where(x => x.Id == PodaciId)
                .SingleOrDefault();
            if (popravniIspitOpstiPodaci == null)
                return Content("Greska");

            PopravniIspitDodajVM model = new PopravniIspitDodajVM
            {
                OpstiPodaciId = popravniIspitOpstiPodaci.Id,
                Nastavnici = db.Nastavnik
                    .Select(x => new SelectListItem
                    {
                        Text = x.Ime + " " + x.Prezime,
                        Value = x.Id.ToString()
                    }).ToList(),
                Skola = popravniIspitOpstiPodaci.Skola.Naziv,
                SkolskaGodina = popravniIspitOpstiPodaci.SkolskaGodina.Naziv,
                Predmet = popravniIspitOpstiPodaci.Predmet.Naziv,
                PredmetId = popravniIspitOpstiPodaci.Predmet.Id,
            };
            return View(model);
        }

        public IActionResult Snimi(PopravniIspitDodajVM model)
        {
            PopravniIspit popravniIspit = new PopravniIspit
            {
                ClanKomisije1Id = model.ClanKomisije1Id,
                ClanKomisije2Id = model.ClanKomisije2Id,
                ClanKomisije3Id = model.ClanKomisije3Id,
                Datum = model.Datum,
                PopravniIspitOpstiPodaciId = model.OpstiPodaciId
            };
            db.PopravniIspit.Add(popravniIspit);
            db.SaveChanges();
            foreach (var x in db.DodjeljenPredmet.Where(y => y.PredmetId == model.PredmetId))
            {
                if (db.DodjeljenPredmet.Where(y => y.Id == x.Id).Count(y => y.ZakljucnoKrajGodine == 1) >= 3)
                {
                    PopravniIspitStavka pps = new PopravniIspitStavka
                    {
                        BrojBodova = null,
                        ImaPravo = false,
                        IsPrisutan = false,
                        OdjeljenjeStavkaId = x.OdjeljenjeStavkaId,
                        PopravniIspitId = popravniIspit.Id,
                    };
                    db.PopravniIspitStavka.Add(pps);
                    continue;
                }
                if (x.ZakljucnoKrajGodine == 1)
                {
                    PopravniIspitStavka pps = new PopravniIspitStavka
                    {
                        BrojBodova = null,
                        ImaPravo = true,
                        IsPrisutan = false,
                        OdjeljenjeStavkaId = x.OdjeljenjeStavkaId,
                        PopravniIspitId = popravniIspit.Id,
                    };
                    db.PopravniIspitStavka.Add(pps);
                }
            }
            db.SaveChanges();
            return Redirect("Index");
        }

        public IActionResult Uredi(int PopravniIspitId)
        {
            var popravniIspit = db.PopravniIspit.Where(x => x.Id == PopravniIspitId)
                .Include(x=>x.ClanKomisije1)
                .Include(x=>x.ClanKomisije2)
                .Include(x=>x.ClanKomisije3)
                .SingleOrDefault();
            if (popravniIspit == null)
                return Content("Error");
            var temp = db.PopravniIspitOpstiPodaci.Where(x => x.Id == popravniIspit.PopravniIspitOpstiPodaciId)
                .Include(x=>x.Skola)
                .Include(x=>x.SkolskaGodina)
                .Include(x=>x.Predmet)
                .SingleOrDefault();
            PopravniIspitUrediVM model = new PopravniIspitUrediVM
            {
                PopravniIspitId = popravniIspit.Id,
                Datum = popravniIspit.Datum.ToShortDateString(),
                ClanKomisije1 = popravniIspit.ClanKomisije1.Ime + " " + popravniIspit.ClanKomisije1.Ime,
                ClanKomisije2 = popravniIspit.ClanKomisije2.Ime + " " + popravniIspit.ClanKomisije2.Ime,
                ClanKomisije3 = popravniIspit.ClanKomisije3.Ime + " " + popravniIspit.ClanKomisije3.Ime,
                PodaciId = popravniIspit.PopravniIspitOpstiPodaciId,
                Predmet = temp.Predmet.Naziv,
                Skola = temp.Skola.Naziv,
                SkolskaGodina = temp.SkolskaGodina.Naziv,
            };
            return View(model);
        }
    }
}