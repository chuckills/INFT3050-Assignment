﻿using System;
using System.Collections.Generic;
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
            // Change Login Status and redirect to home page
            Session["LoginStatus"] = "LoggedOut";
            Session.Remove("UserName");
			Session.Remove("User");
			Session.Remove("Name");
			Response.Redirect("~/UL/");
        }
    }
}