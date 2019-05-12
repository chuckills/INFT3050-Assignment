using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Model to represent the a shopping cart item.
/// </summary>

namespace Assignment_2.BL
{
    public class CartItem
    {
		// Model variables
		public string Name { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }

		public string Image { get; set; }

        public CartItem(string name, string size, int quantity, string image)
        {
            Name = name;
            Size = size;
            Quantity = quantity;
            Image = image;
        }

        // String representation for model and display on user views
        public override string ToString()
        {
            return Name +" - Size: " +Size +" x " +Quantity;
        }
    }
}