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
		public DataSet getProducts()
		{
			DALSelect products = new DALSelect();
			return products.getProducts();
		}

		public DataSet selectProduct(string productNumber)
		{
			DALSelect product = new DALSelect();
			return product.selectProduct(productNumber);
		}
	}
}