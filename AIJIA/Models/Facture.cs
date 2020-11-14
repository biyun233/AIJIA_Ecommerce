using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AIJIA.Models
{
    public class Facture
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }      
        public DateTime DateFacture { get; set; }
        public decimal Vat { get; set; }
        public decimal ExclVat { get; set; }
        public decimal InclVat { get; set; }
    }
}
