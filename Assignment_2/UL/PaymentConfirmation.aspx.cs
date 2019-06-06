using Assignment_2.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class PaymentConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Send confirmation of order to account email address
            BLShoppingCart cart = Session["Cart"] as BLShoppingCart;
            BLShipping shipping = Session["Shipping"] as BLShipping;

			string mailbody = BLPurchase.generateOrderSummary(Session["Name"].ToString(), cart, shipping);
			
            try
            {
                BLEmail.SendEmail(Session["UserName"].ToString(), "Order Receipt - JerseySure", mailbody);
            }
            catch (Exception ex)
            {
                Response.Redirect("~/UL/ErrorPage/1");
            }

            // Remove cart from session
            Session.Remove("Cart");
            Session["Cart"] = new BLShoppingCart();
        }
    }
}