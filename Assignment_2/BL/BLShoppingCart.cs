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
        public double Amount { get; set; }

        public BLShoppingCart()
        {
            Items = new List<BLCartItem>();
        }

        // Adds a new product and its corresponding quantity to the shopping cart model
        public void AddCartItem(BLCartItem item)
        {
            Items.Add(item);
            Amount += item.Quantity * item.Product.prodPrice;
		}

        public void calculate()
        {
	        Amount = 0;
	        foreach (BLCartItem item in Items)
			{
				Amount += item.Quantity * item.Product.prodPrice;
			}
        }

        // Returns string representation of shopping cart model
        public override string ToString()
        {
            string output = "";
            foreach (BLCartItem item in Items)
            {
                output += item + Environment.NewLine;
            }
            return output;
        }
    }
}