using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AIJIA.Models
{
    public class TypeArticle
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "Le Nom de la Catégorie est Obligatoire !")]
        [Display(Name = "Catégorie")]
        public string Name { get; set; }
    }
}
