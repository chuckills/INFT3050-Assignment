using Assignment_2.BL;
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
                else
                {
                    if (!IsPostBack)
                    {
                        BLUser user = Session["CurrentUser"] as BLUser;

                        tbxFirstName.Text = user.userFirstName;
                        tbxLastName.Text = user.userLastName;
                        tbxEmail.Text = user.userEmail;
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
	                        tblBill.Visible = false;
	                        tblBill.Enabled = false;
							tblPost.Visible = true;
                            rfvBillAddress.Enabled = false;
                            rfvBillSuburb.Enabled = false;
                            rfvBillState.Enabled = false;
                            rfvBillPostCode.Enabled = false;
                            rxvBillPostcode.Enabled = false;
                            cbxPostageSame.Visible = false;
						}

                        tbxPostAddress.Text = user.postAddress.addStreet;
                        tbxPostSuburb.Text = user.postAddress.addSuburb;
                        ddlPostState.SelectedValue = user.postAddress.addState;
                        tbxPostPostCode.Text = user.postAddress.addZip.ToString();
                    }
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
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
	            BLUser currentUser = Session["CurrentUser"] as BLUser;

				// Fills the hidden address section
				if (cbxPostageSame.Checked && !currentUser.userAdmin)
                {
                    tbxPostAddress.Text = tbxBillAddress.Text;
                    tbxPostSuburb.Text = tbxBillSuburb.Text;
                    ddlPostState.SelectedIndex = ddlBillState.SelectedIndex;
                    tbxPostPostCode.Text = tbxBillPostCode.Text;
                }

                string billPostCode = currentUser.userAdmin ? "0" : tbxBillPostCode.Text;

                BLUser user = new BLUser
                {
	                userID = currentUser.userID,
	                userFirstName = tbxFirstName.Text,
	                userLastName = tbxLastName.Text,
	                userEmail = tbxEmail.Text,
	                userPhone = tbxPhone.Text,
	                billAddress = BLAddress.fillAddress('B', tbxBillAddress.Text, tbxBillSuburb.Text, ddlBillState.SelectedValue, Convert.ToInt32(billPostCode)),
	                postAddress = BLAddress.fillAddress('P', tbxPostAddress.Text, tbxPostSuburb.Text, ddlPostState.SelectedValue, Convert.ToInt32(tbxPostPostCode.Text)),
	                userAdmin = currentUser.userAdmin,
	                userActive = currentUser.userActive
                };

                if (BLUser.updateUser(user))
                {
                    Session["Name"] = user.userFirstName;
                    Session["CurrentUser"] = user;
                    Session["UserName"] = user.userEmail;

                    Response.Redirect("~/UL/SuccessPage/4");
                }
                else
                {
                    Response.Redirect("~/UL/ErrorPage/9");
                }

                Response.Redirect("~/UL/AccountSettings");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/UL/Default");
        }

        protected void checkExists(object sender, ServerValidateEventArgs args)
        {
            if (BLUser.checkUser(args.Value) == Convert.ToInt32((Session["CurrentUser"] as BLUser).userID))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = BLUser.checkUser(args.Value) == 0;
            }
        }
    }
}