using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CommercialAutomation.Models.Classes
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public String ProductName { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String SKU { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public String ProductBrand { get; set; }
        public int ProductStock { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public bool ProductStatus { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(400)]
        public String ProductImage { get; set; }

        public int CatID { get; set; }
        public virtual Category Category { get; set; } //Bir ürünün bir kategorisi olabilir.
      


        public ICollection<SalesMovement> SalesMovements { get; set; }
    }
}