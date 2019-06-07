using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Assignment_2.DAL;
using Microsoft.Ajax.Utilities;

/// <summary>
/// ADO.net model to represent an order.
/// </summary>

namespace Assignment_2.BL
{
	public class BLOrder
	{
		public int OrderID { get; set; }
		public DataRow OrderDetails { get; set; }
		public DataTable OrderItems { get; set; }
		public DataRow ShippingDetails { get; set; }
		
        /// <summary>
        /// Retrieves orders a specified user has made within the system.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
		public static DataSet getUserOrders(BLUser user)
		{
			return DALSelect.getUserOrders(user);
		}

        /// <summary>
        /// Retrieves a specified order according to an order ID parameter and returns class model representation.
        /// </summary>
        /// <param name="orderID"></param>
        /// <returns></returns>
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