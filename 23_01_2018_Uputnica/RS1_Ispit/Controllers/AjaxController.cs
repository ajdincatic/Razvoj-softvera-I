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
    public class AjaxController : Controller
    {
        public AjaxController(MojContext _db)
        {
            db = _db;
        }

        public MojContext db { get; }

        public IActionResult GetRezultatiPretrage(int UputnicaId)
        {
            var uputnica = db.Uputnica.Where(x => x.Id == UputnicaId).Include(x => x.Pacijent).SingleOrDefault();
            var rezPretrage = db.RezultatPretrage.Where(x => x.UputnicaId == UputnicaId).Include(x => x.LabPretraga).Include(x => x.Modalitet);
            if (rezPretrage == null)
                return Content("Rezultati pretrage ne postoje");
            List<AjaxGetRezultatiPretrageVM> model = rezPretrage
                .Select(x => new AjaxGetRezultatiPretrageVM
                {
                    IzmjerenaVrijednost = x.NumerickaVrijednost.ToString() == "0" ? "(nije evidentirano)" : x.NumerickaVrijednost.ToString(),
                    Modalitet = x.Modalitet.Opis ?? "(nije evidentirano)",
                    JMJ = x.LabPretraga.MjernaJedinica,
                    Pretraga = x.LabPretraga.Naziv,
                    RezultatiPretrageId = x.Id,
                    UputnicaId = UputnicaId,
                    IsZakljucano = uputnica.IsGotovNalaz
                }).ToList();

            return PartialView(model);
        }

        public IActionResult Uredi(int RezultatiPretrageId)
        {
            var rezPretrage = db.RezultatPretrage.Where(x => x.Id == RezultatiPretrageId).Include(x => x.LabPretraga).SingleOrDefault();
            if (rezPretrage == null)
                return Content("Rezultati pretrage ne postoje");
            if (rezPretrage.LabPretraga.VrstaVr == VrstaVrijednosti.NumerickaVrijednost)
            {
                AjaxUrediNumVM model1 = new AjaxUrediNumVM
                {
                    Pretraga=rezPretrage.LabPretraga.Naziv,
                    MjernaJedinica=rezPretrage.LabPretraga.MjernaJedinica,
                    RezultatiPretrageId = RezultatiPretrageId
                };
                return PartialView("EvidentiranjeRezultataNumericki", model1);
            }
            AjaxUrediModVM model2 = new AjaxUrediModVM
            {
                RezultatiPretrageId = RezultatiPretrageId,
                Pretraga = rezPretrage.LabPretraga.Naziv,
                Vrijednosti = db.Modalitet
                    .Select(x => new SelectListItem {
                        Value=x.Id.ToString(),
                        Text=x.Opis
                    }).ToList(),
            };
            return PartialView("EvidentiranjeRezultataModalitet", model2);
        }

        public IActionResult SnimiMod(AjaxUrediModVM model)
        {
            var x = db.RezultatPretrage.Where(y => y.Id == model.RezultatiPretrageId).SingleOrDefault();
            x.ModalitetId = model.VrijednostId;
            db.SaveChanges();
            return Redirect("/Uputnica/Detalji?UputnicaId=" + x.UputnicaId);
        }

        public IActionResult SnimiNum(AjaxUrediNumVM model)
        {
            var x = db.RezultatPretrage.Where(y => y.Id == model.RezultatiPretrageId).SingleOrDefault();
            x.NumerickaVrijednost = model.IzmjerenaVrijednost;
            db.SaveChanges();
            return Redirect("/Uputnica/Detalji?UputnicaId=" + x.UputnicaId);
        }
    }
}