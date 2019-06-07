using System;
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

	    protected void btnActive_Clicked(object sender, EventArgs e)
	    {
			//-==================================================================
			//-==================================================================
			//-==================================================================
			//-==================================================================
		}

		protected void gvUsers_OnRowDataBound(object sender, GridViewRowEventArgs e)
	    {
		    if (e.Row.RowIndex >= 0)
		    {
			    DataRowView rowView = e.Row.DataItem as DataRowView;

				Button btnUserActive = e.Row.FindControl("btnActive") as Button;

			    if (Convert.ToBoolean(rowView["userActive"]))
			    {
				    btnUserActive.CssClass = "btn btn-danger";
				    btnUserActive.Text = "Active";
			    }
			    else
			    {
				    btnUserActive.CssClass = "btn btn-outline-danger";
				    btnUserActive.Text = "Suspended";
			    }
		    }
	    }

	    protected void gvUsers_OnRowCommand(object sender, GridViewCommandEventArgs e)
	    {

		    GridViewRow row = gvUsers.Rows[Convert.ToInt32(e.CommandArgument)];
			switch (e.CommandName)
		    {
			    case "Select":

				    BLUser user = new BLUser();

				    Session["User"] = user.getUser(Convert.ToInt32(row.Cells[0].Text));
				    Response.Redirect("~/UL/AdminUpdateSelectedUser");
				    break;
			    case "Status":

					break;
			    default:
				    return;
		    }
		}
    }
}