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
	public class DALInsert
	{
		public int addNewUser(BLUser user)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;
			int rows;

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlCommand command = new SqlCommand("usp_addUser", connection);

				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.AddWithValue("@userFirst", user.userFirstName);
				command.Parameters.AddWithValue("@userLast", user.userLastName);
				command.Parameters.AddWithValue("@userEmail", user.userEmail);
				command.Parameters.AddWithValue("@userPhone", user.userPhone);
				command.Parameters.AddWithValue("@userPassword", user.userPassword);
				command.Parameters.AddWithValue("@userAdmin", user.userAdmin);
				command.Parameters.AddWithValue("@userActive", user.userActive);

				SqlParameter billStreet = new SqlParameter("@billStreet", SqlDbType.VarChar);
				SqlParameter billSuburb = new SqlParameter("@billSuburb", SqlDbType.VarChar);
				SqlParameter billState = new SqlParameter("@billState", SqlDbType.Char);
				SqlParameter billZip = new SqlParameter("@billZip", SqlDbType.Int);
				
				billStreet.Value = user.userAdmin ? "" : user.billAddress.addStreet;
				billSuburb.Value = user.userAdmin ? "" : user.billAddress.addSuburb;
				billState.Value = user.userAdmin ? "" : user.billAddress.addState;
				billZip.Value = user.userAdmin ? 0 : user.billAddress.addZip;

				command.Parameters.Add(billStreet);
				command.Parameters.Add(billSuburb);
				command.Parameters.Add(billState);
				command.Parameters.Add(billZip);

				command.Parameters.AddWithValue("@postStreet", user.postAddress.addStreet);
				command.Parameters.AddWithValue("@postSuburb", user.postAddress.addSuburb);
				command.Parameters.AddWithValue("@postState", user.postAddress.addState);
				command.Parameters.AddWithValue("@postZip", user.postAddress.addZip);

				connection.Open();

				rows = command.ExecuteNonQuery();
			}
			return rows;
		}

		public int addNewProduct(BLProduct product)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;
			int rows;

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlCommand command = new SqlCommand("usp_addProduct", connection);

				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.AddWithValue("@playFirst", product.playFirstName);
				command.Parameters.AddWithValue("@playLast", product.playLastName);
				command.Parameters.AddWithValue("@jerNumber", product.jerNumber);
				command.Parameters.AddWithValue("@teamID", product.teamID);
				command.Parameters.AddWithValue("@prodDescription", product.prodDescription);
				command.Parameters.AddWithValue("@prodPrice", product.prodPrice);
				command.Parameters.AddWithValue("@imgFront", product.image[0]);
				command.Parameters.AddWithValue("@imgBack", product.image[1]);
				command.Parameters.AddWithValue("@stkSmall", product.stock[0]);
				command.Parameters.AddWithValue("@stkMedium", product.stock[1]);
				command.Parameters.AddWithValue("@stkLarge", product.stock[2]);
				command.Parameters.AddWithValue("@stkXLge", product.stock[3]);
				command.Parameters.AddWithValue("@stkXXL", product.stock[4]);

				connection.Open();

				rows = command.ExecuteNonQuery();
			}
			return rows;
		}

		public int addNewPurchase(BLPurchase purchase, string[] card)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;
			int rows;

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlCommand command = new SqlCommand("usp_addNewOrder", connection);

				SqlParameter orderID = new SqlParameter
				{
					ParameterName = "@ordID",
					SqlDbType = SqlDbType.Int,
					Direction = ParameterDirection.Output
				};

				command.CommandType = CommandType.StoredProcedure;

				command.Parameters.Add(orderID);
				command.Parameters.AddWithValue("@ordSubTotal", purchase.Cart.Amount);
				command.Parameters.AddWithValue("@ordTotal", purchase.Cart.Amount + purchase.Shipping.Cost);
				command.Parameters.AddWithValue("@ordGST", (purchase.Cart.Amount + purchase.Shipping.Cost)/11);
				command.Parameters.AddWithValue("@ordPaid", true);
				command.Parameters.AddWithValue("@shipID", purchase.Shipping.Id);
				command.Parameters.AddWithValue("@userID", purchase.User.userID);
				command.Parameters.AddWithValue("@ccHolderName", card[0]);
				command.Parameters.AddWithValue("@ccNumber", card[1]);
				command.Parameters.AddWithValue("@ccExpiry", "1-" + card[3]);
				command.Parameters.AddWithValue("@ccType", card[4]);

				DataTable cartItems = new DataTable("CartItems");
				cartItems.Columns.Add("userID", typeof(int));
				cartItems.Columns.Add("prodNumber", typeof(string));
				cartItems.Columns.Add("sizeID", typeof(string));
				cartItems.Columns.Add("cartQuantity", typeof(int));
				cartItems.Columns.Add("cartUnitPrice", typeof(double));
				cartItems.Columns.Add("cartProductTotal", typeof(double));
				foreach (BLCartItem item in purchase.Cart.Items)
				{
					cartItems.Rows.Add(purchase.User.userID, item.Product.prodNumber, item.Size, item.Quantity, item.ItemTotal / item.Quantity, item.ItemTotal);
				}

				SqlParameter parameter = new SqlParameter
				{
					ParameterName = "@cartItems",
					SqlDbType = SqlDbType.Structured,
					Value = cartItems
				};
				command.Parameters.Add(parameter);

				connection.Open();
				
				rows = command.ExecuteNonQuery();
			}

			return rows;
		}

		public int addPostageOption(BLShipping option)
        {
            string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;
            int rows;

            using (SqlConnection connection = new SqlConnection(cs))
            {
                SqlCommand command = new SqlCommand("usp_addShipping", connection);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@type", option.Method);
                command.Parameters.AddWithValue("@description", option.Description);
                command.Parameters.AddWithValue("@days", option.Wait);
                command.Parameters.AddWithValue("@cost", option.Cost);

                connection.Open();

                rows = command.ExecuteNonQuery();
            }
            return rows;
        }
    }
}