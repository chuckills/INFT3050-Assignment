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
		public string Name { get; set; }
        public string Size { get; set; }
		public double Price { get; set; }
		public int Quantity { get; set; }
		public string Image { get; set; }

        public BLCartItem(string name, string size, double price, int quantity, string image)
        {
            Name = name;
            Size = size;
            Price = price;
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