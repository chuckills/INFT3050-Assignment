using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_2.DAL;
using System.Data;

namespace Assignment_2.BL
{
	public class BLProduct
	{
		public string prodNumber { get; set; }
		public string prodDescription { get; set; }
		public double prodPrice { get; set; }
		public string teamID { get; set; }
		public string teamLocale { get; set; }
		public string teamName { get; set; }
		public string playFirstName { get; set; }
		public string playLastName { get; set; }
		public string[] image { get; set; }

		public static DataSet getProducts()
		{
			DALSelect products = new DALSelect();
			return products.getProducts();
		}

		public BLProduct selectProduct(string productNumber)
		{
			DALSelect product = new DALSelect();

			DataRow productData = product.selectProduct(productNumber).Tables["Product"].Rows[0];

			prodNumber = productData["prodNumber"].ToString();
			prodDescription = productData["prodDescription"].ToString();
			prodPrice = Convert.ToDouble(productData["prodPrice"]);
			teamID = productData["teamID"].ToString();
			teamLocale = productData["teamLocale"].ToString();
			teamName = productData["teamName"].ToString();
			playFirstName = productData["playFirstName"].ToString();
			playLastName = productData["playLastName"].ToString();
			image = new string[3];
			image[0] = productData["imgFront"].ToString();
			image[1] = productData["imgBack"].ToString();
			image[2] = productData["imgSmall"].ToString();

			return this;
		}
	}
}