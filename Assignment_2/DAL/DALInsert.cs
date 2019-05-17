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
			return rows;
		}

	}
}