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

            string mailbody =
                "<p>"
                + "To " + Session["Name"].ToString() + ","
                + "</p>"
                + "<p>"
                + "Below is a summary of your recent order:"
                + "</p>"
                + "<div>"
                + "<table style=\"border-collapse: collapse; border: 1px solid black;\">"
                +"<tr>"
                + "<th style=\"border: 1px solid black; padding: 2px 5px;\">Quantity</th>"
                + "<th style=\"border: 1px solid black; padding: 2px 5px;\">Size</th>"
                + "<th style=\"border: 1px solid black; padding: 2px 5px;\">Item</th>"
                + "<th style=\"border: 1px solid black; padding: 2px 5px;\">Cost</th>"
                + "</tr>";

            foreach (BLCartItem item in cart.Items)
            {
                mailbody +=
                    "<tr>"
                    + "<td style=\"border: 1px solid black; padding: 2px 5px;\">" +item.Quantity +"</td>"
                    + "<td style=\"border: 1px solid black; padding: 2px 5px;\">" + item.Size + "</td>"
                    + "<td style=\"border: 1px solid black; padding: 2px 5px;\">" 
                    + item.Product.playFirstName
                    + " "
                    + item.Product.playLastName
                    + " - "
                    + item.Product.prodDescription 
                    + "</td>"
                    + "<td style=\"border: 1px solid black; padding: 2px 5px;\">$" + item.ItemTotal + "</td>"
                    + "</tr>";
            }


                mailbody +=
                "<tr>"
                + "<td style=\"border: 1px solid black; padding: 2px 5px;\"></td>"
                + "<th style=\"border: 1px solid black; padding: 2px 5px;\"></td>"
                + "<td style=\"border: 1px solid black; padding: 2px 5px;\">Shipping: " + shipping.Method + "</td>"
                + "<td style=\"border: 1px solid black; padding: 2px 5px;\">$" + shipping.Cost + "</td>"
                + "</tr>"
                +"<tr>"
                + "<td style=\"border: 1px solid black; padding: 2px 5px;\"></td>"
                + "<td style=\"border: 1px solid black; padding: 2px 5px;\"></td>"
                + "<th style=\"border: 1px solid black; padding: 2px 5px;\">Total</td>"
                + "<td style=\"border: 1px solid black; padding: 2px 5px;\">$" + (cart.Amount + shipping.Cost) + "</td>"
                + "</tr>"
                + "</table>"
                + "</div>"
                + "<br/>"
                + "<p>"
                + "Kind Regards,"
                + "</p>"
                + "<p>"
                + "The JerseySure Team"
                + "</p>";

            try
            {
                BLEmail.SendEmail(Session["UserName"].ToString(), "Order Receipt - JerseySure", mailbody);
            }
            catch (Exception ex)
            {
                Response.Redirect("~/UL/ErrorPage?status=1");
            }

            // Remove cart from session
            Session.Remove("Cart");
            Session["Cart"] = new BLShoppingCart();
        }
    }
}