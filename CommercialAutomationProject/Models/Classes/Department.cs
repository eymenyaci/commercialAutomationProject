using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class Department
    {
        [Key]
        public int DepartmentID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String DepartmentName { get; set; }
        public bool Status { get; set; }

        public ICollection<Staff> Staffs { get; set; } // Bir departmanda birden fazla personel olabilir.
    }
}