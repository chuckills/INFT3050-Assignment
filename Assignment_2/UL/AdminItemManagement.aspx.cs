﻿using System;
using System.Collections.Generic;
using System.Configuration;
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
	        if (Request.IsSecureConnection)
	        {
		        // Page only accessible by admin
		        if (Session["LoginStatus"].Equals("Admin"))
		        {
			        gvProducts.DataSource = BLProduct.getProducts(true);
			        gvProducts.DataBind();
		        }
		        else
		        {
			        Response.Redirect("~/UL/ErrorPage/5");
		        }
			}
			else
	        {
		        // Make connection secure if it isn't already
		        string url = ConfigurationManager.AppSettings["SecurePath"] + "AdminItemManagement";
		        Response.Redirect(url);
	        }
		}

        // Redirect to appropriate update page
		protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
		{
			GridViewRow row = gvProducts.SelectedRow;

			BLProduct product = new BLProduct();

			Session["Product"] = product.selectProduct(row.Cells[0].Text);
			Response.Redirect("~/UL/AdminUpdateSelectedItem");
		}

		protected void gvProducts_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowIndex >= 0)
			{
				BLProduct product = new BLProduct();
				product = product.selectProduct(e.Row.Cells[0].Text);
				Label lowStock = e.Row.FindControl("lblLowStock") as Label;
				foreach (int quantity in product.stock)
				{
					if (quantity <= 0)
					{
						lowStock.Visible = true;
						if (quantity < 0)
						{
							lowStock.Text = "Some sizes on backorder";
							break;
						}
						lowStock.Text = "Some sizes zero stock";
					}
				}
			}
		}
	}
}