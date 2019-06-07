using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Assignment_2.BL;

namespace Assignment_2.DAL
{
	/// <summary>
	/// DAL Layer class to handle Select operations in the database
	/// </summary>
	public class DALSelect
	{
		/// <summary>
		/// Selects all the product in the database but filters unavailable products for non-admins
		/// </summary>
		/// <param name="admin"></param>
		/// <returns></returns>
		public static DataSet getProducts(bool admin)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet productDataSet = new DataSet();

			string commandString = admin ? "usp_getAllProducts" : "usp_getProducts";

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlDataAdapter adapter = new SqlDataAdapter(commandString, connection);

				adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

				adapter.Fill(productDataSet, "Products");
			}

			return productDataSet;

		}

		/// <summary>
		/// Selects products that match the search criteria
		/// </summary>
		/// <param name="search"></param>
		/// <returns></returns>
		public static DataSet getProductsSearch(string search)
        {
            string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

            DataSet productDataSet = new DataSet();

            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("usp_getProductsSearch", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@search", search);

                adapter.SelectCommand = command;

                adapter.Fill(productDataSet, "Products");
            }

            return productDataSet;
        }

		/// <summary>
		/// Selects a single product
		/// </summary>
		/// <param name="productNumber"></param>
		/// <returns></returns>
		public static DataRow selectProduct(string productNumber)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet productDataSet = new DataSet();

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlDataAdapter adapter = new SqlDataAdapter();
				SqlCommand command = new SqlCommand("usp_selectProduct", connection);
				
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@productNumber", productNumber);
				adapter.SelectCommand = command;

				adapter.Fill(productDataSet, "Product");
				
			}

			return productDataSet.Tables["Product"].Rows[0];
		}

		/// <summary>
		/// Selects the quantity of product sizes
		/// </summary>
		/// <param name="productNumber"></param>
		/// <returns></returns>
		public static int[] getStock(string productNumber)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet stockDataSet = new DataSet();

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlDataAdapter adapter = new SqlDataAdapter();
				SqlCommand command = new SqlCommand("usp_getProductStock", connection);

				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@prodNumber", productNumber);
				adapter.SelectCommand = command;

				adapter.Fill(stockDataSet, "Stock");
			}

			DataTable stockTable = stockDataSet.Tables["Stock"];

			int[] stock = new int[5];

			for (int i = 0; i < stockTable.Rows.Count; i++) //DataRow row in stockTable.Rows)
			{
				stock[i] = Convert.ToInt32(stockTable.Rows[i]["stkLevel"]);
			}

			return stock;

		}

		/// <summary>
		/// Selects a user by username and checks for existing occurrence
		/// </summary>
		/// <param name="user"></param>
		/// <param name="result"></param>
		/// <returns></returns>
		public DataRow getUserData(string user, out bool result)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet userDataSet = new DataSet();

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlDataAdapter adapter = new SqlDataAdapter();
				SqlCommand command = new SqlCommand("usp_getUser", connection);
				
				command.CommandType = CommandType.StoredProcedure;

				SqlParameter found = new SqlParameter
				{
					ParameterName = "@result",
					SqlDbType = SqlDbType.Int,
					Direction = ParameterDirection.Output
				};

				command.Parameters.Add(found);
				command.Parameters.AddWithValue("@user", user);

				adapter.SelectCommand = command;

				adapter.Fill(userDataSet, "User");

				result = Convert.ToBoolean(found.Value);
				
			}

			if(result)
				return userDataSet.Tables["User"].Rows[0];
			
			return null;
			
		}

		/// <summary>
		/// Selects all users
		/// </summary>
		/// <returns></returns>
		public DataSet getUsers()
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet teamsDataSet = new DataSet();

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlDataAdapter adapter = new SqlDataAdapter("usp_getUsers", connection);

				adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
				
				adapter.Fill(teamsDataSet, "Users");
			}

			return teamsDataSet;
		}


		/// <summary>
		/// Selects a user by userID
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>
		public DataRow getSingleUser(int userID)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet userDataSet = new DataSet();

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlDataAdapter adapter = new SqlDataAdapter();
				SqlCommand command = new SqlCommand("usp_getSingleUser", connection);

				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@user", userID);
				adapter.SelectCommand = command;

				adapter.Fill(userDataSet, "User");

			}

			return userDataSet.Tables["User"].Rows[0];
		}

		/// <summary>
		/// Selects a user by username
		/// </summary>
		/// <param name="email"></param>
		/// <returns></returns>
        public DataRow getUserByEmail(string email)
        {
            string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

            DataSet userDataSet = new DataSet();

            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("usp_getUserByEmail", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@email", email);
                adapter.SelectCommand = command;

                adapter.Fill(userDataSet, "User");

            }

            return userDataSet.Tables["User"].Rows[0];
        }

		/// <summary>
		/// Selects a formatted shipping option list
		/// </summary>
		/// <returns></returns>
        public static DataSet getShippingOptions()
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet shipDataSet = new DataSet();

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlDataAdapter adapter = new SqlDataAdapter("usp_getShipping", connection);

				adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

				adapter.Fill(shipDataSet, "Shipping");
			}

			return shipDataSet;
		}

		/// <summary>
		/// Selects all shipping options in a table
		/// </summary>
		/// <returns></returns>
        public static DataSet getShippingTable()
        {
	        string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

	        DataSet shipDataSet = new DataSet();

	        using (SqlConnection connection = new SqlConnection(cs))
	        {
		        SqlDataAdapter adapter = new SqlDataAdapter("usp_getShippingTable", connection);

		        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

		        adapter.Fill(shipDataSet, "Shipping");
	        }

	        return shipDataSet;
        }

		/// <summary>
		/// Selects a single shipping option
		/// </summary>
		/// <param name="shipID"></param>
		/// <returns></returns>
		public static DataRow getShippingDetails(int shipID)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet userDataSet = new DataSet();

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlDataAdapter adapter = new SqlDataAdapter();
				SqlCommand command = new SqlCommand("usp_getShipDetails", connection);

				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@shipID", shipID);
				adapter.SelectCommand = command;

				adapter.Fill(userDataSet, "Shipping");

			}

			return userDataSet.Tables["Shipping"].Rows[0];
		}

		/// <summary>
		/// Selects all teams from the database
		/// </summary>
		/// <returns></returns>
		public static DataSet getTeams()
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet teamsDataSet = new DataSet();

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlDataAdapter adapter = new SqlDataAdapter("usp_getTeams", connection);

				adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

				adapter.Fill(teamsDataSet, "Teams");
			}

			return teamsDataSet;
		}

		/// <summary>
		/// Selects a user address
		/// </summary>
		/// <param name="user"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		public DataRow getAddress(int user, char type)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet addressDataSet = new DataSet();

			using (SqlConnection connection = new SqlConnection(cs))
			{

				SqlDataAdapter adapter = new SqlDataAdapter();
				SqlCommand command = new SqlCommand("usp_getAddress", connection);

				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@user", user);
				command.Parameters.AddWithValue("@type", type);

				adapter.SelectCommand = command;

				adapter.Fill(addressDataSet, "Address");
			}

			return addressDataSet.Tables["Address"].Rows[0];
		}

		/// <summary>
		/// Selects all orders made by a user
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
        public static DataSet getUserOrders(BLUser user)
        {
            string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

            DataSet orderDataSet = new DataSet();

            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                SqlCommand command = new SqlCommand("usp_getUserOrders", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@userID", user.userID);

                adapter.SelectCommand = command;

                adapter.Fill(orderDataSet, "Address");
            }

            return orderDataSet;
        }

		/// <summary>
		/// Selects a single order made by a user
		/// </summary>
		/// <param name="orderID"></param>
		/// <returns></returns>
        public static DataRow getOrder(int orderID)
        {
	        string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

	        DataSet userDataSet = new DataSet();

	        using (SqlConnection connection = new SqlConnection(cs))
	        {
		        SqlDataAdapter adapter = new SqlDataAdapter();
		        SqlCommand command = new SqlCommand("usp_getSingleOrder", connection);

		        command.CommandType = CommandType.StoredProcedure;
		        command.Parameters.AddWithValue("@orderID", orderID);
		        adapter.SelectCommand = command;

		        adapter.Fill(userDataSet, "Order");

	        }

	        return userDataSet.Tables["Order"].Rows[0];
		}

		/// <summary>
		/// Selects all items on an order
		/// </summary>
		/// <param name="orderID"></param>
		/// <returns></returns>
        public static DataTable getOrderItems(int orderID)
        {
	        string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

	        DataSet userDataSet = new DataSet();

	        using (SqlConnection connection = new SqlConnection(cs))
	        {
		        SqlDataAdapter adapter = new SqlDataAdapter();
		        SqlCommand command = new SqlCommand("usp_getOrderItems", connection);

		        command.CommandType = CommandType.StoredProcedure;
		        command.Parameters.AddWithValue("@orderID", orderID);
		        adapter.SelectCommand = command;

		        adapter.Fill(userDataSet, "Items");

	        }

	        return userDataSet.Tables["Items"];
        }
	}
}