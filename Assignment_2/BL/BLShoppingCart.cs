using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// ADO.net model to represent the entire shopping cart for the current session.
/// </summary>

namespace Assignment_2.BL
{
    public class BLShoppingCart
    {
        public List<BLCartItem> Items { get; set; }
        public double Amount { get; set; }

        /// <summary>
        /// Empty constructor.
        /// </summary>
        public BLShoppingCart()
        {
            Items = new List<BLCartItem>();
        }

        /// <summary>
        /// Adds a new product and its corresponding quantity to the shopping cart model.
        /// </summary>
        /// <param name="item"></param>
        public void AddCartItem(BLCartItem item)
        {
            Items.Add(item);
            Amount += item.Quantity * item.Product.prodPrice;
		}

        /// <summary>
        /// Calculates total cost of all items currently in the shopping cart model.
        /// </summary>
        public void calculate()
        {
	        Amount = 0;
	        foreach (BLCartItem item in Items)
			{
				Amount += item.Quantity * item.Product.prodPrice;
			}
        }
        
        /// <summary>
        /// Determines status of whether cart contains any items currently.
        /// </summary>
        /// <returns></returns>
        public bool isEmpty()
        {
            return (Items.Count == 0);
        }

        /// <summary>
        /// Returns string representation of shopping cart model.
        /// </summary>
        /// <returns></returns>
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