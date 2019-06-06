using Assignment_2.BL;
using Microsoft.AspNet.FriendlyUrls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Page is not viewable on admin site
            if (!Session["LoginStatus"].Equals("Admin"))
            {
                // Calculate total cost of the cart
                int total = 0;
                BLShoppingCart cart = Session["Cart"] as BLShoppingCart;
			
                // Display updated cost
                Cost.Text = string.Format("{0:C}", cart.Amount);
            }
            else
            {
                Response.Redirect("~/UL/ErrorPage/5");
            }
            
        }

        // Returns currently stored cart items in the session
        public List<BLCartItem> GetCartItems()
        {
            BLShoppingCart cart = Session["Cart"] as BLShoppingCart;
            return cart.Items;
        }

        // Initialises shopping cart object in the session to empty
        protected void btnEmptyCart_Click(object sender, EventArgs e)
        {
            Session.Remove("Cart");
            Session["Cart"] = new BLShoppingCart();
            Response.Redirect(Request.Url.ToString(), true);
        }

        // Remove specified cart item from the shopping cart
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            BLShoppingCart cart = Session["Cart"] as BLShoppingCart;
            CheckBox selected;

            ListViewDataItem currDataItem;

            // Finds specified cart item within the overall cart and removes it
            for (int i = ItemList.Items.Count-1; i >= 0; i--)
            {
                currDataItem = ItemList.Items[i];
                selected = currDataItem.FindControl("cbxRemove") as CheckBox;
                if (selected.Checked)
                {
                    cart.Items.RemoveAt(ItemList.Items[i].DisplayIndex);
					cart.calculate();
                }
            }
            Response.Redirect("~/UL/Cart");
        }

        // Attaches total cost of cart as parameter and redirects to payment form
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            BLShoppingCart cart = Session["Cart"] as BLShoppingCart;
            // Cannot checkout unless items are in the cart
            if (!cart.isEmpty())
            {
                string cartTotal = Cost.Text;

                Session["Cost"] = cartTotal;

                if (Session["LoginStatus"].ToString().Equals("LoggedOut"))
                {
                    // Unable to checkout without a registered account
                    Response.Redirect("~/UL/ErrorPage/4");
                }
                else
                {
                    Response.Redirect("~/UL/Payment");
                }
            }
            else
            {
                ErrorLabel.Text = "Cannot perform checkout with no items in cart.";
            }
        }
    }
}