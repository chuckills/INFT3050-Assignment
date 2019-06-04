using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.BL;

namespace Assignment_2.UL
{
    public partial class PaymentConfirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
	        if (!IsPostBack)
	        {
		        Session.Remove("Cart");
		        Session["Cart"] = new BLShoppingCart();
	        }
        }
    }
}