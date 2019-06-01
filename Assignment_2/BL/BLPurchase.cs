using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Assignment_2.BL
{
	public class BLPurchase
	{
		public BLShoppingCart Cart { get; set; }
		public BLUser User { get; set; }
		public BLShipping Shipping { get; set; }
		public double Gst { get; set; }

		public BLPurchase(BLShoppingCart cart, BLUser user, BLShipping ship)
		{
			Cart = cart;
			User = user;
			Shipping = ship;
			Gst = (cart.Amount + Shipping.Cost) / 11;
		}
	}
}