using Assignment_2.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class PurchaseHistory : System.Web.UI.Page
    {
        List<String> purchaseList;

        protected void Page_Load(object sender, EventArgs e)
        {
            BLUser user = Session["CurrentUser"] as BLUser;

            if (Session["LoginStatus"].ToString().Equals("User"))
            {
                gvOrders.DataSource = BLPurchase.getUserOrders(user);
                gvOrders.DataBind();
            }
            else
            {
                // Unauthorised
            }
        }

        // COPIED FROM AdminItemManagment.aspx.cs
        // Redirect to appropriate update page
        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = gvProducts.SelectedRow;

            BLProduct product = new BLProduct();

            Session["Product"] = product.selectProduct(row.Cells[0].Text);
            Response.Redirect("~/UL/AdminUpdateSelectedItem.aspx");
        }
    }
}