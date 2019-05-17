using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Assignment_2.DAL;

namespace Assignment_2.BL
{
	public class BLAddress
	{
		public char addType { get; set; }
		public string addStreet { get; set; }
		public string addSuburb { get; set; }
		public string addState { get; set; }
		public int addZip { get; set; }

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

		public static BLAddress fillAddress(char type, string street, string suburb, string state, int zip)
		{
			BLAddress address = new BLAddress();

			address.addType = type;
			address.addStreet = street;
			address.addSuburb = suburb;
			address.addState = state;
			address.addZip = zip;

			return address;
		}
	}
}