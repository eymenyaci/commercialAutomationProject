using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CommercialAutomation.Models.Classes;
namespace CommercialAutomation.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();
        public ActionResult Index()
        {
            var InvoiceList = c.Invoices.ToList();
            return View(InvoiceList);
        }
        [HttpGet]
        public ActionResult AddInvoice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoice(Invoice i)
        {
            c.Invoices.Add(i);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult GetInvoice(int id)
        {
            var InvoiceGet = c.Invoices.Find(id);
            return View("GetInvoice", InvoiceGet);
        }
        public ActionResult UpdateInvoice(Invoice i)
        {
            var InvoiceUpdate = c.Invoices.Find(i.InvoiceID);
            InvoiceUpdate.InvoiceSerialNumber = i.InvoiceSerialNumber;
            InvoiceUpdate.InvoiceOrderNumber = i.InvoiceOrderNumber;
            InvoiceUpdate.InvoiceTime = i.InvoiceTime;
            InvoiceUpdate.InvoiceDate = i.InvoiceDate;
            InvoiceUpdate.InvoiceDeliverer = i.InvoiceDeliverer;
            InvoiceUpdate.InvoiceReceiver = i.InvoiceReceiver;
            InvoiceUpdate.InvoiceTaxOffice = i.InvoiceTaxOffice;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult DetailsInvoice(int id)
        {
            var InValues = c.InvoiceDetails.Where(x => x.InvoiceID == id).ToList();
            return View(InValues);
        }
        [HttpGet]
        public ActionResult AddDetailsInvoice()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDetailsInvoice(InvoiceDetail a)
        {
            c.InvoiceDetails.Add(a);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult InvoiceList()
        {
            var valueslist = c.Invoices.ToList();
            return View(valueslist);
        }

    }
}