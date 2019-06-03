using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.BL;

namespace Assignment_2.UL
{
    public partial class AdminPostageOptions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
	        lsvPostage.DataSource = BLShipping.getShippingTable();
	        lsvPostage.DataBind();
        }

        // Adds postage option to currently available options
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                //postageList.Add(tbxMethodName.Text + ", " + tbxDescription.Text + ", " + tbxAvgTime.Text + ", " + "$" + tbxPrice.Text);
                Response.Redirect("~/UL/AdminPostageOptions.aspx");
            }
        }

        protected void cbxActive_CheckedChanged(object sender, EventArgs e)
        {
			//BLShipping.toggleActive();
        }

		// Removes specified postage option from currently available
		protected void btnRemove_Click(object sender, EventArgs e)
		{
            /*CheckBox selected;

            // Iterates through all options and removes specified option
            ListViewDataItem currDataItem;
            if (lsvPostage.Items.Count > 0)
            {
                for (int i = lsvPostage.Items.Count - 1; i >= 0; i--)
                {
                    currDataItem = lsvPostage.Items[i];
                    selected = currDataItem.FindControl("cbxRemove") as CheckBox;
                    if (selected.Checked)
                    {
                        postageList.RemoveAt(lsvPostage.Items[i].DisplayIndex);
                    }
                }

                // Update session of postage options and redirect 
                Session["PostList"] = postageList;
                Response.Redirect("~/UL/AdminPostageOptions.aspx");
            }*/
        }
	}
}