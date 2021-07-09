using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index()
        {
            var Products = c.Products.Where(x => x.ProductStatus == true).ToList();
            return View(Products);
        }
        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> value2 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();
            ViewBag.value1 = value2;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            c.Products.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteProduct(int id)
        {
            var deleted = c.Products.Find(id);
            deleted.ProductStatus = false;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult GetProduct(int id)
        {
            List<SelectListItem> value2 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()

                                           }).ToList();
            ViewBag.value1 = value2;
            var productvalues = c.Products.Find(id);
            return View("GetProduct", productvalues);


        }
        public ActionResult UpdateProduct(Product p)
        {
            var updated = c.Products.Find(p.ProductID);
            updated.ProductBrand = p.ProductBrand;
            updated.ProductImage = p.ProductImage;
            updated.ProductName = p.ProductName;
            updated.ProductStatus = p.ProductStatus;
            updated.ProductStock = p.ProductStock;
            updated.PurchasePrice = p.PurchasePrice;
            updated.SalePrice = p.SalePrice;
            updated.CatID = p.CatID;
            c.SaveChanges();
            return RedirectToAction("Index");


        }
        public ActionResult ProductList()
        {
            var valueslist = c.Products.ToList();
            return View(valueslist);
        }
    }
}