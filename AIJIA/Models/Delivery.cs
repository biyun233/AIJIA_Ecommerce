using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace AIJIA.Models
{
    public class Delivery
    {
        [Key]
        public int IdDelivery { get; set; }

        [ForeignKey("ModelDelivery")]
        public int ModelDeliveryID { get; set; }
        public virtual ModelDelivery ModelDelivery { get; set; }

        [ForeignKey("Order")]
        public int OrderID { get; set; }
        public virtual Order Order { get; set; }
        public string RefDelivery { get; set; }
        public string DescriptionDelivery { get; set; }
        public DateTime DateDelivery { get; set; }
    }
}
