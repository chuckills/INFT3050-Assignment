using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_2.DAL;
using System.Data;

/// <summary>
/// ADO.net model representing a product.
/// </summary>

namespace Assignment_2.BL
{
	public class BLProduct
	{
		public string prodNumber { get; set; }
		public string prodDescription { get; set; }
		public double prodPrice { get; set; }
		public bool prodActive { get; set; }
		public string teamID { get; set; }
		public string teamLocale { get; set; }
		public string teamName { get; set; }
		public string playFirstName { get; set; }
		public string playLastName { get; set; }
		public int jerNumber { get; set; }
		public string[] image { get; set; }
		public int[] stock { get; set; }

        /// <summary>
        /// Returns product dataset if login status is admin.
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
		public static DataSet getProducts(bool admin)
		{
			return DALSelect.getProducts(admin);
		}

        /// <summary>
        /// Returns product dataset according to query string.
        /// </summary>
        /// <param name="search"></param>
        /// <returns></returns>
        public static DataSet getProductsSearch(string search)
        {
            return DALSelect.getProductsSearch(search);
        }

        /// <summary>
        /// Returns dataset of alll NBA team that a jersey can be defined under.
        /// </summary>
        /// <returns></returns>
		public static DataSet getTeams()
		{
			return DALSelect.getTeams();
		}

        /// <summary>
        /// Returns ADO.model representation of certain product specified by the product number.
        /// </summary>
        /// <param name="productNumber"></param>
        /// <returns></returns>
		public BLProduct selectProduct(string productNumber)
		{
			DataRow productData = DALSelect.selectProduct(productNumber);

			prodNumber = productData["prodNumber"].ToString();
			prodDescription = productData["prodDescription"].ToString();
			prodPrice = Convert.ToDouble(productData["prodPrice"]);
			prodActive = Convert.ToBoolean(productData["prodActive"]);
			teamID = productData["teamID"].ToString();
			teamLocale = productData["teamLocale"].ToString();
			teamName = productData["teamName"].ToString();
			playFirstName = productData["playFirstName"].ToString();
			playLastName = productData["playLastName"].ToString();
			jerNumber = Convert.ToInt32(productData["jerNumber"]);
			image = new string[2];
			image[0] = productData["imgFront"].ToString();
			image[1] = productData["imgBack"].ToString();
			stock = DALSelect.getStock(productNumber);

			return this;
		}

        /// <summary>
        /// Adds a product to the database and returns success status.
        /// </summary>
        /// <param name="newProduct"></param>
        /// <returns></returns>
		public static bool addProduct(BLProduct newProduct)
		{
			DALInsert product = new DALInsert();

			int rows = product.addNewProduct(newProduct);

			return rows > 0;
		}

        /// <summary>
        /// Activates or deactivates specified product by toggling current status.
        /// </summary>
        /// <param name="prodNum"></param>
		public static void toggleActive(string prodNum)
		{
			DALUpdate.toggleProductActive(prodNum);
		}

        /// <summary>
        /// Updates a specified product according to the specifics of the ADO.net model
        /// provided.
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
		public static bool updateProduct(BLProduct product)
		{
			return DALUpdate.updateProduct(product);
		}
	}
}