using System;
namespace AIJIA.Models
{
    public class Facture
    {
        public int IdFacture { get; set; }
        public int IdOrder { get; set; }
        public DateTime DateFacture { get; set; }
        public decimal Vat { get; set; }
        public decimal ExclVat { get; set; }
        public decimal InclVat { get; set; }
    }
}
