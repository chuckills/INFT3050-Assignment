using System;
using System.Collections.Generic;
using System.Configuration;
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
			if (Request.IsSecureConnection)
			{
				// Page only accessible by admin
				if (Session["LoginStatus"].Equals("Admin"))
				{
					if (!IsPostBack)
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
						tbxPrice.Text = string.Format("{0:F2}", product.prodPrice);
						tbxSmall.Text = product.stock[0].ToString();
						tbxMedium.Text = product.stock[1].ToString();
						tbxLarge.Text = product.stock[2].ToString();
						tbxXLge.Text = product.stock[3].ToString();
						tbxXXL.Text = product.stock[4].ToString();
						if (product.prodActive)
						{
							RemoveProductButton.CssClass = "btn btn-danger";
							RemoveProductButton.Text = "Active";
						}
						else
						{
							RemoveProductButton.CssClass = "btn btn-outline-danger";
							RemoveProductButton.Text = "Inactive";
						}
					}
				}
				else
				{
					Response.Redirect("~/UL/ErrorPage/5");
				}
			}
			else
			{
				// Make connection secure if it isn't already
				string url = ConfigurationManager.AppSettings["SecurePath"] + "AdminUpdateSelectedItem";
				Response.Redirect(url);
			}
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
	        CustomValidator customVal = sender as CustomValidator;

	        FileUpload file = tblImage.FindControl(customVal.ControlToValidate) as FileUpload;

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
	        if (IsValid)
	        {
				BLProduct currentProduct = Session["Product"] as BLProduct;
				
				currentProduct.prodDescription = tbxDescription.Text;
				if (fuImgFront.HasFile)
					currentProduct.image[0] = fuImgFront.FileName;
				if (fuImgBack.HasFile)
					currentProduct.image[1] = fuImgBack.FileName;
				currentProduct.prodPrice = Convert.ToDouble(tbxPrice.Text);
				currentProduct.stock[0] = Convert.ToInt32(tbxSmall.Text);
				currentProduct.stock[1] = Convert.ToInt32(tbxMedium.Text);
				currentProduct.stock[2] = Convert.ToInt32(tbxLarge.Text);
				currentProduct.stock[3] = Convert.ToInt32(tbxXLge.Text);
				currentProduct.stock[4] = Convert.ToInt32(tbxXXL.Text);
				
				Session["Product"] = currentProduct;

		        BLProduct.updateProduct(currentProduct);

				Session.Remove("Product");

		        Response.Redirect("~/UL/AdminItemManagement");
			}
		}

        // Handles removal of the selected product
        protected void RemoveProductButton_Click(object sender, EventArgs e)
        {
	        BLProduct product = Session["Product"] as BLProduct;

			if (product.prodActive)
	        {
		        RemoveProductButton.CssClass = "btn btn-outline-danger";
		        RemoveProductButton.Text = "Inactive";
		        product.prodActive = false;
	        }
	        else
	        {
				RemoveProductButton.CssClass = "btn btn-danger";
				RemoveProductButton.Text = "Active";
				product.prodActive = true;
	        }

			Session["Product"] = product;

			BLProduct.toggleActive(product.prodNumber);
        }

		protected void btnCancel_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/UL/AdminItemManagement");
		}
	}
}