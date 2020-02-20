using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RS1.Ispit.Web.Models;
using RS1_Ispit_asp.net_core.ViewModels;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class UputnicaController : Controller
    {
        public UputnicaController(MojContext _db)
        {
            db = _db;
        }

        public MojContext db { get; }

        public IActionResult Index()
        {
            List<UputnicaIndexVM> model = db.Uputnica
                .Include(x => x.UputioLjekar)
                .Include(x => x.Pacijent)
                .Include(x => x.VrstaPretrage)
                .Select(x => new UputnicaIndexVM
                {
                    DatumUputnice = x.DatumUputnice.ToShortDateString(),
                    UputnicaId = x.Id,
                    Ljekar = "Dr " + x.UputioLjekar.Ime,
                    DatumEvidentiranja = x.DatumRezultata.ToString() ?? "(nema rezultata)",
                    Pacijent = x.Pacijent.Ime,
                    VrstaPretraga = x.VrstaPretrage.Naziv
                }).ToList();
            return View(model);
        }

        public IActionResult Dodaj()
        {
            UputnicaDodajVM model = new UputnicaDodajVM
            {
                Ljekari=db.Ljekar.
                    Select(x=>new SelectListItem
                    {
                        Text=x.Ime,
                        Value=x.Id.ToString()
                    }).ToList(),
                Pacijenti = db.Pacijent.
                    Select(x => new SelectListItem
                    {
                        Text = x.Ime,
                        Value = x.Id.ToString()
                    }).ToList(),
                VrstePretrage = db.VrstaPretrage.
                    Select(x => new SelectListItem
                    {
                        Text = x.Naziv,
                        Value = x.Id.ToString()
                    }).ToList(),
            };
            return View(model);
        }

        public IActionResult Snimi(UputnicaDodajVM model)
        {
            Uputnica uputnica = new Uputnica
            {
                DatumUputnice = model.DatumUputnice,
                IsGotovNalaz = false,
                PacijentId = model.PacijentId,
                UputioLjekarId = model.LjekarId,
                VrstaPretrageId = model.VrstaPretrageId,
            };
            db.Uputnica.Add(uputnica);
            foreach (var p in db.LabPretraga.Where(x => x.VrstaPretrageId == model.VrstaPretrageId))
            {
                RezultatPretrage rp = new RezultatPretrage
                {
                    LabPretragaId = p.Id,
                    NumerickaVrijednost = 0,
                    Uputnica = uputnica,
                };
                db.RezultatPretrage.Add(rp);
            }
            db.SaveChanges();
            return Redirect("Index");
        }

        public IActionResult Detalji(int UputnicaId)
        {
            var uputnica = db.Uputnica.Where(x => x.Id == UputnicaId).Include(x => x.Pacijent).SingleOrDefault();
            if (uputnica == null)
                return Content("Odabrana uputnica ne postoji");
            UputnicaDetaljiVM model = new UputnicaDetaljiVM
            {
                Pacijent = uputnica.Pacijent.Ime,
                UputnicaId = UputnicaId,
                DatumRezultata = uputnica.DatumRezultata.ToString() ?? "(nema podataka)",
                DatumUputnice = uputnica.DatumUputnice.ToShortDateString(),
                IsZavrsen = uputnica.IsGotovNalaz
            };
            return View(model);
        }

        public IActionResult Zakljucaj(int UputnicaId)
        {
            var uputnica = db.Uputnica.Where(x => x.Id == UputnicaId).Include(x => x.Pacijent).SingleOrDefault();
            if (uputnica == null)
                return Content("Odabrana uputnica ne postoji");
            uputnica.IsGotovNalaz = true;
            uputnica.DatumRezultata = DateTime.Now;
            db.SaveChanges();
            return Redirect("Detalji?=" + UputnicaId);
        }
    }
}