using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var values1 = c.Currents.Count().ToString();
            ViewBag.v1 = values1;
            var values2 = c.Products.Count().ToString();
            ViewBag.v2 = values2;
            var values3 = c.Staffs.Count().ToString();
            ViewBag.v3 = values3;
            var values4 = c.Categories.Count().ToString();
            ViewBag.v4 = values4;
            var values5 = c.Products.Sum(x=>x.ProductStock).ToString();
            ViewBag.v5 = values5;
            var values6 = (from x in c.Products select x.ProductBrand).Distinct().Count().ToString();
            ViewBag.v6 = values6;
            var values7 = c.Products.Count(x => x.ProductStock<=5).ToString();
            ViewBag.v7 = values7;
            var values8 = (from x in c.Products orderby x.SalePrice descending select x.SKU).FirstOrDefault();
            ViewBag.v8= values8;
            var values9 = (from x in c.Products orderby x.SalePrice ascending select x.SKU).FirstOrDefault();
            ViewBag.v9 = values9;
            DateTime dt = DateTime.Today;
            var values10= c.SalesMovements.Sum(x => x.SalesTotalPrices).ToString();
            ViewBag.v10= values10;
            var values11 = c.SalesMovements.Count(x => x.SalesDate==dt).ToString();
            ViewBag.v11 = values11;
            var values12 = c.SalesMovements.Where(x => x.SalesDate == dt).Sum(y => y.SalesTotalPrices).ToString();
            ViewBag.v12 = values12;


            return View();
        }
    }
}