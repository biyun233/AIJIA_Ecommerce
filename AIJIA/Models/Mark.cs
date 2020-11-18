using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AIJIA.Models
{
    public class Mark
    {
        [Key]
        [Display(Name = "Marque")]
        public int ID { get; set; }

        [Required(ErrorMessage = "Le Nom de la Marque est Obligatoire !")]
        [Display(Name = "Marque")]
        public string Name { get; set; }
    }
}
