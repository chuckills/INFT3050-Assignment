using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*SearchTextBox.Attributes.Add(
                "onkeypress", "button_click(this,'" + SubmitSearch + "')");*/
        }

        protected void SubmitSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Products.aspx");
        }
    }
}