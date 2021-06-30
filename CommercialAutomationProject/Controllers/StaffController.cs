using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff
        Context c = new Context();
        public ActionResult Index()
        {
            var staffValues = c.Staffs.Where(x=>x.Status==true).ToList();
            return View(staffValues);
        }
        [HttpGet]
        public ActionResult AddStaff()
        {
            List<SelectListItem> value2 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()

                                           }).ToList();
            ViewBag.value1 = value2;
            return View();
        }
        [HttpPost]
        public ActionResult AddStaff(Staff s)
        {
            s.Status = true;
            c.Staffs.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult GetStaff(int id)
        {
            List<SelectListItem> value2 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentID.ToString()

                                           }).ToList();
            ViewBag.value1 = value2;
            var getStaff = c.Staffs.Find(id);
            return View("GetStaff", getStaff);
        }
        public ActionResult UpdateStaff(Staff s)
        {
            var upStaff = c.Staffs.Find(s.StaffID);
            upStaff.StaffName = s.StaffName;
            upStaff.StaffSurname = s.StaffSurname;
            upStaff.StaffImage = s.StaffImage;
            upStaff.DepartmentID = s.DepartmentID;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}