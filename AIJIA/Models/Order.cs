using System;
namespace AIJIA.Models
{
    public class Order
    {
        public int IdOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public int IdUser { get; set; }
        public int Quantity { get; set; }
        public decimal AmountArticle { get; set; }
        public decimal AmountDelivery { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
