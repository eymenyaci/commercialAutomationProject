using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(10)]
        public String Username { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String Password { get; set; }

        [Column(TypeName = "Char")]
        [StringLength(1)]
        public String Authority { get; set; }
    }
}