using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

		    if (found)
			{
				fillUser(userData);

				if (userActive)
				{
					pass = hashPassword(pass);

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

		private static string hashPassword(string pass)
		{
			using (MD5 md5Hash = MD5.Create())
			{
				byte[] passHash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(pass));

				StringBuilder sb = new StringBuilder();

				foreach (byte b in passHash)
				{
					sb.Append(b.ToString("x2"));
				}

				pass = sb.ToString();
			}

			return pass;
		}

		private void fillUser(DataRow userData)
		{
			userID = Convert.ToInt32(userData["userID"]);
			userFirstName = userData["userFirstName"].ToString();
			userLastName = userData["userLastName"].ToString();
			userEmail = userData["userEmail"].ToString();
			userPhone = userData["userPhone"].ToString();
			userPassword = userData["userPassword"].ToString();
			userAdmin = Convert.ToBoolean(userData["userAdmin"]);
			userActive = Convert.ToBoolean(userData["userActive"]);

			billAddress = !userAdmin ? new BLAddress().getAddress(userID, 'B') : billAddress = null;
			
			postAddress = new BLAddress().getAddress(userID, 'P');
		}

		public static DataSet getUsers()
		{
			DALSelect users = new DALSelect();
			return users.getUsers();
		}

		public BLUser getUser(int userID)
		{
			DALSelect user = new DALSelect();

			DataRow userData = user.getSingleUser(userID);

			fillUser(userData);

			return this;
		}

		public static int checkUser(string userName)
		{
			DALSelect check = new DALSelect();

			bool found;

			DataRow userData =  check.getUserData(userName, out found);

			if(found)
				return Convert.ToInt32(userData["userID"]);
			
			return 0;
			
		}

		public static int addUser(BLUser newUser)
		{
			DALInsert user = new DALInsert();

			newUser.userPassword = hashPassword(newUser.userPassword);

			int rows = user.addNewUser(newUser);

			return rows;
		}

		public static bool updateUser(BLUser user)
		{
			return DALUpdate.updateUser(user);
		}

    }
}