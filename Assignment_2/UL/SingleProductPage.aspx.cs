using Assignment_2.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class SingleProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			BLProduct product = new BLProduct();

			rptInfo.DataSource = product.selectProduct((string)Session["productNumber"]);
			rptInfo.DataBind();

			rptJersey.DataSource = product.selectProduct((string)Session["productNumber"]);
			rptJersey.DataBind();
		}

        // Adds current product to cart; gets shopping cart model from session and updates (then writes back to session).
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
				BLShoppingCart cart = HttpContext.Current.Session["Cart"] as BLShoppingCart;
                cart.AddCartItem(new BLCartItem((string)Session["productNumber"], rblSizeOption.SelectedItem.Text, int.Parse(tbxQuantity.Text), (string)Session["image"]));

                Response.Redirect("~/UL/Cart.aspx");
            }
        }
    }
}