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
    public partial class AdminItemManagementInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void addDefaultItem(object sender, EventArgs e)
        {
	        ddlTeam.Items.Insert(0, new ListItem("Select a team...", ""));
        }

		protected void AddProductButton_Click(object sender, EventArgs e)
		{
			if (IsValid)
			{
				BLProduct newProduct = new BLProduct
				{
					playFirstName = tbxFirstName.Text,
					playLastName = tbxLastName.Text,
					teamID = ddlTeam.SelectedValue,
					prodDescription = tbxDescription.Text,
					prodPrice = Convert.ToDouble(tbxPrice.Text),
					jerNumber = Convert.ToInt32(tbxJerNumber.Text),
					image = new []{fuImgFront.FileName, fuImgBack.FileName},
					stock = new[]
					{
						tbxSmall.Text == "" ? 0 : Convert.ToInt32(tbxSmall.Text),
						tbxMedium.Text == "" ? 0 : Convert.ToInt32(tbxMedium.Text),
						tbxLarge.Text == "" ? 0 : Convert.ToInt32(tbxLarge.Text),
						tbxXLge.Text == "" ? 0 : Convert.ToInt32(tbxXLge.Text),
						tbxXXL.Text == "" ? 0 : Convert.ToInt32(tbxXXL.Text)
					}
			};

				uploadImageFile(fuImgFront);
				uploadImageFile(fuImgBack);

				if (BLProduct.addProduct(newProduct))
					Response.Redirect("~/UL/AdminItemManagement.aspx");
				else
					Response.Redirect("~/UL/AdminItemManagementInsert.aspx");
			}
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
	}
}