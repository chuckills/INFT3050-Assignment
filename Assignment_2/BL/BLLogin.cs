using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Assignment_2.DAL;

namespace Assignment_2.BL
{
	public class BLLogin
	{
		/*private string userName;
		private string password;

		public BLLogin(string user, string pass)
		{
			userName = user;
			password = pass;
		}*/

		public int login(string user, string pass, out bool status)
		{
			DALSelect login = new DALSelect();

			return login.login(user, pass, out status);
		}
	}
}