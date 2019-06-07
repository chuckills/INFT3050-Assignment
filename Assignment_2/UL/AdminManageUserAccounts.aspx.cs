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
				    if (!IsPostBack)
				    {
					    gvUsers.DataSource = BLUser.getUsers();
					    gvUsers.DataBind();
				    }
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

		protected void gvUsers_OnRowDataBound(object sender, GridViewRowEventArgs e)
	    {
		    if (e.Row.RowIndex >= 0)
		    {
			    DataRowView rowView = e.Row.DataItem as DataRowView;
				
				Button statusButton = e.Row.Cells[6].FindControl("btnStatus") as Button;

				if (Convert.ToBoolean(rowView["userActive"]))
			    {
				    statusButton.CssClass = "btn btn-danger";
				    statusButton.Text = "Activated";
			    }
			    else
			    {
				    statusButton.CssClass = "btn btn-outline-danger";
				    statusButton.Text = "Suspended";
			    }
		    }
	    }

	    protected void gvUsers_OnRowCommand(object sender, GridViewCommandEventArgs e)
	    {

		    GridViewRow row = gvUsers.Rows[Convert.ToInt32(e.CommandArgument)];

			BLUser user = new BLUser();
			user = user.getUser(Convert.ToInt32(row.Cells[0].Text));
			Session["User"] = user;

			switch (e.CommandName)
		    {
			    case "Select":
				    Response.Redirect("~/UL/AdminUpdateSelectedUser");
				    break;
			    case "Status":
				    Button statusButton = row.Cells[6].FindControl("btnStatus") as Button;
					BLUser.toggleActive(user.userID);

					if (statusButton.Text != "Activated")
					{
						statusButton.CssClass = "btn btn-danger";
						statusButton.Text = "Activated";
					}
					else
					{
						statusButton.CssClass = "btn btn-outline-danger";
						statusButton.Text = "Suspended";
					}
				    gvUsers.DataSource = BLUser.getUsers();
				    gvUsers.DataBind();
					break;
			    default:
				    return;
		    }
		}
    }
}