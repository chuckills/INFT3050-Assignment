using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace Assignment_2.DAL
{
	public class Select
	{
		/*public static DataSet getProducts()
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

		}*/

	}
}