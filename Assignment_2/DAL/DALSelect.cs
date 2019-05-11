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

				adapter.Fill(productDataSet);
			}

			return productDataSet;

		}

		public static DataSet selectProduct(string productNumber)
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

				adapter.Fill(productDataSet);
			}

			return productDataSet;
		}

	}
}