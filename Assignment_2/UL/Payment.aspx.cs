﻿using Assignment_2.BL;
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
	        double amount = Convert.ToDouble((Session["Cart"] as BLShoppingCart).Amount);

	        lblAmount.Text = string.Format("{0:C}", amount);
        }
		
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
	            IPaymentSystem paymentSystem = INFT3050PaymentFactory.Create();

	            PaymentRequest pr = new PaymentRequest
	            {
		            Amount = Convert.ToDecimal((Session["Cart"] as BLShoppingCart).Amount),
		            CardNumber = tbxCardNumber.Text,
		            CardName = tbxCardName.Text,
		            CVC = Convert.ToInt32(tbxCSC.Text),
		            Expiry = Convert.ToDateTime("01-" + tbxExpiration.Text),
		            Description = "BCD Group - JerseySure"
	            };

				Task<PaymentResult> result = paymentSystem.MakePayment(pr);

				switch (result.Result.TransactionResult)
				{
					case (TransactionResult.Approved):
						Session.Remove("Cart");
						Session["Cart"] = new BLShoppingCart();
						Session["Result"] = TransactionResult.Approved;
						Response.Redirect("~/UL/PaymentConfirmation.aspx");
						break;
					case (TransactionResult.Declined):
						Session["Result"] = TransactionResult.Declined;
						Response.Redirect("~/UL/PaymentResponse.aspx");
						break;
					case (TransactionResult.InvalidCard):
						Session["Result"] = TransactionResult.InvalidCard;
						Response.Redirect("~/UL/PaymentResponse.aspx");
						break;
					case (TransactionResult.InvalidExpiry):
						Session["Result"] = TransactionResult.InvalidExpiry;
						Response.Redirect("~/UL/PaymentResponse.aspx");
						break;
					case (TransactionResult.ConnectionFailure):
						Session["Result"] = TransactionResult.ConnectionFailure;
						Response.Redirect("~/UL/PaymentResponse.aspx");
						break;
				}
			}
        }
    }
}