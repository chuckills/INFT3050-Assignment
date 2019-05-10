using Assignment_2.Models;
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
            
        }

        // Adds current product to cart; gets shopping cart model from session and updates (then writes back to session).
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                ShoppingCart cart = HttpContext.Current.Session["Cart"] as ShoppingCart;
                cart.AddCartItem(new CartItem("Kyrie Irving - Swingman Jersey", rblSizeOption.SelectedItem.Text, int.Parse(tbxQuantity.Text)));

                Response.Redirect("~/UL/Cart.aspx");
            }
        }
    }
}