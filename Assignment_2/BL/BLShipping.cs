using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Assignment_2.DAL;

/// <summary>
/// ADO.net model to represent shipping.
/// </summary>

namespace Assignment_2.BL
{
	public class BLShipping
	{
		public int Id { get; set; }
		public string Method { get; set; }
        public string Description { get; set; }
		public double Cost { get; set; }
		public int Wait { get; set; }

        /// <summary>
        /// Returns data set containing all available shipping methods in system.
        /// </summary>
        /// <returns></returns>
		public static DataSet getShippingMethods()
		{
			return DALSelect.getShippingOptions();
		}

        /// <summary>
        /// Returns ADO.net model for shipping linked to the given shipping ID number.
        /// </summary>
        /// <param name="shipID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Adds shipping method to system and returns success status.
        /// </summary>
        /// <param name="shipping"></param>
        /// <returns></returns>
        public static bool addShipping(BLShipping shipping)
        {
            DALInsert shippingOption = new DALInsert();

            return (shippingOption.addPostageOption(shipping) > 0);
        }

        /// <summary>
        /// Returns data set representation of shipping table from the SQL database.
        /// </summary>
        /// <returns></returns>
		public static DataSet getShippingTable()
		{
			return DALSelect.getShippingTable();
		}

        /// <summary>
        /// Toggles active status for specified shipping method.
        /// </summary>
        /// <param name="shipID"></param>
		public static void toggleActive(int shipID)
		{
			DALUpdate.toggleShipActive(shipID);
		}
	}
}