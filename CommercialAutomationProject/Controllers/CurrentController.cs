using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context c = new Context();
        public ActionResult Index()
        {
            var CurrentValues = c.Currents.Where(x => x.Status == true).ToList();
            return View(CurrentValues);
        }
        [HttpGet]
        public ActionResult AddCurrent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCurrent(Current p)
        {
            p.Status = true;
            c.Currents.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult DeleteCurrent(int id)
        {
            var DeleteCur = c.Currents.Find(id);
            DeleteCur.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCurrent(int id)
        {
            var getCur = c.Currents.Find(id);
            return View("GetCurrent", getCur);

        }
        public ActionResult UpdateCurrent(Current p)
        {
            var UpCur = c.Currents.Find(p.CurrentID);
            UpCur.CurrentName = p.CurrentName;
            UpCur.CurrentSurname = p.CurrentSurname;
            UpCur.CurrentCity = p.CurrentCity;
            UpCur.CurrentMail = p.CurrentMail;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SalesCurrent(int id)
        {
            var SalesValues = c.SalesMovements.Where(x => x.CurrentID == id).ToList();
            var CurName = c.Currents.Where(x => x.CurrentID == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.viewName = CurName;
            return View(SalesValues);

        }
    }
}