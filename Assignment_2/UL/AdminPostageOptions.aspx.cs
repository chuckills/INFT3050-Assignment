using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class AdminPostageOptions : System.Web.UI.Page
    {
        private List<String> postageList;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Read in postage options from session
            postageList = Session["PostList"] as List<String>;
            if (postageList == null)
            {
                // Initialise postage options if none are stored in the session
                postageList = new List<String>()
                {
                    "Regular, Regular mail delivery, 7, $10.00",
                    "Express, Express post mail delivery, 3, $15.00",
                    "Courier, Overnight Delivery, 1, $20.00",
                    "The Flash, Fast as you like, 0, $99.99"
                };
                // Put new postage options in the session
                Session["PostList"] = postageList;
            }
        }

        // Adds postage option to currently available options
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                postageList.Add(tbxMethodName.Text + ", " + tbxDescription.Text + ", " + tbxAvgTime.Text + ", " + "$" + tbxPrice.Text);
                Response.Redirect("~/UL/AdminPostageOptions.aspx");
            }
        }

        // Returns postage options
        public List<String> getPostageOptions()
        {
            return postageList;
        }

        // Removes specified postage option from currently available
        protected void btnRemove_Click(object sender, EventArgs e)
        {
            CheckBox selected;

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
            }
        }
    }
}