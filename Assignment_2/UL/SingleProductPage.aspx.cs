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

			DataSet productData = product.selectProduct(Session["productNumber"].ToString());

			rptInfo.DataSource = productData;
			rptInfo.DataBind();

			rptJersey.DataSource = productData;
			rptJersey.DataBind();

			Session["Product"] = productData.Tables[0].Rows[0];
        }

        // Adds current product to cart; gets shopping cart model from session and updates (then writes back to session).
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
	            DataRow productData = Session["Product"] as DataRow;

				BLShoppingCart cart = HttpContext.Current.Session["Cart"] as BLShoppingCart;
                cart.AddCartItem(new BLCartItem((string)productData.ItemArray[0], rblSizeOption.SelectedItem.Text, Convert.ToDouble(productData.ItemArray[2]), int.Parse(tbxQuantity.Text), (string)Session["image"]));

                Response.Redirect("~/UL/Cart.aspx");
            }
        }
    }
}