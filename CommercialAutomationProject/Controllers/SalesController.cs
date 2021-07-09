using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        Context c = new Context();
        public ActionResult Index()
        {
            var SalesValues = c.SalesMovements.ToList();
            return View(SalesValues);
        }
        [HttpGet]
        public ActionResult AddSales()
        {
            List<SelectListItem> values1 = (from x in c.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductID.ToString()
                                            }).ToList();
            
            List<SelectListItem> values2 = (from x in c.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName+" "+x.CurrentSurname,
                                                Value = x.CurrentID.ToString()
                                            }).ToList();
            List<SelectListItem> values3 = (from x in c.Staffs.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.StaffName + " " + x.StaffSurname,
                                                Value = x.StaffID.ToString()
                                            }).ToList();
            ViewBag.vl1 = values1;
            ViewBag.vl2 = values2;
            ViewBag.vl3 = values3;
            return View();
        }
        [HttpPost]
        public ActionResult AddSales(SalesMovement s)
        {
            s.SalesDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMovements.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult GetSales(int id)
        {
            List<SelectListItem> values1 = (from x in c.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductID.ToString()
                                            }).ToList();

            List<SelectListItem> values2 = (from x in c.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName + " " + x.CurrentSurname,
                                                Value = x.CurrentID.ToString()
                                            }).ToList();
            List<SelectListItem> values3 = (from x in c.Staffs.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.StaffName + " " + x.StaffSurname,
                                                Value = x.StaffID.ToString()
                                            }).ToList();
            ViewBag.vl1 = values1;
            ViewBag.vl2 = values2;
            ViewBag.vl3 = values3;
            var values = c.SalesMovements.Find(id);
            return View("GetSales", values);

        }
        public ActionResult UpdateSales(SalesMovement s)
        {
            var values = c.SalesMovements.Find(s.SalesID);
            values.CurrentID = s.CurrentID;
            values.SalesUnit = s.SalesUnit;
            values.SalesPrices = s.SalesPrices;
            values.StaffID = s.StaffID;
            values.SalesDate = s.SalesDate;
            values.SalesTotalPrices = s.SalesTotalPrices;
            values.ProductID = s.ProductID;
            c.SaveChanges();
            return RedirectToAction("Index");

            

        }
        public ActionResult DetailSales(int id)
        {
            var values = c.SalesMovements.Where(x => x.SalesID == id).ToList();
            return View(values);
        }
    }
}