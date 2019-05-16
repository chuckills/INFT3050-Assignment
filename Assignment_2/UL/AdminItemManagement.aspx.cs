using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.BL;

namespace Assignment_2.UL
{
    public partial class AdminManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
	        gvProducts.DataSource = BLProduct.getProducts();
	        gvProducts.DataBind();
		}

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