﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2
{
    public partial class AdminManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Redirect to appropriate update page
        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/AdminUpdateSelectedItem.aspx");
        }
    }
}