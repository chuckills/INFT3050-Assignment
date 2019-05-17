using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.BL;

namespace Assignment_2.UL
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        // Submission of registration form
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (cbxPostageSame.Checked)
            {
                tbxPostAddress.Text = tbxBillAddress.Text;
                tbxPostSuburb.Text = tbxBillSuburb.Text;
                ddlPostState.SelectedIndex = ddlBillState.SelectedIndex;
                tbxPostPostCode.Text = tbxBillPostCode.Text;
            }

            // Redirect if form submission was valid
            if (IsValid)
            {
				BLUser newUser = new BLUser();
				
				newUser.userFirstName = tbxFirstName.Text;
				newUser.userLastName = tbxLastName.Text;
				newUser.userEmail = tbxEmail.Text;
				newUser.userPhone = tbxPhone.Text;
				newUser.billAddress = BLAddress.fillAddress('B', tbxBillAddress.Text, tbxBillSuburb.Text, ddlBillState.SelectedValue, Convert.ToInt32(tbxBillPostCode.Text));
				newUser.postAddress = BLAddress.fillAddress('P', tbxPostAddress.Text, tbxPostSuburb.Text, ddlPostState.SelectedValue, Convert.ToInt32(tbxPostPostCode.Text));
				newUser.userPassword = tbxPassword.Text;

				newUser.userAdmin = false;
				newUser.userActive = true;

				BLUser.addUser(newUser);
				
                Response.Redirect("~/UL/Login.aspx");
            }
        }
    }
}