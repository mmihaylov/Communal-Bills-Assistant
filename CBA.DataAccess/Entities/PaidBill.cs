using CBA.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.DataAccess.Entities
{
    /// <summary>
    /// This entity describes a bill that has been paid for a specific location. 
    /// Example: Strelbishte, Electrocity, 25.00 BGN
    /// </summary>

    [Table("PaidBill")]
    public class PaidBill : AuditableEntity<int>
    {
        [ScaffoldColumn(false)]
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        [Required]
        [Display(Name = "Bill Type")]
        public int BillTypeId { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public int Month { get; set; }

        [Required]
        public decimal Amount { get; set; }


        [ForeignKey("BillTypeId")]
        public virtual BillType BillType { get; set; }             

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }
    }
}
