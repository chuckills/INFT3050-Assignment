using System;
using System.Collections.Generic;
using System.Configuration;
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
			if (Request.IsSecureConnection)
			{
				// Page only accessible by logged in user
				if (Session["LoginStatus"].Equals("User"))
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
				else
				{
					Response.Redirect("~/UL/ErrorPage/0");
				}
			}
			else
			{
				// Make connection secure if it isn't already
				string url = ConfigurationManager.AppSettings["SecurePath"] + "ViewSingleOrder";
				Response.Redirect(url);
			}
		}
    }
}