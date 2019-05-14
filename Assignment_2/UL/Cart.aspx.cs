using Assignment_2.BL;
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
            // Calculate total cost of the cart
            int total = 0;
            BLShoppingCart cart = Session["Cart"] as BLShoppingCart;
			
            // Display updated cost
            Cost.Text = string.Format("{0:C}", cart.Amount);
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
            Response.Redirect("~/UL/Cart.aspx");
        }

        // Attaches total cost of cart as parameter and redirects to payment form
        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            string cartTotal = Cost.Text;

            Session["Cost"] = cartTotal;

            if (Session["LoginStatus"].ToString().Equals("LoggedOut"))
            {
                Response.Redirect("~/UL/GuestRegistration.aspx");
            }
            else
            {
                Response.Redirect("~/UL/Payment.aspx");
            }
        }
    }
}