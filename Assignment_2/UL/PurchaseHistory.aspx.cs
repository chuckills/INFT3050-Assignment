﻿using Assignment_2.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class PurchaseHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
		{
			if (Request.IsSecureConnection)
			{
				// Page only accessible to a logged in user
				if (Session["LoginStatus"].ToString().Equals("User"))
				{
					BLUser user = Session["CurrentUser"] as BLUser;
					gvOrders.DataSource = BLOrder.getUserOrders(user);
					gvOrders.DataBind();
				}
				else
				{
					// Unauthorised
					Response.Redirect("~/UL/ErrorPage/0");
				}
			}
			else
			{
				// Make connection secure if it isn't already
				string url = ConfigurationManager.AppSettings["SecurePath"] + "PurchaseHistory";
				Response.Redirect(url);
			}
		}

        // COPIED FROM AdminItemManagment.aspx.cs
        // Redirect to appropriate update page
        protected void gvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(gvOrders.SelectedRow.Cells[0].Text);

            BLOrder order = new BLOrder();
           
            Session["Order"] = order.getOrder(orderID);
			
            Response.Redirect("~/UL/ViewSingleOrder");
        }
    }
}