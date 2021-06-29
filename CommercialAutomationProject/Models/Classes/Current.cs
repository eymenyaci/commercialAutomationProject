using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class Current
    {
        [Key]
        public int CurrentID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String CurrentName { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String CurrentSurname { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String CurrentCity { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public String CurrentMail { get; set; }
        public bool Status { get; set; }
        public ICollection<SalesMovement> SalesMovements { get; set; }
    }
}