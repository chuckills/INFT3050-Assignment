using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Assignment_2.DAL;

namespace Assignment_2.BL
{
    public class BLUser
    {
	    public int userID { get; set; }
	    public string userFirstName { get; set; }
		public string userLastName { get; set; }
		public string userEmail { get; set; }
		public string userPhone { get; set; }
		public string userUserName { get; set; }
	    public bool userAdmin { get; set; }
		public bool userActive { get; set; }
		public BLAddress billAddress { get; set; }
		public BLAddress postAddress { get; set; }
	    public string userPassword { get; set; }

		public int login(string user, string pass)
	    {
		    DALSelect login = new DALSelect();

		    bool found;

			DataRow userData = login.getUserData(user, out found);

		    userID = Convert.ToInt32(userData["userID"]);
		    userFirstName = userData["userFirstName"].ToString();
			userLastName = userData["userLastName"].ToString();
			userEmail = userData["userEmail"].ToString();
			userPhone = userData["userPhone"].ToString();
			userUserName = userData["userUserName"].ToString();
			userPassword = userData["userPassword"].ToString();
			userAdmin = Convert.ToBoolean(userData["userAdmin"]);
			userActive = Convert.ToBoolean(userData["userActive"]);
			if (!userAdmin)
			{
				billAddress = new BLAddress().getAddress(userID, 'B');
			}
			else
			{
				billAddress = null;
			}
			postAddress = new BLAddress().getAddress(userID, 'P');

			if (found)
			{
				if (userActive)
				{
					if (pass == userPassword)
					{
						return userID;
					}
				}
				else
				{
					return -2;
				}

				return -1;
			}

			return 0;
	    }

		public static DataSet getUsers()
		{
			DALSelect users = new DALSelect();
			return users.getUsers();
		}

    }
}