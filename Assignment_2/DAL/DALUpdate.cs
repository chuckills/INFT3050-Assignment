﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Assignment_2.BL;

namespace Assignment_2.DAL
{
	public class DALUpdate
	{

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

        public static int updateProduct(BLProduct product)
        {


	        return 0;
        }

	}
}