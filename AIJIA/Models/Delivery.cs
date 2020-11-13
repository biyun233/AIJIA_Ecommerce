using System;
namespace AIJIA.Models
{
    public class Delivery
    {
        public int IdDelivery { get; set; }
        public int IdModelDelivery { get; set; }
        public int IdOrder { get; set; }
        public string RefDelivery { get; set; }
        public string DescriptionDelivery { get; set; }
        public DateTime DateDelivery { get; set; }
    }
}
