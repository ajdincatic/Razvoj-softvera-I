using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.VM;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class AjaxController : Controller
    {
        public AjaxController(MojContext db)
        {
            this.db = db;
        }

        public MojContext db { get; }

        public IActionResult PrikazUcenika(int PopravniIspitId)
        {
            var popravniIspit = db.PopravniIspit.Where(x => x.Id == PopravniIspitId).SingleOrDefault();
            if (popravniIspit == null)
                return Content("Error");
            AjaxPrikazUcenikaVM model = new AjaxPrikazUcenikaVM
            {
                PopravniIspitId = popravniIspit.Id,
                rows = db.PopravniIspitStavka
                    .Where(x => x.PopravniIspitId == popravniIspit.Id)
                    .Include(x => x.OdjeljenjeStavka)
                    .Include(x => x.OdjeljenjeStavka.Odjeljenje)
                    .Include(x => x.OdjeljenjeStavka.Ucenik)
                    .Select(x => new AjaxPrikazUcenikaVM.Row
                    {
                        PopravniStavkaId = x.Id,
                        BrojBodova = x.BrojBodova ?? 0,
                        MozePristupiti = x.ImaPravo,
                        PristupioIspitu = x.IsPrisutan,
                        Ucenik = x.OdjeljenjeStavkaId + ". " + x.OdjeljenjeStavka.Ucenik.ImePrezime,
                        BrojUDnevniku = x.OdjeljenjeStavka.BrojUDnevniku,
                        Odjeljenje = x.OdjeljenjeStavka.Odjeljenje.Oznaka
                    }).ToList()
            };
            return PartialView(model);
        }

        public IActionResult UcenikJeOdsutan(int PopravniStavkaId)
        {
            var popravniIspit = db.PopravniIspitStavka.Where(x => x.Id == PopravniStavkaId).SingleOrDefault();
            popravniIspit.IsPrisutan = false;
            popravniIspit.BrojBodova = 0;
            db.SaveChanges();
            return Redirect("/PopravniIspit/Uredi?PopravniIspitId=" + db.PopravniIspit.Where(x=>x.Id==popravniIspit.PopravniIspitId).SingleOrDefault().Id);
        }

        public IActionResult UcenikJePrisutan(int PopravniStavkaId)
        {
            var popravniIspit = db.PopravniIspitStavka.Where(x => x.Id == PopravniStavkaId).SingleOrDefault();
            popravniIspit.IsPrisutan = true;
            db.SaveChanges();
            return Redirect("/PopravniIspit/Uredi?PopravniIspitId=" + db.PopravniIspit.Where(x => x.Id == popravniIspit.PopravniIspitId).SingleOrDefault().Id);
        }

        public IActionResult Uredi(int PopravniStavkaId)
        {
            var popravniIspitStavka = db.PopravniIspitStavka.Where(x => x.Id == PopravniStavkaId)
                .Include(x => x.OdjeljenjeStavka)
                .Include(x => x.OdjeljenjeStavka.Ucenik)
                .SingleOrDefault();
            AjaxUrediVM model = new AjaxUrediVM
            {
                Ucenik = popravniIspitStavka.OdjeljenjeStavka.Ucenik.ImePrezime,
                PopravniIspitStavkaId = popravniIspitStavka.Id,
                Bodovi = popravniIspitStavka.BrojBodova ?? 0,
            };
            return PartialView(model);
        }

        public IActionResult Snimi(AjaxUrediVM model)
        {
            var popravniIspitStavka = db.PopravniIspitStavka.Where(x => x.Id == model.PopravniIspitStavkaId)
                .SingleOrDefault();
            popravniIspitStavka.BrojBodova = model.Bodovi;
            db.SaveChanges();
            return Redirect("/PopravniIspit/Uredi?PopravniIspitId=" + db.PopravniIspit.Where(x => x.Id == popravniIspitStavka.PopravniIspitId).SingleOrDefault().Id);
        }
    }
}