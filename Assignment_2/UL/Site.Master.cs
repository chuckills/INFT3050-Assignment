﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.BL;

namespace Assignment_2.UL
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
	        if (Session["Name"] != null)
	        {
		        lblUser.ForeColor = Session["LoginStatus"].ToString() == "Admin" ? Color.Red : Color.White;
		        lblUser.Text = "Hi, " + Session["Name"];
	        }
	        else
	        {
		        lblUser.Text = "";
	        }
        }

		protected void SubmitSearch_Click(object sender, EventArgs e)
        {
	        if (SearchTextBox.Text != "")
	        {
		        HttpContext.Current.Session["SearchString"] = SearchTextBox.Text;
		        Response.Redirect("~/UL/Products");
	        }
        }
    }
}