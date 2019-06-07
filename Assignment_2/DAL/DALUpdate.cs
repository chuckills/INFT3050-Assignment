using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Assignment_2.BL;

namespace Assignment_2.DAL
{
	/// <summary>
	/// DAL Layer class that handles Update operations on the database
	/// </summary>
	public class DALUpdate
	{
		/// <summary>
		/// Updates a user's details
		/// </summary>
		/// <param name="user"></param>
		/// <returns></returns>
		public static bool updateUser(BLUser user)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;
			int rows;

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlCommand command = new SqlCommand("usp_updateUser", connection)
				{
					CommandType = CommandType.StoredProcedure
				};

				command.Parameters.AddWithValue("@userID", user.userID);
				command.Parameters.AddWithValue("@userFirst", user.userFirstName);
				command.Parameters.AddWithValue("@userLast", user.userLastName);
				command.Parameters.AddWithValue("@userEmail", user.userEmail);
				command.Parameters.AddWithValue("@userPhone", user.userPhone);
				command.Parameters.AddWithValue("@userAdmin", user.userAdmin);
				command.Parameters.AddWithValue("@billStreet", user.billAddress.addStreet);
				command.Parameters.AddWithValue("@billSuburb", user.billAddress.addSuburb);
				command.Parameters.AddWithValue("@billState", user.billAddress.addState);
				command.Parameters.AddWithValue("@billZip", user.billAddress.addZip);
				command.Parameters.AddWithValue("@postStreet", user.postAddress.addStreet);
				command.Parameters.AddWithValue("@postSuburb", user.postAddress.addSuburb);
				command.Parameters.AddWithValue("@postState", user.postAddress.addState);
				command.Parameters.AddWithValue("@postZip", user.postAddress.addZip);

				connection.Open();

				rows = command.ExecuteNonQuery();
			}

			return rows > 0;
		}

		/// <summary>
		/// Updates a user's password
		/// </summary>
		/// <param name="user"></param>
		/// <param name="password"></param>
		/// <returns></returns>
        public static bool updateUserPassword(BLUser user, string password)
        {
            string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;
            int rows;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand("usp_changeUserPassword", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@username", user.userEmail);
                command.Parameters.AddWithValue("@password", password);

                connection.Open();

                rows = command.ExecuteNonQuery();
            }

            return rows > 0;
        }

		/// <summary>
		/// Updates a user's access status
		/// </summary>
		/// <param name="userID"></param>
		/// <returns></returns>
        public static bool toggleUserActive(int userID)
        {
	        string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;
	        int rows;

	        using (SqlConnection connection = new SqlConnection(cs))
	        {
		        SqlCommand command = new SqlCommand("usp_toggleUserActive", connection)
		        {
			        CommandType = CommandType.StoredProcedure
		        };

		        command.Parameters.AddWithValue("@userID", userID);

		        connection.Open();

		        rows = command.ExecuteNonQuery();
	        }

	        return rows > 0;
        }

		/// <summary>
		/// Updates a product's availability status
		/// </summary>
		/// <param name="prodNum"></param>
		/// <returns></returns>
        public static bool toggleProductActive(string prodNum)
        {
	        string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;
	        int rows;

	        using (SqlConnection connection = new SqlConnection(cs))
	        {
		        SqlCommand command = new SqlCommand("usp_toggleProductActive", connection)
		        {
			        CommandType = CommandType.StoredProcedure
		        };

		        command.Parameters.AddWithValue("@prodNum", prodNum);

		        connection.Open();

		        rows = command.ExecuteNonQuery();
	        }

	        return rows > 0;
        }

		/// <summary>
		/// Updates a shipping option's availability status
		/// </summary>
		/// <param name="shipID"></param>
		/// <returns></returns>
		public static bool toggleShipActive(int shipID)
        {
	        string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;
	        int rows;

	        using (SqlConnection connection = new SqlConnection(cs))
	        {
		        SqlCommand command = new SqlCommand("usp_toggleShipActive", connection)
		        {
			        CommandType = CommandType.StoredProcedure
		        };

		        command.Parameters.AddWithValue("@shipID", shipID);

		        connection.Open();

		        rows = command.ExecuteNonQuery();
	        }

	        return rows > 0;
		}

		/// <summary>
		/// Updates a product's details
		/// </summary>
		/// <param name="product"></param>
		/// <returns></returns>
        public static bool updateProduct(BLProduct product)
        {
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;
			int rows;

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlCommand command = new SqlCommand("usp_updateProduct", connection)
				{
					CommandType = CommandType.StoredProcedure
				};

				command.Parameters.AddWithValue("@prodNumber", product.prodNumber);
				command.Parameters.AddWithValue("@prodDescription", product.prodDescription);
				command.Parameters.AddWithValue("@prodPrice", product.prodPrice);
				command.Parameters.AddWithValue("@imgFront", product.image[0]);
				command.Parameters.AddWithValue("@imgBack", product.image[1]);

				DataTable stockLevel = new DataTable("StockLevel");
				stockLevel.Columns.Add("sizeID", typeof(string));
				stockLevel.Columns.Add("stkLevel", typeof(int));
				stockLevel.Rows.Add("S", product.stock[0]);
				stockLevel.Rows.Add("M", product.stock[1]);
				stockLevel.Rows.Add("L", product.stock[2]);
				stockLevel.Rows.Add("XL", product.stock[3]);
				stockLevel.Rows.Add("XXL", product.stock[4]);


				SqlParameter stock = new SqlParameter
				{
					ParameterName = "@stock",
					SqlDbType = SqlDbType.Structured,
					Value = stockLevel
				};
				command.Parameters.Add(stock);

				connection.Open();

				rows = command.ExecuteNonQuery();
			}

			return rows > 0;
        }
	}
}