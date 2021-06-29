using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class Cost
    {
        [Key]
        public int CostID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public String CostDescription { get; set; }
        public DateTime CostDate { get; set; }
        public decimal CostAmount { get; set; }
    }
}