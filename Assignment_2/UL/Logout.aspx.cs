using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
		{
			if (!Request.IsSecureConnection)
			{
				// Page only accessible if not account has been logged in
				if (!Session["LoginStatus"].Equals("LoggedOut"))
				{
					// Change Login Status and redirect to home page
					Session.Remove("UserName");
					Session.Remove("User");
					Session.Remove("Name");
                    Session["LoginStatus"] = "LoggedOut";
                    Response.Redirect("~/UL/Default");
				}
				else
				{
					Response.Redirect("~/UL/ErrorPage/0");
				}
			}
			else
			{
				// Make connection unsecured if it isn't already
				string url = ConfigurationManager.AppSettings["UnsecurePath"] + "Logout";
				Response.Redirect(url);
			}
		}
    }
}