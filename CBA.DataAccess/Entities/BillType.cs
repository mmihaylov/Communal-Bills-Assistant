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
    /// This entity describes what are the possible bill types
    /// Example: Electricity, Heating, Water, Internet, Cable TV
    /// </summary>    

    [Table("BillType")]
    public class BillType : Entity<int>
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}
