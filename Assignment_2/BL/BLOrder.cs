using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Assignment_2.DAL;
using Microsoft.Ajax.Utilities;

namespace Assignment_2.BL
{
	public class BLOrder
	{
		public int OrderID { get; set; }
		public DataRow OrderDetails { get; set; }
		public DataTable OrderItems { get; set; }
		public DataRow ShippingDetails { get; set; }
		
		public static DataSet getUserOrders(BLUser user)
		{
			return DALSelect.getUserOrders(user);
		}

		public BLOrder getOrder(int orderID)
		{
			OrderID = orderID;
			OrderDetails = DALSelect.getOrder(orderID);
			OrderItems = DALSelect.getOrderItems(orderID);
			ShippingDetails = DALSelect.getShippingDetails(Convert.ToInt32(OrderDetails["shipID"]));

			return this;
		}
	}
}