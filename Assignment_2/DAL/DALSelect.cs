using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Assignment_2.DAL
{
	public class DALSelect
	{
		public static DataSet getProducts()
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet productDataSet = new DataSet();

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlDataAdapter adapter = new SqlDataAdapter("usp_getProducts", connection);

				adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

				adapter.Fill(productDataSet, "Products");
			}

			return productDataSet;

		}

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
	}
}