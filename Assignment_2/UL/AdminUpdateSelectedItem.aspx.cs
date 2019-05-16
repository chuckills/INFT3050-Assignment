using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Assignment_2.BL;

namespace Assignment_2.UL
{
    public partial class AdminUpdateSelectedItem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
			BLProduct product = Session["Product"] as BLProduct;
			tbxFirstName.Text = product.playFirstName;
			tbxLastName.Text = product.playLastName;
			tbxDescription.Text = product.prodDescription;
			ddlTeam.SelectedValue = product.teamID;
			tbxJerNumber.Text = product.jerNumber.ToString();
			tbxImgFront.Text = product.image[0];
			tbxImgBack.Text = product.image[1];
			tbxPrice.Text = string.Format("{0:C}", product.prodPrice);
        }

        // Handles update of the selected product
        protected void UpdateProductButton_Click(object sender, EventArgs e)
        {

        }

        // Handles removal of the selected product
        protected void RemoveProductButton_Click(object sender, EventArgs e)
        {

        }
    }
}