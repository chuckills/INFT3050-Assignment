using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Assignment_2.DAL;

/// <summary>
/// Temporary model for proof of concept to provide login functionality
/// </summary>

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

	    private string userPassword;

		public int login(string user, string pass)
	    {
		    DALSelect login = new DALSelect();

		    bool found;

			DataRow userData = login.getUserData(user, out found).Tables["User"].Rows[0];

		    userID = Convert.ToInt32(userData["userID"]);
		    userFirstName = userData["userFirstName"].ToString();
			userLastName = userData["userLastName"].ToString();
			userEmail = userData["userEmail"].ToString();
			userPhone = userData["userPhone"].ToString();
			userUserName = userData["userUserName"].ToString();
			userPassword = userData["userPassword"].ToString();
			userAdmin = Convert.ToBoolean(userData["userAdmin"]);

			if (found)
			{
				if (pass == userPassword)
				{
					return userID;
				}

				return 1;
			}

			return 0;
	    }
		


    }
}