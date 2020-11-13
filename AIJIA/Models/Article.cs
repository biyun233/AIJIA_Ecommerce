using System;
namespace AIJIA.Models
{
    public class Article
    {
        public int IdArticle { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Mark { get; set; }
        public string Provider { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public int QuantityStock { get; set; }
    }
}
