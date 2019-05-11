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
		public static DataSet getProducts()
		{
			return DALSelect.getProducts();
		}

		public static DataSet selectProduct(string productNumber)
		{
			return DALSelect.selectProduct(productNumber);
		}
	}
}