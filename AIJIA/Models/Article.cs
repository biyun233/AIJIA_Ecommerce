using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AIJIA.Models
{
    public class Article
    {
        [Key]
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "Le Nom de l'article est Obligatoire !")]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        
        [Display(Name = "Image")]
        public string Description { get; set; }

        [Display(Name = "Catégorie")]

        [ForeignKey("TypeArticle")]
        public int TypeArticleID { get; set; }
        public virtual TypeArticle TypeArticle { get; set; }

        [ForeignKey("Mark")]
        public int MarkID { get; set; }
        public virtual Mark Mark { get; set; }


        [ForeignKey("Provider")]
        public int ProviderID { get; set; }
        public virtual Provider Provider { get; set; }

        
        [Display(Name = "Couleur")]
        public string Color { get; set; }

        [Required(ErrorMessage = "La Taille doit être indiquée !")]
        [Display(Name = "Taille")]
        public string Size { get; set; }

        [Required(ErrorMessage = "Le Prix doit être indiqué !")]
        [Display(Name = "Prix")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Le Quantité doit être indiquée !")]
        [Display(Name = "Quantité")]
        public int QuantityStock { get; set; }
    }
}
