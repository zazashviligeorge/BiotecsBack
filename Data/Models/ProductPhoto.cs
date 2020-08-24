using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Data.Models
{
    [Owned]
    public class ProductPhoto
    {
        public string FileName { get; set; } 
    }
}
