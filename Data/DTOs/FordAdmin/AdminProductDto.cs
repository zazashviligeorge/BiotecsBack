using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace Data.DTOs.FordAdmin
{
    public class AdminProductDto
    {
        public int? Id { get; set; }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string ProductNameEng { get; set; }

        public string DescriptionEng { get; set; }

        public string ProductNameRu { get; set; }

        public string DescriptionRu { get; set; }

        public int? GroupId { get; set; }

        public int? SubstanceId { get; set; }

        public string PhotoUrl { get; set; }

        public IFormFile Photo { get; set; }
    }
}
