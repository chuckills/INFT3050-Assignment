using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class Main : System.Web.UI.Page
    {
	    protected void Page_Load(object sender, EventArgs e)
	    {
		    if (Request.IsSecureConnection)
		    {
			    // Make connection unsecured if it isn't already
			    string url = ConfigurationManager.AppSettings["UnsecurePath"] + "Default";
			    Response.Redirect(url);
		    }
	    }
    }
}