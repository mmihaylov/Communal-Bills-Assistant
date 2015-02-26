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
    /// This table contains information about all the bill types, that are registered for a specific location
    /// Example: 
    /// Strelbishte - Electricity
    /// Strelbishte - Internet
    /// Strelbishte - Water
    /// </summary>    

    [Table("LocationBill")]
    public class LocationBill : AuditableEntity<int>
    {
        [ScaffoldColumn(false)]
        [Display(Name = "Location")]
        public int LocationId { get; set; }

        [Required]
        [Display(Name = "Bill Type")]
        public int BillTypeId { get; set; }

        [ForeignKey("BillTypeId")]
        public virtual BillType BillType { get; set; }             

        [ForeignKey("LocationId")]
        public virtual Location Location { get; set; }

        //All Locations, where this bill type is registered
        public virtual IEnumerable<Location> Locations { get; set; }
    }
}
