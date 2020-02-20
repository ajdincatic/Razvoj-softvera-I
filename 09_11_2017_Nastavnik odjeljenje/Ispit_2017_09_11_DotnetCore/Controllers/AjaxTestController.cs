using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ispit_2017_09_11_DotnetCore.EF;
using Microsoft.AspNetCore.Mvc;
using Ispit_2017_09_11_DotnetCore.VM;
using Ispit_2017_09_11_DotnetCore.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ispit_2017_09_11_DotnetCore.Controllers
{
    public class AjaxTestController : Controller
    {
        public MojContext db { get; }

        public AjaxTestController(MojContext _db)
        {
            db = _db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AjaxTestAction()
        {
            return PartialView("_AjaxTestView");
        }

        public IActionResult GetOdjeljenjaStavke(int Id)
        {
            Odjeljenje x = db.Odjeljenje.Find(Id);

            AjaxOdjeljenjaStavkeVM model = new AjaxOdjeljenjaStavkeVM
            {
                OdjeljenjeId = x.Id,
                rows = db.OdjeljenjeStavka
                    .Where(y => y.OdjeljenjeId == Id)
                    .Include(y => y.Ucenik)
                    .Include(y => y.Odjeljenje)
                    .Select(y => new AjaxOdjeljenjaStavkeVM.Row
                    {
                        OdjeljenjeStavkeId = y.Id,
                        BrojUDnevniku = y.BrojUDnevniku,
                        Ucenik = y.Ucenik.ImePrezime,
                        BrojZakljucniOcjena = db.DodjeljenPredmet.Where(z => z.OdjeljenjeStavkaId == y.Id).Count(z => z.ZakljucnoKrajGodine != 0)
                    }).ToList()
            };
            
            return PartialView("OdjeljenjaStavke", model);
        }

        public IActionResult Dodaj(int odjeljenjeId)
        {
            var x = db.Odjeljenje.Find(odjeljenjeId);
            AjaxOdjeljenjeDodaj model = new AjaxOdjeljenjeDodaj
            {
                OdjeljenjeID = odjeljenjeId,
                BrojUDnevniku = db.OdjeljenjeStavka.Count(s => s.OdjeljenjeId == odjeljenjeId) + 1,
                ucenici = db.Ucenik
                    .Select(y => new SelectListItem
                    {
                        Text = y.ImePrezime,
                        Value = y.Id.ToString()
                    }).ToList()
            };
            return PartialView(model);
        }

        public IActionResult Snimi(AjaxOdjeljenjeDodaj model)
        {
            OdjeljenjeStavka x;

            if (model.OdjeljenjeStavkaId == 0)
            {
                x = new OdjeljenjeStavka();
                db.OdjeljenjeStavka.Add(x);
            }
            else
            {
                x = db.OdjeljenjeStavka.Find(model.OdjeljenjeStavkaId);
            }

            x.OdjeljenjeId = model.OdjeljenjeID;
            x.UcenikId = model.UcenikId;
            x.BrojUDnevniku = model.BrojUDnevniku;

            db.SaveChanges();
            return Redirect("/AjaxTest/GetOdjeljenjaStavke?Id=" + model.OdjeljenjeID);
        }
    }
}