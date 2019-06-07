using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class AccountSettings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
	        if (Request.IsSecureConnection)
	        {
		        // Must be logged in to access
		        if (Session["LoginStatus"].Equals("LoggedOut"))
		        {
			        Response.Redirect("~/UL/ErrorPage/0");
		        }
	        }
	        else
            {
	            // Make connection secure if it isn't already
	            string url = ConfigurationManager.AppSettings["SecurePath"] + "AccountSettings";
	            Response.Redirect(url);
            }
		}

        // Makes Postal Address fields visible when unchecked
        protected void cbxPostageSame_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxPostageSame.Checked)
            {
                tblPost.Visible = false;
            }
            else
            {
                tblPost.Visible = true;
            }
        }

        // Performs the submission of updated account settings
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Fills the hidden address section
            if (cbxPostageSame.Checked)
            {
                tbxPostAddress.Text = tbxBillAddress.Text;
                tbxPostSuburb.Text = tbxBillSuburb.Text;
                ddlPostState.SelectedIndex = ddlBillState.SelectedIndex;
                tbxPostPostCode.Text = tbxBillPostCode.Text;
            }

            if (IsValid)
            {
                lblUpdate.Text = "Your details have been updated";                
            }

            // resets fields to default once form is submitted
            tbxFirstName.Text = "";
            tbxLastName.Text = "";
            tbxEmail.Text = "";
            tbxEmail2.Text = "";
            tbxPhone.Text = "";
            tbxBillAddress.Text = "";
            tbxBillSuburb.Text = "";
            ddlBillState.SelectedIndex = 0;
            tbxBillPostCode.Text = "";
            tbxPostAddress.Text = "";
            tbxPostSuburb.Text = "";
            ddlPostState.SelectedIndex = 0;
            tbxPostPostCode.Text = "";
            tbxUsername.Text = "";

        }
    }
}