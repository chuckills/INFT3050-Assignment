using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using Assignment_2.DAL;

/// <summary>
/// ADO.net model representing a user.
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
	    public bool userAdmin { get; set; }
		public bool userActive { get; set; }
		public BLAddress billAddress { get; set; }
		public BLAddress postAddress { get; set; }
	    public string userPassword { get; set; }

        /// <summary>
        /// Atttempts to login using user credentials against those stored in the database.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
		public int login(string user, string pass)
	    {
		    DALSelect login = new DALSelect();
		    bool found;
            // Attempt to retrieve user from database
			DataRow userData = login.getUserData(user, out found);

            // If user found
		    if (found)
			{
				fillUser(userData);
                // If user account has not been suspended
				if (userActive)
				{
					pass = hashPassword(pass);
                    // Check password
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

        /// <summary>
        /// Performs MD5 Hash function on input string.
        /// </summary>
        /// <param name="pass"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Update specified user's password.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool updateUserPassword(BLUser user, string password)
        {
            return DALUpdate.updateUserPassword(user, hashPassword(password));
        }

        /// <summary>
        /// Update user's information using row of table from SQL database.
        /// </summary>
        /// <param name="userData"></param>
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

        /// <summary>
        /// Get all users currently in the system.
        /// </summary>
        /// <returns></returns>
		public static DataSet getUsers()
		{
			DALSelect users = new DALSelect();
			return users.getUsers();
		}

        /// <summary>
        /// Returns ADO.net model of user for the given user ID.
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
		public BLUser getUser(int userID)
		{
			DALSelect user = new DALSelect();

			DataRow userData = user.getSingleUser(userID);

			fillUser(userData);

			return this;
		}

        /// <summary>
        /// Returns ADO.net model of user for the given user email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public BLUser getUserByEmail(string email)
        {
            DALSelect user = new DALSelect();

            DataRow userData = user.getUserByEmail(email);

            fillUser(userData);

            return this;
        }

        /// <summary>
        /// Checks if user exists in the database under the given username.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static int checkUser(string userName)
		{
			DALSelect check = new DALSelect();

			bool found;

			DataRow userData =  check.getUserData(userName, out found);

			if(found)
				return Convert.ToInt32(userData["userID"]);
			
			return 0;
			
		}

        /// <summary>
        /// Checks if user exists in the database under the given email.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool checkUserEmail(string email)
        {
            DALSelect user = new DALSelect();

            bool found;

            DataRow userData = user.getUserData(email, out found);

            return found;
        }
    
        /// <summary>
        /// Attempts to add a new user to the database and returns the result status.
        /// </summary>
        /// <param name="newUser"></param>
        /// <returns></returns>
		public static int addUser(BLUser newUser)
		{
			DALInsert user = new DALInsert();

			newUser.userPassword = hashPassword(newUser.userPassword);

			int rows = user.addNewUser(newUser);

			return rows;
		}

        /// <summary>
        /// Toggles active/suspend status for a specified user according to their current
        /// status.
        /// </summary>
        /// <param name="userID"></param>
		public static void toggleActive(int userID)
		{
			DALUpdate.toggleUserActive(userID);
		}

        /// <summary>
        /// Attempts to update specified user details and returns success status.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
		public static bool updateUser(BLUser user)
		{
			return DALUpdate.updateUser(user);
		}

    }
}