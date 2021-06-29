using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class SalesMovement
    {
            [Key]
            public int SalesID { get; set; }
            public DateTime SalesDate { get; set; }
            public int SalesUnit { get; set; }
            public decimal SalesPrices { get; set; }
            public decimal SalesTotalPrices { get; set; }
            public int ProductID { get; set; }
            public int StaffID { get; set; }
            public int CurrentID { get; set; }
            public virtual Product Product { get; set; }
            public virtual Current Current { get; set; }
            public virtual Staff Staff { get; set; }

      
    }
}