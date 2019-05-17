using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.BL;

namespace Assignment_2.UL
{
    public partial class AdminUpdateSelectedUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
	        BLUser user = Session["User"] as BLUser;
	        tbxFirstName.Text = user.userFirstName;
			tbxLastName.Text = user.userLastName;
			tbxEmail.Text = user.userEmail;
			tbxEmail2.Text = user.userEmail;
			tbxPhone.Text = user.userPhone;
			cbxActive.Checked = user.userActive;
			if (!user.userAdmin)
			{
				tbxBillAddress.Text = user.billAddress.addStreet;
				tbxBillSuburb.Text = user.billAddress.addSuburb;
				ddlBillState.SelectedValue = user.billAddress.addState;
				tbxBillPostCode.Text = user.billAddress.addZip.ToString();
			}
			else
			{
				tbxBillAddress.Enabled = false;
				tbxBillSuburb.Enabled = false;
				ddlBillState.Enabled = false;
				tbxBillPostCode.Enabled = false;
				rfvBillAddress.Enabled = false;
				rfvBillSuburb.Enabled = false;
				rfvBillState.Enabled = false;
				rfvBillPostCode.Enabled = false;
				rxvBillPostcode.Enabled = false;
			}
			tbxPostAddress.Text = user.postAddress.addStreet;
			tbxPostSuburb.Text = user.postAddress.addSuburb;
			ddlPostState.SelectedValue = user.postAddress.addState;
			tbxPostPostCode.Text = user.postAddress.addZip.ToString();
		}

        // Handles update of the selected product
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        // Handles update of the selected product
        protected void btnCancel_Click(object sender, EventArgs e)
        {
			Response.Redirect("~/UL/AdminManageUserAccounts.aspx");
        }
	}
}