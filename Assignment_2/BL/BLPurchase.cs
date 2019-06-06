using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using Assignment_2.DAL;
using INFT3050.PaymentSystem;

namespace Assignment_2.BL
{
	public class BLPurchase
	{
		public BLShoppingCart Cart { get; set; }
		public BLUser User { get; set; }
		public BLShipping Shipping { get; set; }
		public double Gst { get; set; }

		public BLPurchase(BLShoppingCart cart, BLUser user, BLShipping ship)
		{
			Cart = cart;
			User = user;
			Shipping = ship;
			Gst = (Cart.Amount + Shipping.Cost) / 11;
		}

		public TransactionResult processPurchase(string[] card)
		{
			IPaymentSystem paymentSystem = INFT3050PaymentFactory.Create();

			PaymentRequest pr = new PaymentRequest
			{
				Amount = Convert.ToDecimal(Cart.Amount + Shipping.Cost),
				CardName = card[0],
				CardNumber = card[1],
				CVC = Convert.ToInt32(card[2]),
				Expiry = Convert.ToDateTime("01-" + card[3]),
				Description = "BCD Group - JerseySure"
			};

			Task<PaymentResult> result = paymentSystem.MakePayment(pr);

			return result.Result.TransactionResult;
		}

		public static int storePurchase(BLPurchase purchase, string[] card)
		{
			DALInsert newPurchase = new DALInsert();
			return newPurchase.addNewPurchase(purchase, card);
		}

		public static string generateOrderSummary(string name, BLShoppingCart cart, BLShipping shipping)
		{
			string mailbody =
				"<p>"
				+ "To " + name + ","
				+ "</p>"
				+ "<p>"
				+ "Below is a summary of your recent order:"
				+ "</p>"
				+ "<div>"
				+ "<table style=\"border-collapse: collapse; border: 1px solid black;\">"
				+ "<tr>"
				+ "<th style=\"border: 1px solid black; padding: 2px 5px;\">Quantity</th>"
				+ "<th style=\"border: 1px solid black; padding: 2px 5px;\">Size</th>"
				+ "<th style=\"border: 1px solid black; padding: 2px 5px;\">Item</th>"
				+ "<th style=\"border: 1px solid black; padding: 2px 5px;\">Cost</th>"
				+ "</tr>";

			foreach (BLCartItem item in cart.Items)
			{
				mailbody +=
					"<tr>"
					+ "<td style=\"border: 1px solid black; padding: 2px 5px;\">" + item.Quantity + "</td>"
					+ "<td style=\"border: 1px solid black; padding: 2px 5px;\">" + item.Size + "</td>"
					+ "<td style=\"border: 1px solid black; padding: 2px 5px;\">"
					+ item.Product.playFirstName
					+ " "
					+ item.Product.playLastName
					+ " - "
					+ item.Product.prodDescription
					+ "</td>"
					+ "<td style=\"border: 1px solid black; padding: 2px 5px;\">$" + item.ItemTotal + "</td>"
					+ "</tr>";
			}

			mailbody +=
			"<tr>"
			+ "<td style=\"border: 1px solid black; padding: 2px 5px;\"></td>"
			+ "<th style=\"border: 1px solid black; padding: 2px 5px;\"></td>"
			+ "<td style=\"border: 1px solid black; padding: 2px 5px;\">Shipping - " + shipping.Method + "</td>"
			+ "<td style=\"border: 1px solid black; padding: 2px 5px;\">$" + shipping.Cost + "</td>"
			+ "</tr>"
			+ "<tr>"
			+ "<td style=\"border: 1px solid black; padding: 2px 5px;\"></td>"
			+ "<td style=\"border: 1px solid black; padding: 2px 5px;\"></td>"
			+ "<th style=\"border: 1px solid black; padding: 2px 5px;\">Total</td>"
			+ "<td style=\"border: 1px solid black; padding: 2px 5px;\">$" + (cart.Amount + shipping.Cost) + "</td>"
			+ "</tr>"
			+ "</table>"
			+ "</div>"
			+ "<br/>"
			+ "<p>"
			+ "Kind Regards,"
			+ "</p>"
			+ "<p>"
			+ "The JerseySure Team"
			+ "</p>";

			return mailbody;
		}
		
    }
}