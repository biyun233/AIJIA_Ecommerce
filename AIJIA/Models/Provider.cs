using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AIJIA.Models
{
    public class Provider
    {
        [Key]
        [Display(Name = "Fournisseur")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Le Nom du Fournisseur est Obligatoire !")]
        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Required(ErrorMessage = "L'adresse Mail est Obligatoire !")]
        [Display(Name = "Email")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le Numéro de Telephone est Obligatoire !")]
        [Display(Name = "Telephone")]
        public string phone { get; set; }

        [Required(ErrorMessage = "L'Adresse du Fournisseur est Obligatoire !")]
        [Display(Name = "Ville")]
        public string City { get; set; }
    }
}
