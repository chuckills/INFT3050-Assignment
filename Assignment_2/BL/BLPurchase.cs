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
	}
}