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
		public DataSet getProducts()
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet productDataSet = new DataSet();

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlDataAdapter adapter = new SqlDataAdapter("usp_getProducts", connection);

				adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

				adapter.Fill(productDataSet);
			}

			return productDataSet;

		}

		public DataSet selectProduct(string productNumber)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet productDataSet = new DataSet();

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlDataAdapter adapter = new SqlDataAdapter();
				using (SqlCommand command = new SqlCommand("usp_selectProduct", connection))
				{
					command.CommandType = CommandType.StoredProcedure;
					command.Parameters.AddWithValue("@productNumber", productNumber);
					adapter.SelectCommand = command;

					adapter.Fill(productDataSet);
				}
			}

			return productDataSet;
		}

		public int login(string user, string pass, out bool status)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			int result;

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlCommand command = new SqlCommand("usp_userLogin", connection);
				
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddWithValue("@user", user);
				command.Parameters.AddWithValue("@pass", pass);

				SqlParameter admin = new SqlParameter();
				admin.ParameterName = "@status";
				admin.SqlDbType = SqlDbType.Bit;
				admin.Direction = ParameterDirection.Output;

				command.Parameters.Add(admin);

				SqlParameter userID = new SqlParameter();
				userID.ParameterName = "@result";
				userID.SqlDbType = SqlDbType.Int;
				userID.Direction = ParameterDirection.Output;

				command.Parameters.Add(userID);

				connection.Open();
				command.ExecuteNonQuery();

				status = (bool)admin.Value;
				result = (int)userID.Value;
			}

			return result;
		}

	}
}