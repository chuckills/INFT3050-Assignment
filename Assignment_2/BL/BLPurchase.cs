using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Assignment_2.DAL;

namespace Assignment_2.BL
{
	public class BLPurchase
	{
		public BLShoppingCart Cart { get; set; }
		public BLUser User { get; set; }
		public BLShipping Shipping { get; set; }
		public double Gst { get; set; }

		public BLPurchase(BLShoppingCart cart, BLUser user, int ship)
		{
			Cart = cart;
			User = user;
			DataRow shipSelection = DALSelect.getShippingDetails(ship);
			Shipping.Id = Convert.ToInt32(shipSelection["shipID"]);
			Shipping.Method = shipSelection["shipType"].ToString();
			Shipping.Cost = Convert.ToDouble(shipSelection["shipCost"]);
			Shipping.Wait = Convert.ToInt32(shipSelection["shipDays"]);
			Gst = (cart.Amount + Shipping.Cost) / 11;
		}
	}
}