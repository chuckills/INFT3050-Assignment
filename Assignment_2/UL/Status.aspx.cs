using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class Status : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string status = Request.QueryString["status"].ToString();
            if (!string.IsNullOrEmpty(Request.QueryString["status"]))
            {
                if (Equals(status, "success"))
                {
                    StatusLabel.Text = "Success";
                    DescriptionLabel.Text = "User password successfully updated.";
                    ResultingButton.Text = "Return Home";
                    ResultingButton.PostBackUrl = "~/UL/Default";
                }
                else
                {
                    StatusLabel.Text = "Sorry...";
                    DescriptionLabel.Text = "User password was unable to be updated at this time.";
                    ResultingButton.Text = "Try Again";
                    ResultingButton.PostBackUrl = "~/UL/ChangePassword";
                }
            }
            else
            {
                StatusLabel.Text = "ERROR";
                DescriptionLabel.Text = "Something went wrong...";
                ResultingButton.Text = "Return Home";
                ResultingButton.PostBackUrl = "~/UL/Default";
            }
        }
    }
}