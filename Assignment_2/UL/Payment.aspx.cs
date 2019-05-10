using Assignment_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Cost.Text = Request.QueryString["cost"];
        }

        // Redirects to payment confirmation message and removes current shopping cart 
        // from session.
        protected void PaymentConfirmLink_Click(object sender, EventArgs e)
        {
            HttpContext.Current.Session.Remove("Cart");
            HttpContext.Current.Session["Cart"] = new ShoppingCart();
            Response.Redirect("~/UL/PaymentConfirmation.aspx");
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Response.Redirect("~/UL/PaymentResponse.aspx");
            }
        }
    }
}