using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace group19Web.DTO
{
    public class Cart
    {
        public List<CartItem> cartItems { get; set; }
        public decimal totalPrice { get; set; }

        public override string ToString()
        {
            return "cartItem: " + cartItems.ToString() + " totalPrice: " + totalPrice; 
        }
    }
}