using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace group19Web.DTO
{
    public class CartItem
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public decimal priceUnit { get; set; }
        public decimal finalTotal { get; set; }
        public DateTime createDate { get; set; }

        public override string ToString()
        {
            return "productId: " + productId + " producname: " + productName + " quantity: " + quantity + " priceUnit: " + priceUnit + " priceTotal: " + finalTotal;
                
        }

    }
}