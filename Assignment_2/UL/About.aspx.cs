using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
	        if (!Request.IsSecureConnection)
	        {
		        // Not a page featured in the Admin site
		        if (Session["LoginStatus"].Equals("Admin"))
		        {
			        Response.Redirect("~/UL/ErrorPage/5");
		        }
			}
			else
	        {
				// Make connection unsecured if it isn't already
				string url = ConfigurationManager.AppSettings["UnsecurePath"] + "About";
		        Response.Redirect(url);

	        }

		}
    }
}