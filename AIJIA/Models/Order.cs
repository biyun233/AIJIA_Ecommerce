using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Collections.Generic;
namespace AIJIA.Models
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        public DateTime DateOrder { get; set; }


        public string UserID { get; set; }

        public int FactureID { get; set; }

        public decimal AmountDelivery { get; set; }
        public decimal TotalAmount { get; set; }

      
    }
}
