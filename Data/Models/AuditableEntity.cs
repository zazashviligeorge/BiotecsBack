using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class AuditableEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}
