using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomationProject.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index()
        {
            var CategoryValues = c.Categories.ToList();
            return View(CategoryValues);
        }
        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(Category cat)
        {
            c.Categories.Add(cat);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCategory(int id)
        {
            var CatId = c.Categories.Find(id);
            c.Categories.Remove(CatId);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetCategory(int id)
        {
            var getcat = c.Categories.Find(id);
            return View("GetCategory", getcat);

        }
        public ActionResult UpdateCategory(Category u)
        {
            var UpdateCat = c.Categories.Find(u.CategoryID);
            UpdateCat.CategoryName = u.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}