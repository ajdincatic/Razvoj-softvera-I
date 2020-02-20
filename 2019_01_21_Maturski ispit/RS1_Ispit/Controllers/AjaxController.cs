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

        public IActionResult MaturskiIspitStavke(int MaturskiIspitId)
        {
            var maturskiIspit = db.MaturskiIspit.Where(x => x.Id == MaturskiIspitId)
                .Include(x => x.Predmet)
                .SingleOrDefault();
            if (maturskiIspit == null)
                return Content("Error");

            AjaxMaturskiIspitStavkeVM model = new AjaxMaturskiIspitStavkeVM
            {
                MaturskiIspitId = MaturskiIspitId,
                rows = db.MaturskiIspitStavka
                    .Where(x => x.MaturskiIspitId == MaturskiIspitId)
                    .Include(x => x.OdjeljenjeStavka)
                        .ThenInclude(x => x.Ucenik)
                    .Select(x => new AjaxMaturskiIspitStavkeVM.Row
                    {
                        Ucenik = x.OdjeljenjeStavka.Ucenik.ImePrezime,
                        StavkaId = x.Id,
                        Bodovi = x.BrojBodova,
                        Pristupio = x.IsPristupio,
                        Prosjek = db.DodjeljenPredmet.Where(y => y.OdjeljenjeStavkaId == x.OdjeljenjeStavka.Id).Average(y => y.ZakljucnoKrajGodine).ToString()
                    }).ToList()
            };

            return PartialView(model);
        }

        public IActionResult UcenikJeOdsutan(int StavkaId)
        {
            var maturskiIspitStavka = db.MaturskiIspitStavka.Where(x => x.Id == StavkaId).SingleOrDefault();
            var maturskiIspit = db.MaturskiIspit.Where(x => x.Id == maturskiIspitStavka.MaturskiIspitId).SingleOrDefault();
            maturskiIspitStavka.IsPristupio = false;
            db.SaveChanges();
            return Redirect("/OdrzanaNastava/Uredi?MaturskiIspitId=" + maturskiIspit.Id);
        }

        public IActionResult UcenikJePrisutan(int StavkaId)
        {
            var maturskiIspitStavka = db.MaturskiIspitStavka.Where(x => x.Id == StavkaId).SingleOrDefault();
            var maturskiIspit = db.MaturskiIspit.Where(x => x.Id == maturskiIspitStavka.MaturskiIspitId).SingleOrDefault();
            maturskiIspitStavka.IsPristupio = true;
            db.SaveChanges();
            return Redirect("/OdrzanaNastava/Uredi?MaturskiIspitId=" + maturskiIspit.Id);
        }

        public IActionResult Uredi(int StavkaId)
        {
            var maturskiIspitStavka = db.MaturskiIspitStavka.Where(x => x.Id == StavkaId)
                .Include(x => x.OdjeljenjeStavka)
                    .ThenInclude(x => x.Ucenik)
                .SingleOrDefault();

            AjaxUrediVM model = new AjaxUrediVM
            {
                Bodovi = maturskiIspitStavka.BrojBodova,
                Ucenik = maturskiIspitStavka.OdjeljenjeStavka.Ucenik.ImePrezime,
                StavkaId = maturskiIspitStavka.Id,
                MaturskiId = maturskiIspitStavka.MaturskiIspitId
            };
            return PartialView(model);
        }

        public IActionResult Snimi(AjaxUrediVM model)
        {
            var maturskiIspitStavka = db.MaturskiIspitStavka.Where(x => x.Id == model.StavkaId)
                .Include(x => x.OdjeljenjeStavka)
                    .ThenInclude(x => x.Ucenik)
                .SingleOrDefault();
            maturskiIspitStavka.BrojBodova = model.Bodovi;
            db.SaveChanges();
            return Redirect("/OdrzanaNastava/Uredi?MaturskiIspitId=" + model.MaturskiId);
        }

        public IActionResult UpdateBodova(int StavkaId,int Bodovi)
        {
            var maturskiIspitStavka = db.MaturskiIspitStavka.Where(x => x.Id == StavkaId)
                .Include(x => x.OdjeljenjeStavka)
                    .ThenInclude(x => x.Ucenik)
                .SingleOrDefault();
            maturskiIspitStavka.BrojBodova = Bodovi;
            db.SaveChanges();
            return Redirect("/OdrzanaNastava/Uredi?MaturskiIspitId=" + maturskiIspitStavka.MaturskiIspitId);
        }
    }
}