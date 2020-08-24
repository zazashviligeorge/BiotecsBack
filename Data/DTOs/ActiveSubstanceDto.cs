using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.DTOs
{
    public class ActiveSubstanceDto
    {
        public int? Id { get; set; }
        
        public string SubstanceName { get; set; }
    }
}
