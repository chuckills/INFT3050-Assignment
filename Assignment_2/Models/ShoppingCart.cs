using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Model to represent the entire shopping cart for the current session.
/// </summary>

namespace Assignment_2.Models
{
    public class ShoppingCart
    {
        // Model data
        public List<CartItem> Items { get; set; }

        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }

        // Adds a new product and its corresponding quantity to the shopping cart model
        public void AddCartItem(CartItem item)
        {
            Items.Add(item);
        }

        // Returns string representation of shopping cart model
        public override string ToString()
        {
            String output = "";
            foreach (CartItem item in Items)
            {
                output += item.ToString() +Environment.NewLine;
            }
            return output;
        }
    }
}