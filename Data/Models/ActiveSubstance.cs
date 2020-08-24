using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class ActiveSubstance : AuditableEntity
    {
        public ActiveSubstance()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; set; }

       
        [StringLength(100)]
        public string SubstanceName { get; set; }

        
        [StringLength(100)]
        public string SubstanceNameEng { get; set; }

       
        [StringLength(100)]
        public string SubstanceNameRu { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
