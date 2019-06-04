using System;
using System.Collections.Generic;
using System.IO;
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
	        ddlTeam.DataSource = BLProduct.getTeams();
	        ddlTeam.DataBind();

			BLProduct product = Session["Product"] as BLProduct;
			tbxFirstName.Text = product.playFirstName;
			tbxLastName.Text = product.playLastName;
			tbxDescription.Text = product.prodDescription;
			ddlTeam.SelectedValue = product.teamID;
			imgFront.ImageUrl = "~/UL/Images/jerseys/" + product.image[0];
			imgBack.ImageUrl = "~/UL/Images/jerseys/" + product.image[1];
			tbxJerNumber.Text = product.jerNumber.ToString();
			tbxPrice.Text = string.Format("{0:.2f}", product.prodPrice);
			tbxSmall.Text = product.stock[0].ToString();
			tbxMedium.Text = product.stock[1].ToString();
			tbxLarge.Text = product.stock[2].ToString();
			tbxXLge.Text = product.stock[3].ToString();
			tbxXXL.Text = product.stock[4].ToString();
		}

        protected void addDefaultItem(object sender, EventArgs e)
        {
	        ddlTeam.Items.Insert(0, new ListItem("Select a team...", ""));
        }

        protected void uploadImageFile(FileUpload file)
        {
	        if (file.HasFile)
	        {
		        file.SaveAs(Server.MapPath("~/UL/Images/jerseys/") + file.FileName);
	        }
        }

        protected void checkValidImage(object sender, ServerValidateEventArgs args)
        {
	        CustomValidator csv = sender as CustomValidator;

	        FileUpload file = tblImage.FindControl(csv.ControlToValidate) as FileUpload;

	        args.IsValid = file.PostedFile.ContentLength > 0 && (file.PostedFile.ContentType.Contains("image/jpeg") || file.PostedFile.ContentType.Contains("image/png"));
        }

        protected void fileExists(object sender, ServerValidateEventArgs args)
        {
	        CustomValidator csv = sender as CustomValidator;

	        FileUpload file = tblImage.FindControl(csv.ControlToValidate) as FileUpload;

	        args.IsValid = !File.Exists(Server.MapPath("~/UL/Images/jerseys/") + file.FileName);
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