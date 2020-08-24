using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.DTOs
{
    public class ArticleDto
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string ArticleText { get; set; }

        public ICollection<string> PhotoUrls { get; set; }
    }
}
