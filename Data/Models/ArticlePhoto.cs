using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Models
{
    public class ArticlePhoto
    {
        public int Id { get; set; }

        public string FileName { get; set; }

        public int? ArticleId { get; set; }

        public Article Article { get; set; }
    }
}
