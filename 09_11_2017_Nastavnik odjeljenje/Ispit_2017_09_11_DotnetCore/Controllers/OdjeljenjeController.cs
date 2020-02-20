using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Ispit_2017_09_11_DotnetCore.VM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class OdjeljenjeController : Controller
    {
        public OdjeljenjeController(MojContext db)
        {
            this.db = db;
        }

        public MojContext db { get; }

        public IActionResult Index()
        {
            List<OdjeljenjeIndexVM> model = db.Odjeljenje
                .Select(x => new OdjeljenjeIndexVM
                {
                    OdId=x.Id,
                    SkolskaGodina = x.SkolskaGodina,
                    Razred = x.Razred,
                    Oznaka = x.Oznaka,
                    Razrednik = db.Nastavnik.Where(y => y.NastavnikID == x.NastavnikID).SingleOrDefault().ImePrezime,
                    IsPrebacen = x.IsPrebacenuViseOdjeljenje,
                    Prosjek = db.DodjeljenPredmet.Where(y => y.OdjeljenjeStavka.OdjeljenjeId == x.Id).Average(y =>(int?) y.ZakljucnoKrajGodine).ToString() ?? "??",
                    NajUcenik = "", 
                }).ToList();
            return View(model);
        }

        public IActionResult Dodaj()
        {
            OdjeljenjeDodajVM model = new OdjeljenjeDodajVM();
            model.Razrednici = db.Nastavnik
                .Select(x => new SelectListItem
                {
                    Text=x.ImePrezime,
                    Value=x.NastavnikID.ToString()
                }).ToList();
            model.NizaOdjeljenja = db.Odjeljenje
                .Where(x => x.IsPrebacenuViseOdjeljenje == false)
                .Select(x => new SelectListItem
                {
                    Text=x.SkolskaGodina + "," + x.Oznaka,
                    Value=x.Id.ToString()
                }).ToList();
            return View(model);
        }

        public IActionResult Snimi(OdjeljenjeDodajVM model)
        {
            Odjeljenje o2 = new Odjeljenje
            {
                SkolskaGodina = model.SkolskaGodina,
                NastavnikID = model.RazrednikId,
                Razred = model.Razred,
                Oznaka = model.Oznaka,
                IsPrebacenuViseOdjeljenje = false,
            };
            db.Odjeljenje.Add(o2);
            db.SaveChanges();

            var o1 = db.Odjeljenje.Find(model.OdjeljenjeId);

            if (o1 != null)
            {
                int brojUDnevniku = 0;
                o1.IsPrebacenuViseOdjeljenje = true;
                foreach (OdjeljenjeStavka x in db.OdjeljenjeStavka.Where(y => y.OdjeljenjeId == o1.Id))
                {
                    bool temp = db.DodjeljenPredmet.Where(y => y.OdjeljenjeStavkaId == x.Id).Any(y => y.ZakljucnoKrajGodine == 1);
                    if (!temp)
                    {
                        OdjeljenjeStavka odStavka = new OdjeljenjeStavka
                        {
                            OdjeljenjeId = o2.Id,
                            UcenikId = x.UcenikId,
                            BrojUDnevniku = ++brojUDnevniku,
                        };
                        db.OdjeljenjeStavka.Add(odStavka);

                        List<Predmet> predmeti = db.Predmet.Where(a => a.Razred == o2.Razred).ToList();
                        foreach (Predmet y in predmeti)
                        {
                            db.DodjeljenPredmet.Add(new DodjeljenPredmet
                            {
                                OdjeljenjeStavka = odStavka,
                                ZakljucnoKrajGodine = 0,
                                ZakljucnoPolugodiste = 0,
                                PredmetId = y.Id
                            });
                        }
                    }
                }
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Obrisi(int Id)
        {
            var odjeljenje = db.Odjeljenje.Find(Id);
            if (db.OdjeljenjeStavka.Find(odjeljenje.Id) == null)
            {
                db.Odjeljenje.Remove(odjeljenje);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (odjeljenje != null)
            {
                var OdjeljenjaStavke = db.OdjeljenjeStavka.Find(odjeljenje.Id);
                if (OdjeljenjaStavke != null)
                    db.OdjeljenjeStavka.Remove(OdjeljenjaStavke);
                var DodijeljeniPredemt = db.DodjeljenPredmet.Find(OdjeljenjaStavke.Id);
                if (DodijeljeniPredemt != null)
                    db.DodjeljenPredmet.Remove(DodijeljeniPredemt);
                db.Odjeljenje.Remove(odjeljenje);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Detalji(int Id)
        {
            var x = db.Odjeljenje
                .Where(y => y.Id == Id)
                .Include(y => y.Nastavnik)
                .SingleOrDefault();

            OdjeljenjeDetaljiVM model = new OdjeljenjeDetaljiVM
            {
                OdjeljenjeId = x.Id,
                SkolskaGodina = x.SkolskaGodina,
                Razred = x.Razred,
                Oznaka = x.Oznaka,
                BrojPredmeta = db.Predmet.Where(y => y.Razred == x.Razred).Count()
            };
            if (x.Nastavnik != null)
                model.Razrednik = x.Nastavnik.ImePrezime;
            else
                model.Razrednik = "Nema podataka";

            return View(model);
        }

        public IActionResult RekonstruisiBrojeveDnevnika(int Id)
        {
            var x = db.OdjeljenjeStavka.Where(y => y.OdjeljenjeId == Id).Include(y => y.Ucenik);
            // !!!
            return Redirect("Index");
        }
    }
}