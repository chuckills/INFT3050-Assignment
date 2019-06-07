using Assignment_2.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            // Check for secure connection
            if (Request.IsSecureConnection)
            {
                // Page only accessible to a logged in user
                if (Session["LoginStatus"].Equals("User"))
                {
                    // Check if items are still in the cart - otherwise; wrong state
                    BLShoppingCart cart = Session["Cart"] as BLShoppingCart;
                    if (!cart.isEmpty())
                    { 
                        // Send confirmation of order to account email address
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
                    else
                    {
                        Response.Redirect("~/UL/ErrorPage/7");
                    }
                }
                else
                {
                    Response.Redirect("~/UL/ErrorPage/0");
                }
            }
            else
            {
                // Make connection secure if it isn't already
                string url = ConfigurationManager.AppSettings["SecurePath"] + "PaymentConfirmation";
                Response.Redirect(url);
            }
        }
    }
}