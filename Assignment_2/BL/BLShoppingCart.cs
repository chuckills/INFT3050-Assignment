using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Model to represent the entire shopping cart for the current session.
/// </summary>

namespace Assignment_2.BL
{
    public class BLShoppingCart
    {
        // Model data
        public List<BLCartItem> Items { get; set; }

        public BLShoppingCart()
        {
            Items = new List<BLCartItem>();
        }

        // Adds a new product and its corresponding quantity to the shopping cart model
        public void AddCartItem(BLCartItem item)
        {
            Items.Add(item);
        }

        // Returns string representation of shopping cart model
        public override string ToString()
        {
            String output = "";
            foreach (BLCartItem item in Items)
            {
                output += item.ToString() +Environment.NewLine;
            }
            return output;
        }
    }
}