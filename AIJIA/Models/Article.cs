using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AIJIA.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [ForeignKey("TypeArticle")]
        public int TypeArticleID { get; set; }
        public virtual TypeArticle TypeArticle { get; set; }

        [ForeignKey("Mark")]
        public int MarkID { get; set; }
        public virtual Mark Mark { get; set; }

        [ForeignKey("Provider")]
        public int ProviderID { get; set; }
        public virtual Provider Provider { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int QuantityStock { get; set; }
    }
}
