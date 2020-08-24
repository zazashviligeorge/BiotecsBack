using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.Models
{
    public class Article : AuditableEntity
    {
        public Article()
        {
            ArticlePhotos=new HashSet<ArticlePhoto>();
        }
        public int Id { get; set; }

        
        [StringLength(100)]
        public string Title { get; set; }

        public string ArticleText { get; set; }

       
        [StringLength(100)]
        public string TitleEng { get; set; }

        public string ArticleTextEng { get; set; }

       
        [StringLength(100)]
        public string TitleRu { get; set; }
        public string ArticleTextRu { get; set; }

        public ICollection<ArticlePhoto> ArticlePhotos { get; set; }
    }
}
