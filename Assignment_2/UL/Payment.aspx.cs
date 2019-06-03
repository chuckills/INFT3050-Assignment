using Assignment_2.BL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using INFT3050.PaymentSystem;

namespace Assignment_2.UL
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
	        if (!IsPostBack)
	        {
		        double amount = Convert.ToDouble((Session["Cart"] as BLShoppingCart).Amount);

		        lblAmount.Text = string.Format("{0:C}", amount);

		        ddlShipping.DataSource = BLShipping.getShippingMethods();
		        ddlShipping.DataBind();

		        BLUser user = Session["CurrentUser"] as BLUser;

		        lblFirst.Text = user.userFirstName;
		        lblLast.Text = user.userLastName;
		        lblBillStreet.Text = user.billAddress.addStreet;
		        lblBillSuburb.Text = user.billAddress.addSuburb;
		        lblBillState.Text = user.billAddress.addState;
		        lblBillZip.Text = user.billAddress.addZip.ToString();
		        lblPostStreet.Text = user.postAddress.addStreet;
		        lblPostSuburb.Text = user.postAddress.addSuburb;
		        lblPostState.Text = user.postAddress.addState;
		        lblPostZip.Text = user.postAddress.addZip.ToString();
	        }
        }

        protected void addDefaultItem(object sender, EventArgs e)
        {
	        ddlShipping.Items.Insert(0, new ListItem("Select a shipping method...", ""));
        }

		protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
				BLPurchase purchase = new BLPurchase(Session["Cart"] as BLShoppingCart, Session["CurrentUser"] as BLUser, Session["Shipping"] as BLShipping);

				string[] card = {tbxCardName.Text, tbxCardNumber.Text, tbxCSC.Text, tbxExpiration.Text};

				TransactionResult result = purchase.processPurchase(card);

				Session["Result"] = result;

				switch (result)
				{
					case TransactionResult.Approved:

						int rows = BLPurchase.storePurchase(purchase, card);

						Session.Remove("Cart");
						Session["Cart"] = new BLShoppingCart();
						Response.Redirect("~/UL/PaymentConfirmation.aspx");
						break;
					case TransactionResult.Declined:
					case TransactionResult.InvalidCard:
					case TransactionResult.InvalidExpiry:
					case TransactionResult.ConnectionFailure:
						Response.Redirect("~/UL/PaymentResponse.aspx");
						break;
				}
			}
        }

		protected void checkCardNumber(object sender, ServerValidateEventArgs args)
		{
			switch (rblCardType.SelectedValue)
			{
				case "MCARD":
				case "VISA":
					args.IsValid = args.Value.Length == 16 && args.Value.All(char.IsDigit);
					break;
				case "AMEX":
					args.IsValid = args.Value.Length == 15 && args.Value.All(char.IsDigit);
					break;
				case "DINR":
					args.IsValid = args.Value.Length == 14 && args.Value.All(char.IsDigit);
					break;
			}
		}

		protected void ddlShipping_SelectedIndexChanged(object sender, EventArgs e)
		{
			BLShipping shipping = new BLShipping();
			double amount;

			if (ddlShipping.SelectedValue != "")
			{
				shipping = shipping.getShipping(Convert.ToInt32(ddlShipping.SelectedValue));
				Session["Shipping"] = shipping;
				amount = Convert.ToDouble((Session["Cart"] as BLShoppingCart).Amount) + shipping.Cost;
			}
			else
				amount = Convert.ToDouble((Session["Cart"] as BLShoppingCart).Amount);

			lblAmount.Text = string.Format("{0:C}", amount);
		}
	}
}