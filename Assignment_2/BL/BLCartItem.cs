using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Model to represent the a shopping cart item.
/// </summary>

namespace Assignment_2.BL
{
    public class BLCartItem
    {
		// Model variables
		public BLProduct Product { get; set; }
        public string Size { get; set; }
		public int Quantity { get; set; }

        public BLCartItem(BLProduct product, string size, int quantity)
        {
	        Product = product;
            Size = size;
            Quantity = quantity;
        }

        // String representation for model and display on user views
        public override string ToString()
        {
            return Product.prodNumber +" - Size: " +Size +" x " +Quantity;
        }
    }
}