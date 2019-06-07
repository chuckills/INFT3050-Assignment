﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.BL;

namespace Assignment_2.UL
{
    public partial class AdminManageUserAccounts : System.Web.UI.Page
    {
	    protected void Page_Load(object sender, EventArgs e)
	    {
		    if (Request.IsSecureConnection)
		    {
				// Page only accessible by admin
				if (Session["LoginStatus"].Equals("Admin"))
			    {
				    gvUsers.DataSource = BLUser.getUsers();
				    gvUsers.DataBind();
			    }
			    else
			    {
				    Response.Redirect("~/UL/ErrorPage/5");
			    }
		    }
		    else
		    {
				// Make connection secure if it isn't already
				string url = ConfigurationManager.AppSettings["SecurePath"] + "AdminManageUserAccounts";
				Response.Redirect(url);
			}
		}

		protected void gvUsers_SelectedIndexChanged(object sender, EventArgs e)
		{
			GridViewRow row = gvUsers.SelectedRow;

			BLUser user = new BLUser();

			Session["User"] = user.getUser(Convert.ToInt32(row.Cells[0].Text));
			Response.Redirect("~/UL/AdminUpdateSelectedUser");
		}

		/* 
         * Temporary Functionality follows these comments
         */

		/*protected void ViewTransactions_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/PurchaseHistory.aspx");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            toggleAccount(Button2, lblBadge1);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            toggleAccount(Button4, lblBadge2);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            toggleAccount(Button6, lblBadge3);
        }

        // Simulates changing the status of a user account
        private void toggleAccount(Button button, Label label)
        {
            if (button.Text == "Activate")
            {
                button.Text = "Suspend";
                label.Text = "Active";
            }
            else
            {
                button.Text = "Activate";
                label.Text = "Suspended";
            }
        }*/
	}
}