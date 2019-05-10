using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2
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
                Response.Redirect("~/UL/Login.aspx");
            }
        }
    }
}