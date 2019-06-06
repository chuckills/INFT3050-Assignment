﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.BL;

namespace Assignment_2.UL
{
    public partial class ViewSingleOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			BLOrder order = Session["Order"] as BLOrder;

			lblOrderID.Text = order.OrderID.ToString();
			lblDate.Text = string.Format("{0:d}", order.OrderDetails["ordDate"]);

			lblSubtotal.Text = string.Format("{0:C}", order.OrderDetails["ordSubTotal"]);
			
			lblShip.Text = order.ShippingDetails["shipType"].ToString();
			lblShipCost.Text = string.Format("{0:C}", order.ShippingDetails["shipCost"]);

			lblTotal.Text = string.Format("{0:C}", order.OrderDetails["ordTotal"]);
			lblGst.Text = string.Format("{0:C}", order.OrderDetails["ordGST"]);

			lsvItems.DataSource = order.OrderItems;
			lsvItems.DataBind();
        }
    }
}