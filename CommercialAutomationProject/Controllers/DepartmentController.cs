using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;

namespace CommercialAutomation.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var DepartmenValues = c.Departments.Where(x => x.Status == true).ToList();
            return View(DepartmenValues);
        }
        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();

        }
        [HttpPost]
        public ActionResult AddDepartment(Department d)
        {
            c.Departments.Add(d);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DeleteDepartment(int id)
        {
            var DeleteDep = c.Departments.Find(id);
            DeleteDep.Status = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult GetDepartment(int id)
        {
            var UpdateDep = c.Departments.Find(id);
            return View("GetDepartment", UpdateDep);


        }
        public ActionResult UpdateDepartment(Department dp)
        {
            var UpDep = c.Departments.Find(dp.DepartmentID);
            UpDep.DepartmentName = dp.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DetailsDepartment(int id)
        {
            var depValues = c.Staffs.Where(x => x.DepartmentID == id).ToList();
            var depName = c.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.v = depName;
            return View(depValues);
        }
        public ActionResult DepartmentStaffSales(int id)
        {
            var degerler = c.SalesMovements.Where(x => x.StaffID == id).ToList();
            var st = c.Staffs.Where(x => x.StaffID == id).Select(y => y.StaffName +" "+ y.StaffSurname).FirstOrDefault();
            ViewBag.vst = st;
            return View(degerler);
        }
    }
}