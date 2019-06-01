using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Assignment_2.DAL;

namespace Assignment_2.BL
{
	public class BLShipping
	{
		public int Id { get; set; }
		public string Method { get; set; }
		public double Cost { get; set; }
		public int Wait { get; set; }

		public BLShipping(int id, string method, double cost, int wait)
		{
			Id = id;
			Method = method;
			Cost = cost;
			Wait = wait;
		}

		public static DataSet getShippingMethods()
		{
			return DALSelect.getShippingOptions();
		}
	}
}