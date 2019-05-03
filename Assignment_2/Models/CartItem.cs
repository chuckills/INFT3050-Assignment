using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Model to represent the a shopping cart item.
/// </summary>

namespace Assignment_1.Models
{
    public class CartItem
    {
        // Model variables
        public string Name { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }

        public CartItem(string name, string size, int quantity)
        {
            Name = name;
            Size = size;
            Quantity = quantity;
        }

        // String representation for model and display on user views
        public override string ToString()
        {
            return Name +" - Size: " +Size +" x " +Quantity;
        }
    }
}