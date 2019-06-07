using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_2.DAL;

/// <summary>
/// ADO.net model to represent the a shopping cart item.
/// </summary>

namespace Assignment_2.BL
{
    public class BLCartItem
    {
		public BLProduct Product { get; set; }
        public string Size { get; set; }
		public int Quantity { get; set; }
		public double ItemTotal { get; set; }

        /// <summary>
        /// Constructor to set all model variables for ADO.net BLCartItem model.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="size"></param>
        /// <param name="quantity"></param>
		public BLCartItem(BLProduct product, string size, int quantity)
        {
	        Product = product;
            Size = size;
            Quantity = quantity;
            ItemTotal = Product.prodPrice * Quantity;
        }

        /// <summary>
        /// Returns string representation for model and display on user views.
        /// </summary>
        /// <returns></returns>
		public override string ToString()
        {
            return Product.prodNumber +" - Size: " +Size +" x " +Quantity;
        }
    }
}