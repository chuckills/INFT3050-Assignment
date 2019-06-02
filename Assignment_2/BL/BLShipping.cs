﻿using System;
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

		public static DataSet getShippingMethods()
		{
			return DALSelect.getShippingOptions();
		}

		public BLShipping getShipping(int shipID)
		{
			DataRow shipping =  DALSelect.getShippingDetails(shipID);
			Id = Convert.ToInt32(shipping["shipID"]);
			Method = shipping["shipType"].ToString();
			Cost = Convert.ToDouble(shipping["shipCost"]);
			Wait = Convert.ToInt32(shipping["shipDays"]);

			return this;
		}
	}
}