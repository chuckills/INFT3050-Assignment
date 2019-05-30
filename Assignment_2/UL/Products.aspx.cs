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
    public partial class Products : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string searchParameter;
            // If page is reached via search input field: display corresponding products
            if (HttpContext.Current.Session["SearchString"] != null)
            {
                // Get search input
                searchParameter = HttpContext.Current.Session["SearchString"].ToString();
                // Get products from query
                DataSet productSearch = BLProduct.getProductsSearch(searchParameter);
                int count = productSearch.Tables["Products"].Rows.Count;
                rptProducts.DataSource = productSearch;
                rptProducts.DataBind();
                // Display search input for results
                if (count == 0)
                    searchLabel.Text = "No search results for \"" + searchParameter + "\"...";
                else
                    searchLabel.Text = "Search results for \"" + searchParameter + "\"...";
                // Remove from session
                HttpContext.Current.Session.Remove("SearchString");
            }
            // Otherwise, show all products
            else
            {
                rptProducts.DataSource = BLProduct.getProducts();
                rptProducts.DataBind();
            }
        }

		protected void btnBuy_Click(object sender, EventArgs e)
		{
			LinkButton btnBuy = sender as LinkButton;

			Session["productNumber"] = btnBuy.CommandArgument;

			Response.Redirect("~/UL/SingleProductPage");
		}
	}
}