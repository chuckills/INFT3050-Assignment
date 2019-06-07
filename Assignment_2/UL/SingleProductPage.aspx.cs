using Assignment_2.BL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_2.UL
{
    public partial class SingleProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
		{
			if (!Request.IsSecureConnection)
			{
				// Page not accessible on admin site
				if (!Session["LoginStatus"].Equals("Admin"))
				{
					BLProduct product = new BLProduct();
					BLShoppingCart cart = Session["Cart"] as BLShoppingCart;

					product = product.selectProduct(Session["productNumber"].ToString());

					Session["Product"] = product;

					lblTitle.Text = product.playFirstName + " " + product.playLastName + " " + product.teamLocale +
					                " " + product.teamName;
					lblDescription.Text = product.prodDescription;
					lblPrice.Text = string.Format("{0:C0}", product.prodPrice);

					imgFront.ImageUrl = "Images\\jerseys\\" + product.image[0];
					imgBack.ImageUrl = "Images\\jerseys\\" + product.image[1];

					if (cart != null)
					{
						if (cart.Items.Count > 0)
						{
							foreach (BLCartItem item in cart.Items)
							{
								if (item.Product.prodNumber == product.prodNumber)
								{
									switch (item.Size)
									{
										case "S":
											product.stock[0] -= item.Quantity;
											break;
										case "M":
											product.stock[1] -= item.Quantity;
											break;
										case "L":
											product.stock[2] -= item.Quantity;
											break;
										case "XL":
											product.stock[3] -= item.Quantity;
											break;
										case "XXL":
											product.stock[4] -= item.Quantity;
											break;
									}
								}
							}
						}
					}
					
					rblSizeOption.Items[0].Enabled = product.stock[0] > 0;
					rblSizeOption.Items[1].Enabled = product.stock[1] > 0;
					rblSizeOption.Items[2].Enabled = product.stock[2] > 0;
					rblSizeOption.Items[3].Enabled = product.stock[3] > 0;
					rblSizeOption.Items[4].Enabled = product.stock[4] > 0;

					btnAddToCart.Visible = tbxQuantity.Visible = rblSizeOption.Visible = product.stock.Sum() > 0;
					csvQuantity.Enabled = rfvQuantity.Enabled = rxvQuantity.Enabled = rfvSize.Enabled = product.stock.Sum() > 0;
					lblNoStock.Visible = product.stock.Sum() == 0;
				}
				else
				{
					Response.Redirect("~/UL/ErrorPage/5");
				}
			}
			else
			{
				// Make connection unsecured if it isn't already
				string url = ConfigurationManager.AppSettings["UnsecurePath"] + "SingleProductPage";
				Response.Redirect(url);

			}
		}

		// Adds current product to cart; gets shopping cart model from session and updates (then writes back to session).
		protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
	            BLProduct productData = Session["Product"] as BLProduct;

				BLShoppingCart cart = HttpContext.Current.Session["Cart"] as BLShoppingCart;

				bool existingItem = false;

				foreach (BLCartItem item in cart.Items)
				{
					if (item.Product.prodNumber == productData.prodNumber &&
					    item.Size == rblSizeOption.SelectedItem.Value)
					{
						item.Quantity += Convert.ToInt32(tbxQuantity.Text);
						existingItem = true;
						break;
					}
				}
				
				if(!existingItem)
					cart.AddCartItem(new BLCartItem(productData, rblSizeOption.SelectedItem.Value, Convert.ToInt32(tbxQuantity.Text)));

                Response.Redirect("~/UL/Cart");
            }
        }

		protected void checkStock(object sender, ServerValidateEventArgs args)
		{
			BLProduct productData = Session["Product"] as BLProduct;

			int remaining = 0;

			switch (rblSizeOption.SelectedValue)
			{
				case "S":
					args.IsValid = productData.stock[0] >= Convert.ToInt32(tbxQuantity.Text) && productData.stock[0] > 0;
					remaining = productData.stock[0];
					break;
				case "M":
					args.IsValid = productData.stock[1] >= Convert.ToInt32(tbxQuantity.Text) && productData.stock[1] > 0;
					remaining = productData.stock[1];
					break;
				case "L":
					args.IsValid = productData.stock[2] >= Convert.ToInt32(tbxQuantity.Text) && productData.stock[2] > 0;
					remaining = productData.stock[2];
					break;
				case "XL":
					args.IsValid = productData.stock[3] >= Convert.ToInt32(tbxQuantity.Text) && productData.stock[3] > 0;
					remaining = productData.stock[3];
					break;
				case "XXL":
					args.IsValid = productData.stock[4] >= Convert.ToInt32(tbxQuantity.Text) && productData.stock[4] > 0;
					remaining = productData.stock[4];
					break;
			}
			csvQuantity.ErrorMessage = "Only " + remaining + " left";
		}

		protected void rblSizeOption_SelectedIndexChanged(object sender, EventArgs e)
		{
			tbxQuantity.Enabled = rblSizeOption.SelectedItem != null;
		}
	}
}