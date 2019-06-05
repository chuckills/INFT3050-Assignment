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
	        if (!IsPostBack)
	        {
		        BLUser user = Session["User"] as BLUser;

		        lblUserID.Text = user.userID.ToString();
		        tbxFirstName.Text = user.userFirstName;
		        tbxLastName.Text = user.userLastName;
		        tbxEmail.Text = user.userEmail;
		        tbxEmail2.Text = user.userEmail;
		        tbxPhone.Text = user.userPhone;
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

		        if (user.userActive)
		        {
			        btnActive.CssClass = "btn btn-danger";
			        btnActive.Text = "Active";
		        }
				else
		        {
			        btnActive.CssClass = "btn btn-outline-danger";
			        btnActive.Text = "Inactive";
		        }
			}
        }

        // Handles update of the selected product
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
	        if (IsValid)
	        {
		        BLUser currentUser = new BLUser
		        {
					userID = Convert.ToInt32(lblUserID.Text),
			        userFirstName = tbxFirstName.Text,
			        userLastName = tbxLastName.Text,
			        userEmail = tbxEmail.Text,
			        userPhone = tbxPhone.Text,
			        billAddress = BLAddress.fillAddress('B', tbxBillAddress.Text, tbxBillSuburb.Text, ddlBillState.SelectedValue, Convert.ToInt32(tbxBillPostCode.Text)),
			        postAddress = BLAddress.fillAddress('P', tbxPostAddress.Text, tbxPostSuburb.Text, ddlPostState.SelectedValue, Convert.ToInt32(tbxPostPostCode.Text)),
			        userAdmin = (Session["User"] as BLUser).userAdmin,
			        userActive = (Session["User"] as BLUser).userActive
				};

		        Session["User"] = currentUser;

		        BLUser.updateUser(currentUser);

				Session.Remove("User");

		        Response.Redirect("~/UL/AdminManageUserAccounts.aspx");
			}
        }

        // Handles update of the selected product
        protected void btnCancel_Click(object sender, EventArgs e)
        {
			Response.Redirect("~/UL/AdminManageUserAccounts.aspx");
        }

        protected void checkExists(object sender, ServerValidateEventArgs args)
        {
	        if (BLUser.checkUser(args.Value) == Convert.ToInt32(lblUserID.Text))
	        {
		        args.IsValid = true;
	        }
	        else
	        {
		        args.IsValid = BLUser.checkUser(args.Value) == 0;
	        }
        }

        protected void btnActive_Click(object sender, EventArgs e)
        {
	        BLUser user = Session["User"] as BLUser;

	        if (user.userActive)
	        {
		        btnActive.CssClass = "btn btn-outline-danger";
		        btnActive.Text = "Inactive";
		        user.userActive = false;
	        }
	        else
	        {
		        btnActive.CssClass = "btn btn-danger";
		        btnActive.Text = "Active";
		        user.userActive = true;
	        }

	        Session["User"] = user;

			BLUser.toggleActive(user.userID);
        }
	}
}