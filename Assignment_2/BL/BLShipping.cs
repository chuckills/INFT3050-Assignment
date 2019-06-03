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
        public string Description { get; set; }
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
            Description = shipping["shipDescription"].ToString();
			Cost = Convert.ToDouble(shipping["shipCost"]);
			Wait = Convert.ToInt32(shipping["shipDays"]);

			return this;
		}

        public static bool addShipping(BLShipping shipping)
        {
            DALInsert shippingOption = new DALInsert();

            return (shippingOption.addPostageOption(shipping) > 0);
        }

		public static DataSet getShippingTable()
		{
			return DALSelect.getShippingTable();
		}

		public static void toggleActive(int shipID)
		{
			DALUpdate.toggleShipActive(shipID);
		}
	}
}