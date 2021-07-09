using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class Invoice
    {
        [Key]
        public int InvoiceID { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public String InvoiceSerialNumber { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String InvoiceOrderNumber { get; set; }
        public DateTime InvoiceDate { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public String InvoiceTaxOffice { get; set; }
        
        [Column(TypeName = "char")]
        [StringLength(5)]
        public String InvoiceTime { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String InvoiceDeliverer { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String InvoiceReceiver { get; set; }
        public decimal Total { get; set; }
        public ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}