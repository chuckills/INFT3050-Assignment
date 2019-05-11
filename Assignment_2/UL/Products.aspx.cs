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
	        Repeater1.DataSource = Product.getProducts();
			Repeater1.DataBind();
        }

		protected void btnBuy_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/UL/SingleProductPage");
		}
	}
}