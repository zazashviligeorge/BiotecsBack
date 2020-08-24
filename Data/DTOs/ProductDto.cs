using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Data.Helpers.Paging;
using Microsoft.AspNetCore.Http;

namespace Data.DTOs
{
   public class ProductDto
    {
        public int? Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public int? GroupId { get; set; }

        public int? SubstanceId { get; set; }

        public string PhotoUrl { get; set; }

    
    }
}
