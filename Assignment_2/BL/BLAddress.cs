using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Assignment_2.DAL;

/// <summary>
/// ADO.net model to represent an address.
/// </summary>

namespace Assignment_2.BL
{
	public class BLAddress
	{
		public char addType { get; set; }
		public string addStreet { get; set; }
		public string addSuburb { get; set; }
		public string addState { get; set; }
		public int addZip { get; set; }

		/// <summary>
        /// Returns populated ADO.net model of address from database.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public BLAddress getAddress(int user, char type)
		{
			DALSelect address = new DALSelect();
			DataRow addressData = address.getAddress(user, type);

			addType = type;
			addStreet = addressData["addStreet"].ToString();
			addSuburb = addressData["addSuburb"].ToString();
			addState = addressData["addState"].ToString();
			addZip = Convert.ToInt32(addressData["addZip"]);

			return this;
		}

        /// <summary>
        /// Returns a new ADO.net BLAddress model defined by the parameters given.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="street"></param>
        /// <param name="suburb"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        /// <returns></returns>
		public static BLAddress fillAddress(char type, string street, string suburb, string state, int zip)
		{
			BLAddress address = new BLAddress
			{
				addType = type,
				addStreet = street,
				addSuburb = suburb,
				addState = state,
				addZip = zip
			};
			return address;
		}
	}
}