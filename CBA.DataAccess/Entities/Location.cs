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
    /// This entity specifies a location, for which bill can be added and paid.
    /// </summary>
   
    [Table("Location")]
    public class Location : AuditableEntity<int>
    {
        [Required]
        [MaxLength(64)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Description { get; set; }

        //Registered bills for this location
        public virtual IEnumerable<LocationBill> LocationBills { get; set; }

        //Paid bills for this location
        public virtual IEnumerable<PaidBill> PaidBills { get; set; }
    }
}
