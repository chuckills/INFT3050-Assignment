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

				adapter.Fill(productDataSet, "Products");
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

					adapter.Fill(productDataSet, "Product");
				}
			}

			return productDataSet;
		}

		public DataSet getUserData(string user, out bool result)
		{
			string cs = ConfigurationManager.ConnectionStrings["JerseySure"].ConnectionString;

			DataSet userDataSet = new DataSet();

			using (SqlConnection connection = new SqlConnection(cs))
			{
				SqlDataAdapter adapter = new SqlDataAdapter();
				using (SqlCommand command = new SqlCommand("usp_getUser", connection))
				{
					command.CommandType = CommandType.StoredProcedure;

					SqlParameter found = new SqlParameter();
					found.ParameterName = "@result";
					found.SqlDbType = SqlDbType.Int;
					found.Direction = ParameterDirection.Output;

					command.Parameters.Add(found);

					command.Parameters.AddWithValue("@user", user);

					adapter.SelectCommand = command;

					adapter.Fill(userDataSet, "User");

					result = Convert.ToBoolean(found.Value);
				}
			}

			return userDataSet;
		}

		public DataSet getTeams()
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
	}
}