using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class InvoiceDetail
    {
        [Key]
        public int InvoiceDetailID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public String InvoiceDetailDescription { get; set; }
        public int InvoiceDetailTotal { get; set; }
        public decimal InvoiceDetailUnitPrice { get; set; }
        public decimal InvoiceDetailAmount { get; set; }
        public Invoice Invoice { get; set; }
    }
}