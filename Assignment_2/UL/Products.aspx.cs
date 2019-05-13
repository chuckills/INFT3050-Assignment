using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.BL;

namespace Assignment_2.UL
{
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			BLProduct products = new BLProduct();

	        Repeater1.DataSource = products.getProducts();
			Repeater1.DataBind();
        }

		protected void btnBuy_Click(object sender, EventArgs e)
		{
			LinkButton btnBuy = sender as LinkButton;

			Session["productNumber"] = btnBuy.CommandArgument;

			Response.Redirect("~/UL/SingleProductPage");
		}
	}
}