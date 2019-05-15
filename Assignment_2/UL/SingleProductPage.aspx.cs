using Assignment_2.BL;
using System;
using System.Collections.Generic;
using System.Data;
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

			product = product.selectProduct(Session["productNumber"].ToString());

			Session["Product"] = product;

			lblTitle.Text = product.playFirstName + " " + product.playLastName + " " + product.teamLocale + " " + product.teamName;
			lblDescription.Text = product.prodDescription;
			lblPrice.Text = string.Format("{0:C0}", product.prodPrice);

			imgFront.ImageUrl = "Images\\jerseys\\" + product.image[0];


			imgBack.ImageUrl = "Images\\jerseys\\" + product.image[1];
			//Images\jerseys\

			/*rptInfo.DataSource = productData;
			rptInfo.DataBind();

			rptJersey.DataSource = productData;
			rptJersey.DataBind();*/
		}

		// Adds current product to cart; gets shopping cart model from session and updates (then writes back to session).
		protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
	            BLProduct productData = Session["Product"] as BLProduct;

				BLShoppingCart cart = HttpContext.Current.Session["Cart"] as BLShoppingCart;
                cart.AddCartItem(new BLCartItem(productData, rblSizeOption.SelectedItem.Text, int.Parse(tbxQuantity.Text)));

                Response.Redirect("~/UL/Cart.aspx");
            }
        }
    }
}