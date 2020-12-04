using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AIJIA.Models
{
    public class CartItem
    {
 
        public Article Article { get; set; }

        public int Quantity { get; set; }
    }
}